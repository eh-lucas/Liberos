using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Liberos.Domain.Models;

[Table("contents")]
public class Content
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("book_id")]
    public int BookId { get; set; }

    [Column("chapter_number")]
    public int? ChapterNumber { get; set; }

    [Column("title")]
    public string? Title { get; set; }

    [Column("content")]
    public string? ContentText { get; set; }

    [Column("position_index")]
    public int PositionIndex { get; set; }

    //public Book Book { get; set; } = null!;
}
