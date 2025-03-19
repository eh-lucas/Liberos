using System.ComponentModel.DataAnnotations;

namespace Liberos.Api.Models;

public class User
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Informe o e-mail do usuário")]
    [MaxLength(80, ErrorMessage = "O e-mail deve ter no máximo 80 caracteres")]
    public string Email { get; set; }
    public string Cpf { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
}
