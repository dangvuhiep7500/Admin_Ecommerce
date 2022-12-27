using System.ComponentModel.DataAnnotations;

namespace Admin_Ecommerce.Controller_API
{
    public class EditUser
    {

        [Required]
        public string?firstName { get; set; }

        [Required]
        public string?lastName { get; set; }

        [Required]
        public string?phoneNumber { get; set; }

        [MinLength(6, ErrorMessage = "The Password field must be a minimum of 6 characters")]
        public string?password { get; set; }

        public EditUser() { }

        public EditUser(User user)
        {
            firstName = user.firstName;
            lastName = user.lastName;
            phoneNumber = user.phoneNumber;
        }
    }
}
