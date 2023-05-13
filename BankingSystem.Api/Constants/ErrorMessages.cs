namespace BankingSystem.Api.Constants;

public static class ErrorMessages
{
    public static class Database
    {
        public const string CausedBy = "Database";
        public const string Failed = "Operation failed. Database has been not updated";
    }
    
    public static class Identity
    {
        public const string WrongCredentials = "User with given credentials does not exist";
    }
    public static class BankAccount
    {
        public const string NotFound = "There is no bank account with given id";
    }
}