using System.ComponentModel.DataAnnotations;

    public class User
    {
    public int _id { get; set; }
    [Required]
    public string email { get; set; }
    [Required]
    public string password { get; set; }
    [Required]
    public string firstName { get; set; }
    [Required]
    public string lastName { get; set; }
    [Required]
    public string phoneNumber { get; set; }
    public string role { get; set; }

    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}

