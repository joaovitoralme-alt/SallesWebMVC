
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;

public class DepartmentsController : Controller
{
    private readonly SalesWebMvcContext _context;

    public DepartmentsController(SalesWebMvcContext context)
    {
        _context = context;
    }

    // GET: DEPARTMENTSS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Departments.ToListAsync());
    }

    // GET: DEPARTMENTSS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var departments = await _context.Departments
            .FirstOrDefaultAsync(m => m.Id == id);
        if (departments == null)
        {
            return NotFound();
        }

        return View(departments);
    }

    // GET: DEPARTMENTSS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: DEPARTMENTSS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name")] Departments departments)
    {
        if (ModelState.IsValid)
        {
            _context.Add(departments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(departments);
    }

    // GET: DEPARTMENTSS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var departments = await _context.Departments.FindAsync(id);
        if (departments == null)
        {
            return NotFound();
        }
        return View(departments);
    }

    // POST: DEPARTMENTSS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name")] Departments departments)
    {
        if (id != departments.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(departments);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentsExists(departments.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(departments);
    }

    // GET: DEPARTMENTSS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var departments = await _context.Departments
            .FirstOrDefaultAsync(m => m.Id == id);
        if (departments == null)
        {
            return NotFound();
        }

        return View(departments);
    }

    // POST: DEPARTMENTSS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var departments = await _context.Departments.FindAsync(id);
        if (departments != null)
        {
            _context.Departments.Remove(departments);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool DepartmentsExists(int? id)
    {
        return _context.Departments.Any(e => e.Id == id);
    }
}
