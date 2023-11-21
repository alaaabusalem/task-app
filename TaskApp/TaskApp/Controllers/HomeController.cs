using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using TaskApp.Models;
using TaskApp.Models.Dtos;
using TaskApp.Models.Interfaces;

namespace TaskApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMyTask _Db;
       

        public HomeController(IMyTask db)
        {
            _Db = db;

        }
       
        public async Task<IActionResult> Index()
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var Todo = await _Db.GetToDoTask(userId);
            var Doing = await _Db.GetOngoningTask(userId);
            var done = await _Db.GetDoneTask(userId);
            var allTasks = new AllTasks()
            {
                ToDo = Todo,
                Doing = Doing,
                Done = done
            };
            return View(allTasks);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}