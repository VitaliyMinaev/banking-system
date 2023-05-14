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

        public static class Operations
        {
            public const string SenderNotFound = "The user who initiated the operation was not found";
            public const string RecipientNotFound = "The user to whom the amount needs to be transferred was not found";
            public const string NotEnoughMoney = "Not enough money to carry out the operation";
        }
    }
}