using System.Text.Json.Serialization;

namespace BankingSystem.Common.Contracts.Responses;

public class TransactionSuccessResponse
{
    [JsonPropertyName("status")]
    public string Status { get; set; } = "Success";
    [JsonPropertyName("bank_account_amount")]
    public double BankAccountAmount { get; set; }
}