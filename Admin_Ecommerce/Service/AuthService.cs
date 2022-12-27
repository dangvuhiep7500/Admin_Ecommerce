using Admin_Ecommerce.Controller_API;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using System.Security.Cryptography;

namespace Admin_Ecommerce.Service
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;
        private string _userKey = "user";
        public User user { get; private set; }
     
        public AuthService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }
        public async Task Initialize()
        {
            user = await _localStorage.GetItemAsync<User>(_userKey);
        }
        public async Task<IList<User>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IList<User>>("http://localhost:5000/users/get/all");
        }
        public async Task<User> GetById(string _id)
        {
            return await _httpClient.GetFromJsonAsync<User>($"http://localhost:5000/users/getUser/{_id}");
        }
        public async Task Update(string _id, EditUser model)
        {
            await _httpClient.PatchAsJsonAsync($"http://localhost:5000/users/update/{_id}", model);

            // update stored user if the logged in user updated their own record
            if (_id == user._id)
            {
                // update local storage
                user.firstName = model.firstName;
                user.lastName = model.lastName;
                user.phoneNumber = model.phoneNumber;
                await _localStorage.SetItemAsync(_userKey, user);
            }
        }
        public async Task Delete(string _id)
        {
            await _httpClient.DeleteAsync($"http://localhost:5000/users/update/{_id}");

            // auto logout if the logged in user deleted their own record
            if (_id == user._id)
                await Logout();
        }

        /*  public async Task<RegisterResult> Register(RegisterModel registerModel)
          {
              var result = await _httpClient.PostJsonAsync<RegisterResult>("api/accounts", registerModel);

              return result;
          }*/

        public async Task<User> Login(LoginModel loginModel)
        {
            var loginAsJson = JsonSerializer.Serialize(loginModel);
            var response = await _httpClient.PostAsync("http://localhost:5000/users/login", new StringContent(loginAsJson, Encoding.UTF8, "application/json"));
            var loginResult = JsonSerializer.Deserialize<User>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (!response.IsSuccessStatusCode)
                return loginResult;
            await _localStorage.SetItemAsStringAsync("authToken", loginResult.Token);

            ((CustomAuthStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginModel.email);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResult.Token);

            return new User { Successful = true };

        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((CustomAuthStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
