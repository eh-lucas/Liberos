using AutoMapper;
using Liberos.Api.DTOs;
using Liberos.Api.Interfaces;
using Liberos.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Liberos.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UsersController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<UserDto>> Get()
    {
        var users = _unitOfWork.UserRepository.GetAll();
        if (users is null || !users.Any())
            return NotFound("Usuários não encontrados.");

        var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);

        return Ok(usersDto);
    }

    [HttpGet("{id:int}", Name = "ObterUser")]
    public ActionResult<UserDto> Get(int id)
    {
        var user = _unitOfWork.UserRepository.Get(c => c.Id == id);
        if (user is null)
            return NotFound("Usuário não encontrado.");
        
        var userDto = _mapper.Map<UserDto>(user);

        return Ok(userDto);
    }

    [HttpPost]
    public ActionResult<UserDto> Post(UserDto userDto)
    {
        if (userDto is null)
            return BadRequest("Usuário informado inválido");

        var user = _mapper.Map<User>(userDto);

        var createdUser = _unitOfWork.UserRepository.Create(user);
        _unitOfWork.Commit();

        var createdUserDto = _mapper.Map<UserDto>(createdUser);

        return new CreatedAtRouteResult("ObterUser", new { id = createdUserDto.Id }, createdUserDto);
    }

    [HttpPut("{id:int}")]
    public ActionResult<UserDto> Put(int id, UserDto userDto)
    {
        if (id != userDto.Id)
            return BadRequest("Id informado não corresponde ao id do usuário.");

        var user = _mapper.Map<User>(userDto);

        var updatedUser = _unitOfWork.UserRepository.Update(user);
        _unitOfWork.Commit();

        var updatedUserDto = _mapper.Map<UserDto>(updatedUser);

        return Ok(updatedUserDto);
    }

    [HttpDelete]
    public ActionResult<UserDto> Delete(int id)
    {
        var user = _unitOfWork.UserRepository.Get(c => c.Id == id);
        if (user is null)
            return NotFound("Usuário informado não encontrado.");

        var deletedUser = _unitOfWork.UserRepository.Delete(user);
        _unitOfWork.Commit();

        var deletedUserDto = _mapper.Map<UserDto>(deletedUser);

        return Ok(deletedUserDto);
    }
}
