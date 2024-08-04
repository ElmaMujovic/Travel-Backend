using Travel.Models;

namespace Travel.Contracts.User.Response
{
    public class AuthSuccessResponse
    {
        //public string Token { get; set; }

        public Korisnik User { get; set; }

        public string Role { get; set; }
        public string Token { get; set; }
    }
}
