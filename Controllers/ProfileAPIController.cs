using Microsoft.AspNetCore.Mvc;
using GradConnect.Models;
using GradConnect.ViewModels;
using GradConnect.Data;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;

using System;


namespace GradConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileAPIController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProfileAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Produces("application/json")]
        [HttpGet("search")]
        public async Task<IActionResult> Search()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                
                var userName =  _context.Users.Where(x => x.Forename.ToLower().Contains(term.ToLower()) || x.Surname.ToLower().Contains(term.ToLower()))                   
                                .Select(x => x.Forename + " " + x.Surname).ToList();
                
                return Ok(userName);
            }
            catch 
            {
                return BadRequest();
                
            }
        }
    }
}