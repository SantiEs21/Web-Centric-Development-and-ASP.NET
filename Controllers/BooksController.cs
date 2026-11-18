
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
    private readonly LibraryContext _context;

    public BooksController(LibraryContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var books = await _context.Books
            .AsNoTracking()
            .Select(b => new
            {
                b.book_id,
                b.title,
                b.isbn,
                b.publication_year,
                author = new
                {
                    b.Author.author_id,
                    b.Author.name
                },
                total_copies = b.Copies.Count,
                available_copies = b.Copies.Count(c => c.status == "available")}).ToListAsync();

        return Ok(books);
    }
}
