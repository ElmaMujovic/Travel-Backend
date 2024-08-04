using Microsoft.AspNetCore.Mvc;
using TravelApp.Contracts.Destinacija.Request;
using TravelApp.Interfaces;

namespace TravelApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinacijaController : ControllerBase
    {
        private readonly IDestinacijaService destinacijaService;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        public DestinacijaController(IDestinacijaService destinacijaService, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            this.destinacijaService = destinacijaService;
            _hostingEnvironment = hostingEnvironment;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var destinacije = await destinacijaService.GetAllDestinacija();
            return Ok(destinacije);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var destinacija = await destinacijaService.GetDestinacijaById(id);
            return Ok(destinacija);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] DestinacijaCreateRequest destinacija)
        {
          
            var newDestinacija = await destinacijaService.createDestinacija(destinacija);
            if (!newDestinacija)
                return BadRequest();
            return Ok(newDestinacija);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromForm] DestinacijaUpdateRequest destinacija, int id)
        {
            var updateDestinacija = await destinacijaService.updateDestinacija(destinacija, id);
            if (!updateDestinacija)
                return BadRequest();
            return Ok(updateDestinacija);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteDestinacija = await destinacijaService.deleteDestinacija(id);
            if (!deleteDestinacija)
                return BadRequest();
            return Ok(deleteDestinacija);
        }
    }
}
