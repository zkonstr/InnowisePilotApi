using InnowisePilotApi.Data;
using InnowisePilotApi.Models;
using InnowisePilotApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnowisePilotApi.Services.Implementations
{
    public class FridgeService : IFridgeService
    {
        private readonly ApplicationDbContext _context;
        public FridgeService(ApplicationDbContext context) { _context = context; }

        public async Task<ActionResult<IEnumerable<Fridge>>> GetAllFridges()
        {
            return await _context.Fridge.ToListAsync();
        }

        public Fridge GetFridgeById(int id) => _context.Fridge.FirstOrDefault(fridge => fridge.FridgeId == id);

        public async Task<Fridge> CreateFridge(Fridge fridge)
        {
            await _context.AddAsync(fridge);
            await _context.SaveChangesAsync();
            return fridge;
        }

        public Fridge UpdateFridge(Fridge fridge)
        {
            _context.Entry(fridge).State = EntityState.Modified;
            _context.SaveChangesAsync();
            return fridge;
        }

        public async Task DeleteFridge(int id)
        {
            var toDelete = _context.Fridge.FirstOrDefault(fridge => fridge.FridgeId == id);
            if (toDelete != null)
            {
                _context.Fridge.Remove(toDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
