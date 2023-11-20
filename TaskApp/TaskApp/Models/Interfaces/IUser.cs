using Microsoft.AspNetCore.Mvc.ModelBinding;
using TaskApp.Models.Dtos;

namespace TaskApp.Models.Interfaces
{
    public interface IUser
    {
        Task<RegisterUserDto> Register(RegisterUserDto registerUser, ModelStateDictionary modelState);
        Task<UserDto> Login(LoginDto loginDto);
        Task Logout();
    }
}
