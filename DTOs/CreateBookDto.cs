using System.ComponentModel.DataAnnotations;
namespace TodoApi.DTOs;

public class CreateBookDto
{
    [Required]
    public int author_id {get; set;}

    [Required]
    public string title {get; set;} = "";

    public string isbn {get; set;} = "";

    [Range(1, 9999)]
    public int publication_year {get; set;}
}
