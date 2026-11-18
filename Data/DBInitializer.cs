using TodoApi.Models;

namespace TodoApi.Data;

public static class DBInitializer
{
    public static void Initialize(LibraryContext context)
    {
        if (!context.Authors.Any())
        {
            context.Authors.AddRange(
                new Author { name = "George Orwell", city = "London" },
                new Author { name = "J.K. Rowling", city = "Edinburgh" }
            );
            context.SaveChanges();
        }

        if (!context.Books.Any())
        {
            var orwell = context.Authors.First(a => a.name == "George Orwell");
            var rowling = context.Authors.First(a => a.name == "J.K. Rowling");

            context.Books.AddRange(
                new Book
                {
                    title = "1984",
                    publication_year = 1949,
                    author_id = orwell.author_id
                },
                new Book
                {
                    title = "Harry Potter and the Philosopher's Stone",
                    publication_year = 1997,
                    author_id = rowling.author_id
                }
            );
            context.SaveChanges();
        }

        if (!context.Categories.Any())
        {
            context.Categories.AddRange(
                new Category { name = "Dystopian fiction" },
                new Category { name = "Fantasy" }
            );
            context.SaveChanges();
        }

        // Associa as categorias aos livros, sem repetir associacoes existentes.
        var book1984 = context.Books.First(b => b.title == "1984");
        var bookHarryPotter = context.Books.First(b => b.title == "Harry Potter and the Philosopher's Stone");
        var dystopia = context.Categories.First(c => c.name == "Dystopian fiction");
        var fantasy = context.Categories.First(c => c.name == "Fantasy");

        context.Entry(book1984).Collection(b => b.Categories).Load();
        context.Entry(bookHarryPotter).Collection(b => b.Categories).Load();
        if (!book1984.Categories.Any(c => c.category_id == dystopia.category_id))
            book1984.Categories.Add(dystopia);
        if (!bookHarryPotter.Categories.Any(c => c.category_id == fantasy.category_id))
            bookHarryPotter.Categories.Add(fantasy);
        context.SaveChanges();

        if (!context.BookCopies.Any())
        {
            context.BookCopies.AddRange(
                new BookCopy
                {
                    book_id = book1984.book_id,
                    barcode = "COPY-1984-001",
                    status = "borrowed"
                },
                new BookCopy
                {
                    book_id = book1984.book_id,
                    barcode = "COPY-1984-002",
                    status = "available"
                },
                new BookCopy
                {
                    book_id = bookHarryPotter.book_id,
                    barcode = "COPY-HP-001",
                    status = "borrowed"
                }
            );
            context.SaveChanges();
        }

        if (!context.LibraryUsers.Any())
        {
            context.LibraryUsers.AddRange(
                new LibraryUser
                {
                    name = "Enzo Tacla",
                    email = "enzo.westphal@groupe-esigelec.org",
                    phone = "123456789"
                },
                new LibraryUser
                {
                    name = "Santiago Estrada",
                    email = "roberto.estrada@groupe-esigelec.org",
                    phone = "987654321"
                }
            );
            context.SaveChanges();
        }

        var enzo = context.LibraryUsers.First(u => u.email == "enzo.westphal@groupe-esigelec.org");
        var santiago = context.LibraryUsers.First(u => u.email == "roberto.estrada@groupe-esigelec.org");

        if (!context.UserCards.Any())
        {
            context.UserCards.AddRange(
                new UserCard
                {
                    user_id = enzo.user_id,
                    registration_date = DateTime.Today,
                    status = "active"
                },
                new UserCard
                {
                    user_id = santiago.user_id,
                    registration_date = DateTime.Today,
                    status = "active"
                }
            );
            context.SaveChanges();
        }

        if (!context.Loans.Any())
        {
            var copy1984 = context.BookCopies.First(c => c.barcode == "COPY-1984-001");
            var copyHarryPotter = context.BookCopies.First(c => c.barcode == "COPY-HP-001");

            context.Loans.AddRange(
                new Loan
                {
                    user_id = enzo.user_id,
                    copy_id = copy1984.copy_id,
                    loan_date = DateTime.Today.AddDays(-3),
                    due_date = DateTime.Today.AddDays(11),
                    status = "active"
                },
                new Loan
                {
                    user_id = santiago.user_id,
                    copy_id = copyHarryPotter.copy_id,
                    loan_date = DateTime.Today.AddDays(-20),
                    due_date = DateTime.Today.AddDays(-6),
                    status = "overdue"
                }
            );
            context.SaveChanges();
        }

        if (!context.Fines.Any())
        {
            var overdueLoan = context.Loans.First(l => l.user_id == santiago.user_id && l.status == "overdue");
            context.Fines.Add(new Fine
            {
                loan_id = overdueLoan.loan_id,
                amount = 5.00m,
                paid = false
            });
            context.SaveChanges();
        }
    }
}