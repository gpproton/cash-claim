using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using XClaim.Web.Components.Extensions;
using XClaim.Web.Shared;

WebAssemblyHostBuilder? builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.UseSharedExtensions();
builder.Services.UseComponentsExtensions();

await builder.Build().RunAsync();