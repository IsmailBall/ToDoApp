using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Dal.Configrations;
using ToDoApp.Entities.Concrete;

namespace ToDoApp.Dal.Contexts
{
    public class WorkContext : DbContext
    {
        public DbSet<Work> Works { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=ToDoApp;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
        public WorkContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WorkConfigrations());
            base.OnModelCreating(modelBuilder);
        }
    }
}
