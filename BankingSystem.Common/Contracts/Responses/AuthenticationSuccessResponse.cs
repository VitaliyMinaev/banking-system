using System.Text.Json.Serialization;

namespace BankingSystem.Common.Contracts.Responses;

public class AuthenticationSuccessResponse
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = String.Empty;
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; } = 86400;
    [JsonPropertyName("token_type")]
    public string TokenType { get; set; } = "Bearer";
}