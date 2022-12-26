using Admin_Ecommerce.Controller_API;
using System.Threading.Tasks;
namespace Admin_Ecommerce.Service
{
    public interface IAuthService
    {
        Task<LoginResult> Login(User loginModel);
        Task Logout();
    }
}
