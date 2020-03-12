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
        public IActionResult BlankSkill()
        {
            return PartialView("_SkillsEditor", new Skill());
        }
        public IActionResult BlankExperience()
        {
            return PartialView("_ExperienceEditor", new Experience());
        }

        public IActionResult BlankPortfolio()
        {
            return PartialView("_PortfolioEditor", new Portfolio());
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



        public async Task<IActionResult> EditPortfolio(UserProfileViewModel model)
        {
            var user = GetUser();

            if (ModelState.IsValid)
            {
                //var userFromDb = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
                var portfoliosFromDb = await _context.Portfolios.Include(x => x.Photo).Where(x => x.UserId == user.Id).ToListAsync();

                if (portfoliosFromDb != null || model.ListOfPortfolios.Count() != 0)
                {
                    foreach (var port in portfoliosFromDb)
                    {
                        _context.Portfolios.Remove(port);
                        await _context.SaveChangesAsync();
                    }
                }

                if (model.ListOfPortfolios == null || model.ListOfPortfolios.Count() == 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    for (var i = 0; i < model.ListOfPortfolios.Count(); i++)
                    {
                        Portfolio newPort = new Portfolio();
                        newPort.ProjectName = model.ListOfPortfolios[i].ProjectName;
                        newPort.Description = model.ListOfPortfolios[i].Description;
                        newPort.Link = model.ListOfPortfolios[i].Link;
                        newPort.User = user;
                        newPort.UserId = user.Id;

                        if (model.PictureFiles != null)
                        {
                            var files = HttpContext.Request.Form.Files;
                            if (files.Count > 0 && files[0] != null)
                            {
                                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images/Portfolios");
                                if(files.Count < i+1)
                                {
                                    await _context.Portfolios.AddAsync(newPort);
                                    await _context.SaveChangesAsync();
                                    return RedirectToAction(nameof(Index));
                                }
                                var extension = Path.GetExtension(files[i].FileName);
                                //find extension of the images
                                var extension_new = Path.GetExtension(files[i].FileName);
                                var extension_old = Path.GetExtension(model.ListOfPortfolios[i].Image);

                                //if old image exists
                                if (System.IO.File.Exists(Path.Combine(uploadsFolder, model.ListOfPortfolios[i].ProjectName + extension_old)))
                                {
                                    //delete old image
                                    System.IO.File.Delete(Path.Combine(uploadsFolder, model.ListOfPortfolios[i].ProjectName + extension_old));
                                }

                                newPort.Image = model.ListOfPortfolios[i].ProjectName + extension;
                                string filePath = Path.Combine(uploadsFolder, newPort.Image);
                                using (var fileStream = new FileStream(filePath, FileMode.Create))
                                {
                                    files[i].CopyTo(fileStream);
                                }
                            }

                        }
                        // string uniqueFileName = UploadedPortfolioImage(model);
                        // newPort.Image = uniqueFileName;
                        await _context.Portfolios.AddAsync(newPort);
                        await _context.SaveChangesAsync();
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }


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
        private string UploadedPortfolioImage(UserProfileViewModel model)
        {
            var user = GetUser();
            var portfolio = _context.Portfolios.Where(x => x.UserId == user.Id).ToList();
            string uniqueFileName = null;

            if (model.PictureFiles != null)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0 && files[0] != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images/Portfolios");
                    for (var i = 0; i < files.Count(); i++)
                    {
                        foreach (var project in model.ListOfPortfolios)
                        {

                            do
                            {
                                var extension = Path.GetExtension(files[i].FileName);
                                //find extension of the images
                                var extension_new = Path.GetExtension(files[i].FileName);
                                var extension_old = Path.GetExtension(project.Image);

                                //if old image exists
                                if (System.IO.File.Exists(Path.Combine(uploadsFolder, project.ProjectName + extension_old)))
                                {
                                    //delete old image
                                    System.IO.File.Delete(Path.Combine(uploadsFolder, project.ProjectName + extension_old));
                                }

                                uniqueFileName = project.ProjectName + extension;
                                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                                using (var fileStream = new FileStream(filePath, FileMode.Create))
                                {
                                    files[i].CopyTo(fileStream);
                                }
                                project.ImageProcessed = true;
                                _context.Portfolios.Update(project);
                            } while (project.ImageProcessed != true);
                            break;
                        }

                    }

                }
            }
            return uniqueFileName;
        }
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