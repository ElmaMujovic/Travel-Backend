using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TravelApp.Contracts.User.Response;
using TravelApp.Data;
using TravelApp.Interfaces;
using TravelApp.Models;

namespace TravelApp.Services
{
    public class KorisnikService : IKorisnikService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<Korisnik> _userManager;

        private readonly IMapper mapper;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        public KorisnikService(AppDbContext context, IMapper mapper, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment, UserManager<Korisnik> userManager)
        {
            _context = context;
            this.mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
            this._userManager = userManager;
        }

        public async Task<Korisnik?> GetUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<UpdatedUserResponse?> UpdateUser(Korisnik user, string currPass, string newPass)

        {
            var message = "";
            if (currPass != "old")
            {
                var msg = await _userManager.CheckPasswordAsync(user, currPass);

                if (msg)
                {
                    await _userManager.ChangePasswordAsync(user, currPass, newPass);
                    message = "";


                }
                else
                {
                    message = "Your password is not correct";
                }
            }


            await _userManager.UpdateAsync(user);

            return new UpdatedUserResponse() { Message = message, User = user };
        }
    }
}
