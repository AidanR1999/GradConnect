﻿// <auto-generated />
using System;
using GradConnect.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GradConnect.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
<<<<<<< HEAD:Migrations/20200321181601_newMig2.Designer.cs
    [Migration("20200321181601_newMig2")]
    partial class newMig2
=======
    [Migration("20200302165808_UpdatedJobs")]
    partial class UpdatedJobs
>>>>>>> Jobs:Migrations/20200302165808_UpdatedJobs.Designer.cs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("GradConnect.Models.BookmarkedPost", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<int>("PostId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "PostId");

                    b.HasIndex("PostId");

                    b.ToTable("BookmarkedPosts");
                });

            modelBuilder.Entity("GradConnect.Models.CV", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("CvName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PersonalStatement")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Postcode")
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("CVs");
                });

            modelBuilder.Entity("GradConnect.Models.Comment", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<int>("ArticleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DatePosted")
                        .HasColumnType("TEXT");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "ArticleId");

                    b.HasIndex("ArticleId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("GradConnect.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CourseName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CvId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Institution")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("YearEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("YearStart")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CvId");

                    b.HasIndex("UserId");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("GradConnect.Models.Employer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Employers");
                });

            modelBuilder.Entity("GradConnect.Models.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CompanyName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CvId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("JobTitle")
                        .HasColumnType("TEXT");

                    b.Property<string>("Responsibilities")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("YearEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("YearStart")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CvId");

                    b.HasIndex("UserId");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("GradConnect.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContractType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ContractedHours")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DatePosted")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EmployerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.Property<double>("Salary")
                        .HasColumnType("REAL");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EmployerId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("GradConnect.Models.JobSkill", b =>
                {
                    b.Property<int>("JobId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SkillId")
                        .HasColumnType("INTEGER");

                    b.HasKey("JobId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("JobSkills");
                });

            modelBuilder.Entity("GradConnect.Models.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EducationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Grade")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EducationId");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("GradConnect.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DateUploaded")
                        .HasColumnType("TEXT");

                    b.Property<string>("Link")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PostId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("GradConnect.Models.Portfolio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("Link")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PhotoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProjectName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PhotoId");

                    b.HasIndex("UserId");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("GradConnect.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DatePosted")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("Thumbnail")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("post_type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");

                    b.HasDiscriminator<string>("post_type").HasValue("Post");
                });

            modelBuilder.Entity("GradConnect.Models.PostSkill", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SkillId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PostId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("PostSkills");
                });

            modelBuilder.Entity("GradConnect.Models.Reference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CvId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CvId");

                    b.ToTable("References");
                });

            modelBuilder.Entity("GradConnect.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CvId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CvId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("GradConnect.Models.Submission", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<int>("ChallengeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContentLink")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateSubmitted")
                        .HasColumnType("TEXT");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "ChallengeId");

                    b.HasIndex("ChallengeId");

                    b.ToTable("Submissions");
                });

            modelBuilder.Entity("GradConnect.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("About")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("CourseName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Forename")
                        .HasColumnType("TEXT");

                    b.Property<string>("InstitutionName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PhotoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("TEXT");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("StudentEmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StudentEmial")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.HasIndex("PhotoId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("GradConnect.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RoleId1")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId1");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("GradConnect.Models.UserSkill", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<int>("SkillId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("UserSkills");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("GradConnect.Models.Article", b =>
                {
                    b.HasBaseType("GradConnect.Models.Post");

                    b.Property<string>("Link")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("article");
                });

            modelBuilder.Entity("GradConnect.Models.Challenge", b =>
                {
                    b.HasBaseType("GradConnect.Models.Post");

                    b.Property<int>("EmployerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Task")
                        .HasColumnType("TEXT");

                    b.HasIndex("EmployerId");

                    b.HasDiscriminator().HasValue("challenge");
                });

            modelBuilder.Entity("GradConnect.Models.Sponsored", b =>
                {
                    b.HasBaseType("GradConnect.Models.Post");

                    b.Property<int>("EmployerId")
                        .HasColumnName("Sponsored_EmployerId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("EmployerId");

                    b.HasDiscriminator().HasValue("sponsored");
                });

            modelBuilder.Entity("GradConnect.Models.Role", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole");

                    b.HasDiscriminator().HasValue("Role");
                });

            modelBuilder.Entity("GradConnect.Models.BookmarkedPost", b =>
                {
                    b.HasOne("GradConnect.Models.Post", "Post")
                        .WithMany("BookmarkedPosts")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GradConnect.Models.User", "User")
                        .WithMany("BookmarkedPosts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GradConnect.Models.CV", b =>
                {
                    b.HasOne("GradConnect.Models.User", "User")
                        .WithMany("CVs")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("GradConnect.Models.Comment", b =>
                {
                    b.HasOne("GradConnect.Models.Article", "Article")
                        .WithMany("Comments")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GradConnect.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GradConnect.Models.Education", b =>
                {
                    b.HasOne("GradConnect.Models.CV", "Cv")
                        .WithMany("Educations")
                        .HasForeignKey("CvId");

                    b.HasOne("GradConnect.Models.User", "User")
                        .WithMany("Educations")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("GradConnect.Models.Experience", b =>
                {
                    b.HasOne("GradConnect.Models.CV", "Cv")
                        .WithMany("Experiences")
                        .HasForeignKey("CvId");

                    b.HasOne("GradConnect.Models.User", "User")
                        .WithMany("Experiences")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("GradConnect.Models.Job", b =>
                {
                    b.HasOne("GradConnect.Models.Employer", null)
                        .WithMany("Jobs")
                        .HasForeignKey("EmployerId");
                });

            modelBuilder.Entity("GradConnect.Models.JobSkill", b =>
                {
                    b.HasOne("GradConnect.Models.Job", "Job")
                        .WithMany("JobSkills")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GradConnect.Models.Skill", "Skill")
                        .WithMany("JobSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GradConnect.Models.Module", b =>
                {
                    b.HasOne("GradConnect.Models.Education", "Education")
                        .WithMany("Modules")
                        .HasForeignKey("EducationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GradConnect.Models.Photo", b =>
                {
                    b.HasOne("GradConnect.Models.Post", null)
                        .WithMany("Photos")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("GradConnect.Models.Portfolio", b =>
                {
                    b.HasOne("GradConnect.Models.Photo", "Photo")
                        .WithMany()
                        .HasForeignKey("PhotoId");

                    b.HasOne("GradConnect.Models.User", "User")
                        .WithMany("Portfolios")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("GradConnect.Models.Post", b =>
                {
                    b.HasOne("GradConnect.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("GradConnect.Models.PostSkill", b =>
                {
                    b.HasOne("GradConnect.Models.Post", "Post")
                        .WithMany("PostSkills")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GradConnect.Models.Skill", "Skill")
                        .WithMany("PostSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GradConnect.Models.Reference", b =>
                {
                    b.HasOne("GradConnect.Models.CV", "Cv")
                        .WithMany("References")
                        .HasForeignKey("CvId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GradConnect.Models.Skill", b =>
                {
                    b.HasOne("GradConnect.Models.CV", "Cv")
                        .WithMany("Skills")
                        .HasForeignKey("CvId");
                });

            modelBuilder.Entity("GradConnect.Models.Submission", b =>
                {
                    b.HasOne("GradConnect.Models.Challenge", "Challenge")
                        .WithMany("Submissions")
                        .HasForeignKey("ChallengeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GradConnect.Models.User", "User")
                        .WithMany("Submissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GradConnect.Models.User", b =>
                {
                    b.HasOne("GradConnect.Models.Photo", "Photo")
                        .WithMany()
                        .HasForeignKey("PhotoId");
                });

            modelBuilder.Entity("GradConnect.Models.UserRole", b =>
                {
                    b.HasOne("GradConnect.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId1");

                    b.HasOne("GradConnect.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("GradConnect.Models.UserSkill", b =>
                {
                    b.HasOne("GradConnect.Models.Skill", "Skill")
                        .WithMany("UserSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GradConnect.Models.User", "User")
                        .WithMany("UserSkills")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("GradConnect.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GradConnect.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GradConnect.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("GradConnect.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GradConnect.Models.Challenge", b =>
                {
                    b.HasOne("GradConnect.Models.Employer", "Employer")
                        .WithMany("Challenges")
                        .HasForeignKey("EmployerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GradConnect.Models.Sponsored", b =>
                {
                    b.HasOne("GradConnect.Models.Employer", "Employer")
                        .WithMany("SponsoredPosts")
                        .HasForeignKey("EmployerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
