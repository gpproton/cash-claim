using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using XClaim.Service.Extensions;
using XClaim.Web.Shared;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient(typeof(Lazy<>), typeof(Lazy<>));
builder.Services.RegisterDefaultService();
builder.Services.RegisterSwaggerService();
builder.Services.RegisterAuthenticationService();

// TODO: Review dependency injection
builder.Services.AddSingleton<HttpClient>(sp => {
    var server = sp.GetRequiredService<IServer>();
    var addressFeature = server.Features.Get<IServerAddressesFeature>();
    string baseAddress = addressFeature!.Addresses.First();
    return new HttpClient { BaseAddress = new Uri(baseAddress) };
});
builder.Services.RegisterSharedBlazorServices();

WebApplication app = builder.Build();

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