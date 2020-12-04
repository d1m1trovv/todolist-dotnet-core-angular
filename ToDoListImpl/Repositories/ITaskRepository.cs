using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListImpl.Repositories
{
    public class ITaskRepository : IRepository<Entities.Task>
    {
        public object DelegateSettings => throw new NotImplementedException();

        public Entities.Task Settings { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Type => throw new NotImplementedException();

        public Task<Entities.Task> AddAsync(Entities.Task entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Entities.Task> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Entities.Task> UpdateAsync(Entities.Task entity)
        {
            throw new NotImplementedException();
        }
    }
}
