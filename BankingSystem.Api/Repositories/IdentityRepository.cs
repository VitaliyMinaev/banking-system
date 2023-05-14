using BankingSystem.Api.Constants;
using BankingSystem.Api.Data;
using BankingSystem.Api.Entities;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Api.Repositories;

public class IdentityRepository : IIdentityRepository
{
    private readonly ApplicationDatabaseContext _context;
    private readonly ILogger<IdentityRepository> _logger;
    public IdentityRepository(ApplicationDatabaseContext context, ILogger<IdentityRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<ApplicationUserEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<ApplicationUserEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Users.ToListAsync(cancellationToken);
    }

    public async Task<Result<ApplicationUserEntity>> CreateUserAsync(string username, string passwordHash, Guid bankAccountId, CancellationToken cancellationToken)
    {
        var user = new ApplicationUserEntity
        {
            Username = username,
            PasswordHash = passwordHash,
            BankAccountId = bankAccountId,
            RegistrationTime = DateTime.Now
        };

        await _context.Users.AddAsync(user, cancellationToken);
        var updated = await _context.SaveChangesAsync(cancellationToken);
        if (updated > 0 == false)
        {
            _logger.LogWarning("Database has no change/delete/add any data");
        }
        
        return Result.Ok(user);
    }

    public async Task<Result<ApplicationUserEntity>> LoginAsync(string username, string passwordHash, CancellationToken cancellationToken)
    {
        var exists = await _context.Users.FirstOrDefaultAsync(x => x.Username == username 
            && x.PasswordHash == passwordHash, cancellationToken);

        if (exists is null)
        {
            return Result.Fail(new Error(ErrorMessages.Identity.WrongCredentials));
        }
        
        return Result.Ok(exists);
    }

    public async Task<bool> UsernameAlreadyExistsAsync(string username, CancellationToken cancellationToken)
    {
        var exists = await _context.Users.FirstOrDefaultAsync(x => x.Username == username, cancellationToken);
        return exists is not null;
    }
}