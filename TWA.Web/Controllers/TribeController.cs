using Microsoft.AspNetCore.Mvc;
using TWA.Web.Models;

namespace TWA.Web.Controllers
{
    public class TribeController : Controller
    {
        public IActionResult Index()
        {
            var model = new TribeViewModel
            {
                TribeName = "Kabile Adı",
                TribeTag = "TAG",
                MemberCount = 0,
                TotalPoints = 0,
                Rank = 0
            };

            return View(model);
        }

        public IActionResult Members()
        {
            var model = new TribeMembersViewModel
            {
                Members = new List<TribeMember>() // TODO: Load from game
            };

            return View(model);
        }
    }
}
