using Microsoft.AspNetCore.Mvc;
using TravelApp.Models; // Namespace za List model
using TravelApp.Contracts.List.Request; // Namespace za DTO-ove
using TravelApp.Interfaces; // Namespace za IListService
using System.Collections.Generic;
using System.Threading.Tasks;


namespace TravelApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly IListService _listService;

        public ListController(IListService listService)
        {
            _listService = listService;
        }

        // GET: api/List
        [HttpGet]
        public async Task<ActionResult<IEnumerable<List>>> GetLists()
        {
            var lists = await _listService.GetAllListsAsync();
            return Ok(lists);
        }

        // GET: api/List/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List>> GetList(int id)
        {
            var list = await _listService.GetListByIdAsync(id);
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }

        // POST: api/List
        [HttpPost]
        [HttpPost]
        public async Task<ActionResult<List>> CreateList([FromForm] ListCreateDTO listCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Vrati sve greške validacije klijentu
            }

            try
            {
                var list = await _listService.CreateListAsync(listCreateDTO);
                return Ok(list);
            }
            catch (Exception ex)
            {
                // Logujte grešku ovde
                return StatusCode(500, "Internal server error");
            }
        }


        // PUT: api/List/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateList(int id, [FromBody] ListUpdateDTO listUpdateDTO)
        {
            if (id != listUpdateDTO.Id)
            {
                return BadRequest();
            }

            try
            {
                await _listService.UpdateListAsync(id, listUpdateDTO);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/List/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteList(int id)
        {
            try
            {
                await _listService.DeleteListAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
