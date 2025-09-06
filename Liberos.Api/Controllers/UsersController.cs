using AutoMapper;
using Liberos.Application.DTOs;
using Liberos.Domain.Interfaces;
using Liberos.Domain.Models;
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
    public async Task<ActionResult<IEnumerable<UserDto>>> Get()
    {
        var users = await _unitOfWork.UserRepository.GetAllAsync();
        if (users is null || !users.Any())
            return NotFound("Usuários não encontrados.");

        var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);

        return Ok(usersDto);
    }

    [HttpGet("{id:int}", Name = "ObterUser")]
    public async Task<ActionResult<UserDto>> Get(int id)
    {
        var user = await _unitOfWork.UserRepository.GetAsync(c => c.Id == id);
        if (user is null)
            return NotFound("Usuário não encontrado.");
        
        var userDto = _mapper.Map<UserDto>(user);

        return Ok(userDto);
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> Post(UserDto userDto)
    {
        if (userDto is null)
            return BadRequest("Usuário informado inválido");

        var user = _mapper.Map<User>(userDto);

        var createdUser = _unitOfWork.UserRepository.Create(user);
        _unitOfWork.CommitAsync();

        var createdUserDto = _mapper.Map<UserDto>(createdUser);

        return new CreatedAtRouteResult("ObterUser", new { id = createdUserDto.Id }, createdUserDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<UserDto>> Put(int id, UserDto userDto)
    {
        if (id != userDto.Id)
            return BadRequest("Id informado não corresponde ao id do usuário.");

        var user = _mapper.Map<User>(userDto);

        var updatedUser = _unitOfWork.UserRepository.Update(user);
        await _unitOfWork.CommitAsync();

        var updatedUserDto = _mapper.Map<UserDto>(updatedUser);

        return Ok(updatedUserDto);
    }

    [HttpDelete]
    public async Task<ActionResult<UserDto>> Delete(int id)
    {
        var user = await _unitOfWork.UserRepository.GetAsync(c => c.Id == id);
        if (user is null)
            return NotFound("Usuário informado não encontrado.");

        var deletedUser = _unitOfWork.UserRepository.Delete(user);
        await _unitOfWork.CommitAsync();

        var deletedUserDto = _mapper.Map<UserDto>(deletedUser);

        return Ok(deletedUserDto);
    }
}
