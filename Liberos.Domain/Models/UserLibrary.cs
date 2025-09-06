using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Liberos.Domain.Models;

[Table("user_library")]
public class UserLibrary
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("book_id")]
    public int BookId { get; set; }

    [Column("added_at")]
    public DateTime AddedAt { get; set; }

    [Column("last_opened_at")]
    public DateTime? LastOpenedAt { get; set; }

    [Column("is_favorite")]
    public bool IsFavorite { get; set; }

    [Column("is_active")]
    public bool IsActive { get; set; }

    public User User { get; set; } = null!;
    public Book Book { get; set; } = null!;
}
