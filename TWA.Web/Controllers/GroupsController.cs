using Microsoft.AspNetCore.Mvc;
using TWA.Core.Entities;
using TWA.Core.Interfaces;
using TWA.Web.Models;

namespace TWA.Web.Controllers
{
    public class GroupsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public GroupsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var model = new GroupsViewModel
            {
                Groups = new List<VillageGroup>() // TODO: Load from database
            };

            return View(model);
        }

        public IActionResult Create()
        {
            return View(new VillageGroup());
        }

        [HttpPost]
        public async Task<IActionResult> Create(VillageGroup group)
        {
            // TODO: Save to database
            TempData["Success"] = "Grup oluşturuldu!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            // TODO: Load from database
            return View(new VillageGroup { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(VillageGroup group)
        {
            // TODO: Update in database
            TempData["Success"] = "Grup güncellendi!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            // TODO: Delete from database
            TempData["Success"] = "Grup silindi!";
            return RedirectToAction("Index");
        }
    }
}
