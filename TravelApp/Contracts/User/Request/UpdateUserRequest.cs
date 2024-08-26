namespace TravelApp.Contracts.User.Request
{
    public class UpdateUserRequest
    {
        public string Ime { get; set; }

        public string Prezime { get; set; }
        public string Email { get; set; }
        public IFormFile ImagePath { get; set; }
        public string Grad { get; set; }
        public int Godina { get; set; }

        public string CurrentPassword { get; set; } = "";

        public string NewPassword { get; set; } = "";

    }
}
