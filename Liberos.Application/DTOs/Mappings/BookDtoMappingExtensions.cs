using Liberos.Domain.Models;

namespace Liberos.Application.DTOs.Mappings;
public static class BookDtoMappingExtensions
{
    public static BookDto? ToBookDto(this Book book)
    {
        if (book is null)
            return null;

        return new BookDto
        {
            Id = book.Id,
            Author = book.Author,
            Title = book.Title,
            Description = book.Description,
            IsAvailable = book.IsAvailable,
            Isbn = book.Isbn,
            Language = book.Language,
            PublicationYear = book.PublicationYear,
        };
    }

    public static Book? ToBook(this BookDto bookDto)
    {
        if (bookDto is null)
            return null;

        return new Book
        {
            Id = bookDto.Id,
            Author = bookDto.Author,
            Title = bookDto.Title,
            Description = bookDto.Description,
            IsAvailable = bookDto.IsAvailable,
            Isbn = bookDto.Isbn,
            Language = bookDto.Language,
            PublicationYear = bookDto.PublicationYear,
        };
    }
    
    public static IEnumerable<BookDto> ToBookDtoList(this IEnumerable<Book> books)
    {
        if (books is null || !books.Any())
            return new List<BookDto>();

        return books.Select(book => new BookDto
        {
            Id = book.Id,
            Author = book.Author,
            Title = book.Title,
            Description = book.Description,
            IsAvailable = book.IsAvailable,
            Isbn = book.Isbn,
            Language = book.Language,
            PublicationYear = book.PublicationYear,
        }).ToList();
    }
}
