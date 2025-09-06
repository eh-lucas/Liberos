using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Liberos.Domain.Models;

[Table("tokens")]
public class Token
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("token_uid")]
    [Required]
    public string TokenUid { get; set; } = null!;

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}
