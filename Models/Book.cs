using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models;
public class Book{
    [Key]
    public int book_id{get; set;}
    public int author_id{get; set;}
    public string title{get; set;}="";
    public int publication_year{get; set;}
    public Author Author {get; set;} = new Author();
    public List<Loan> Loans {get; set;} = new();
}