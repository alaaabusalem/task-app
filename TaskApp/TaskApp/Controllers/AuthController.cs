using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskApp.Models.Dtos;
using TaskApp.Models.Interfaces;

namespace TaskApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUser _context;


        public AuthController(IUser context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();

        }

        public IActionResult SignUp()
        {
            RegisterUserDto regUser = new RegisterUserDto();
            return View(regUser);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterUserDto regUser)
        {
            await _context.Register(regUser,this.ModelState);
            if (!ModelState.IsValid)
            {
                return View(regUser);
            }
            
            return RedirectToAction("Index", "Home");

        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _context.Login(loginDto);
            if(user != null)
            return RedirectToAction("Index", "Home");
            return View(loginDto);  

        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            

            return View();
           

        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _context.Logout();
            
            return RedirectToAction("Index", "Home");
        }
    }
}
