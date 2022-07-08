using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolDataApplication.Data;
using SchoolDataApplication.Models.ViewModels;
using Services.Interfaces;
using FluentValidation.AspNetCore;
using WebApp.Extensions;


namespace SchoolDataApplication.Controllers
{
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;
        private readonly SchoolDataApplicationDbContext _context;

        public UsersController(ILogger<UsersController> logger, SchoolDataApplicationDbContext context, IUserService userService)
        {
            _context = context;
            _logger = logger;
            _userService = userService;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var schoolDataApplicationDbContext = _context.Users
                .Include(u => u.UserType)
                .Include(u => u.School)
                .Include(u => u.YearGroup);
            return View(await schoolDataApplicationDbContext.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            //var user = await _context.Users
            //    .Include(u => u.UserType).Include(u => u.School).Include(u => u.YearGroup)
            //    .FirstOrDefaultAsync(m => m.UserId == id);


            var user = await _context.Users.Include(a => a.UserType).Include(a => a.YearGroup).Include(a => a.School).ToListAsync();

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = await _userService.BuildCreateUserViewModel();
            return View(viewModel);
        }

        // POST: Users/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserViewModel viewModel)
        {
            viewModel = await _userService.BuildCreateUserViewModel(viewModel);
            var result = await _userService.ValidateCreateUserViewModel(viewModel);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View(viewModel);
            }

            var user = viewModel.User;
            await _userService.AddUser(user);
            return Redirect("Index");
            
        }


        // GET: Users/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Users == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await _context.Users.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["UserTypeId"] = new SelectList(_context.UserTypes, "UserTypeId", "UserTypeId", user.UserTypeId);
        //    return View(user);
        //}

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("UserId,FirstName,LastName,School,DateOfBirth,YearGroup,UserTypeId")] User user)
        //{
        //    if (id != user.UserId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(user);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UserExists(user.UserId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["UserTypeId"] = new SelectList(_context.UserTypes, "UserTypeId", "UserTypeId", user.UserTypeId);
        //    return View(user);
        //}

        // GET: Users/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Users == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await _context.Users
        //        .Include(u => u.UserType)
        //        .FirstOrDefaultAsync(m => m.UserId == id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(user);
        //}

        // POST: Users/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Users == null)
        //    {
        //        return Problem("Entity set 'SchoolDataApplicationDbContext.Users'  is null.");
        //    }
        //    var user = await _context.Users.FindAsync(id);
        //    if (user != null)
        //    {
        //        _context.Users.Remove(user);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool UserExists(int id)
        //{
        //  return (_context.Users?.Any(e => e.UserId == id)).GetValueOrDefault();
        //}
    }
}
