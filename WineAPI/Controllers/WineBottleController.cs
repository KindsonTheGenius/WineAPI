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
    public class WineBottleController : ControllerBase
    {
        private readonly WineContext _context;

        public WineBottleController(WineContext context)
        {
            _context = context;
        }

        // *********** GET ALL WINEBOTTLES - /api/winebottle *******************
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WineBottle>>> GetWineBottle()
        {
            return await _context.WineBottle.ToListAsync();
        }

        // ***********  GET WINEBOTTLE BY ID - /api/winebottle/id *********** 
        [HttpGet("{id}")]
        public async Task<ActionResult<WineBottle>> GetWineBottle(int id)
        {
            var wineBottle = await _context.WineBottle.FindAsync(id);

            if (wineBottle == null)
            {
                return NotFound();
            }
            return wineBottle;
        }

        // *********** FILTER  BY WINEMAKER - /api/winebottle/winemaker/1 *********** 
        [HttpGet("winemaker/{id}")]
        public async Task<ActionResult<IEnumerable<WineBottle>>> GetWineBottlesByWineMaker(int id)
        {
            var wineBottles = await _context.WineBottle.Where(x => x.WineMakerId == id).ToListAsync();

            if (wineBottles == null)
            {
                return NotFound();
            }
            return wineBottles;
        }

        // *********** FILTER  BY YEAR - /api/bottles/2021 *********** 
        [HttpGet("{year}")]
        public async Task<ActionResult<IEnumerable<WineBottle>>> GetWineBottlesByYear(int year)
        {
            var wineBottles = await _context.WineBottle.Where(x => x.Year == year).ToListAsync();

            if (wineBottles == null)
            {
                return NotFound();
            }
            return wineBottles;
        }

        // *********** FILTER  BY YEAR RANGE - /api/winebottle/?startyear=2021&&endyear=2022 *********** 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WineBottle>>> GetWineBottlesByYearRange(int startyear, int endyear)
        {
            var wineBottles = await _context.WineBottle.Where(x => x.Year >= startyear && x.Year >= endyear).ToListAsync();

            if (wineBottles == null)
            {
                return NotFound();
            }
            return wineBottles;
        }


        // ***********  UPDATE WINEBOTTLE /api/winebottle/id *********** 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWineBottle(int id, WineBottle wineBottle)
        {
            if (id != wineBottle.WineBottleId)
            {
                return BadRequest();
            }

            _context.Entry(wineBottle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WineBottleExists(id))
                {
                    return NotFound();
                }
                else {
                    throw;
                }
            }
            return NoContent();
        }

        // ***********  INSERT WINEBOTTLE - /api/winebottle *********** 
        [HttpPost]
        public async Task<ActionResult<WineBottle>> PostWineBottle(WineBottle wineBottle)
        {
            _context.WineBottle.Add(wineBottle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWineBottle", new { id = wineBottle.WineBottleId }, wineBottle);
        }

        // ***********  DELETE WINEBOTTLE - /api/winebottle/1 *********** 
        [HttpDelete("{id}")]
        public async Task<ActionResult<WineBottle>> DeleteWineBottle(int id)
        {
            var wineBottle = await _context.WineBottle.FindAsync(id);
            if (wineBottle == null)
            {
                return NotFound();
            }
            _context.WineBottle.Remove(wineBottle);
            await _context.SaveChangesAsync();

            return wineBottle;
        }

        // ***********  CHECK IF WINEBOTTLE EXISTS *********** 
        private bool WineBottleExists(int id)
        {
            return _context.WineBottle.Any(e => e.WineBottleId == id);
        }

    }
}
