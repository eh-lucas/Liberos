using System.ComponentModel.DataAnnotations;

namespace Liberos.Application.DTOs;
public class UserDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe o e-mail do usuário")]
    [MaxLength(80, ErrorMessage = "O e-mail deve ter no máximo 80 caracteres")]
    public string Email { get; set; } = null!;

    public string? Cpf { get; set; }

    public string? Name { get; set; }

    [Required]
    public string Password { get; set; } = null!;

    public bool Active { get; set; } = true;
}
