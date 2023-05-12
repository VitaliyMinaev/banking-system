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
    
    [ForeignKey(nameof(BankAccountEntity))]
    public Guid BankAccountId { get; set; }
    public BankAccountEntity? BankAccount { get; set; }
    
    [ForeignKey(nameof(BankAccountEntity))]
    public Guid BankAccountRecipientId { get; set; }
    public BankAccountEntity? Recipient { get; set; }
}