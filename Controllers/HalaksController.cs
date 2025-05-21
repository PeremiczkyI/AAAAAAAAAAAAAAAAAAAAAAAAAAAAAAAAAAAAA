using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HalakAPI.Models;

namespace HalakAPI.Controllers
{
    [Route("Halak")]
    [ApiController]
    public class HalaksController : ControllerBase
    {
        private readonly HalakContext _context;

        public HalaksController(HalakContext context)
        {
            _context = context;
        }

        [HttpGet("FajMeretTo")]
        public async Task<ActionResult<IEnumerable<HalakDto>>> GetHalakAdatok()
        {
            var halak = await _context.Halaks
                .Select(h => new HalakDto
                {
                    Faj = h.Faj,
                    MeretCm = h.MeretCm,
                    ToNeve = h.To != null ? h.To.Nev : null
                })
                .ToListAsync();

            if (halak != null)
            {
                return StatusCode(200, halak);
            }

            return StatusCode(400);
        }

        [HttpPut]
        public async Task<IActionResult> PutHalak(int id, Halak halak)
        {
            if (id != halak.Id)
            {
                return StatusCode(400);
            }

            _context.Entry(halak).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HalakExists(id))
                {
                    return StatusCode(200);
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(404, new { message = "Nincs ilyen azonosítójú hal!" });
        }

        // POST: api/Halaks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Halak>> PostHalak(Halak halak)
        {
            _context.Halaks.Add(halak);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHalak", new { id = halak.Id }, halak);
        }

        // DELETE: api/Halaks/5
        [HttpDelete]
        public async Task<IActionResult> DeleteHalak(int id)
        {
            var halak = await _context.Halaks.FindAsync(id);
            if (halak == null)
            {
                return NotFound();
            }

            _context.Halaks.Remove(halak);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HalakExists(int id)
        {
            return _context.Halaks.Any(e => e.Id == id);
        }
    }
}
