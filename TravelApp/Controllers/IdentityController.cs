using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using System.Text;
using System;
using Travel.Contracts.User.Request;
using Travel.Interfaces;
using Travel.Models;
using Travel.Contracts.User.Response;
using RentACar.ImageUploadMethod;

namespace Travel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        private readonly IMapper mapper;

        public IdentityController(IIdentityService identityService, IMapper mapper, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment, IMapper mapper1)
        {
            _identityService = identityService;
            _hostingEnvironment = hostingEnvironment;
            this.mapper = mapper1;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] UserRegisterRequest request)
        {
            var userR = mapper.Map<Korisnik>(request.UserRegister);
            userR.ImagePath = await Upload.SaveFile(_hostingEnvironment.ContentRootPath, request.Path, "images");
            var registerResponse = await _identityService.RegisterAsync(userR, request.UserRegister.Password, request.Role);

            if (registerResponse.Error != null)
            {
                return BadRequest(new AuthFailedResponse { Error = registerResponse.Error });

            }
            
            return Ok(new AuthSuccessResponse
            {
                
                User = registerResponse.User,
                Role = registerResponse.Role,
                Token = registerResponse.Token
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var loginResponse = await _identityService.LoginAsync(request);

            if (loginResponse.Error != null)
            {
                return BadRequest(new AuthFailedResponse { Error = loginResponse.Error });
            }

            return Ok(new AuthSuccessResponse
            {
                User = loginResponse.User,
                Role = loginResponse.Role,
                Token = loginResponse.Token
            });
        }
       
    }
}
