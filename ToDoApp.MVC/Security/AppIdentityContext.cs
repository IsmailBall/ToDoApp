using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.MVC.Security
{
    public class AppIdentityContext : IdentityDbContext<AppUser,AppRole,int>
    {
        public AppIdentityContext(DbContextOptions options) : base(options)
        {

        }
        
    }
}
