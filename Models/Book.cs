using System.ComponentModel.DataAnnotations;
namespace TodoApi.Models;

public class Book{
    [Key]
    public int book_id{get; set;}
    public int author_id{get; set;}
    public string title{get; set;}="";
    public string isbn{get; set;}="";                          
    public int publication_year{get; set;}
    public Author Author {get; set;} = null!;
    public List<BookCopy> Copies {get; set;} = new();          
    public List<Category> Categories {get; set;} = new();      
}