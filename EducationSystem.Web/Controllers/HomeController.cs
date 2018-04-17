using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EducationSystem.Web.Models;
using EducationSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EducationSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly EducationSystemContext _context;

        public HomeController(EducationSystemContext context)
        {
            _context = context;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            ViewBag.AllPrograms = _context.Program.ToArray();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List(Int32 _program_id)
        {
            if (!_context.Program.Any(c => c.ProgramId == _program_id))
                return NotFound();

            var course = _context.Course.Include(x => x.Subject).ThenInclude(x => x.Program).Where(p => p.Subject.ProgramId == _program_id).OrderBy(c => c.CourseCode);
            return View("Index", course);
        }
        public IActionResult About()
        {
            //var subject_select = _context.Subject; // igy csak egy lekérdezés
            var subject = _context.Subject.Include(p => p.Program).ToList(); // igy csak egy lekérdezés

            var first = subject.FirstOrDefault(); //LINQ
            return View(subject);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
