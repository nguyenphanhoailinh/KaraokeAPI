using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testAPI.Data;
using testAPI.Models;

namespace testAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly MyDbContext _context;
        public MenuController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Menu>>> GetAll()
        {
            var menu = await _context.Menu.ToListAsync();
            return menu;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var menu = _context.Menu.SingleOrDefault(x => x.Id == id);
                return Ok(menu);
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<ActionResult<KaraokeRoom>> PostKaraokeItem(Menu menu)
        {
            _context.Menu.Add(menu);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = menu.Id }, menu);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatekaraokeById(int id, Menu menus)
        {
            var menu = _context.Menu.SingleOrDefault(k => k.Id == id);
            if (menu != null)
            {
                menu.Name = menus.Name;
                menu.Price = menus.Price;
                menu.MenuID = menus.MenuID;

                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {

            var menu = _context.Menu.SingleOrDefault(k => k.Id == id);
            if (menu != null)
            {
                _context.Remove(menu);
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
