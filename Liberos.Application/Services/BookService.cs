using Liberos.Domain.Models;
using Liberos.Domain.Interfaces;

namespace Liberos.Application.Services;

public class BookService
{
    private readonly IUnitOfWork _unitOfWork;

    public BookService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Book>> GetAllBooksAsync() => await _unitOfWork.BookRepository.GetAllAsync();

    public async Task<Book?> GetBookByIdAsync(int id) => await _unitOfWork.BookRepository.GetAsync(b => b.Id == id);
}
