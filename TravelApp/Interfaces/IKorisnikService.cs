using TravelApp.Contracts.User.Response;
using TravelApp.Models;

namespace TravelApp.Interfaces
{
    public interface IKorisnikService
    {

        Task<Korisnik?> GetUserByEmail(string email);

        Task<UpdatedUserResponse?> UpdateUser(Korisnik user, string currentPassword, string newPassword);
    }
}
