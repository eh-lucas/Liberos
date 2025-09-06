using AutoMapper;
using Liberos.Application.DTOs;
using Liberos.Domain.Interfaces;
using Liberos.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Liberos.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserLibraryController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<UserLibraryController> _logger;
    private readonly IMapper _mapper;

    public UserLibraryController(IUnitOfWork unitOfWork, ILogger<UserLibraryController> logger, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserLibraryDto>>> GetAsync()
    {
        var userLibraries = await _unitOfWork.UserLibraryRepository.GetAllAsync();
        if (userLibraries is null || !userLibraries.Any())
            return NotFound("Livros não encontrados.");

        var userLibrariesDto = _mapper.Map<IEnumerable<UserLibraryDto>>(userLibraries);

        return Ok(userLibrariesDto);
    }

    [HttpGet("{id:int}", Name = "ObterUsuarioLivro")]
    public async Task<ActionResult<UserLibraryDto>> Get(int id)
    {
        var userLibrary = await _unitOfWork.UserLibraryRepository.GetAsync(b => b.Id == id);
        if (userLibrary is null)
            return NotFound("UsuarioLivro não encontrado.");

        var userLibraryDto = _mapper.Map<UserLibraryDto>(userLibrary);

        return Ok(userLibraryDto);
    }

    [HttpPost]
    public async Task<ActionResult<UserLibraryDto>> Post(UserLibraryDto userLibraryDto)
    {
        var userLibrary = _mapper.Map<UserLibrary>(userLibraryDto);

        var createdUserLibrary = _unitOfWork.UserLibraryRepository.Create(userLibrary);

        var newUserLibraryDto = _mapper.Map<UserLibraryDto>(createdUserLibrary);

        await _unitOfWork.CommitAsync();

        return new CreatedAtRouteResult("Obter User Library", new { id = newUserLibraryDto.Id }, newUserLibraryDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<UserLibraryDto>> Put(int id, UserLibraryDto userLibraryDto)
    {
        if (id != userLibraryDto.Id)
            return BadRequest("Id informado não corresponde ao id do livro.");

        var userLibrary = _mapper.Map<UserLibrary>(userLibraryDto);

        var updatedUserLibrary = _unitOfWork.UserLibraryRepository.Update(userLibrary);
        await _unitOfWork.CommitAsync();

        var updatedUserLibraryDto = _mapper.Map<UserLibraryDto>(updatedUserLibrary);

        return Ok(updatedUserLibraryDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<UserLibraryDto>> Delete(int id)
    {
        var userLibrary = await _unitOfWork.UserLibraryRepository.GetAsync(b => b.Id == id);
        if (userLibrary is null)
            return NotFound("UsuarioLivro informado não encontrado.");

        var deletedUserLibrary = _unitOfWork.UserLibraryRepository.Delete(userLibrary);
        await _unitOfWork.CommitAsync();

        var deletedUserLibraryDto = _mapper.Map<UserLibraryDto>(deletedUserLibrary);

        return Ok(deletedUserLibraryDto);
    }
}
