using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.MVC.Security
{
    public class AppUser : IdentityUser<int>
    {
        public string Gender { get; set; }
        public string ImagaePath { get; set; }
    }
}
