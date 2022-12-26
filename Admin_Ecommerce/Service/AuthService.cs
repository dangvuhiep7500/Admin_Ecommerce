using Admin_Ecommerce.Controller_API;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;

namespace Admin_Ecommerce.Service
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

      /*  public async Task<RegisterResult> Register(RegisterModel registerModel)
        {
            var result = await _httpClient.PostJsonAsync<RegisterResult>("api/accounts", registerModel);

            return result;
        }*/

        public async Task<LoginResult> Login(User loginModel)
        {
            var loginAsJson = JsonSerializer.Serialize(loginModel);
            var response = await _httpClient.PostAsync("http://localhost:5000/users/login", new StringContent(loginAsJson, Encoding.UTF8, "application/json"));
            var loginResult = JsonSerializer.Deserialize<LoginResult>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (!response.IsSuccessStatusCode)
            {
                return loginResult;
            }

            await _localStorage.SetItemAsync("authToken", loginResult.Token);
            ((CustomAuthStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginModel.email);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResult.Token);

            return loginResult;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((CustomAuthStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
