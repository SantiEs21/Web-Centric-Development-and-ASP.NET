using NuGet.Common;
using TodoApi.Models;
namespace TodoApi.Data;

public static class DBInitializer{

    public static void Initialize(LibraryContext context)
    {
        if(!context.Authors.Any()){
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
        }

        if (!context.Books.Any())
        {
            var author1 = context.Authors.First(a=>a.name == "George Orwell");
            var author2 = context.Authors.First(a=>a.name == "J.K. Rowling");

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

        if (!context.LibraryUsers.Any()){
            var user1 = new LibraryUser
            {
                name = "Enzo Tacla",
                email = "enzo.westphal@groupe-esigelec.org",
                phone = "123456789"
            };
            var user2 = new LibraryUser
            {
                name = "Santiago Estrada",
                email = "roberto.estrada@groupe-esigelec.org",
                phone = "987654321"
            };
            context.LibraryUsers.AddRange(user1,user2);
            context.SaveChanges(); 
        }

        if (!context.UserCards.Any()){
            var user1 = context.LibraryUsers.First(u => u.email == "enzo.westphal@groupe-esigelec.org");
            var user2 = context.LibraryUsers.First(u => u.email == "roberto.estrada@groupe-esigelec.org");

            var card1 = new UserCard{
                user_id = user1.user_id,
                registration_date = DateTime.Now,
                status = "active"
            };
            var card2 = new UserCard{
                user_id = user2.user_id,
                registration_date = DateTime.Now,
                status = "overdue"                
            };
            context.UserCards.AddRange(card1,card2);
            context.SaveChanges();
        }
        if (!context.Loans.Any()){
            var user1 = context.LibraryUsers.First(u => u.email == "enzo.westphal@groupe-esigelec.org");
            var user2 = context.LibraryUsers.First(u => u.email == "roberto.estrada@groupe-esigelec.org");

            var book1 = context.Books.First(b => b.title == "1984");
            var book2 = context.Books.First(b => b.title == "Harry Potter and the Philosopher's Stone");

            var loan1 = new Loan{
                user_id = user1.user_id,
                book_id = book1.book_id,
                loan_date = DateTime.Now,
                due_date = DateTime.Now.AddDays(14),
                status = "active"
            };
            var loan2 = new Loan{
                user_id = user2.user_id,
                book_id = book2.book_id,
                loan_date = DateTime.Now,
                due_date = DateTime.Now.AddDays(14),
                status = "overdue"
            };

            context.Loans.AddRange(loan1,loan2);
            context.SaveChanges();
        }
    } 
}