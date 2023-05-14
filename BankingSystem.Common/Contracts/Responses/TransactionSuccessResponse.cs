namespace BankingSystem.Common.Contracts.Responses;

public class TransactionSuccessResponse
{
    public string Status { get; set; } = "Success";
    public double BankAccountAmount { get; set; }
}