﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GradConnect.Data;
using GradConnect.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using GradConnect.ViewModels;

namespace GradConnect.Controllers
{
    public class PostsController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly ApplicationDbContext _context;

        public PostsController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            //previous scaffolded code
            //var applicationDbContext = _context.Posts.Include(p => p.User);
            //return View(await applicationDbContext.ToListAsync());

            //sorts the posts and lists them in chronological order
            var posts = _context.Posts.Include(p => p.User);
            var jobs = _context.Jobs;

            var feed = new FeedViewModel();

            foreach(var post in posts)
            {
                var postCard = new PostCardViewModel()
                {
                    Id = post.Id,
                    Title = post.Title,
                    DatePosted = (DateTime)post.DatePosted,
                    Description = post.Description,
                    Salary = null,
                    Location = "",
                    ContractType = "",
                    Icon = null
                };
                feed.PostCardFeed.Add(postCard);
            }

            foreach(var job in jobs)
            {
                var postCard = new PostCardViewModel()
                {
                    Id = job.Id,
                    Title = job.Title,
                    DatePosted = (DateTime)job.DatePosted,
                    Description = job.Description,
                    Salary = job.Salary,
                    Location = job.Location,
                    ContractType = job.ContractType,
                    Icon = null
                };
                feed.PostCardFeed.Add(postCard);
            }

            //feed.PostCardFeed = (List<PostCardViewModel>) feed.PostCardFeed.OrderByDescending(x => x.DatePosted);

            return View(feed);
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        //this method adds a post to the database and saves the changes to the database.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,UserId")] Post post)
        {
            if (ModelState.IsValid)
            {
                //post date time is now
                post.DatePosted = DateTime.Now;
                //find the current user, this user posts the post
                post.UserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                //the thumbnail is always zero. would reference a photoId, but out of scope.
                post.Thumbnail = 0;
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", post.UserId);
            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //protect against unauthorised editing here

            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", post.UserId);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,DatePosted,Thumbnail,UserId")] Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", post.UserId);
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
