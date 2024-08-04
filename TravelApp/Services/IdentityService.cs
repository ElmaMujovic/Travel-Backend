using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using TravelApp.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TravelApp.Contracts.User.Request;
using TravelApp.Contracts.User.Response;
using TravelApp.Data;
using TravelApp.Interfaces;
using TravelApp.Models;

namespace TravelApp.Services
{
    public class IdentityService : IIdentityService
    { 
        private readonly UserManager<Korisnik> userManager;
        private readonly AppDbContext appDbContext;
        private readonly JwtSettings _jwtSettings;

        public IdentityService(UserManager<Korisnik> userManager, AppDbContext appDbContext, JwtSettings jwtSettings)
        {
            this.userManager = userManager;
            this.appDbContext = appDbContext;
            _jwtSettings = jwtSettings;
        }

        public Task<string> ChangeYourPasswordAsync(string email, string password)
        {
            //sama
            throw new NotImplementedException();
        }

        public async Task<AuthServiceResponse> LoginAsync(LoginRequest request)
        {
            var userExist = await userManager.FindByEmailAsync(request.Email);

            if (userExist == null)
            {
                return new AuthServiceResponse { Error = $"User with {request.Email} email are not registered", StatusCode = 404 };
            }


            var isValidPassword = await userManager.CheckPasswordAsync(userExist, request.Password);

            if (!isValidPassword)
            {
                return new AuthServiceResponse { Error = "Wrong password", StatusCode = 400 };
            }

          
            var roleList = await userManager.GetRolesAsync(userExist);

            var role = roleList.FirstOrDefault();

            string token = GenerateToken(userExist.Id, role, _jwtSettings);

            return new AuthServiceResponse
            {
  
                User = userExist,
                Role = role,
                Token = token
            };
        }

        public async Task<AuthServiceResponse> RegisterAsync(Korisnik request, string password, string role)
        {
            var userExist = await userManager.FindByEmailAsync(request.Email);

            if (userExist != null)
            {
                return new AuthServiceResponse { Error = $"User with {request.Email} email are registered", StatusCode = 400 };
            }

            var newUser = await userManager.CreateAsync(request, password);

            if (newUser.Succeeded == false)
            {
                return new AuthServiceResponse { Error = $"Something went wrong", StatusCode = 500, User = null };
            }

            await userManager.AddToRoleAsync(request, role);

            string token = GenerateToken(request.Id, role, _jwtSettings);

            return new AuthServiceResponse
            {
                
                User = request,
                Role = role,
                Token = token

            };
        }


        private string GenerateToken(int id, string role, TravelApp.Settings.JwtSettings _jwtSettings)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("id", id.ToString()),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddHours(200),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            var token = tokenHandler.WriteToken(securityToken);

            return token;
        }

        public Task<string> ResetPassword(string email)
        {
            //sama
            throw new NotImplementedException();
        }
    }
}
