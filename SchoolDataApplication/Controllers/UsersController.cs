using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolDataApplication.Data;
using Services.Interfaces;
using FluentValidation.AspNetCore;
using SchoolDataApplication.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.ViewModels;
using Models.Entities;
using AutoMapper;

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
            var userList = await _userService.GetAllUsers();
            return View(userList);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.Include(a => a.UserType).Include(a => a.YearGroup).Include(a => a.School).FirstOrDefaultAsync(m => m.UserId == id);

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

        // GET: Users
        public async Task<IActionResult> Sort(int sortColumn, string sortDirection)
        {
            var userList = await _userService.GetAllUsers(sortColumn, sortDirection);
            var sortedData = this.ViewData;
            return PartialView("_UserResults", userList.UserResults);
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
            return RedirectToAction("Index");

        }


        //GET: Users/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var viewModel = await _userService.BuildEditUserViewModel(id);
            return View(viewModel);

        }

        //POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditUserViewModel viewModel)
        {

            viewModel = await _userService.BuildEditUserViewModel(id, viewModel);
            var result = await _userService.ValidateEditUserViewModel(viewModel);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View(viewModel);
            }
            var userToUpdate = viewModel.User;
            await _userService.EditUser(userToUpdate);
            return RedirectToAction("Index");
        }


        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.Include(a => a.UserType).Include(a => a.YearGroup).Include(a => a.School).FirstOrDefaultAsync(m => m.UserId == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'SchoolDataApplicationDbContext.Users'  is null.");
            }
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

