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
    public class FridgeModelController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FridgeModelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FridgeModel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FridgeModel>>> GetFridgeModels()
        {
            return await _context.FridgeModels.ToListAsync();
        }

        // GET: api/FridgeModel/id
        [HttpGet("{id}")]
        public async Task<ActionResult<FridgeModel>> GetFridgeModel(int id)
        {
            var fridgeModel = await _context.FridgeModels.FindAsync(id);

            if (fridgeModel == null)
            {
                return NotFound();
            }

            return fridgeModel;
        }

        // PUT: api/FridgeModel/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFridgeModel(int id, FridgeModel fridgeModel)
        {
            if (id != fridgeModel.FridgeModelId)
            {
                return BadRequest();
            }

            _context.Entry(fridgeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FridgeModelExists(id))
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

        // POST: api/FridgeModel
        [HttpPost]
        public async Task<ActionResult<FridgeModel>> PostFridgeModel(FridgeModel fridgeModel)
        {
            _context.FridgeModels.Add(fridgeModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFridgeModel", new { id = fridgeModel.FridgeModelId }, fridgeModel);
        }

        // DELETE: api/FridgeModel/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFridgeModel(int id)
        {
            var fridgeModel = await _context.FridgeModels.FindAsync(id);
            if (fridgeModel == null)
            {
                return NotFound();
            }

            _context.FridgeModels.Remove(fridgeModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FridgeModelExists(int id)
        {
            return _context.FridgeModels.Any(e => e.FridgeModelId == id);
        }
    }
}
