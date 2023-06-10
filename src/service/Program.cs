using XClaim.Service.Extensions;
using XClaim.Web.Shared;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterDefaultService();
builder.Services.RegisterSwaggerService();
builder.Services.RegisterAuthenticationService();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5124/") });
// builder.Services.RegisterSharedBlazorServices();

WebApplication? app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseWebAssemblyDebugging();
}
else {
    app.UseExceptionHandler("/Error");
}

app.RegisterSwaggerService();
app.RegisterDefaultService();
app.RegisterFileUploadService();

app.Run();