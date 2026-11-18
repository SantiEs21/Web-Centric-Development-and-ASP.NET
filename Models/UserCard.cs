using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models;

public class UserCard{
    [Key]
    public int card_id{get;set;}
    public int user_id{get;set;}
    public DateTime registration_date{get;set;}
    public string status{get;set;} = "active";
    public LibraryUser User{get;set;} = null!;
}