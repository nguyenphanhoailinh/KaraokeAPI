using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testAPI.Data;
using testAPI.Models;

namespace testAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MyDbContext _context;
        public UsersController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Users>>> GetAll()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var users = _context.Users.SingleOrDefault(x => x.Id == id);
                return Ok(users);
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<ActionResult<KaraokeRoom>> PostKaraokeItem(Users users)
        {
            _context.Users.Add(users);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = users.Id }, users);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatekaraokeById(int id, Users usersm)
        {
            var users = _context.Users.SingleOrDefault(k => k.Id == id);
            if (users != null)
            {
                users.UserName = usersm.UserName;
                users.Password = usersm.Password;
                users.Permission = usersm.Permission;
                
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

            var users = _context.Users.SingleOrDefault(k => k.Id == id);
            if (users != null)
            {
                _context.Remove(users);
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
