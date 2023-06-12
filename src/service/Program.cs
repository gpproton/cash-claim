// Copyright 2023 - 2023 Godwin peter .O (me@godwin.dev)
//
// Licensed under the MIT License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using XClaim.Service.Extensions;
using XClaim.Web.Components.Extensions;
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
builder.Services.RegisterAppState();

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