using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListImpl.Entities;
using ToDoListImpl.Models;

namespace ToDoListImpl.Models
{
    public class ToDoDatabaseContext : IdentityDbContext<UserModel>
    {
        public ToDoDatabaseContext(DbContextOptions<ToDoDatabaseContext> options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlServer("Server=8460P\\LOCALDB;Database=ToDoTestDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<Entities.Task> Tasks { get; set; }
        
    }
}
