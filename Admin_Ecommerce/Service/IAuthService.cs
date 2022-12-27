using Admin_Ecommerce.Controller_API;
using System.Threading.Tasks;
namespace Admin_Ecommerce.Service
{
    public interface IAuthService
    {
        User user { get; }
        Task Initialize();
        Task<User> Login(LoginModel loginModel);
        Task<User> GetById(string id);
        Task<IList<User>> GetAll();
        Task Update(string id, EditUser model);
        Task Delete(string id);
        Task Logout();
    }
}
