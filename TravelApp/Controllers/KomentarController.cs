using Microsoft.AspNetCore.Mvc;
using TravelApp.Contracts.Komentar.Request;
using TravelApp.Interfaces;

namespace TravelApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KomentarController : ControllerBase
    {
        

        private readonly IKomentarService _komentarService;

        public KomentarController(IKomentarService komentarService)
        {
            _komentarService = komentarService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var komentari = await _komentarService.GetAllKomentarAsync();

            return Ok(komentari);
        }

        [HttpGet("comments/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var komentar = await _komentarService.GetKomentarByDestinacijaIdAsync(id);

            return Ok(komentar);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] KomentarCreateRequest komentar)
        {
            var result = await _komentarService.AddKomentarAsync(komentar);
            if(!result)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("delete-comment{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _komentarService.DeleteKomentarAsync(id);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
