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
            var user = GetUser();
            var allCvs = await _context.CVs.Where(x => x.UserId == user.Id).ToListAsync();
            return View(allCvs);
        }
        public IActionResult BlankEducation()
        {
            return PartialView("_EducationEditor", new Education());
        }
        public IActionResult BlankExperience()
        {
            return PartialView("_ExperienceEditor", new Experience());
        }
        public IActionResult BlankSkill()
        {
            return PartialView("_SkillsEditor", new Skill());
        }
        public IActionResult BlankReference()
        {
            return PartialView("_ReferencesEditor", new Reference());
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
            foreach (var edu in model.Educations)
            {
                edu.UserId = user.Id;
                edu.User = user;
            }
            foreach (var exp in model.Experiences)
            {
                exp.UserId = user.Id;
                exp.User = user;
            }

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
    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cv = await _context.CVs
                .Include(x => x.References)
                .Include(x => x.Skills)
                .Include(x => x.Educations)
                .Include(x => x.Experiences)
            .FirstOrDefaultAsync(x => x.Id == id);
        var model = new UpdateCvViewModel();
        
        model.CvName = cv.CvName;
        model.FirstName = cv.FirstName;
        model.LastName = cv.LastName;
        model.Street = cv.Street;
        model.City = cv.City;
        model.Postcode = cv.Postcode;
        model.PhoneNumber = cv.PhoneNumber;
        model.Email = cv.Email;
        model.DateOfBirth = cv.DateOfBirth;
        model.PersonalStatement = cv.PersonalStatement;
        model.Experiences = cv.Experiences;
        model.Educations = cv.Educations;
        model.References = cv.References;
        model.Skills = cv.Skills;
        
        
        return View(model);        
    }
        
    [HttpPost]
    [ActionName("Edit")]
    public async Task<IActionResult> Edit(int id, UpdateCvViewModel model)
    {
        if (ModelState.IsValid)
        {
            var cv = await _context.CVs
                .Include(m => m.References)
                .Include(m => m.Educations)
                .Include(m => m.Experiences)
                .Include(m => m.Skills)
                .FirstOrDefaultAsync(x => x.Id == id);
            cv.CvName = model.CvName;
            cv.FirstName = model.FirstName;
            cv.LastName = model.LastName;
            cv.Street = model.Street;
            cv.City = model.City;
            cv.Postcode = model.Postcode;
            cv.PhoneNumber = model.PhoneNumber;
            cv.Email = model.Email;
            cv.DateOfBirth = model.DateOfBirth;
            cv.PersonalStatement = model.PersonalStatement;
            cv.Experiences = model.Experiences;
            cv.Educations = model.Educations;
            cv.References = model.References;
            cv.Skills = model.Skills;
            _context.CVs.Update(cv);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    public User GetUser()
    {
        var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        var user = _context.Users.FirstOrDefault(x => x.Id == userId);
        return user;
    }

}
}