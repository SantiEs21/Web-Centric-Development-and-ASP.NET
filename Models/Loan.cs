using System.ComponentModel.DataAnnotations;
namespace TodoApi.Models;

public class Loan{
    [Key]
    public int loan_id{get; set;}
    public int user_id{get; set;}
    public int copy_id{get; set;}                    
    public DateTime loan_date{get; set;}
    public DateTime due_date{get; set;}              
    public DateTime? return_date{get; set;}          
    public string status{get;set;} = "active";
    public LibraryUser User{get; set;} = null!;
    public BookCopy Copy{get; set;} = null!;         
    public List<Fine> Fines{get; set;} = new();      
}