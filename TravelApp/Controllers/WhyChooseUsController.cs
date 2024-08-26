using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TravelApp.Interfaces;
using TravelApp.Models;
using System.IO;
using System.Threading.Tasks;

namespace TravelApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WhyChooseUsController : ControllerBase
    {
        private readonly IWhyChooseUsService _service;

        public WhyChooseUsController(IWhyChooseUsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<WhyChooseUsInfo>> GetInfo()
        {
            var info = await _service.GetInfoAsync();
            return Ok(info);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateInfo([FromForm] WhyChooseUsInfo updatedInfo, [FromForm] IFormFile imageFile)
        {
            try
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    // Definišite putanju gde ćete čuvati slike
                    var filePath = Path.Combine("Uploads", imageFile.FileName);

                    // Sačuvajte sliku na serveru
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    // Postavite putanju slike u model
                    updatedInfo.ImageUrl = filePath;
                }

                await _service.UpdateInfoAsync(updatedInfo);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
