#region USINGS
using Microsoft.AspNetCore.Mvc;
using GradConnect.Models;
using GradConnect.ViewModels;
using GradConnect.Data;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;

#endregion
namespace GradConnect.Controllers
{
    public class ProfileController : Controller
    {
        #region constructor
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProfileController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostingEnvironment)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _webHostEnvironment = webHostingEnvironment;
        }
        #endregion

        #region CRUD
        public async Task<IActionResult> Index()
        {
            var user = GetUser();
            UserProfileViewModel model = new UserProfileViewModel();

            var userFromDb = await _context.Users.Include(x => x.Photo).FirstOrDefaultAsync(x => x.Id == user.Id);
            var portfolios = await _context.Portfolios.Where(x => x.UserId == user.Id).ToListAsync();
            var userSkills = await _context.UserSkills.Include(x => x.Skill).Where(x => x.UserId == user.Id).ToListAsync();
            // var photos = await _context.Photos.Where(x => x. == user.Id).ToListAsync();
            model.Forename = userFromDb.Forename;
            model.Surname = userFromDb.Surname;
            model.Experiences = userFromDb.Experiences;
            model.Email = userFromDb.Email;
            model.About = userFromDb.About;
            model.Course = userFromDb.CourseName;
            model.ProfilePhoto = userFromDb.ProfileImage;
            model.UserPortfolios = portfolios;
            model.VerifiedStudent = userFromDb.StudentEmailConfirmed;
            model.Institution = userFromDb.InstitutionName;
            List<Skill> skills = new List<Skill>();
            if (userSkills.Count == 0)
            {
                return View(model);
            }
            else
            {
                foreach (var s in userSkills)
                {
                    //var skill = await _context.Skills.FirstOrDefaultAsync(x => x.Id == s.SkillId);
                    skills.Add(s.Skill);

                }
                model.ListOfSkills = skills;
            }


            return View(model);
        }
        public IActionResult BlankSkill()
        {
            return PartialView("_SkillsEditor", new Skill());
        }

        public async Task<IActionResult> AddSkillsToUser(UserProfileViewModel model)
        {
            var user = GetUser();

            if (ModelState.IsValid)
            {
                var userFromDb = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
                var userSkills = await _context.UserSkills.Include(x => x.Skill).Where(x => x.UserId == user.Id).ToListAsync();
                
                foreach (var item in userSkills)
                {
                    _context.UserSkills.Remove(item);
                    await _context.SaveChangesAsync();
                }
                //userSkills.ToHashSet();
                foreach (var skill in model.ListOfSkills)
                {
                    if (model.ListOfSkills.FindAll(x => x.Name == skill.Name).Count == 1)
                    {
                        UserSkill us = new UserSkill
                        {
                            Skill = skill,
                            SkillId = skill.Id,
                            UserId = user.Id,
                            User = user
                        };
                        await _context.UserSkills.AddAsync(us);
                        //await _context.UserSkills.AddRangeAsync(us);
                    }
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditAbout(UserProfileViewModel model)
        {
            var user = GetUser();

            if (ModelState.IsValid)
            {
                var userFromDb = await _context.Users.Include(x => x.Photo).FirstOrDefaultAsync(x => x.Id == user.Id);

                userFromDb.About = model.About;
                
                _context.Users.Update(userFromDb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), model);
            }

            return RedirectToAction(nameof(Index), model);
        }

        // public void AddSkillToUser(List<Skill> list)
        // {
        //     var user = GetUser();
        //     var userFromDb = _context.Users.FirstOrDefault(x => x.Id == user.Id);
        //     List<UserSkill> userSkills = new List<UserSkill>();
        //     foreach (var s in list)
        //     {
        //         UserSkill newUS = new UserSkill
        //         {
        //             UserId = user.Id,
        //             SkillId = s.Id
        //         };
        //     };
        // }

        public async Task<IActionResult> AddProfileImage(UserProfileViewModel model)
        {
            var user = GetUser();

            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                user.ProfileImage = uniqueFileName;


                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Utils

        private string UploadedFile(UserProfileViewModel model)
        {
            var user = GetUser();
            string uniqueFileName = null;

            if (model.ProfilePicture != null)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0 && files[0] != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images/UsersProfileImages");
                    var extension = Path.GetExtension(files[0].FileName);
                    //find extension of the images
                    var extension_new = Path.GetExtension(files[0].FileName);
                    var extension_old = Path.GetExtension(user.ProfileImage);

                    //if old image exists
                    if (System.IO.File.Exists(Path.Combine(uploadsFolder, user.Forename + "_" + user.Surname + extension_old)))
                    {
                        //delete old image
                        System.IO.File.Delete(Path.Combine(uploadsFolder, user.Forename + "_" + user.Surname + extension_old));
                    }

                    uniqueFileName = user.Forename + "_" + user.Surname + extension;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ProfilePicture.CopyTo(fileStream);
                    }
                }
            }
            return uniqueFileName;
        }

        public User GetUser()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            return user;
        }
        #endregion
    }
}