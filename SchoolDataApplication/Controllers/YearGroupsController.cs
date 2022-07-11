using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using SchoolDataApplication.Data;

namespace SchoolDataApplication.Controllers
{
    public class YearGroupsController : Controller
    {
        private readonly SchoolDataApplicationDbContext _context;

        public YearGroupsController(SchoolDataApplicationDbContext context)
        {
            _context = context;
        }

        // GET: YearGroups
        public async Task<IActionResult> Index()
        {
              return _context.YearGroups != null ? 
                          View(await _context.YearGroups.ToListAsync()) :
                          Problem("Entity set 'SchoolDataApplicationDbContext.YearGroups'  is null.");
        }

        // GET: YearGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.YearGroups == null)
            {
                return NotFound();
            }

            var yearGroup = await _context.YearGroups
                .FirstOrDefaultAsync(m => m.YearGroupId == id);
            if (yearGroup == null)
            {
                return NotFound();
            }

            return View(yearGroup);
        }

        // GET: YearGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YearGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YearGroupId,Name")] YearGroup yearGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yearGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yearGroup);
        }

        // GET: YearGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.YearGroups == null)
            {
                return NotFound();
            }

            var yearGroup = await _context.YearGroups.FindAsync(id);
            if (yearGroup == null)
            {
                return NotFound();
            }
            return View(yearGroup);
        }

        // POST: YearGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("YearGroupId,Name")] YearGroup yearGroup)
        {
            if (id != yearGroup.YearGroupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yearGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YearGroupExists(yearGroup.YearGroupId))
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
            return View(yearGroup);
        }

        // GET: YearGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.YearGroups == null)
            {
                return NotFound();
            }

            var yearGroup = await _context.YearGroups
                .FirstOrDefaultAsync(m => m.YearGroupId == id);
            if (yearGroup == null)
            {
                return NotFound();
            }

            return View(yearGroup);
        }

        // POST: YearGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.YearGroups == null)
            {
                return Problem("Entity set 'SchoolDataApplicationDbContext.YearGroups'  is null.");
            }
            var yearGroup = await _context.YearGroups.FindAsync(id);
            if (yearGroup != null)
            {
                _context.YearGroups.Remove(yearGroup);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YearGroupExists(int id)
        {
          return (_context.YearGroups?.Any(e => e.YearGroupId == id)).GetValueOrDefault();
        }
    }
}
