using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WineAPI.Models;

namespace WineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WineMakerController : ControllerBase
    {
        private readonly WineContext _context;

        public WineMakerController(WineContext context)
        {
            _context = context;
        }

        // GET: api/WineMaker
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WineMaker>>> GetWineMaker()
        {
            return await _context.WineMaker
                .Include(wineMaker => wineMaker.WineBottles)
                .ToListAsync();
        }

        // GET: api/WineMaker/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WineMaker>> GetWineMaker(int id)
        {
            var wineMaker = await _context.WineMaker.FindAsync(id);

            if (wineMaker == null)
            {
                return NotFound();
            }

            return wineMaker;
        }

        // PUT: api/WineMaker/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWineMaker(int id, WineMaker wineMaker)
        {
            if (id != wineMaker.WineMakerId)
            {
                return BadRequest();
            }

            _context.Entry(wineMaker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WineMakerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/WineMaker
        [HttpPost]
        public async Task<ActionResult<WineMaker>> PostWineMaker(WineMaker wineMaker)
        {
            _context.WineMaker.Add(wineMaker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWineMaker", new { id = wineMaker.WineMakerId }, wineMaker);
        }

        // DELETE: api/WineMaker/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WineMaker>> DeleteWineMaker(int id)
        {
            var wineMaker = await _context.WineMaker.FindAsync(id);
            if (wineMaker == null)
            {
                return NotFound();
            }

            _context.WineMaker.Remove(wineMaker);
            await _context.SaveChangesAsync();

            return wineMaker;
        }

        private bool WineMakerExists(int id)
        {
            return _context.WineMaker.Any(e => e.WineMakerId == id);
        }
    }
}
