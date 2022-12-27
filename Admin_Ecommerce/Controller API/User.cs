namespace Admin_Ecommerce.Controller_API
{
    public class User
    {
        public string? _id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? phoneNumber { get; set; }
        public string? Token { get; set; }
        public bool IsDeleting { get; set; }
        public bool Successful { get; set; }
    }
}
