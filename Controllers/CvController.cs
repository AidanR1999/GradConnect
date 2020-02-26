using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GradConnect.Models;
using GradConnect.ViewModels;
using GradConnect.Data;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace GradConnect.Controllers
{
    public class CvController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CvController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var user = await _context.Users.Include(x => x.CVs).FirstOrDefaultAsync(x => x.Id == userId);
            var allCvs = await _context.CVs.Where(x => x.UserId == userId).ToListAsync();
            return View(allCvs);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> CreateCv(CreateCvViewModel model)
        {
            var user = GetUser();
            var cv = new CV
            {
                CvName = model.CvName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserId = user.Id,
                User = user,
                Street = model.Street,
                City = model.City,
                Postcode = model.Postcode,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                DateOfBirth = model.DateOfBirth,
                PersonalStatement = model.PersonalStatement,
                Experiences = model.Experiences,
                Educations = model.Educations,
                References = model.References,
                Skills = model.Skills

            };


            user.CVs.Append(cv);
            _context.Users.Update(user);
            await _context.CVs.AddAsync(cv);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cv = await _context.CVs.FirstOrDefaultAsync(x => x.Id == id);
            return View(cv);
        }
        [HttpPost]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }

        public User GetUser()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            return user;
        }

    }
}