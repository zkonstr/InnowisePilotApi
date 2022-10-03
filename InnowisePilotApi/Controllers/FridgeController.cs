using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InnowisePilotApi.Data;
using InnowisePilotApi.Models;
using InnowisePilotApi.Services.Interfaces;

namespace InnowisePilotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FridgeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IFridgeService FridgeService { get; set; }

        public FridgeController(ApplicationDbContext context, IFridgeService fridgeService)
        {
            FridgeService = fridgeService;
            _context = context;
        }

        // GET: api/Fridge
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fridge>>> GetFridge() => await FridgeService.GetAllFridges();

        // GET: api/Fridge/id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Fridge), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var result = FridgeService.GetFridgeById(id);
            return result == null ? NotFound() : Ok(result);
        }

        // PUT: api/Fridge/id
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreateFridge(Fridge fridge)
        {
            FridgeService.CreateFridge(fridge);
            return CreatedAtAction(nameof(GetById), new { id = fridge.FridgeId}, fridge);
        }
        //POST: api/Fridge/id
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult UpdateFridge(int id, Fridge fridge)
        {
            if (id != fridge.FridgeId) return BadRequest();
            FridgeService.UpdateFridge(fridge);
            return NoContent();
        }

        // DELETE: api/Fridge/id
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteFridge(int id)
        {
            var fridgeToDelete = await _context.Fridge.FindAsync(id);
            if (fridgeToDelete == null) return NotFound();
            await FridgeService.DeleteFridge(id);
            return NoContent();
        }
    }
}
