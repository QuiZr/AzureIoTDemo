using AzureIoTDemo.Data;
using AzureIoTDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AzureIoTDemo.Controllers
{
    [Route("api/[controller]")]
    public class TemperatureController : Controller
    {
        private TemperatureContext _context;
        public TemperatureController(TemperatureContext context)
        {
            _context = context;
        }

        // GET api/temperature
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tempReads = await _context
                .TemperatureReads
                .ToListAsync();

            if (tempReads.Count == 0)
                return NoContent();

            return Ok(tempReads);
        }

        // GET api/temperature/{id}
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var tempRead = await _context
                .TemperatureReads
                .FirstOrDefaultAsync(item => item.ID == id);

            if (tempRead == null)
                return NotFound();

            return Ok(tempRead);
        }

        // POST api/temperature
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TemperatureRead tempRead)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            // Because binding doesn't seem to work.
            tempRead.ID = 0;
            // Because NTP is hard.
            tempRead.Date = DateTime.Now;

            _context.Add(tempRead);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE /api/temperature/{id}
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tempRead = await _context.TemperatureReads.FirstOrDefaultAsync(t => t.ID == id);

            if (tempRead == null)
                return BadRequest();

            _context
                .TemperatureReads
                .Remove(tempRead);

            await _context
                .SaveChangesAsync();

            return Ok();
        }
    }
}
