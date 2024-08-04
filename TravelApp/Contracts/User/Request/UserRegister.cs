namespace TravelApp.Contracts.User.Request
{
    public class UserRegister
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }
        public string Username { get; set; }
        public int Godina { get; set; }
        public string Grad { get; set; }
    }
}
