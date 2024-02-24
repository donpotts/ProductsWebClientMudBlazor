using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsWebClientMudBlazor.Models;

public class UserModel
{
    [Key]
    [Display(Name = "User Id")]
    public int Id { get; set; }

    [MaxLength(30)]
    [Required]
    [Display(Name = "First Name")]
    public string? FirstName { get; set; }

    [MaxLength(30)]
    [Required]
    [Display(Name = "Last Name")]
    public string? LastName { get; set; }

    [MaxLength(30)]
    [Required]
    [Display(Name = "User Name")]
    public string? UserName { get; set; }
    
    [MaxLength(30)]
    [Required]
    public string Password { get; set; } = string.Empty;

    [MaxLength(30)]
    [Required]
    [NotMapped]
    public string ConfirmPassword { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

   
}
