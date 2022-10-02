using InnowisePilotApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InnowisePilotApi.Services.Interfaces
{
    public interface IFridgeProductsService
    {
        public Task<ActionResult<IEnumerable<FridgeProducts>>> GetAllFridgeProducts();
        public FridgeProducts GetFridgeProducstById(int id);
        public Task<FridgeProducts> CreateFridgeProducts(FridgeProducts fridgeProducts);
        public FridgeProducts UpdateFridgeProducts(FridgeProducts fridgeProducts);
        public Task DeleteFridgeProducts(int id);
        public Task<ActionResult<IEnumerable<FridgeProducts>>> GetProductsInFridge(int id);
        public Task UpdateProductsQuantity();
    }
}
