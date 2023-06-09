using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testAPI.Data;
using testAPI.Models;

namespace testAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly MyDbContext _context;
        public CustomerController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAll()
        {
            var customers = await _context.customer.ToListAsync();
            return customers;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var customers = _context.customer.SingleOrDefault(c => c.Id == id);
                return Ok(customers);
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<ActionResult<Customer>> PostKaraokeItem(Customer customerModels)
        {
            _context.customer.Add(customerModels);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = customerModels.Id }, customerModels);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomerById(int id, Customer customerModels)
        {
            var customers = _context.customer.SingleOrDefault(c => c.Id == id);
            if (customers != null)
            {
                
                customers.FullName = customerModels.FullName;
                customers.phonenumber = customerModels.phonenumber;
                customers.email = customerModels.email;
                customers.acount = customerModels.acount;
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

            var customers = _context.customer.SingleOrDefault(c => c.Id == id);
            if (customers != null)
            {
                _context.Remove(customers);
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
