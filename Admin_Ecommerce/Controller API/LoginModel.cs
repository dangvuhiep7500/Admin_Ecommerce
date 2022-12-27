using System.ComponentModel.DataAnnotations;

    public class LoginModel
    {
    public int _id { get; set; }
    [Required(ErrorMessage = "Email is required")]
    public string? email { get; set; }
    [Required(ErrorMessage = "Password is required")]
    public string? password { get; set; }
    public bool RememberMe { get; set; }

}

