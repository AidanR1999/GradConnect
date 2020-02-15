using System;
using System.Collections.Generic;
using System.Text;
using GradConnect.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GradConnect.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<BookmarkedPost> BookmarkedPosts { get; set; }
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CV> CVs { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobSkill> JobSkills { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostSkill> PostSkills { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Sponsored> SponsoredPosts { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
    }
}
