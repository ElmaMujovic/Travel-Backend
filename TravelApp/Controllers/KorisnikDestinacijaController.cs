using Microsoft.AspNetCore.Mvc;
using Travel.Contracts.KorisnikDestinacija.Request;
using Travel.Interfaces;

namespace Travel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KorisnikDestinacijaController : ControllerBase
    {
        private readonly IKorisnikDestinacija korisnikDestinacija;

        public KorisnikDestinacijaController(IKorisnikDestinacija korisnikDestinacija)
        {
            this.korisnikDestinacija = korisnikDestinacija;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var korisnikDestinacijeList = await korisnikDestinacija.GetAllKorisnikDestinacijaAsync();
            return Ok(korisnikDestinacijeList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var korisnikDestinacijaById = await korisnikDestinacija.GetKorisnikDestinacijaByIdAsync(id);
            return Ok(korisnikDestinacijaById);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] KorisnikDestinacijaRequest korisnikDestinacija)
        {
            var newKorisnikDestinacija = await this.korisnikDestinacija.AddKorisnikDestinacijaAsync(korisnikDestinacija);
            if(!newKorisnikDestinacija)
                return BadRequest("KorisnikDestinacija nije dodata");
            return Ok("KorisnikDestinacija je uspesno dodata");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteKorisnikDestinacija = await korisnikDestinacija.DeleteKorisnikDestinacijaAsync(id);
            if(!deleteKorisnikDestinacija)
                return BadRequest("KorisnikDestinacija nije obrisana");
            return Ok("KorisnikDestinacija je uspesno obrisana");
        }

        
    }
}
