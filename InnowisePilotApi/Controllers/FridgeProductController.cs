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
    public class FridgeProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FridgeProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FridgeProduct
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FridgeProducts>>> GetFridgeProducts()
        {
            return await _context.FridgeProducts.ToListAsync();
        }

        // GET: api/FridgeProduct/id
        [HttpGet("{id}")]
        public async Task<ActionResult<FridgeProducts>> GetFridgeProducts(int id)
        {
            var fridgeProducts = await _context.FridgeProducts.FindAsync(id);

            if (fridgeProducts == null)
            {
                return NotFound();
            }

            return fridgeProducts;
        }

        // PUT: api/FridgeProduct/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFridgeProducts(int id, FridgeProducts fridgeProducts)
        {
            if (id != fridgeProducts.Id)
            {
                return BadRequest();
            }

            _context.Entry(fridgeProducts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FridgeProductsExists(id))
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

        // POST: api/FridgeProduct
        [HttpPost]
        public async Task<ActionResult<FridgeProducts>> PostFridgeProducts(FridgeProducts fridgeProducts)
        {
            _context.FridgeProducts.Add(fridgeProducts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFridgeProducts", new { id = fridgeProducts.Id }, fridgeProducts);
        }

        // DELETE: api/FridgeProduct/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFridgeProducts(int id)
        {
            var fridgeProducts = await _context.FridgeProducts.FindAsync(id);
            if (fridgeProducts == null)
            {
                return NotFound();
            }

            _context.FridgeProducts.Remove(fridgeProducts);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FridgeProductsExists(int id)
        {
            return _context.FridgeProducts.Any(e => e.Id == id);
        }
    }
}
