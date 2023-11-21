using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskApp.Models;
using TaskApp.Models.Dtos;
using TaskApp.Models.Interfaces;

namespace TaskApp.Controllers
{
    public class MyTaskController : Controller
    {
        private readonly  IMyTask _Db;
        public MyTaskController(IMyTask db)
        {
            _Db = db;
        }
        // GET: MyTaskController
        public async Task<ActionResult> Index()
        {
            return View();


        }
        [Authorize]
        public async Task<ActionResult> ToDo()
        {
            var userId=  User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tasks = await _Db.GetToDoTask(userId);
            return View(tasks);


        }
        [Authorize]
        public async Task<ActionResult> OnGoing()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tasks = await _Db.GetOngoningTask(userId);
            return View(tasks);


        }
        [Authorize]
        public async Task<ActionResult> Done()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tasks = await _Db.GetDoneTask(userId);
            return View(tasks);


        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult> CreateTask()
        {
            var task = new CreateMyTask();
            task.Tasks = await _Db.TaskStatuses();
            return View(task);


        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateTask(CreateMyTask createMyTask)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tasks = await _Db.create(createMyTask,userId);
            return RedirectToAction("ToDo");


        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> UpdateTask(int id)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var task = await _Db.GetTask(userId, id);
            if (task != null)
            {
                task.Tasks = await _Db.TaskStatuses();
                return View(task);
            }
            else return RedirectToAction("Index", "Home");


        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> UpdateTask(UpdateMyTask updateMyTask)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tasks = await _Db.Update(updateMyTask, userId);
            return RedirectToAction("ToDo");


        }


        [Authorize]
        
        public async Task<ActionResult> DeleteTask(int id )
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tasks = await _Db.delete( id, userId);
            return RedirectToAction("ToDo");


        }


    }
}
