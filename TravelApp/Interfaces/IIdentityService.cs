using Travel.Contracts.User.Request;
using Travel.Contracts.User.Response;
using Travel.Models;

namespace Travel.Interfaces
{
    public interface IIdentityService
    {
        Task<AuthServiceResponse> RegisterAsync(Korisnik request, string password, string role);

        Task<AuthServiceResponse> LoginAsync(LoginRequest request);

        Task<string> ChangeYourPasswordAsync(string email, string password);
        Task<string> ResetPassword(string email);
    }
}
