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
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = GetUser();
            UserProfileViewModel model = new UserProfileViewModel();

            var userFromDb = await _context.Users.Include(x => x.Photo).FirstOrDefaultAsync(x => x.Id == user.Id);
            var portfolios = await _context.Portfolios.Where(x => x.UserId == user.Id).ToListAsync();
            var userSkills = await _context.UserSkills.Include(x => x.Skill).Where(x => x.UserId == user.Id).ToListAsync();
            var exps = await _context.Experiences.Where(x => x.UserId == user.Id).ToListAsync();
            // var photos = await _context.Photos.Where(x => x. == user.Id).ToListAsync();
            model.Forename = userFromDb.Forename;
            model.Surname = userFromDb.Surname;
            model.Experiences = exps;
            model.Email = userFromDb.Email;
            model.About = userFromDb.About;
            model.Course = userFromDb.CourseName;
            model.ProfilePhoto = userFromDb.ProfileImage;
            model.ListOfPortfolios = portfolios;
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
                    skills.Add(s.Skill);

                }
                model.ListOfSkills = skills;
            }


            return View(model);
        }
        [Authorize]
        public IActionResult BlankSkill()
        {
            return PartialView("_SkillsEditor", new Skill());
        }
        [Authorize]
        public IActionResult BlankExperience()
        {
            return PartialView("_ExperienceEditor", new Experience());
        }
        [Authorize]
        public IActionResult BlankPortfolio()
        {
            return PartialView("_PortfolioEditor", new Portfolio());
        }
        [Authorize]
        public async Task<IActionResult> AddPortfolio(UserProfileViewModel model)
        {
            var user = GetUser();

            if (ModelState.IsValid)
            {
                foreach (var item in model.ListOfPortfolios)
                {
                    Portfolio newPort = new Portfolio();
                    newPort.ProjectName = item.ProjectName;
                    newPort.Description = item.Description;
                    newPort.Link = item.Link;
                    newPort.User = user;
                    newPort.UserId = user.Id;
                    await _context.Portfolios.AddAsync(newPort);
                    await _context.SaveChangesAsync();
                    if (model.PictureFile != null)
                    {
                        var files = HttpContext.Request.Form.Files;
                        if (files.Count > 0 && files[0] != null)
                        {
                            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images/Portfolios");
                            if (files.Count < 1)
                            {
                                await _context.Portfolios.AddAsync(newPort);
                                await _context.SaveChangesAsync();
                                return RedirectToAction(nameof(Index));
                            }
                            var extension = Path.GetExtension(files[0].FileName);
                            newPort.Image = newPort.Id + extension;
                            string filePath = Path.Combine(uploadsFolder, newPort.Image);
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                files[0].CopyTo(fileStream);
                            }
                        }

                    }
                    _context.Portfolios.Update(newPort);
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EditPortfolio(int id)
        {
            var user = GetUser();
            var port = await _context.Portfolios.FirstOrDefaultAsync(x => x.Id == id);

            UserProfileViewModel model = new UserProfileViewModel();
            model.Portfolio = port;

            return PartialView("_EditPortfolio", model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditPortfolioPost(int id, UserProfileViewModel model)
        {
            var user = GetUser();
            var port = await _context.Portfolios.FirstOrDefaultAsync(x => x.Id == id);
            if (ModelState.IsValid)
            {
                // var item = model.ListOfPortfolios.Where(x => x.Id == id).FirstOrDefault();

                port.Description = model.Portfolio.Description;
                port.Link = model.Portfolio.Link;
                port.ProjectName = model.Portfolio.ProjectName;
                port.Image = model.Portfolio.Image;
                port.User = user;
                port.UserId = user.Id;
                if (model.PictureFile != null)
                {
                    var files = HttpContext.Request.Form.Files;
                    if (files.Count > 0 && files[0] != null)
                    {
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images/Portfolios");
                        if (files.Count < 1)
                        {
                            _context.Portfolios.Update(port);
                            await _context.SaveChangesAsync();
                            return RedirectToAction(nameof(Index));
                        }
                        var extension = Path.GetExtension(files[0].FileName);
                        //find extension of the images
                        var extension_new = Path.GetExtension(files[0].FileName);
                        var extension_old = Path.GetExtension(port.Image);

                        //if old image exists
                        if (System.IO.File.Exists(Path.Combine(uploadsFolder, id + extension_old)))
                        {
                            //delete old image
                            System.IO.File.Delete(Path.Combine(uploadsFolder, id + extension_old));
                        }

                        port.Image = id + extension;
                        string filePath = Path.Combine(uploadsFolder, port.Image);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }
                    }

                }

                _context.Portfolios.Update(port);
                await _context.SaveChangesAsync();

            }

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> DeletePortfolio(int id)
        {
            var user = GetUser();
            var port = await _context.Portfolios.FirstOrDefaultAsync(x => x.Id == id);

            UserProfileViewModel model = new UserProfileViewModel();
            model.Portfolio = port;

            return PartialView("_DeletePortfolio", model);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeletePortfolioPost(int id, UserProfileViewModel model)
        {
            var user = GetUser();

            if (ModelState.IsValid)
            {
                var port = await _context.Portfolios.FirstOrDefaultAsync(x => x.Id == id);
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images/Portfolios");
                var extension_old = Path.GetExtension(port.Image);
                if (System.IO.File.Exists(Path.Combine(uploadsFolder, id + extension_old)))
                {
                    //delete old image
                    System.IO.File.Delete(Path.Combine(uploadsFolder, id + extension_old));
                }

                _context.Portfolios.Remove(port);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
        [Authorize]
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

                if (model.ListOfSkills == null || model.ListOfSkills.Count() == 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
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

            }

            return RedirectToAction(nameof(Index));
        }


        [Authorize]
        public async Task<IActionResult> EditAbout(UserProfileViewModel model)
        {
            var user = GetUser();

            if (ModelState.IsValid)
            {
                var userFromDb = await _context.Users.Include(x => x.Photo).FirstOrDefaultAsync(x => x.Id == user.Id);

                userFromDb.About = model.About;

                _context.Users.Update(userFromDb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> EditExperience(UserProfileViewModel model)
        {
            var user = GetUser();

            if (ModelState.IsValid)
            {
                //var userFromDb = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
                var expFromDb = await _context.Experiences.Where(x => x.UserId == user.Id).ToListAsync();

                if (expFromDb != null || model.Experiences.Count() != 0)
                {
                    foreach (var exp in expFromDb)
                    {
                        _context.Experiences.Remove(exp);
                        await _context.SaveChangesAsync();
                    }
                }

                if (model.Experiences == null || model.Experiences.Count() == 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var mExp in model.Experiences)
                    {
                        Experience newExp = new Experience();

                        newExp.JobTitle = mExp.JobTitle;
                        newExp.CompanyName = mExp.CompanyName;
                        newExp.YearStart = mExp.YearStart;
                        newExp.YearEnd = mExp.YearEnd;
                        newExp.Responsibilities = mExp.Responsibilities;
                        newExp.UserId = user.Id;
                        newExp.User = user;


                        await _context.Experiences.AddAsync(newExp);
                        await _context.SaveChangesAsync();
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> AddCourse(UserProfileViewModel model)
        {
            var user = GetUser();
            if (ModelState.IsValid)
            {
                var userFromDb = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
                userFromDb.CourseName = model.Course;
                _context.Users.Update(userFromDb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
        [Authorize]
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
                    if (System.IO.File.Exists(Path.Combine(uploadsFolder, user.Id + extension_old)))
                    {
                        //delete old image
                        System.IO.File.Delete(Path.Combine(uploadsFolder, user.Id + extension_old));
                    }

                    uniqueFileName = user.Id + extension;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ProfilePicture.CopyTo(fileStream);
                    }
                }
            }
            return uniqueFileName;
        }

        private User GetUser()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            return user;
        }
        #endregion
    }
}