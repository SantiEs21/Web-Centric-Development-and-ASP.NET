using System.ComponentModel.DataAnnotations;
namespace TodoApi.Models;

public class Category{
    [Key]
    public int category_id{get; set;}
    public string name{get; set;} = "";
    public List<Book> Books{get; set;} = new();
}