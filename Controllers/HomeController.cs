using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Asp.netMVC.Models;
using Asp.netMVC.Data;
using System.Threading.Tasks;
using System.Linq;

namespace Asp.netMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Page1()
        {
            return View();
        }

        public IActionResult Page2()
        {
            return View();
        }

        public async Task<IActionResult> Page3()
        {
            var testTables = await _context.GetAllTestTables();
            return View(testTables);
        }

        public IActionResult Page4()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Page4(TestTable model)
        {
            if (ModelState.IsValid)
            {
                await _context.InsertTestTable(model);
                return RedirectToAction(nameof(Page3));
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
