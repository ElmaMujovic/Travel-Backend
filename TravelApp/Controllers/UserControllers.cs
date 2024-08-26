using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelApp.Contracts.User.Request;
using TravelApp.Contracts.User.Response;
using TravelApp.ImageUploadMethod;
using TravelApp.Interfaces;
using TravelApp.Models;

namespace TravelApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserControllers : ControllerBase
    {

        private readonly IKorisnikService _userService;
        private readonly IMapper _mapper;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        private readonly UserManager<Korisnik> _userManager;



        public UserControllers(IKorisnikService userService, IMapper mapper, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment, UserManager<Korisnik> userManager)
        {
            _userService = userService;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
            _userManager = userManager;
        }




        [HttpPatch]
        public async Task<IActionResult> UpdateUser([FromForm] UpdateUserRequest request)
        {
            //user sa svim atributima?
            var user = await _userService.GetUserByEmail(request.Email);

            //??
            _mapper.Map<UpdateUserRequest, Korisnik>(request, user);

            if (request.ImagePath != null)
            {
                user.ImagePath = await Upload.SaveFile(_hostingEnvironment.ContentRootPath, request.ImagePath, "images");
            }

            var updatedUser = await _userService.UpdateUser(user, request.CurrentPassword, request.NewPassword);

            var dataUser = _mapper.Map<UserResponse>(updatedUser.User);
            var msg = updatedUser.Message;


            return Ok(new UserWithMessageResponse() { UserResponse = dataUser, Message = msg });
        }


    }

}
