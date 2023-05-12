namespace BankingSystem.Common;

public static class ApiRoutes
{
    private const string Root = "api";
    private const string Version = "v1";
    private const string Base = Root + "/" + Version;
    
    public static class Identity
    {
        public const string Register = $"{Base}/Register";
        public const string Login = $"{Base}/Login";
    }

    public static class HealthCheck
    {
        public const string Check = $"{Base}/{nameof(HealthCheck)}";
    }
}