
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.DTOs;
using TodoApi.Models;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
    private readonly LibraryContext cntxt;

    public BooksController(LibraryContext context)
    {
        cntxt = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var books = await cntxt.Books.AsNoTracking().Select(b => new{
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookById(int id)
    {
        var book = await cntxt.Books.AsNoTracking().Where(b => b.book_id == id).Select(b => new
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
            available_copies = b.Copies.Count(
                    c => c.status == "available"
                )
        })
            .FirstOrDefaultAsync();

        if (book == null)
        {
            return NotFound();
        }

        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook(CreateBookDto dto)
    {
        var authorExists = await cntxt.Authors
            .AnyAsync(a => a.author_id == dto.author_id);

        if (!authorExists)
        {
            return BadRequest("Author does not exist.");
        }

        var book = new Book
        {
            author_id = dto.author_id,
            title = dto.title,
            isbn = dto.isbn,
            publication_year = dto.publication_year
        };

        cntxt.Books.Add(book);
        await cntxt.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetBookById),
            new { id = book.book_id },
            new { book.book_id, book.title }
        );
    }
}