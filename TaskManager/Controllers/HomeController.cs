using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITask _task;

        public HomeController(ILogger<HomeController> logger,ITask task)
        {
            _logger = logger;
            _task = task;
        }

        public IActionResult TaskPage()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TaskPage(TaskDetails task) 
        {
            if(!ModelState.IsValid)
            {
                return View(task);
            }
            _task.Insert(task);
            List<TaskDetails> tasks = _task.GetAll();

            return View("TaskList",tasks);
        }

        public IActionResult TaskList()
        {
            List<TaskDetails> taskDetails = _task.GetAll();
            return View(taskDetails);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TaskList(int taskId)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _task.Delete(taskId);
            List<TaskDetails> task= _task.GetAll();
            return View("TaskList",task);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}