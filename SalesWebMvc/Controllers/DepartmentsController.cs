using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Data;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly SalesWebMvcContext _context;

        public DepartmentsController(SalesWebMvcContext context)
        {
            _context = context;
        }

        // GET: DepartmentsController
        public ActionResult Index()
        {
            var list = _context.Departments.ToList();
            return View(list);
        }

        // GET: DepartmentsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepartmentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Departments department)
        {
            if(!ModelState.IsValid)
            {
                return View(department);
            }

            _context.Departments.Add(department);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
            
        }

        // GET: DepartmentsController/Edit/5
        public ActionResult Edit(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: DepartmentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Departments department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }

            var departmentDb = _context.Departments.Find(id);
            if (departmentDb == null)
            {
                return NotFound();
            }
            departmentDb.Name = department.Name;


            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: DepartmentsController/Delete/5
        public ActionResult Delete(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            
            return View(department);
        }

        // POST: DepartmentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Departments department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }

            var departmentDb = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            departmentDb.Name = department.Name;


            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
