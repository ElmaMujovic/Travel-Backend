using Travel.Models;

namespace Travel.Contracts.User.Response
{
    public class AuthServiceResponse
    {
        public string? Token { get; set; }

        public Korisnik? User { get; set; }

        public string? Role { get; set; }

        public string? Error { get; set; }

        public int StatusCode { get; set; }
    }
}
