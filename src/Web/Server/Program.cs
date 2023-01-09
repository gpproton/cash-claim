using System.Net;
using AutoFilterer.Swagger;
using HealthChecks.ApplicationStatus.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using XClaim.Web.Server;
using XClaim.Web.Server.Data;
using XClaim.Web.Server.Helpers;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ServerContext>(options => {
    options.UseSqlite(connectionString).UseSnakeCaseNamingConvention();
});
builder.Services.AddTransient<FileUploadService>();

builder.Services.Configure<CookiePolicyOptions>(options => {
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddAuthentication("Cookies")
    .AddCookie(opt => {
        opt.Cookie.Name = "AuthCookie";
        opt.Cookie.IsEssential = true;
        opt.ExpireTimeSpan = TimeSpan.FromDays(7);
        opt.SlidingExpiration = true;
    })
    .AddMicrosoftAccount(opt => {
        var clientId = builder.Configuration.GetValue<string>("Microsoft:ClientId") ?? "";
        var clientSecret = builder.Configuration.GetValue<string>("Microsoft:ClientSecret") ?? "";

        opt.SignInScheme = "Cookies";
        opt.ClientId = clientId;
        opt.ClientSecret = clientSecret;
        opt.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    });
builder.Services.AddHttpContextAccessor(); ;
builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt => {
    opt.UseAutoFiltererParameters();
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = $"X-Claim", Version = "v1" });
});
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.RegisterModules();

var healthCheck = builder.Services.AddHealthChecks()
    .AddApplicationStatus();
builder.Services.AddHealthChecksUI()
    .AddInMemoryStorage();

if (connectionString != null) {
    healthCheck.AddSqlite(connectionString);
}

var app = builder.Build();
if (app.Environment.IsDevelopment()) {
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI(opt => {
        const string path = "/swagger/v1/swagger.json";
        opt.SwaggerEndpoint(path, "X-Claim V1 Docs");
        opt.DefaultModelExpandDepth(3);
        opt.EnableDeepLinking();
        opt.DisplayRequestDuration();
        opt.ShowExtensions();
    });
}
else
    app.UseExceptionHandler("/Error");


app.UseCookiePolicy(new CookiePolicyOptions {
    MinimumSameSitePolicy = SameSiteMode.Lax
});
app.RegisterApiEndpoints();
app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");
app.UseAuthentication();
app.UseAuthorization();

var uploadService = app.Services.GetService<FileUploadService>();
if (uploadService != null) {
    var fullUploadPath = uploadService.GetUploadRootPath();
    app.UseStaticFiles();

    void OnPrepareResponse(StaticFileResponseContext ctx) {
        if (!ctx.Context.Request.Path.StartsWithSegments("/static")) return;

        ctx.Context.Response.Headers.Add("Cache-Control", "no-store");
        if (ctx.Context.User.Identity == null || ctx.Context.User.Identity.IsAuthenticated) return;

        ctx.Context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        ctx.Context.Response.ContentLength = 0;
        ctx.Context.Response.Body = Stream.Null;
        // JsonSerializer.Serialize(new { Status = 401, Message = "UnAuthorized file access" });
    }

    app.UseStaticFiles(new StaticFileOptions {
        FileProvider = new PhysicalFileProvider(fullUploadPath),
        RequestPath = new PathString("/static"),
        OnPrepareResponse = OnPrepareResponse
    });
}

app.Run();