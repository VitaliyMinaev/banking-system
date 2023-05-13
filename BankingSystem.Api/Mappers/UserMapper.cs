using BankingSystem.Api.Domain;
using BankingSystem.Api.Entities;
using BankingSystem.Common.Contracts.Responses;

namespace BankingSystem.Api.Mappers;

public static class UserMapper
{
    public static UserDomain ToDomain(this ApplicationUserEntity user)
    {
        return new UserDomain(user.Id, user.Username, user.PasswordHash);
    }
    public static ApplicationUserEntity ToEntity(this UserDomain user)
    {
        return new ApplicationUserEntity
        {
            Id = user.Id,
            Username = user.Username,
            PasswordHash = user.PasswordHash
        };
    }

    public static UserViewModel ToViewModel(this UserDomain user)
    {
        return new UserViewModel { Id = user.Id, Username = user.Username };
    }
}