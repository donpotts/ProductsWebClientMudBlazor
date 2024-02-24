using System.ComponentModel.DataAnnotations;

namespace ProductsWebClientMudBlazor.Models;

public class LoginModel
{
    [MaxLength(30)]
    [Required]
    [Display(Name = "User Name")]
    public string? UserName { get; set; }

    [MaxLength(20)]
    [Required]
    public string? Password { get; set; }
}
