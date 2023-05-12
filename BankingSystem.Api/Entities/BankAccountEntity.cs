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

    [ForeignKey(nameof(ApplicationUserEntity))]
    public Guid OwnerId { get; set; }
    public ApplicationUserEntity? Owner { get; set; }

    public ICollection<TransactionEntity>? Transaction { get; set; }
}