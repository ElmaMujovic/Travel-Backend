using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelApp.Contracts.Paketi.Requests;
using TravelApp.Interfaces;

namespace TravelApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaketController : ControllerBase
    {
        private readonly IPaketService paketService;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public PaketController(IPaketService paketService, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            this.paketService = paketService;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var paketi = await paketService.GetAllPaketi();
            return Ok(paketi);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var paket = await paketService.GetPaketById(id);
            return Ok(paket);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] PaketiCreateRequests paket)
        {
            var newPaket = await paketService.CreatePaket(paket);
            if (!newPaket)
                return BadRequest();
            return Ok(newPaket);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromForm] PaketiUpdateRequest paket, int id)
        {
            var updatePaket = await paketService.UpdatePaket(paket, id);
            if (!updatePaket)
                return BadRequest();
            return Ok(updatePaket);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletePaket = await paketService.DeletePaket(id);
            if (!deletePaket)
                return BadRequest();
            return Ok(deletePaket);
        }
    }
}