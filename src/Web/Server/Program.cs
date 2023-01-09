using AutoFilterer.Swagger;
using HealthChecks.ApplicationStatus.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using XClaim.Web.Server;
using XClaim.Web.Server.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ServerContext>(options => {
    options.UseSqlite(connectionString).UseSnakeCaseNamingConvention();
});

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
builder.Services.AddHttpContextAccessor();;
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

app.Run();