using Liberos.Api.Interfaces;
using Liberos.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Liberos.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IRepository<User> _repository;

    public UsersController(IRepository<User> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> Get()
    {
        var users = _repository.GetAll();
        if (users is null || !users.Any())
            return NotFound("Usuários não encontrados.");

        return Ok(users);
    }

    [HttpGet("{id:int}", Name = "ObterUser")]
    public ActionResult<User> Get(int id)
    {
        var user = _repository.Get(c => c.Id == id);
        if (user is null)
            return NotFound("Usuário não encontrado.");

        return Ok(user);
    }

    [HttpPost("{id:int}")]
    public ActionResult Post(User user)
    {
        if (user is null)
            return BadRequest("Usuário informado inválido");

        var createdUser = _repository.Create(user);

        return new CreatedAtRouteResult("ObterUser", new { id = createdUser.Id }, createdUser);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, User user)
    {
        if (id != user.Id)
            return BadRequest("Id informado não corresponde ao id do usuário.");

        _repository.Update(user);

        return Ok(user);
    }

    [HttpDelete]
    public ActionResult Delete(int id)
    {
        var user = _repository.Get(c => c.Id == id);
        if (user is null)
            return NotFound("Usuário informado não encontrado.");

        var deletedUser = _repository.Delete(user);

        return Ok(deletedUser);
    }
}
