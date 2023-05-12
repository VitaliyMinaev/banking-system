using BankingSystem.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public DbSet<ApplicationUserEntity> Users { get; set; }
    public DbSet<BankAccountEntity> BankAccountEntities { get; set; }
    public DbSet<TransactionEntity> Transactions { get; set; }
}