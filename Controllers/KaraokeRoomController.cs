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
        public async Task<ActionResult<KaraokeRoom>> PostKaraokeItem(KaraokeRoom karaokeroom)
        {
            _context.karaokeRoom.Add(karaokeroom);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = karaokeroom.Id }, karaokeroom);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatekaraokeById(int id, KaraokeRoom karaokeroomModels)
        {
           var  karaokerooms =_context.karaokeRoom.SingleOrDefault(k => k.Id == id);
            if(karaokerooms != null)
            {
                karaokerooms.TenQuan=karaokeroomModels.TenQuan;
                karaokerooms.DiaChi = karaokeroomModels.DiaChi;
                karaokerooms.Img=karaokeroomModels.Img;
                karaokerooms.SucChua = karaokeroomModels.SucChua;
                karaokerooms.MoTa=karaokeroomModels.MoTa;
                _context.SaveChanges();
                return NoContent();
            }else
            {
                return NotFound();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            
                var karaokerooms = _context.karaokeRoom.SingleOrDefault(k => k.Id == id);
            if (karaokerooms != null)
            {
                _context.Remove(karaokerooms);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return NotFound();
            }

        }
    }
}
