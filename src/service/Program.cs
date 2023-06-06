using Axolotl.AspNet;
using Axolotl.EFCore;
using DotNetEd.CoreAdmin;
using XClaim.Common.Context;
using XClaim.Service.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => { });
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.RegisterFeatures(typeof(Program).Assembly);
builder.Services.RegisterGenericServices();

builder.Services.RegisterDataContext();
builder.Services.RegisterGenericRepositories(typeof(GenericRepository<>));
builder.Services.AddHostedService<MigrationService>();
builder.Services.AddCoreAdmin(new CoreAdminOptions {
    Title = "X-Claim",
    ShowPageSizes = true,
    PageSizes = new Dictionary<int, string>() {
        { 25, "25"},
        { 100, "100"},
        { 0, "All"}
    },
    IgnoreEntityTypes = new List<Type> { }
});

var app = builder.Build();
if (app.Environment.IsDevelopment()) {
    app.UseWebAssemblyDebugging();
} else {
    app.UseExceptionHandler("/Error");
}

app.UseHttpsRedirection();
app.MapDefaultControllerRoute();
app.UseRouting();
app.UseStaticFiles();
app.UseAuthorization();
app.UseBlazorFrameworkFiles();
app.MapRazorPages();
app.MapControllers();
app.UseCoreAdminCustomUrl("admin");
app.UseCoreAdminCustomAuth((serviceProvider) => Task.FromResult(true));
app.MapFallbackToPage("/_Host");

app.Run();
