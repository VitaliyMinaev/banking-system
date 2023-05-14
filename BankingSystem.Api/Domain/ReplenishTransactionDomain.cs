namespace BankingSystem.Api.Domain;

public record ReplenishTransactionDomain(Guid SenderId, Guid RecipientId, double Amount);