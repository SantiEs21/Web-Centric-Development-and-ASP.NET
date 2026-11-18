using System.ComponentModel.DataAnnotations;
namespace TodoApi.Models;

public class Fine{
    [Key]
    public int fine_id{get; set;}
    public int loan_id{get; set;}
    public decimal amount{get; set;}
    public bool paid{get; set;}
    public Loan Loan{get; set;} = null!;
}