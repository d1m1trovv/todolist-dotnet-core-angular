using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoListImpl.Entities;
using ToDoListImpl.Models;

namespace ToDoListImpl.Controllers
{
    public class TasksController : Controller
    {
        private readonly ToDoDatabaseContext _context;

        public TasksController(ToDoDatabaseContext context)
        {
            _context = context;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            List<TaskModel> taskModels = new List<TaskModel>();

            foreach(Entities.Task task in await _context.Tasks.ToListAsync())
            {
                TaskModel taskModel = new TaskModel();

                taskModel.Id = task.Id;
                taskModel.Title = task.Title;
                taskModel.Content = task.Content;
                taskModel.Date = task.Date;

                taskModels.Add(taskModel);
            }

            return View(taskModels);
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Content,Date")] TaskModel model)
        {
            if (ModelState.IsValid)
            {
                Entities.Task newTask = new Entities.Task();

                newTask.Id = model.Id;
                newTask.Title = model.Title;
                newTask.Content = model.Content;
                newTask.Date = model.Date;

                _context.Add(newTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Index");
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks.FindAsync(id);

            TaskModel taskModel = new TaskModel();

            taskModel.Id = task.Id;
            taskModel.Title = task.Title;
            taskModel.Content = task.Content;
            taskModel.Date = task.Date;

            if (task == null)
            {
                return NotFound();
            }
            return View(taskModel);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,Date")] TaskModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Entities.Task task = new Entities.Task();

                    task.Id = model.Id;
                    task.Title = model.Title;
                    task.Content = model.Content;
                    task.Date = model.Date;

                    _context.Update(task);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks
                .FirstOrDefaultAsync(m => m.Id == id);

            TaskModel taskModel = new TaskModel();

            taskModel.Id = task.Id;
            taskModel.Title = task.Title;
            taskModel.Content = task.Content;
            taskModel.Date = task.Date;

            if (task == null)
            {
                return NotFound();
            }

            return View(taskModel);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
