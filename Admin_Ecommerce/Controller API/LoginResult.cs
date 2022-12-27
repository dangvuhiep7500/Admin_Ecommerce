namespace Admin_Ecommerce.Controller_API
{
    public class LoginResult
    {
        public bool Successful { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Token { get; set; }
    }
}
