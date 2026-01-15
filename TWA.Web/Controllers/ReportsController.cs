using Microsoft.AspNetCore.Mvc;
using TWA.Core.Entities;
using TWA.Core.Interfaces;
using TWA.Web.Models;

namespace TWA.Web.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index(string category = "all")
        {
            var model = new ReportsViewModel
            {
                SelectedCategory = category,
                Reports = new List<ReportItem>() // TODO: Load from database
            };

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            // TODO: Load report details from database
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            // TODO: Delete report
            TempData["Success"] = "Rapor silindi!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAll(string category)
        {
            // TODO: Delete all reports in category
            TempData["Success"] = $"{category} kategorisindeki tüm raporlar silindi!";
            return RedirectToAction("Index", new { category });
        }
    }
}
