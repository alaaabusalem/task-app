using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TaskApp.Data;
using TaskApp.Models.Dtos;
using TaskApp.Models.Interfaces;

namespace TaskApp.Models.Services
{
    public class UserService:IUser
    {
        private UserManager<ApplicationUser> _userManager;

        private SignInManager<ApplicationUser> _signManager;
        private readonly TaskDbContext _DB;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signManager,TaskDbContext db)
        {
            _userManager = userManager;
			_signManager = signManager;
            _DB= db;    
        }
        public async Task<RegisterUserDto> Register(RegisterUserDto registerUser, ModelStateDictionary modelState)
        {
            var user = (ApplicationUser)registerUser;
            var result = await _userManager.CreateAsync(user, registerUser.Password);
            if (result.Succeeded) {
                return registerUser;
            
            }
            foreach (var error in result.Errors)
            {
                var errorKey = error.Code.Contains("Password") ? nameof(registerUser.Password) :
                         error.Code.Contains("Email") ? nameof(registerUser.Email) :
                         error.Code.Contains("Username") ? nameof(registerUser.Name) :
                         error.Code.Contains("PhoneNumber") ? nameof(registerUser.Phone) :

                         "";

                modelState.AddModelError(errorKey, error.Description);
            }
            return registerUser;
        }

        public async Task<UserDto> Login(LoginDto loginDto)
        {
            var result = await _signManager.PasswordSignInAsync(loginDto.Name, loginDto.Password, true, false);
            if (result.Succeeded)
            {

                var user = await _userManager.FindByNameAsync(loginDto.Name);
               
                  return new UserDto()
                  {
                      Id=user.Id,
                    UserName=user.UserName,
                    Email=user.Email,   
                    Phone=user.PhoneNumber,
    };

            }
            return null;
        }

        public async Task Logout()
        {
            await _signManager.SignOutAsync();
        }
    }
}
