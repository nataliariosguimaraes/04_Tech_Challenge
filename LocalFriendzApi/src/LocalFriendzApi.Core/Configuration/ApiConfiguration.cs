namespace LocalFriendzApi.Core.Configuration
{
    public static class ApiConfiguration
    {
        public static string ConnectionString { get; set; } = string.Empty;
        public static string CorsPolicyName = "wasm";
    }
}
