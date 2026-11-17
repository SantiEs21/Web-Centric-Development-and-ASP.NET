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
    //create the relationship between Author and Book
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<LibraryUser>().ToTable("User");
        modelBuilder.Entity<UserCard>().ToTable("User_Card");
        modelBuilder.Entity<Author>().ToTable("Author");
        modelBuilder.Entity<Book>().ToTable("Book");
        modelBuilder.Entity<Loan>().ToTable("Loan");

        //Author->Book
        modelBuilder.Entity<Author>().HasMany(a => a.Books).WithOne(b => b.Author).HasForeignKey(b => b.author_id).OnDelete(DeleteBehavior.Restrict);
        //User->Card
        modelBuilder.Entity<LibraryUser>().HasOne(u => u.Card).WithOne(c => c.User).HasForeignKey<UserCard>(c => c.user_id);
        //User->Loan
        modelBuilder.Entity<LibraryUser>().HasMany(u => u.Loans).WithOne(l => l.User).HasForeignKey(l => l.user_id).OnDelete(DeleteBehavior.Restrict);
        //Book->Loan
        modelBuilder.Entity<Book>().HasMany(b => b.Loans).WithOne(l => l.Book).HasForeignKey(l => l.book_id).OnDelete(DeleteBehavior.Restrict);
        
    }
}