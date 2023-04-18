using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Models;

namespace Test.Controllers
{
    public class StudentsController : Controller
    {
        private readonly TestDbContext _context;
        public StudentsController(TestDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var students = _context.Students.Include("Group");
            return View(students);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var groupList = _context.Groups.Select(g => new SelectListItem
            {
                Value = g.Id.ToString(),
                Text = g.Name
            }).ToList();
            groupList.Insert(0, new SelectListItem
            {
                Value = "0",
                Text = "Seçin",
                Selected = true,
                Disabled = true
            });
            ViewBag.Groups = groupList;
            //ViewBag.Groups = _context.Groups.Select(g => new SelectListItem
            //{
            //    Value = g.Id.ToString(),
            //    Text = g.Name
            //}).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            //if (_context.Students.Any(s => s.Name == student.Name))
            //{
            //    ModelState.AddModelError("Name", "Bu adda tələbə artıq var");
            //}

                ModelState.Remove("Group");
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            var groupList = _context.Groups.Select(g => new SelectListItem 
            {
                Value = g.Id.ToString(),
                Text = g.Name
            }).ToList();
            groupList.Insert(0, new SelectListItem
            {
                Value = "0",
                Text = "Seçin",
                Selected = true,
                Disabled = true
            });
            ViewBag.Groups = groupList;
            //ViewBag.Groups = _context.Groups.Select(g => new SelectListItem
            //{
            //    Value = g.Id.ToString(),
            //    Text = g.Name
            //}).ToList();
            return View(student);
        }
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null) return NotFound();
            _context.Students.Remove(student);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            var student = _context.Students.Include("Group").FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            ViewBag.Groups= _context.Groups.Select(g => new SelectListItem
            {
                Value = g.Id.ToString(),
                Text = g.Name
            }).ToList();
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            ModelState.Remove("Group");
            if(ModelState.IsValid)
            {
                _context.Entry(student).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("index");
            }

            ViewBag.Groups = _context.Groups.Select(g => new SelectListItem
            {
                Value = g.Id.ToString(),
                Text = g.Name
            }).ToList();
            return View(student);
        }
    }
}
