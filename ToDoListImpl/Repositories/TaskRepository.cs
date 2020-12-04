using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListImpl.Models;

namespace ToDoListImpl.Repositories
{
    public class TaskRepository : Repository<Entities.Task>
    {
        public TaskRepository(ToDoDatabaseContext context) : base(context)
        {

        }

        
    }
}
