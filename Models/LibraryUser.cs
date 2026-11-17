namespace TodoApi.Models;

public class LibraryUser
{
    public int user_id{get; set;}
    public string name{get; set;} = "";
    public string email{get; set;} = "";
    public string phone{get; set;} = "";
    public UserCard? Card{get; set;}
    public List<Loan> Loans{get; set;} = new();
}