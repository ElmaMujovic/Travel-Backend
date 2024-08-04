using TravelApp.Contracts.User.Request;
using TravelApp.Contracts.User.Response;
using TravelApp.Models;

namespace TravelApp.Interfaces
{
    public interface IIdentityService
    {
        Task<AuthServiceResponse> RegisterAsync(Korisnik request, string password, string role);

        Task<AuthServiceResponse> LoginAsync(LoginRequest request);

        Task<string> ChangeYourPasswordAsync(string email, string password);
        Task<string> ResetPassword(string email);
    }
}
