using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InnowisePilotApi.Data;
using InnowisePilotApi.Models;
using InnowisePilotApi.Services.Implementations;
using InnowisePilotApi.Services.Interfaces;

namespace InnowisePilotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FridgeProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IFridgeProductsService FridgeProductsService { get; set; }

        public FridgeProductsController(ApplicationDbContext context, IFridgeProductsService fridgeProductsService)
        {
            FridgeProductsService = fridgeProductsService;
            _context = context;
        }
        
        // GET: api/FridgeProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FridgeProducts>>> GetFridgeProducts()
        {
            var products = FridgeProductsService.GetAllFridgeProducts();
            return await products;
        }

        // GET: api/FridgeProducts/id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Fridge), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var result = FridgeProductsService.GetFridgeProducstById(id);
            return result == null ? NotFound() : Ok(result);
        }
        [HttpGet("{id}/check-products")]
        [ProducesResponseType(typeof(Fridge), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<FridgeProducts>>> GetProductsInFridge(int id)
        {
            var result = await FridgeProductsService.GetProductsInFridge(id);
            return result == null ? NotFound() : Ok(result);
        }

        // PUT: api/FridgeProducts/id
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreateFridgeProducts(FridgeProducts fridgeProducts)
        {
            FridgeProductsService.CreateFridgeProducts(fridgeProducts);
            return CreatedAtAction(nameof(GetById), new { id = fridgeProducts.Id}, fridgeProducts);
        }

        // POST: api/FridgeProducts
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult UpdateFridgeProducts(int id, FridgeProducts fridgeProducts)
        {
            if (id != fridgeProducts.Id ) return BadRequest();
            FridgeProductsService.UpdateFridgeProducts(fridgeProducts);
            return NoContent();
        }
        [HttpPatch]
        public async Task UpdateProductQuantity()
        {
            await FridgeProductsService.UpdateProductsQuantity();
        }

        // DELETE: api/FridgeProducts/id
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteFridgeProducts(int id)
        {
            var fridgeProductsToDelete = await _context.FridgeProducts.FindAsync(id);
            if (fridgeProductsToDelete == null) return NotFound();
            await FridgeProductsService.DeleteFridgeProducts(id);
            return NoContent();
        }

        private bool FridgeProductsExists(int id)
        {
            return _context.FridgeProducts.Any(e => e.Id == id);
        }
    }
}
