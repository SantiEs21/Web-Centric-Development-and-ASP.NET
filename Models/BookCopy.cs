using System.ComponentModel.DataAnnotations;
namespace TodoApi.Models;

public class BookCopy{
    [Key]
    public int copy_id{get; set;}
    public int book_id{get; set;}
    public string barcode{get; set;} = "";
    public string status{get; set;} = "available";   
    public Book Book{get; set;} = null!;
    public List<Loan> Loans{get; set;} = new();
}