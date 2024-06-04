using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Asp.netMVC.Data;
using Asp.netMVC.Models;

namespace Asp.netMVC.Controllers
{
    public class CrudController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;
        public CrudController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Crud/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testTable = await _context.TestTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testTable == null)
            {
                return NotFound();
            }

            return View(testTable);
        }


        // GET: Crud/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testTable = await _context.TestTable.FindAsync(id);
            if (testTable == null)
            {
                return NotFound();
            }
            return View(testTable);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,WtNum")] TestTable testTable)
        {
        // Log ModelState
        foreach (var modelState in ModelState.Values)
        {
            foreach (var error in modelState.Errors)
            {
                _logger.LogError($"ModelState Error: {error.ErrorMessage}");
            }
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(testTable);
                await _context.SaveChangesAsync();
                return RedirectToAction("Page3", "Home"); // Redirect to Index action of CrudController
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestTableExists(testTable.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        return View(testTable);
    }



        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testTable = await _context.TestTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testTable == null)
            {
                return NotFound();
            }

            return View(testTable);
        }

        // POST: Crud/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testTable = await _context.TestTable.FindAsync(id);
            _context.TestTable.Remove(testTable);
            await _context.SaveChangesAsync();
            return RedirectToAction("Page3", "Home"); // Redirect to Index action of OtherHomeController
        }


        private bool TestTableExists(int id)
        {
            return _context.TestTable.Any(e => e.Id == id);
        }
    }
}
