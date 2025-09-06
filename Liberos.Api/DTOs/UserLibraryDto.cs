using System.ComponentModel.DataAnnotations;

namespace Liberos.Api.DTOs;
public class UserLibraryDto
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    public int BookId { get; set; }

    public DateTime AddedAt { get; set; }

    public DateTime? LastOpenedAt { get; set; }

    public bool IsFavorite { get; set; }

    public bool IsActive { get; set; }
}
