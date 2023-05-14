using BankingSystem.Common;
using BankingSystem.Common.Contracts.Requests;
using BankingSystem.Common.Contracts.Responses;
using BankingSystem.UI.Constants;
using BankingSystem.UI.Extensions;
using BankingSystem.UI.Models;
using System.Text;

namespace BankingSystem.UI.Http
{
    public class BankingSystemApi
    {
        public async Task<AuthResponse> RegisterAsync(RegistrationRequest request)
        {
            string url = ApiHost.Url + ApiRoutes.Identity.Register;
            using(var httpClient = new HttpClient())
            {
                var content = new StringContent(request.Serialize(), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, content);
                return await HandleResponseAsync(response);
            }
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            string url = ApiHost.Url + ApiRoutes.Identity.Login;
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(request.Serialize(), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, content);
                return await HandleResponseAsync(response);
            }
        }

        private async Task<AuthResponse> HandleResponseAsync(HttpResponseMessage response)
        {
            var json = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return new AuthResponse(json.Deserialize<AuthenticationSuccessResponse>());
            }
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new InvalidOperationException("Api returned 500 error");
            }
            else
            {
                return new AuthResponse(json.Deserialize<AuthenticationFailedResponse>());
            }
        }
    }
}
