using System.ComponentModel.DataAnnotations;

    public class LoginModel
    {
    public int _id { get; set; }
    [Required]
    public string? email { get; set; }
    [Required]
    public string? password { get; set; }
    [Required]
    public bool RememberMe { get; set; }

}

