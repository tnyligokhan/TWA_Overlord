using Microsoft.AspNetCore.Mvc;
using TWA.Core.Entities;
using TWA.Core.Interfaces;
using TWA.Web.Models;

namespace TWA.Web.Controllers
{
    public class CommandsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly TWA.Core.Interfaces.Services.IGameBrowserService _browserService;

        public CommandsController(IUnitOfWork unitOfWork, TWA.Core.Interfaces.Services.IGameBrowserService browserService)
        {
            _unitOfWork = unitOfWork;
            _browserService = browserService;
        }

        public async Task<IActionResult> Index(string type = "outgoing")
        {
            var allCommands = await _unitOfWork.Repository<Command>().GetAllAsync();
            var filteredCommands = new List<Command>();

            if (type == "incoming")
            {
                filteredCommands = allCommands.Where(c => c.IsIncoming).ToList();
            }
            else
            {
                filteredCommands = allCommands.Where(c => !c.IsIncoming).ToList();
            }

            var commandItems = filteredCommands.Select(c => new CommandItem
            {
                Id = c.Id,
                Type = c.Type.ToString(),
                OriginVillage = c.OriginVillageName,
                TargetVillage = c.TargetVillageName,
                ArrivalTime = c.ArrivalTime,
                Icon = c.IconName,
                ColorClass = GetColorClass(c.Type, c.IsIncoming)
            }).OrderBy(c => c.ArrivalTime).ToList();

            var model = new CommandsViewModel
            {
                SelectedType = type,
                Commands = commandItems,
                TotalCount = commandItems.Count
            };

            return View(model);
        }

        private string GetColorClass(CommandType type, bool isIncoming)
        {
            if (isIncoming && type == CommandType.Attack) return "text-danger";
            if (type == CommandType.Attack) return "text-warning"; // Outgoing attack usually different
            if (type == CommandType.Support) return "text-info";
            return "";
        }

        [HttpPost]
        public async Task<IActionResult> Cancel(int id)
        {
            // Real implementation would use _browserService to navigate to command page and click cancel
            // For now we simulate success or remove from DB if we want to "hide" it
            // var command = await _unitOfWork.Repository<Command>().GetByIdAsync(id);
            // if (command != null) { ... logic to cancel in game ... }
            
            TempData["Success"] = "Komut iptal simülasyonu başarılı! (Gerçek iptal henüz aktif değil)";
            return RedirectToAction("Index");
        }
    }
}
