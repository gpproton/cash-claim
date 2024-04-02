using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CashClaim.Common.HTTP;
using XClaim.Web.Client;
using CashClaim.Web.Components.Extensions;
using CashClaim.Web.Shared;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient {
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

builder.Services.UseSharedExtensions();
builder.Services.UseComponentsExtensions();
builder.Services.UseHttpServices();

await builder.Build().RunAsync();