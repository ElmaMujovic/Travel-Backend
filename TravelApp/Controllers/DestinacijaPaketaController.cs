using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelApp.Contracts.DestinacijePaketa.Requests;
using TravelApp.Interfaces;

namespace TravelApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinacijaPaketaController : ControllerBase
    {
        private readonly IDestinacijaPaketaService destinacijaPaketaService;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public DestinacijaPaketaController(IDestinacijaPaketaService destinacijaPaketaService, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            this.destinacijaPaketaService = destinacijaPaketaService;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var destinacijePaketa = await destinacijaPaketaService.GetAllDestinacijePaketa();
            return Ok(destinacijePaketa);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var destinacijaPaketa = await destinacijaPaketaService.GetDestinacijaPaketaById(id);
            if (destinacijaPaketa == null)
                return NotFound();
            return Ok(destinacijaPaketa);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] DestinacijaPaketaCreateRequest destinacijaPaketaRequest)
        {
            var newDestinacijaPaketa = await destinacijaPaketaService.CreateDestinacijaPaketa(destinacijaPaketaRequest);
            if (!newDestinacijaPaketa)
                return BadRequest();
            return Ok(newDestinacijaPaketa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromForm] DestinacijaPaketaUpdateRequest destinacijaPaketaRequest, int id)
        {
            var updateDestinacijaPaketa = await destinacijaPaketaService.UpdateDestinacijaPaketa(destinacijaPaketaRequest, id);
            if (!updateDestinacijaPaketa)
                return BadRequest();
            return Ok(updateDestinacijaPaketa);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteDestinacijaPaketa = await destinacijaPaketaService.DeleteDestinacijaPaketa(id);
            if (!deleteDestinacijaPaketa)
                return BadRequest();
            return Ok(deleteDestinacijaPaketa);
        }
    }
}
