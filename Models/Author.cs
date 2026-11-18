using System.ComponentModel.DataAnnotations;
namespace TodoApi.Models;
public class Author{
    [Key]
    public int author_id {get; set;}
    public string name {get; set;}="";
    public string city {get; set;}="";
    public List<Book> Books {get; set;} = new();
}