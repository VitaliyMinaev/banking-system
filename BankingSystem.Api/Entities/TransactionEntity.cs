using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingSystem.Api.Entities;

[Table("Transactions")]
public class TransactionEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column(TypeName = "uniqueidentifier")]
    public Guid Id { get; set; }   
    [Required, Column(TypeName = "int"), Range(0, int.MaxValue)]
    public double Amount { get; set; }
    
    [ForeignKey(nameof(BankAccount))]
    public Guid BankAccountId { get; set; }
    public BankAccountEntity? BankAccount { get; set; }
    
    public Guid BankAccountRecipientId { get; set; }
}