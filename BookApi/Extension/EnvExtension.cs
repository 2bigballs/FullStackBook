namespace BookApi.Extension
{
    public static class EnvExtension
    {
        public static bool IsRunningInContainer(this IWebHostEnvironment env)
        {
            string value = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER");
            return string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }
    }
}
