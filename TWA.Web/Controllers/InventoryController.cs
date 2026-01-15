using Microsoft.AspNetCore.Mvc;
using TWA.Core.Entities;
using TWA.Core.Interfaces;
using System.Threading.Tasks;
using System.Linq;

namespace TWA.Web.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public InventoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _unitOfWork.Repository<InventoryItem>().GetAllAsync();
            return View(items);
        }
    }
}
