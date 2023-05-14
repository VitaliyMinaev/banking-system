namespace BankingSystem.Api.Domain;

public record WithdrawTransactionDomain(Guid OwnerOfBankAccountId, double Amount);