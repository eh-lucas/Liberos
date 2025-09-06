using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Liberos.Domain.Models;

[Table("books")]
public class Book
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe o título do livro")]
    [MaxLength(100, ErrorMessage = "O título deve ter no máximo 100 caracteres")]
    [Column("title")]
    public string Title { get; set; } = null!;

    [Column("author")]
    public string? Author { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("cover_image")]
    public string? CoverImage { get; set; }

    [Column("language")]
    public string? Language { get; set; }

    [Column("publication_year")]
    public DateTime? PublicationYear { get; set; }

    [Column("isbn")]
    public long? Isbn { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [Column("is_available")]
    public bool IsAvailable { get; set; } = true;

    public ICollection<Content>? Contents { get; set; }
    public ICollection<UserLibrary>? UserLibrary { get; set; }
}
