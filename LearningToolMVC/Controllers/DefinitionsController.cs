using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningToolMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningToolMVC.Controllers
{
    public class DefinitionsController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public DefinitionModel Definition { get; set; }

        public DefinitionsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Definition = new DefinitionModel();
            if (id == null)
            {
                return View(Definition);
            }
            Definition = _db.Definitions.FirstOrDefault(u => u.Id == id);
            if (id == null)
            {
                return NotFound();
            }
            return View(Definition);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(DefinitionModel definition)
        {
            if (ModelState.IsValid)
            {
                if (Definition.Id == 0)
                {
                    _db.Definitions.Add(Definition);
                }
                else
                {
                    _db.Definitions.Update(Definition);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Definition);
        }

        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Definitions.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var defFromDb = await _db.Definitions.FirstOrDefaultAsync(u => u.Id == id);
            if (defFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Definitions.Remove(defFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successfull" });
        }
        #endregion
    }
}
