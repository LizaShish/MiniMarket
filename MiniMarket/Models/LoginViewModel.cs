using System.ComponentModel.DataAnnotations;

namespace MiniMarket.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "Введите имя пользователя")]
    public string UserName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "Введите пароль")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public bool RememberMe { get; set; }
    
}