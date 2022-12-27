namespace Admin_Ecommerce.Controller_API
{
    public class User
    {
        public string? _id { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? phoneNumber { get; set; }
        public string? role { get; set; }
        public bool IsDeleting { get; set; }
    }
}
