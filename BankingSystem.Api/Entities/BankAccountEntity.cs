using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingSystem.Api.Entities;

[Table("BankAccounts")]
public class BankAccountEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column(TypeName = "uniqueidentifier")]
    public Guid Id { get; set; }   
    [Required, Column(TypeName = "int"), Range(0, int.MaxValue)]
    public double Money { get; set; }
    
    public ApplicationUserEntity? Owner { get; set; }
    public ICollection<TransactionEntity>? Transactions { get; set; }
}