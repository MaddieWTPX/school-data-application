using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using SchoolDataApplication.Data;

namespace SchoolDataApplication.Controllers
{
    public class ClassAssignmentsController : Controller
    {
        private readonly SchoolDataApplicationDbContext _context;

        public ClassAssignmentsController(SchoolDataApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClassAssignments
        public async Task<IActionResult> Index()
        {
            var schoolDataApplicationDbContext = _context.ClassAssignments.Include(c => c.SchoolClass).Include(c => c.User);
            return View(await schoolDataApplicationDbContext.ToListAsync());
        }

        // GET: ClassAssignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ClassAssignments == null)
            {
                return NotFound();
            }

            var classAssignment = await _context.ClassAssignments
                .Include(c => c.SchoolClass)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (classAssignment == null)
            {
                return NotFound();
            }

            return View(classAssignment);
        }

        // GET: ClassAssignments/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.SchoolClasses, "ClassId", "ClassId");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: ClassAssignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,ClassId")] ClassAssignment classAssignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classAssignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.SchoolClasses, "ClassId", "ClassId", classAssignment.ClassId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", classAssignment.UserId);
            return View(classAssignment);
        }

        // GET: ClassAssignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ClassAssignments == null)
            {
                return NotFound();
            }

            var classAssignment = await _context.ClassAssignments.FindAsync(id);
            if (classAssignment == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.SchoolClasses, "ClassId", "ClassId", classAssignment.ClassId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", classAssignment.UserId);
            return View(classAssignment);
        }

        // POST: ClassAssignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,ClassId")] ClassAssignment classAssignment)
        {
            if (id != classAssignment.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classAssignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassAssignmentExists(classAssignment.UserId))
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
            ViewData["ClassId"] = new SelectList(_context.SchoolClasses, "ClassId", "ClassId", classAssignment.ClassId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", classAssignment.UserId);
            return View(classAssignment);
        }

        // GET: ClassAssignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ClassAssignments == null)
            {
                return NotFound();
            }

            var classAssignment = await _context.ClassAssignments
                .Include(c => c.SchoolClass)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (classAssignment == null)
            {
                return NotFound();
            }

            return View(classAssignment);
        }

        // POST: ClassAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ClassAssignments == null)
            {
                return Problem("Entity set 'SchoolDataApplicationDbContext.ClassAssignments'  is null.");
            }
            var classAssignment = await _context.ClassAssignments.FindAsync(id);
            if (classAssignment != null)
            {
                _context.ClassAssignments.Remove(classAssignment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassAssignmentExists(int id)
        {
          return (_context.ClassAssignments?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
