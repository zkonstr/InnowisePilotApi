using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InnowisePilotApi.Data;
using InnowisePilotApi.Models;

namespace InnowisePilotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FridgeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FridgeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Fridge
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fridge>>> GetFridge()
        {
            return await _context.Fridge.ToListAsync();
        }

        // GET: api/Fridge/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Fridge>> GetFridge(int id)
        {
            var fridge = await _context.Fridge.FindAsync(id);

            if (fridge == null)
            {
                return NotFound();
            }

            return fridge;
        }

        // PUT: api/Fridge/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFridge(int id, Fridge fridge)
        {
            if (id != fridge.FridgeId)
            {
                return BadRequest();
            }

            _context.Entry(fridge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FridgeExists(id))
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

        // POST: api/Fridge
        [HttpPost]
        public async Task<ActionResult<Fridge>> PostFridge(Fridge fridge)
        {
            _context.Fridge.Add(fridge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFridge", new { id = fridge.FridgeId }, fridge);
        }

        // DELETE: api/Fridge/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFridge(int id)
        {
            var fridge = await _context.Fridge.FindAsync(id);
            if (fridge == null)
            {
                return NotFound();
            }

            _context.Fridge.Remove(fridge);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FridgeExists(int id)
        {
            return _context.Fridge.Any(e => e.FridgeId == id);
        }
    }
}
