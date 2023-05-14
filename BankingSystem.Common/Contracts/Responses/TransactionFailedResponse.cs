using System.Text.Json.Serialization;

namespace BankingSystem.Common.Contracts.Responses;

public class TransactionFailedResponse
{
    [JsonPropertyName("failed")]
    public string Status { get; set; } = "Failed";
    [JsonPropertyName("errors")]
    public string[] Errors { get; set; } = Array.Empty<string>();
}