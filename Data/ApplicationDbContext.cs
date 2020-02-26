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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //CONFIGURE INHERITANCE RELATIONSHIP
            modelBuilder.Entity<Post>()
                .HasDiscriminator<string>("post_type")
                .HasValue<Challenge>("challenge")
                .HasValue<Article>("article")
                .HasValue<Sponsored>("sponsored");

            //JOB : SKILL M:M RELATIONSHIP
            modelBuilder.Entity<JobSkill>()
                .HasKey(js => new { js.JobId, js.SkillId });  
            modelBuilder.Entity<JobSkill>()
                .HasOne(js => js.Job)
                .WithMany(j => j.JobSkills)
                .HasForeignKey(js => js.JobId);  
            modelBuilder.Entity<JobSkill>()
                .HasOne(js => js.Skill)
                .WithMany(s => s.JobSkills)
                .HasForeignKey(js => js.SkillId);

            //USER : SKILL M:M RELATIONSHIP
            modelBuilder.Entity<UserSkill>()
                .HasKey(us => new { us.UserId, us.SkillId });  
            modelBuilder.Entity<UserSkill>()
                .HasOne(us => us.User)
                .WithMany(u => u.UserSkills)
                .HasForeignKey(us => us.UserId);  
            modelBuilder.Entity<UserSkill>()
                .HasOne(us => us.Skill)
                .WithMany(s => s.UserSkills)
                .HasForeignKey(us => us.SkillId);

            //POST : SKILL M:M RELATIONSHIP
            modelBuilder.Entity<PostSkill>()
                .HasKey(ps => new { ps.PostId, ps.SkillId });  
            modelBuilder.Entity<PostSkill>()
                .HasOne(ps => ps.Post)
                .WithMany(p => p.PostSkills)
                .HasForeignKey(ps => ps.PostId);  
            modelBuilder.Entity<PostSkill>()
                .HasOne(ps => ps.Skill)
                .WithMany(s => s.PostSkills)
                .HasForeignKey(ps => ps.SkillId);

            //USER : POST M:M RELATIONSHIP (BOOKMARKEDPOST)
            modelBuilder.Entity<BookmarkedPost>()
                .HasKey(bp => new { bp.UserId, bp.PostId });  
            modelBuilder.Entity<BookmarkedPost>()
                .HasOne(bp => bp.User)
                .WithMany(b => b.BookmarkedPosts)
                .HasForeignKey(bp => bp.UserId);  
            modelBuilder.Entity<BookmarkedPost>()
                .HasOne(bp => bp.Post)
                .WithMany(p => p.BookmarkedPosts)
                .HasForeignKey(bp => bp.PostId);

            //USER : ARTICLES M:M RELATIONSHIP (COMMENT)
            modelBuilder.Entity<Comment>()
                .HasKey(ua => new { ua.UserId, ua.ArticleId });  
            modelBuilder.Entity<Comment>()
                .HasOne(ua => ua.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(ua => ua.UserId);  
            modelBuilder.Entity<Comment>()
                .HasOne(ua => ua.Article)
                .WithMany(a => a.Comments)
                .HasForeignKey(ua => ua.ArticleId);

            //USER : CHALLENGE M:M RELATIONSHIP (SUBMISSION)
            modelBuilder.Entity<Submission>()
                .HasKey(uc => new { uc.UserId, uc.ChallengeId });  
            modelBuilder.Entity<Submission>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.Submissions)
                .HasForeignKey(uc => uc.UserId);  
            modelBuilder.Entity<Submission>()
                .HasOne(uc => uc.Challenge)
                .WithMany(c => c.Submissions)
                .HasForeignKey(uc => uc.ChallengeId);
        }
        
        public DbSet<BookmarkedPost> BookmarkedPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CV> CVs { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobSkill> JobSkills { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostSkill> PostSkills { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
    }
}
