using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Common.Contracts.Requests;

public class TopUpRequest
{
    [Range(1, double.MaxValue)]
    public double Amount { get; set; }
}