using BankingSystem.Common;
using BankingSystem.Common.Contracts.Requests;
using BankingSystem.Common.Contracts.Responses;
using BankingSystem.UI.Constants;
using BankingSystem.UI.Extensions;
using BankingSystem.UI.Models;
using System.Net.Http.Headers;
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
                return await HandleAuthResponseAsync(response);
            }
        }
        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            string url = ApiHost.Url + ApiRoutes.Identity.Login;
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(request.Serialize(), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, content);
                return await HandleAuthResponseAsync(response);
            }
        }
        private async Task<AuthResponse> HandleAuthResponseAsync(HttpResponseMessage response)
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
    
        public async Task<List<UserViewModel>> GetUsersAsync(string accessToken)
        {
            string url = ApiHost.Url + ApiRoutes.Identity.GetAll;
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var response = await httpClient.GetAsync(url);
                if(response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return json.Deserialize<List<UserViewModel>>();
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public async Task<BankAccountViewModel> GetBankAccountAsync(string accessToken)
        {
            string url = ApiHost.Url + ApiRoutes.BankAccount.GetByUser;
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return json.Deserialize<BankAccountViewModel>();
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public async Task<TransactionSuccessResponse> TopUpAsync(string accessToken, double amount)
        {
            string url = ApiHost.Url + ApiRoutes.BankAccount.TopUp;
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var request = new TopUpRequest { Amount = amount };
                var content = new StringContent(request.Serialize(), Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(url, content);
                var json = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return json.Deserialize<TransactionSuccessResponse>();
                }
                else if(response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var failed = json.Deserialize<TransactionFailedResponse>();
                    throw new InvalidOperationException(failed.Errors.BuildErrorMessage());
                }
                else
                {
                    throw new Exception();
                }
            }
        }
        public async Task<TransactionSuccessResponse> WithdrawAsync(string accessToken, int amount)
        {
            string url = ApiHost.Url + ApiRoutes.BankAccount.Withdraw;
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var request = new WithdrawRequest { Amount = amount };
                var content = new StringContent(request.Serialize(), Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(url, content);
                var json = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return json.Deserialize<TransactionSuccessResponse>();
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var failed = json.Deserialize<TransactionFailedResponse>();
                    throw new InvalidOperationException(failed.Errors.BuildErrorMessage());
                }
                else
                {
                    throw new Exception();
                }
            }
        }
        public async Task<TransactionSuccessResponse> ReplenishAsync(string accessToken, ReplenishRequest request)
        {
            string url = ApiHost.Url + ApiRoutes.BankAccount.Replenish;
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var content = new StringContent(request.Serialize(), Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(url, content);
                var json = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return json.Deserialize<TransactionSuccessResponse>();
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var failed = json.Deserialize<TransactionFailedResponse>();
                    throw new InvalidOperationException(failed.Errors.BuildErrorMessage());
                }
                else
                {
                    throw new Exception();
                }
            }
        }

    }
}
