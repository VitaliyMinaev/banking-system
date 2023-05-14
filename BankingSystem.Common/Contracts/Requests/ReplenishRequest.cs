using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Common.Contracts.Requests;

public class ReplenishRequest
{
    [Range(0, int.MaxValue)]
    public int Amount { get; set; }
}