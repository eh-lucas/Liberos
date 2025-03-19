using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Liberos.Api.Models;
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }

    [Required(ErrorMessage = "Informe o nome do autor")]
    [MaxLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres")]
    public string Author { get; set; }
    public string Content { get; set; }
}
