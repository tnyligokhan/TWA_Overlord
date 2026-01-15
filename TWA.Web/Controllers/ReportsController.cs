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
            var reports = (await _unitOfWork.Repository<Report>().GetAllAsync())
                          .OrderByDescending(r => r.Date)
                          .ToList();

            // Filter by category if we had 'Category' property on Report entity.
            // For now, returning all.

            var reportItems = reports.Select(r => new ReportItem
            {
                Id = r.Id,
                Title = r.Subject,
                ReceivedAt = r.Date,
                IsRead = !r.IsUnread,
                Icon = r.StatusIcon, // Correct property
                // Use icon name to guess category or color
                ColorClass = r.IsUnread ? "fw-bold" : ""
            }).ToList();

            var model = new ReportsViewModel
            {
                SelectedCategory = category,
                Reports = reportItems,
                TotalCount = reportItems.Count,
                UnreadCount = reportItems.Count(r => !r.IsRead)
            };

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var report = await _unitOfWork.Repository<Report>().GetByIdAsync(id);
            if (report == null) return NotFound();
            
            // Mark as read
            if (report.IsUnread)
            {
                report.IsUnread = false;
                _unitOfWork.Repository<Report>().Update(report);
                await _unitOfWork.CommitAsync();
            }

            return View(report);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var report = await _unitOfWork.Repository<Report>().GetByIdAsync(id);
            if (report != null)
            {
                _unitOfWork.Repository<Report>().Remove(report);
                await _unitOfWork.CommitAsync();
                TempData["Success"] = "Rapor silindi!";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAll(string category)
        {
            var allReports = await _unitOfWork.Repository<Report>().GetAllAsync();
            // Simple filtering logic based on category string if we had a robust mapping. 
            // For now, if "all", delete all. Else try to match ReportType if populated.
            
            IEnumerable<Report> toDelete;
            if (category == "all" || string.IsNullOrEmpty(category))
            {
                toDelete = allReports;
            }
            else
            {
                // Try to match category (e.g. "attack" matches ReportType containing "attack" or similar)
                toDelete = allReports.Where(r => r.ReportType != null && r.ReportType.Contains(category, StringComparison.OrdinalIgnoreCase));
            }

            foreach (var r in toDelete)
            {
                _unitOfWork.Repository<Report>().Remove(r);
            }
            
            await _unitOfWork.CommitAsync();
            
            TempData["Success"] = $"{category} kategorisindeki raporlar silindi!";
            return RedirectToAction("Index", new { category });
        }
    }
}
