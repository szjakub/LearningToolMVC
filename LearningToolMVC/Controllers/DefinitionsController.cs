using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningToolMVC.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
