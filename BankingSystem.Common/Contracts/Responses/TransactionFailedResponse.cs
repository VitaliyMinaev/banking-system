namespace BankingSystem.Common.Contracts.Responses;

public class TransactionFailedResponse
{
    public string Status { get; set; } = "Failed";
    public string[] Errors { get; set; } = Array.Empty<string>();
}