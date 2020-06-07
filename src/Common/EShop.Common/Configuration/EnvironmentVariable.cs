using System;

namespace EShop.Common.Configuration
{
    public static class EnvironmentVariableKeys
    {
        public const string MicroServiceName = "MICRO_SERVICE_NAME";
        public const string PathBase = "PATH_BASE";
        public const string Version = "VERSION";
    }

    public class EnvironmentVariableValues
    {
        public static  string MicroServiceName => Environment.GetEnvironmentVariable(EnvironmentVariableKeys.MicroServiceName) ?? "APP";
        public static string PathBase => Environment.GetEnvironmentVariable(EnvironmentVariableKeys.PathBase) ?? string.Empty;
        public static string Version => Environment.GetEnvironmentVariable(EnvironmentVariableKeys.Version) ?? "v1";
    }
}
