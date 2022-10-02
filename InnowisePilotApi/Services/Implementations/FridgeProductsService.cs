using InnowisePilotApi.Data;
using InnowisePilotApi.Models;
using InnowisePilotApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnowisePilotApi.Services.Implementations
{
    public class FridgeProductsService : IFridgeProductsService
    {
        private readonly ApplicationDbContext _context;
        public FridgeProductsService(ApplicationDbContext context) { _context = context; }

        public async Task<FridgeProducts> CreateFridgeProducts(FridgeProducts fridgeProducts)
        {
            await _context.AddAsync(fridgeProducts);
            await _context.SaveChangesAsync();
            return fridgeProducts; 
        }

        public async Task DeleteFridgeProducts(int id)
        {
            var toDelete = _context.FridgeProducts.FirstOrDefault(fridgeProduct => fridgeProduct.Id == id);
            if (toDelete != null)
            {
                _context.FridgeProducts.Remove(toDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ActionResult<IEnumerable<FridgeProducts>>> GetAllFridgeProducts()
        {
            return await _context.FridgeProducts.ToListAsync();
        }

        public FridgeProducts GetFridgeProducstById(int id) => _context.FridgeProducts.FirstOrDefault(fridgeProducts => 
        fridgeProducts.Id == id);

        public async Task<ActionResult<IEnumerable<FridgeProducts>>> GetProductsInFridge(int id)
        {
            var products = await _context.FridgeProducts.ToListAsync();
            var productsInFridge = products.Where(products => products.FridgeID == id).ToList();
            return productsInFridge;
        }

        public FridgeProducts UpdateFridgeProducts(FridgeProducts fridgeProducts)
        {
            _context.Entry(fridgeProducts).State = EntityState.Modified;
            _context.SaveChangesAsync();
            return fridgeProducts;
        }

        public async Task UpdateProductsQuantity()
        {
            var productsToRefill = _context.FridgeProducts.FromSqlRaw("sp_check_quantity").ToListAsync();

            foreach(var product in await productsToRefill)
            {
                var p = _context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
                _context.Entry(product).State = EntityState.Modified;
                product.Quantity = p.DefaultQuantity;
                await _context.SaveChangesAsync();
            }

            await _context.SaveChangesAsync();
        } //add smth to print if OK 
    }
}
