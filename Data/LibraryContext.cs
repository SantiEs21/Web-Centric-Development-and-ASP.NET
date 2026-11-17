using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
namespace TodoApi.Data;

public class LibraryContext:DbContext{
    public LibraryContext(DbContextOptions<LibraryContext> options):base(options){
    }
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Book> Books => Set<Book>();
    //create the relationship between Author and Book
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Author>().HasMany(a => a.Books).WithOne(b => b.Author).HasForeignKey(b => b.author_id);
    }
}