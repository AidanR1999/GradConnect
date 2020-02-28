using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradConnect.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GradConnect.Data
{
    public class DatabaseSeed
    {
        public async static void Seed(ApplicationDbContext context, RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            // if no users exist in database
            if (!context.Users.Any())
            {
                if(!await roleManager.RoleExistsAsync("Admin"))
                {
                    await roleManager.CreateAsync(new Role("Admin"));
                }

                if(!await roleManager.RoleExistsAsync("Moderator"))
                {
                    await roleManager.CreateAsync(new Role("Moderator"));
                }

                if (!await roleManager.RoleExistsAsync("Staff"))
                {
                    await roleManager.CreateAsync(new Role("Staff"));
                }

                if (!await roleManager.RoleExistsAsync("Employer"))
                {
                    await roleManager.CreateAsync(new Role("Employer"));
                }

                if (!await roleManager.RoleExistsAsync("User"))
                {
                    await roleManager.CreateAsync(new Role("User"));
                }
                
            }

            if (await userManager.FindByNameAsync("admin@gradconnect.network") == null)
            {
                var admin = new User()
                {
                    Forename = "Admin",
                    Surname = "",
                    Email = "admin@gradconnect.network",
                    EmailConfirmed = true,
                    UserName = "admin@gradconnect.network",
                    StudentEmial = "",
                    StudentEmailConfirmed = false,
                    DateOfBirth = DateTime.Parse("01/01/1990"),
                    About = "Admin at GradConect",
                    InstitutionName = "GradConnect",
                    CourseName = "GradConnect"
                };


                var result = await userManager.CreateAsync(admin);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(admin, "Pass123!");
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }

            if (await userManager.FindByNameAsync("james.lawn@gradconnect.network") == null)
            {
                var mod = new User()
                {
                    Forename = "James",
                    Surname = "Lawn",
                    Email = "james.lawn@gradconnect.network",
                    EmailConfirmed = true,
                    UserName = "james.lawn@gradconnect.network",
                    StudentEmial = "",
                    StudentEmailConfirmed = false,
                    DateOfBirth = DateTime.Parse("11/07/1990"),
                    About = "Staff at GradConect",
                    InstitutionName = "Glasgow Caledonian University",
                    CourseName = "Computing"
                };


                var result = await userManager.CreateAsync(mod);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(mod, "Pass123!");
                    await userManager.AddToRoleAsync(mod, "Moderator");
                }
            }

            if (await userManager.FindByNameAsync("lukasz.bonkowski@gradconnect.network") == null)
            {
                var staff = new User()
                {
                    Forename = "Lukasz",
                    Surname = "Bonkowski",
                    Email = "lukasz.bonkowski@gradconnect.network",
                    EmailConfirmed = true,
                    UserName = "lukasz.bonkowski@gradconnect.network",
                    StudentEmial = "",
                    StudentEmailConfirmed = false,
                    DateOfBirth = DateTime.Parse("01/01/1990"),
                    About = "3rd Year Computing student @ GCU",
                    InstitutionName = "Glasgow Caledonian University",
                    CourseName = "Computing"
                };


                var result = await userManager.CreateAsync(staff);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(staff, "Pass123!");
                    await userManager.AddToRoleAsync(staff, "Staff");
                }
            }

            if (await userManager.FindByNameAsync("ibm@gradconnect.network") == null)
            {
                var employer = new User()
                {
                    Forename = "IBM",
                    Surname = "",
                    Email = "jobs@ibm.com",
                    EmailConfirmed = true,
                    UserName = "jobs@ibm.com",
                    StudentEmial = "",
                    StudentEmailConfirmed = false,
                    DateOfBirth = DateTime.Parse("01/01/1980"),
                    About = "Job oppertunities at IBM",
                    InstitutionName = "",
                    CourseName = ""
                };


                var result = await userManager.CreateAsync(employer);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(employer, "Pass123!");
                    await userManager.AddToRoleAsync(employer, "Employer");
                }
            }

            if (await userManager.FindByNameAsync("arooney200@caledonian.ac.uk") == null)
            {
                var user = new User()
                {
                    Forename = "Aidan",
                    Surname = "Rooney",
                    Email = "arooney200@caledonian.ac.uk",
                    EmailConfirmed = true,
                    UserName = "arooney200@caledonian.ac.uk",
                    StudentEmial = "arooney200@caledonian.ac.uk",
                    StudentEmailConfirmed = true,
                    DateOfBirth = DateTime.Parse("10/11/1999"),
                    About = "3rd Year Computing student @ GCU",
                    InstitutionName = "Glasgow Caledonian University",
                    CourseName = "Computing"
                };


                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, "Pass123!");
                    await userManager.AddToRoleAsync(user, "User");
                }
            }

        }
    }
}
