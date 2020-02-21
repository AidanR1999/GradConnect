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

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //CONFIGURE INHERITANCE RELATIONSHIP
            modelBuilder.Entity<Post>()
                .HasDiscriminator<string>("post_type")
                .HasValue<Challenges>("challenge")
                .HasValue<Article>("article")
                .HasValue<Sponsored>("sponsored");

            //JOB : SKILL M:M RELATIONSHIP
            modelBuilder.Entity<Jobskill>()
                .HasKey(js => new { js.JobId, js.SkillId });  
            modelBuilder.Entity<JobSkill>()
                .HasOne(js => js.Job)
                .WithMany(j => j.JobSkills)
                .HasForeignKey(js => js.JobId);  
            modelBuilder.Entity<JobSkill>()
                .HasOne(js => js.Skill)
                .WithMany(s => s.JobSkills)
                .HasForeignKey(js => js.SkillId);
        }
        
        public DbSet<BookmarkedPost> BookmarkedPosts { get; set; }
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
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
    }
}
