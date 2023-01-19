using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VisitsCounter.Interfaces;
using VisitsCounter.Models;

namespace VisitsCounter.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVisitor _visitors;

        public HomeController(IVisitor visitors)
        {
            _visitors = visitors;
        }
        public async Task<IActionResult> GetStatistics()
        {
            var today = DateTime.Today;
            var statistic = await _visitors.GetStatisticsByDate(today, today);
            return View(statistic);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}