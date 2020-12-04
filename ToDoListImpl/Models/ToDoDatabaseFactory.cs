using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListImpl.Models
{
    public class ToDoDatabaseFactory: IDesignTimeDbContextFactory<ToDoDatabaseContext>
    {
        public ToDoDatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ToDoDatabaseContext>();
            optionsBuilder.UseSqlServer("Server=8460P\\LOCALDB;Database=ToDoTestDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new ToDoDatabaseContext(optionsBuilder.Options);
        }
    }
}
