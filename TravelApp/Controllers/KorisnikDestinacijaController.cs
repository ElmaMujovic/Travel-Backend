using Microsoft.AspNetCore.Mvc;
using TravelApp.Contracts.KorisnikDestinacija.Request;
using TravelApp.Interfaces;
using TravelApp.Models;
using System.Threading.Tasks;
namespace TravelApp.Controllers
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
        //[HttpPost("api")]
        //public async Task<IActionResult> PostFavorites([FromBody] KorisnikDestinacijaRequest korisnikDestinacija)
        //{
        //    var newKorisnikDestinacija = await this.korisnikDestinacija.AddKorisnikDestinacijaFavorites(korisnikDestinacija);
        //    if (!newKorisnikDestinacija)
        //        return BadRequest("KorisnikDestinacija nije dodata");
        //    return Ok("KorisnikDestinacija je uspešno dodata");
        //}

        [HttpPost("api")]
        public async Task<IActionResult> AddCarToFavourite([FromBody] KorisnikDestinacijaRequest request)
        {
            var result = await korisnikDestinacija.AddKorisnikDestinacijaFavoritesAsync(request.KorisnikId, request.DestinacijaId);

            return Ok();
        }

        [HttpDelete("api/{id}")]
        public async Task<IActionResult> DeleteRemove([FromRoute] int id)
        {
            
            var  resultnew = await this.korisnikDestinacija.RemoveKorisnikDestinacijaAsync(id);
            if (!resultnew)
                return BadRequest("Lajk nije pronađen ili nije mogao biti obrisan");

            return Ok("Lajk je uspešno obrisan");
        }


        [HttpGet("user/destinacije/{id}")]
        public async Task<IActionResult> GetLajkovaneDestinacije(int id)
        {
            var destinacije = await korisnikDestinacija.GetLajkovaneDestinacijeAsync(id);
            if (destinacije == null || !destinacije.Any())
            {
                return NotFound("Korisnik nema lajkovane destinacije.");
            }
            return Ok(destinacije);
        }







    }
}
