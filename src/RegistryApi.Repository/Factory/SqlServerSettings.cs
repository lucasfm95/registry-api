namespace RegistryApi.Repository;

public static class SqlServerSettings
{
    public static string ConnectionString { get => Environment.GetEnvironmentVariable("CONNECTION_STRING_SQLSERVER") ?? ""; }
}
