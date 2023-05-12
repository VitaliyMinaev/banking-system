using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingSystem.Api.Entities;

[Table("ApplicationUsers")]
public class ApplicationUserEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column(TypeName = "uniqueidentifier")]
    public Guid Id { get; set; }
    [Required, Column(TypeName = "nvarchar(128)"), MinLength(6)]
    public string Username { get; set; } = String.Empty;
    [Required, Column(TypeName = "nvarchar(128)"), MinLength(6)]
    public string PasswordHash { get; set; } = String.Empty;
    [Required, Column(TypeName = "datetime2")]
    public DateTime RegistrationTime { get; set; } = DateTime.Now;
}