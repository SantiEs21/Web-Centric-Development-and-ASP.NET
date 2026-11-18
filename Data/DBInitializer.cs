using TodoApi.Models;
namespace TodoApi.Data;

public static class DBInitializer{

    public static void Initialize(LibraryContext context)
    {
        if(context.Authors.Any()){
            return;
        }

        var author1 = new Author{
            name = "George Orwell",
            city = "London"
        };

        var author2 = new Author{
            name = "J.K. Rowling",
            city = "Edinburgh"
        };

        context.Authors.AddRange(author1, author2);
        context.SaveChanges();

        var book1 = new Book{
            title = "1984",
            publication_year = 1949,
            author_id = author1.author_id
        };
        
        var book2 = new Book{
            title = "Harry Potter and the Philosopher's Stone",
            publication_year = 1997,
            author_id = author2.author_id
        };

        context.Books.AddRange(book1, book2);
        context.SaveChanges();
    } 
}