using System.ComponentModel.DataAnnotations;
namespace MiniMarket.Models;

public class RegisterViewModel
{
    [Required(ErrorMessage = "User Name")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Email")]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required(ErrorMessage = "Confirm Password")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "The passwords do not match")]
    public string ConfirmPassword { get; set; }
}