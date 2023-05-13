using BankingSystem.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Api.Data;

public class ApplicationDatabaseContext : DbContext
{
    public DbSet<ApplicationUserEntity> Users { get; set; }
    public DbSet<BankAccountEntity> BankAccountEntities { get; set; }
    public DbSet<TransactionEntity> Transactions { get; set; }
    public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options)
    { }
}