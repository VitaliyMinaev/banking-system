namespace BankingSystem.Api.Domain;

public record TopUpTransactionDomain(Guid UserId, double Amount) : TransactionBase(Amount);