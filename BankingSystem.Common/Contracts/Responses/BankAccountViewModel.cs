using System.Text.Json.Serialization;

namespace BankingSystem.Common.Contracts.Responses;

public class BankAccountViewModel
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("money")]
    public double Money { get; set; }
}