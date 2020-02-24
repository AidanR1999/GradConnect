using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradConnect.Models
{
    public class Role : IdentityRole
    {
        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}
