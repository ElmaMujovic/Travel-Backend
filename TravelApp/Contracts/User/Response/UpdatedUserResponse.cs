using TravelApp.Models;

namespace TravelApp.Contracts.User.Response
{
    public class UpdatedUserResponse
    {
        public Korisnik? User { get; set; }

        public string? Message { get; set; }
    }
}
