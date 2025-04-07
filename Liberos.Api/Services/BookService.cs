using Liberos.Api.Interfaces;
using Liberos.Api.Models;

namespace Liberos.Api.Services;

public class BookService
{
    private readonly IUnitOfWork _unitOfWork;

    public BookService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<Book> GetAllBooks() => _unitOfWork.BookRepository.GetAll();

    public Book? GetBookById(int id) => _unitOfWork.BookRepository.Get(b => b.Id == id);
}
