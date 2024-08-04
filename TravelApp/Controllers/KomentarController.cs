using Microsoft.AspNetCore.Mvc;
using Travel.Contracts.Komentar.Request;
using Travel.Interfaces;

namespace Travel.Controllers
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var komentar = await _komentarService.GetKomentarByIdAsync(id);

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

        [HttpDelete("{id}")]
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
