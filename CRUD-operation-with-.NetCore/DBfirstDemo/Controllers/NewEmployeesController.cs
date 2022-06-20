using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBfirstDemo.Models;

namespace DBfirstDemo.Controllers
{
    public class NewEmployeesController : Controller
    {
        private readonly DemoDBContext _context;

        public NewEmployeesController(DemoDBContext context)
        {
            _context = context;
        }

        // GET: NewEmployees
        public async Task<IActionResult> Index()
        {
            var demoDBContext = _context.NewEmployees.Include(n => n.Dept);
            return View(await demoDBContext.ToListAsync());
        }

        // GET: NewEmployees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newEmployee = await _context.NewEmployees
                .Include(n => n.Dept)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newEmployee == null)
            {
                return NotFound();
            }

            return View(newEmployee);
        }

        // GET: NewEmployees/Create
        public IActionResult Create()
        {
            ViewData["DeptId"] = new SelectList(_context.Depts, "DeptId", "Dname");
            return View();
        }

        // POST: NewEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Age,DeptId")] NewEmployee newEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeptId"] = new SelectList(_context.Depts, "DeptId", "Dname", newEmployee.DeptId);
            return View(newEmployee);
        }

        // GET: NewEmployees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newEmployee = await _context.NewEmployees.FindAsync(id);
            if (newEmployee == null)
            {
                return NotFound();
            }
            ViewData["DeptId"] = new SelectList(_context.Depts, "DeptId", "Dname", newEmployee.DeptId);
            return View(newEmployee);
        }

        // POST: NewEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Age,DeptId")] NewEmployee newEmployee)
        {
            if (id != newEmployee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewEmployeeExists(newEmployee.Id))
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
            ViewData["DeptId"] = new SelectList(_context.Depts, "DeptId", "Dname", newEmployee.DeptId);
            return View(newEmployee);
        }

        // GET: NewEmployees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newEmployee = await _context.NewEmployees
                .Include(n => n.Dept)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newEmployee == null)
            {
                return NotFound();
            }

            return View(newEmployee);
        }

        // POST: NewEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newEmployee = await _context.NewEmployees.FindAsync(id);
            _context.NewEmployees.Remove(newEmployee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewEmployeeExists(int id)
        {
            return _context.NewEmployees.Any(e => e.Id == id);
        }
    }
}
