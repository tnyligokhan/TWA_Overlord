using Microsoft.AspNetCore.Mvc;
using TWA.Core.Entities;
using TWA.Core.Interfaces;
using TWA.Web.Models;

namespace TWA.Web.Controllers
{
    public class CommandsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommandsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index(string type = "outgoing")
        {
            var model = new CommandsViewModel
            {
                SelectedType = type,
                Commands = new List<CommandItem>() // TODO: Load from database
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Cancel(int id)
        {
            // TODO: Cancel command via GameBrowserService
            TempData["Success"] = "Komut iptal edildi!";
            return RedirectToAction("Index");
        }
    }
}
