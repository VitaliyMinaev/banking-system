namespace BankingSystem.UI.Models
{
    public class ApiResponse<TSuccess, TFailure>
        where TSuccess : class
        where TFailure : class
    {
        public bool Success { get; }
        public TSuccess? SuccessObject { get; set; }
        public TFailure? Failure { get; set; }   
        public ApiResponse(TSuccess success)
        {
            Success = true;
            SuccessObject = success;
            Failure = null;
        }
        public ApiResponse(TFailure failure)
        {
            Success = false;
            SuccessObject = null;
            Failure = failure;
        }
    }
}
