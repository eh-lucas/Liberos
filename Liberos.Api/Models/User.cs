using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Liberos.Api.Models;

public class User
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe o e-mail do usuário")]
    [MaxLength(80, ErrorMessage = "O e-mail deve ter no máximo 80 caracteres")]
    [Column("email")]
    public string Email { get; set; } = null!;

    [Column("cpf")]
    public string? Cpf { get; set; }
    
    [Column("name")]
    public string? Name { get; set; }

    [Column("password")]
    [Required]
    public string Password { get; set; } = null!;

    [Column("active")]
    public bool Active { get; set; } = true;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    public ICollection<Token>? Tokens { get; set; }
    public ICollection<UserLibrary>? UserLibrary { get; set; }
}
