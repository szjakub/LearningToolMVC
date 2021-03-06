﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningToolMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningToolMVC.Controllers
{
    public class AttemptsController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public AttemptModel Attempt { get; set; }
 
        public DefinitionModel Definition { get; set; }

        public AttemptsController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Attempt = new AttemptModel();
            List<DefinitionModel> Definitions = _db.Definitions.ToList();
            Random random = new Random();
            int randomIndex = random.Next(Definitions.Count);
            DefinitionModel definition = Definitions[randomIndex];
            Attempt.Definition = definition;

            return View(Attempt);
        }


        [HttpPost]
        public IActionResult Index(AttemptModel att)
        {
            Attempt = new AttemptModel();
           
                var definition = _db.Definitions
                    .FirstOrDefault(u => u.Id == att.Definition.Id);
                Attempt.Definition = definition;
                Attempt.DefinitionId = definition.Id;
                Attempt.Attempt = att.Attempt;
                if (definition.Meaning == att.Attempt) 
                {
                    Attempt.IsCorrect = true; 
                }
                else 
                { 
                    Attempt.IsCorrect = false; 
                }
                _db.Attempts.Add(Attempt);
                _db.SaveChanges();
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = new List<Dictionary<string, string>>();
            var attempts = await _db.Attempts.ToListAsync();

            foreach(var attempt in attempts)
            {
                var definition = await _db.Definitions
                    .FirstOrDefaultAsync(u => u.Id == attempt.DefinitionId);
                var row = new Dictionary<string, string>();
                row.Add("id", attempt.Id.ToString());
                row.Add("attempt", attempt.Attempt);
                row.Add("isCorrect", attempt.IsCorrect.ToString());
                row.Add("sentence", definition.Sentence);
                row.Add("meaning", definition.Meaning);
                result.Add(row);
            }
            return Json(new { data = result });
        }
        /*
        [HttpGet]
        public async Task<IActionResult> GetStatistics()
        {
            var stats = await _db.Attempts
                .FromSqlRaw(@"
                    SELECT COUNT(*) as count, IsCorrect, Sentence, Meaning    
                    FROM Attempts
                    LEFT JOIN Definitions ON DefinitionId = Definitions.Id
                    GROUP BY IsCorrect, Sentence, Meaning"
                ).ToListAsync();


            return Json(new { data = stats });
        }
        */
    }
}
