using Liberos.Api.Interfaces;
using Liberos.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Liberos.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public UsersController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> Get()
    {
        var users = _unitOfWork.UserRepository.GetAll();
        if (users is null || !users.Any())
            return NotFound("Usuários não encontrados.");

        return Ok(users);
    }

    [HttpGet("{id:int}", Name = "ObterUser")]
    public ActionResult<User> Get(int id)
    {
        var user = _unitOfWork.UserRepository.Get(c => c.Id == id);
        if (user is null)
            return NotFound("Usuário não encontrado.");

        return Ok(user);
    }

    [HttpPost]
    public ActionResult Post(User user)
    {
        if (user is null)
            return BadRequest("Usuário informado inválido");

        var createdUser = _unitOfWork.UserRepository.Create(user);
        _unitOfWork.Commit();

        return new CreatedAtRouteResult("ObterUser", new { id = createdUser.Id }, createdUser);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, User user)
    {
        if (id != user.Id)
            return BadRequest("Id informado não corresponde ao id do usuário.");

        _unitOfWork.UserRepository.Update(user);
        _unitOfWork.Commit();

        return Ok(user);
    }

    [HttpDelete]
    public ActionResult Delete(int id)
    {
        var user = _unitOfWork.UserRepository.Get(c => c.Id == id);
        if (user is null)
            return NotFound("Usuário informado não encontrado.");

        var deletedUser = _unitOfWork.UserRepository.Delete(user);
        _unitOfWork.Commit();

        return Ok(deletedUser);
    }
}
