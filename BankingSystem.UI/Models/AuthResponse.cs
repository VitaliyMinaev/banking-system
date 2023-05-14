using BankingSystem.Common.Contracts.Responses;

namespace BankingSystem.UI.Models
{
    public class AuthResponse : ApiResponse<AuthenticationSuccessResponse, AuthenticationFailedResponse>
    {
        public AuthResponse(AuthenticationSuccessResponse success) : base(success)
        { }
        public AuthResponse(AuthenticationFailedResponse failure) : base(failure)
        { }
    }
}
