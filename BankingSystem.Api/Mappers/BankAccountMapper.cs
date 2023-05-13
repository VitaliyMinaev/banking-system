using BankingSystem.Api.Domain;
using BankingSystem.Api.Entities;
using BankingSystem.Common.Contracts.Responses;

namespace BankingSystem.Api.Mappers;

public static class BankAccountMapper
{
    public static BankAccountViewModel ToViewModel(this BankAccountDomain domain)
    {
        return new BankAccountViewModel { Id = domain.Id, Money = domain.Money };
    }
    public static BankAccountEntity ToEntity(this BankAccountDomain domain)
    {
        return new BankAccountEntity { Id = domain.Id, Money = domain.Money };
    }
    public static BankAccountDomain ToDomain(this BankAccountEntity entity)
    {
        return new BankAccountDomain(entity.Id, entity.Money);
    }
}