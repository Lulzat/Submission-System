using MarkelApp.Data;
using MarkelApp.Models;
using MarkelApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkelApp.Controllers
{
    // Class SubmissionController : Inherits from Controller
    public class SubmissionController : Controller
    {
        // DEPENDENCY INJECTION TO BRING IN ApplicationDbContext
        private readonly ApplicationDbContext _db;

        public SubmissionController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET LIST OF SUBMISSIONS
        public IActionResult Index()
        {
            IEnumerable<Submission> objList = _db.Submissions;
            return View(objList);
        }

        // GET CREATE SUBMISSION VIEW
        public IActionResult Create()
        {
            return View();
        }

        // POST CREATE SUBMISSION
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Submission obj)
        {
            _db.Submissions.Add(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET SUBMISSION DETAILS
        public IActionResult Details(int Id)
        {
            IEnumerable<Analysis> analyses = from r in _db.Analysis where r.SubmissionId == Id select r;
            IEnumerable<Submission> submission = from r in _db.Submissions where r.SubmissionId == Id select r;
            
            var SubmissionDetails = new SubmissionDetailsViewModel
            {
                Analyses = analyses,
                Submissions = submission
            };
            return View(SubmissionDetails);
        }
    }
}
