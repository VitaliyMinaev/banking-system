using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Common.Contracts.Requests;

public class RegistrationRequest
{
    [Required, MinLength(6)] 
    public string Username { get; set; } = String.Empty;
    [Required, DataType(DataType.Password), MinLength(6)]
    public string Password { get; set; } = String.Empty;
}