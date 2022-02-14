using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.MVC.Security
{
    public class AppRole : IdentityRole<int>
    {
        public DateTime CreationTime { get; set; }
    }
}
