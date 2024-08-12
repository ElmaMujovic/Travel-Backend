using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelApp.Contracts.DestinacijePaketa.Requests;
using TravelApp.Interfaces;
using System.Collections.Generic;

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

        // Ovaj endpoint vraća sve destinacije paketa
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var destinacijePaketa = await destinacijaPaketaService.GetAllDestinacijePaketa();
            return Ok(destinacijePaketa);
        }

        // Ovaj endpoint vraća destinaciju paketa prema njenom ID-u
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var destinacijaPaketa = await destinacijaPaketaService.GetDestinacijaPaketaById(id);
            if (destinacijaPaketa == null)
                return NotFound();
            return Ok(destinacijaPaketa);
        }

        // Ovaj endpoint vraća sve destinacije za dati paketId
        [HttpGet("Paket/{paketId}")]
        public async Task<IActionResult> GetDestinacijeByPaketId(int paketId)
        {
            var destinacije = await destinacijaPaketaService.GetDestinacijeByPaketId(paketId);
            if (destinacije == null || !destinacije.Any())
                return NotFound();

            return Ok(destinacije);
        }

        // Kreiranje nove destinacije paketa
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] DestinacijaPaketaCreateRequest destinacijaPaketaRequest)
        {
            var newDestinacijaPaketa = await destinacijaPaketaService.CreateDestinacijaPaketa(destinacijaPaketaRequest);
            if (!newDestinacijaPaketa)
                return BadRequest();
            return Ok(newDestinacijaPaketa);
        }

        // Ažuriranje destinacije paketa prema njenom ID-u
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromForm] DestinacijaPaketaUpdateRequest destinacijaPaketaRequest, int id)
        {
            var updateDestinacijaPaketa = await destinacijaPaketaService.UpdateDestinacijaPaketa(destinacijaPaketaRequest, id);
            if (!updateDestinacijaPaketa)
                return BadRequest();
            return Ok(updateDestinacijaPaketa);
        }

        // Brisanje destinacije paketa prema njenom ID-u
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
