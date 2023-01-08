using AutoFilterer.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using XClaim.Web.Server;
using XClaim.Web.Server.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ServerContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("Default");
    options.UseSqlite(connectionString).UseSnakeCaseNamingConvention();
});

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"))
    .EnableTokenAcquisitionToCallDownstreamApi()
    .AddMicrosoftGraph(builder.Configuration.GetSection("MicrosoftGraph"))
    .AddInMemoryTokenCaches()
    .AddDownstreamWebApi("DownstreamApi", builder.Configuration.GetSection("DownstreamApi"))
    .AddInMemoryTokenCaches();
builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt => {
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = $"XClaim", Version = "v1" });
    opt.UseAutoFiltererParameters();
});
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.RegisterModules();

var app = builder.Build();
if (app.Environment.IsDevelopment()) {
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI(opt => {
        const string path = "/swagger/v1/swagger.json";
        opt.SwaggerEndpoint(path, "XClaim V1");
    });
}
else
    app.UseExceptionHandler("/Error");

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