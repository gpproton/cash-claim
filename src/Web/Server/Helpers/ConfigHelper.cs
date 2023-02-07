using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace XClaim.Web.Server.Helpers;

public static class ConfigHelper {
    public static void ApplyDefaultAppConfiguration(HostBuilderContext hostingContext, IConfigurationBuilder builder, string[]? args) {
        IHostEnvironment env = hostingContext.HostingEnvironment;
        bool reloadOnChange = GetReloadConfigOnChangeValue(hostingContext);
        builder.SetBasePath(env.ContentRootPath);
        builder.AddIniFile("config.ini", optional: false, reloadOnChange: reloadOnChange);
        builder.AddIniFile("config.Development.ini", optional: true, reloadOnChange: reloadOnChange);
        builder.AddEnvironmentVariables();
        {
            builder.AddCommandLine(args!);
        }

        if (env.IsDevelopment() && env.ApplicationName is { Length: > 0 }) {
            var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
            if (appAssembly != null)
                builder.AddUserSecrets(appAssembly, optional: true, reloadOnChange: reloadOnChange);
        }

        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Calling IConfiguration.GetValue is safe when the T is bool.")]
        static bool GetReloadConfigOnChangeValue(HostBuilderContext hostingContext) => hostingContext.Configuration.GetValue("hostBuilder:reloadConfigOnChange", defaultValue: true);
    }
}