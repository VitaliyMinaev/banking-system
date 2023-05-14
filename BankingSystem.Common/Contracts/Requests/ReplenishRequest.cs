using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Common.Contracts.Requests;

public class ReplenishRequest
{
    [Range(1, int.MaxValue)]
    public int Amount { get; set; }
    [Required]
    public Guid RecipientId { get; set; }
}