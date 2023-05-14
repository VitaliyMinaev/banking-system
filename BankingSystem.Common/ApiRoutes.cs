namespace BankingSystem.Common;

public static class ApiRoutes
{
    private const string Root = "api";
    private const string Version = "v1";
    private const string Base = Root + "/" + Version;
    
    public static class Identity
    {
        public const string GetAll = $"{Base}/Identity";
        public const string Register = $"{Base}/Register";
        public const string Login = $"{Base}/Login";
    }
    public static class BankAccount
    {
        public const string Get = $"{Base}/BankAccount" + "/{id}";
        public const string Withdraw = $"{Base}/BankAccount/withdraw";
        public const string Replenish = $"{Base}/BankAccount/replenish";
        public const string TopUp = $"{Base}/BankAccount/topup";
    }

    public static class HealthCheck
    {
        public const string Check = $"{Base}/{nameof(HealthCheck)}";
    }
}