using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
namespace TodoApi.Data;

public class LibraryContext:DbContext{
    public LibraryContext(DbContextOptions<LibraryContext> options):base(options){
    }
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Loan> Loans => Set<Loan>();
    public DbSet<LibraryUser> LibraryUsers => Set<LibraryUser>();
    public DbSet<UserCard> UserCards => Set<UserCard>();
    public DbSet<BookCopy> BookCopies => Set<BookCopy>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Fine> Fines => Set<Fine>();
    //create the relationship between Author and Book
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<LibraryUser>().ToTable("User");
        modelBuilder.Entity<UserCard>().ToTable("User_Card");
        modelBuilder.Entity<Author>().ToTable("Author");
        modelBuilder.Entity<Book>().ToTable("Book");
        modelBuilder.Entity<Loan>().ToTable("Loan");
        modelBuilder.Entity<BookCopy>().ToTable("Book_Copy");
        modelBuilder.Entity<Category>().ToTable("Category");
        modelBuilder.Entity<Fine>().ToTable("Fine");

        //Book->BookCopy
        modelBuilder.Entity<Book>().HasOne(b => b.Author).WithMany(a => a.Books).HasForeignKey(b => b.author_id).OnDelete(DeleteBehavior.Restrict);
        //User->Card
        modelBuilder.Entity<LibraryUser>().HasOne(u => u.Card).WithOne(c => c.User).HasForeignKey<UserCard>(c => c.user_id);
        //User->Loan
        modelBuilder.Entity<LibraryUser>().HasMany(u => u.Loans).WithOne(l => l.User).HasForeignKey(l => l.user_id).OnDelete(DeleteBehavior.Restrict);
        //Book->Copy
        modelBuilder.Entity<Book>().HasMany(b => b.Copies).WithOne(c => c.Book).HasForeignKey(c => c.book_id).OnDelete(DeleteBehavior.Restrict);
        //Copy->Loan
        modelBuilder.Entity<BookCopy>().HasMany(c => c.Loans).WithOne(l => l.Copy).HasForeignKey(l => l.copy_id).OnDelete(DeleteBehavior.Restrict);
        //Loan->Fine
        modelBuilder.Entity<Loan>().HasMany(l => l.Fines).WithOne(f => f.Loan).HasForeignKey(f => f.loan_id).OnDelete(DeleteBehavior.Restrict);
        //Book<->Category
        modelBuilder.Entity<Book>().HasMany(b => b.Categories).WithMany(c => c.Books);
        //Fine value precision
        modelBuilder.Entity<Fine>().Property(f => f.amount).HasPrecision(10, 2);
        
    }
}