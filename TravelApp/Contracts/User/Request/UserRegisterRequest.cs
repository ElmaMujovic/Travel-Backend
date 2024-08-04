namespace Travel.Contracts.User.Request
{
    public class UserRegisterRequest
    {
        
        public UserRegister UserRegister { get; set; }

        public string Role { get; set; }
       

        public IFormFile Path { get; set; }
    }
}
