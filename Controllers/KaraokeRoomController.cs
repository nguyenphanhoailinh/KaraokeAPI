using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testAPI.Data;
using testAPI.Models;

namespace testAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KaraokeRoomController : ControllerBase
    {
        private readonly MyDbContext _context;
        public KaraokeRoomController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<KaraokeRoom>>> GetAll()
        {
            var karaokerooms = await _context.karaokeRoom.ToListAsync();
            return karaokerooms;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {   
            try
            {
                var karaokerooms = _context.karaokeRoom.SingleOrDefault(x => x.Id == id);
                return Ok(karaokerooms);
            }
            catch
            {
                return NotFound();
            }   
        }
        [HttpPost]
        public async Task<ActionResult<KaraokeRoom>> PostTodoItem(KaraokeRoom karaokeroom)
        {
            _context.karaokeRoom.Add(karaokeroom);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = karaokeroom.Id }, karaokeroom);
        }
    }
}
