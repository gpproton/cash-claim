using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace XClaim.Web.Server.Helpers;

public static class ConfigHelper {
    public static void ApplyDefaultAppConfiguration(HostBuilderContext hostingContext, IConfigurationBuilder appConfigBuilder, string[]? args) {
        IHostEnvironment env = hostingContext.HostingEnvironment;
        bool reloadOnChange = GetReloadConfigOnChangeValue(hostingContext);

        appConfigBuilder.AddIniFile("config.ini", optional: true, reloadOnChange: reloadOnChange)
        .AddIniFile($"config{env.EnvironmentName}.ini", optional: true, reloadOnChange: reloadOnChange);

        if (env.IsDevelopment() && env.ApplicationName is { Length: > 0 }) {
            var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
            if (appAssembly != null)
                appConfigBuilder.AddUserSecrets(appAssembly, optional: true, reloadOnChange: reloadOnChange);
        }

        appConfigBuilder.AddEnvironmentVariables(); {
            appConfigBuilder.AddCommandLine(args!);
        }

        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Calling IConfiguration.GetValue is safe when the T is bool.")]
        static bool GetReloadConfigOnChangeValue(HostBuilderContext hostingContext) => hostingContext.Configuration.GetValue("hostBuilder:reloadConfigOnChange", defaultValue: true);
    }
}