using XClaim.Service.Extensions;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterDefaultService();
builder.Services.RegisterSwaggerService();
builder.Services.RegisterAuthenticationService();

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