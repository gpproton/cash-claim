using XClaim.Service.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterDefaultService();
builder.Services.RegisterSwaggerService();
builder.Services.RegisterAuthenticationService();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseWebAssemblyDebugging();
} else {
    app.UseExceptionHandler("/Error");
}

app.RegisterSwaggerService();
app.RegisterDefaultService();
app.RegisterFileUploadService();

app.Run();
