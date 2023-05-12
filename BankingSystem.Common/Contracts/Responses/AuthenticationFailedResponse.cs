namespace BankingSystem.Common.Contracts.Responses;

public class AuthenticationFailedResponse
{
    public bool Failed { get; set; } = true;
    public string[] ErrorMessages { get; set; } = Array.Empty<string>();
}