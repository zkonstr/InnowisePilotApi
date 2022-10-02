using InnowisePilotApi.Models;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using InnowisePilotApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePilotApi.Services.Interfaces
{
    public interface IFridgeService
    {
        public Task<ActionResult<IEnumerable<Fridge>>> GetAllFridges();
        public Fridge GetFridgeById(int id);
        public Task<Fridge> CreateFridge(Fridge fridge);
        public Fridge UpdateFridge(Fridge fridge);
        public Task DeleteFridge(int id);
    }
}
