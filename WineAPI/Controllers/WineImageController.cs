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
    public class WineImageController : ControllerBase
    {
        private readonly WineContext _context;

        public WineImageController(WineContext context)
        {
            _context = context;
        }

        // GET: api/WineImage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WineImage>>> GetWineImage()
        {
            return await _context.WineImage.ToListAsync();
        }

        // GET: api/WineImage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WineImage>> GetWineImage(int id)
        {
            var wineImage = await _context.WineImage.FindAsync(id);

            if (wineImage == null)
            {
                return NotFound();
            }

            return wineImage;
        }

        // PUT: api/WineImage/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWineImage(int id, WineImage wineImage)
        {
            if (id != wineImage.WineImageId)
            {
                return BadRequest();
            }

            _context.Entry(wineImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WineImageExists(id))
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

        // POST: api/WineImage
        [HttpPost]
        public async Task<ActionResult<WineImage>> PostWineImage(WineImage wineImage)
        {
            _context.WineImage.Add(wineImage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWineImage", new { id = wineImage.WineImageId }, wineImage);
        }

        // DELETE: api/WineImage/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WineImage>> DeleteWineImage(int id)
        {
            var wineImage = await _context.WineImage.FindAsync(id);
            if (wineImage == null)
            {
                return NotFound();
            }

            _context.WineImage.Remove(wineImage);
            await _context.SaveChangesAsync();

            return wineImage;
        }

        private bool WineImageExists(int id)
        {
            return _context.WineImage.Any(e => e.WineImageId == id);
        }
    }
}
