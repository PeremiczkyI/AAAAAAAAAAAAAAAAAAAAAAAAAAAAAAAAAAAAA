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
    [Route("Horgaszok")]
    [ApiController]
    public class HorgaszoksController : ControllerBase
    {
        private readonly HalakContext _context;

        public HorgaszoksController(HalakContext context)
        {
            _context = context;
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<Horgaszok>>> GetHorgaszoks()
        {
            var horgaszok = await _context.Horgaszoks.ToListAsync();

            if (horgaszok != null)
            {
                return StatusCode(200, horgaszok);
            }

            return StatusCode(400);
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<Horgaszok>> GetHorgaszok(int id)
        {
            try
            {
                var horgaszok = await _context.Horgaszoks.FindAsync(id);

                if (horgaszok != null)
                {
                    return StatusCode(200, horgaszok);
                }

                return StatusCode(400);
            }
            catch (Exception e)
            {

                return StatusCode(404, new { message = "Nincs ilyen azonosítójú horgász!" });
            }
        }
    }
}
