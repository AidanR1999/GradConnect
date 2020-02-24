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

namespace GradConnect.Controllers
{
    public class CvController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CvController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> CreateCv(CV cv)
        {
            await _context.CVs.AddAsync(cv);
            await _context.SaveChangesAsync();
            return View();
        }


    }
}