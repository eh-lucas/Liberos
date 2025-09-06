using System.ComponentModel.DataAnnotations;

namespace Liberos.Application.DTOs;
public class BookDto
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe o título do livro")]
    [MaxLength(100, ErrorMessage = "O título deve ter no máximo 100 caracteres")]
    public string Title { get; set; } = null!;

    public string? Author { get; set; }

    public string? Description { get; set; }

    public string? Language { get; set; }

    public DateTime? PublicationYear { get; set; }

    public long? Isbn { get; set; }

    public bool IsAvailable { get; set; } = true;
}
