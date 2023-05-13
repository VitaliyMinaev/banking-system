using System.Text.Json.Serialization;

namespace BankingSystem.Common.Contracts.Responses;

public class UserViewModel
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("username")]
    public string Username { get; set; } = String.Empty;
    [JsonPropertyName("bank_account_id")]
    public Guid BankAccountId { get; set; }
}