using System.Text.Json.Serialization;

namespace BankingSystem.Common.Contracts.Responses;

public class AuthenticationFailedResponse
{
    public bool Failed { get; set; } = true;
    [JsonPropertyName("error_messages")]
    public string[] ErrorMessages { get; set; } = Array.Empty<string>();
}