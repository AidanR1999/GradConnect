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
#endregion
namespace GradConnect.Controllers
{
    public class ProfileController : Controller
    {
#region constructor
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProfileController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
#endregion
        
#region CRUD
        public async Task<IActionResult> Index()
        {
            var user = GetUser();
            UserProfileViewModel model = new UserProfileViewModel();
            var userFromDb = await _context.Users.Include(x => x.Photo).FirstOrDefaultAsync(x => x.Id == user.Id);

            var portfolios = await _context.Portfolios.Where(x => x.UserId == user.Id).ToListAsync();
            var userSkills = await _context.UserSkills.Where(x => x.UserId == user.Id).ToListAsync();
            // var photos = await _context.Photos.Where(x => x. == user.Id).ToListAsync();
            model.Forename = userFromDb.Forename;
            model.Surname = userFromDb.Surname;
            model.Experiences = userFromDb.Experiences;
            model.Email = userFromDb.Email;
            model.About = userFromDb.About;
            model.Course = userFromDb.CourseName;
            model.ProfilePicture = userFromDb.Photo;

            foreach (var s in userSkills)
            {
                model.ListOfSkills.Add(s.Skill);
            }
            model.UserPortfolios = portfolios;
            model.VerifiedStudent = userFromDb.StudentEmailConfirmed;
            model.Institution = userFromDb.InstitutionName;
            return View(model);
        }

#endregion

#region Utils
        public User GetUser()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            return user;
        }
#endregion
    }
}