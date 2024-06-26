using System.Net;
using System.Text.Json.Serialization;
using AutoFilterer.Swagger;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using CashClaim.Service;
using CashClaim.Service.Data;
using CashClaim.Service.Extensions;
using CashClaim.Service.Helpers;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.SetupDatabase(builder.Configuration)
.Configure<JsonOptions>(options => {
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddTransient<FileUploadService>();
builder.Services.AddTransient<IdentityHelper>();

builder.Services.Configure<CookiePolicyOptions>(options => {
    options.CheckConsentNeeded = _ => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddAuthentication("Cookies")
    .AddCookie(opt => {
        opt.Cookie.Name = Constants.AppSessionName;
        opt.Cookie.IsEssential = true;
        opt.ExpireTimeSpan = TimeSpan.FromDays(7);
        opt.SlidingExpiration = true;
    })
    .AddMicrosoftAccount(opt => {
        opt.SignInScheme = "Cookies";
        opt.ClientId = builder.Configuration.GetValue<string>("Microsoft:ClientId") ?? "client-id";
        opt.ClientSecret = builder.Configuration.GetValue<string>("Microsoft:ClientSecret") ?? "client-secret";
        opt.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        opt.SaveTokens = true;
    });
builder.Services.AddHttpContextAccessor(); ;
builder.Services.AddAuthorization();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(2);
    options.Cookie.HttpOnly = false;
    options.Cookie.IsEssential = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt => {
    opt.UseAutoFiltererParameters();
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = $"X-Claim", Version = "v1" });
    opt.OperationFilter<FileUploadOperationFilter>();
});
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.RegisterModules();

WebApplication app = builder.Build();

using (var scope = app.Services.CreateScope()) {
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ServerContext>();
    await context.Database.MigrateAsync();
}

const string swaggerTittle = "X-Claim V1 Docs";
const string swaggerPath = "/swagger/v1/swagger.json";
app.UseReDoc(c => {
    c.DocumentTitle = swaggerTittle;
    c.SpecUrl(swaggerPath);
});

if (app.Environment.IsDevelopment()) {
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI(opt => {
        opt.SwaggerEndpoint(swaggerPath, swaggerTittle);
        opt.DefaultModelExpandDepth(3);
        opt.EnableDeepLinking();
        opt.DisplayRequestDuration();
        opt.ShowExtensions();
    });
}
else {
    _ = app.UseExceptionHandler("/Error");
}

app.UseCookiePolicy(new CookiePolicyOptions {
    MinimumSameSitePolicy = SameSiteMode.None
});

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.MapFallbackToFile("index.html");
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapRazorPages();
app.RegisterApiEndpoints();
// INFO: Disabled due to mobile self signed certificate
// app.UseHttpsRedirection();

FileUploadService? uploadService = app.Services.GetService<FileUploadService>();
if (uploadService != null) {
    string fullUploadPath = uploadService.GetUploadRootPath();
    if (!Directory.Exists(fullUploadPath)) {
        Console.WriteLine("Creating static files directory");
        _ = Directory.CreateDirectory(fullUploadPath);
    }
    _ = app.UseStaticFiles();

    static void OnPrepareResponse(StaticFileResponseContext ctx) {
        if (!ctx.Context.Request.Path.StartsWithSegments("/static")) {
            return;
        }

        ctx.Context.Response.Headers.Add("Cache-Control", "no-store");
        if (ctx.Context.User.Identity == null || ctx.Context.User.Identity.IsAuthenticated) {
            return;
        }

        ctx.Context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        ctx.Context.Response.ContentLength = 0;
        ctx.Context.Response.Body = Stream.Null;
        // TODO: Use better response
        // JsonSerializer.Serialize(new { Status = 401, Message = "UnAuthorized file access" });
    }

    _ = app.UseStaticFiles(new StaticFileOptions {
        FileProvider = new PhysicalFileProvider(fullUploadPath),
        RequestPath = new PathString("/static"),
        OnPrepareResponse = OnPrepareResponse
    });
}

app.Run();