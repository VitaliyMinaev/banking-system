namespace BankingSystem.Api.Domain;

public record UserDomain(Guid Id, string Username, string PasswordHash);