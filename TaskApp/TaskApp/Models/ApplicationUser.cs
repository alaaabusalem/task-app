using Microsoft.AspNetCore.Identity;
using TaskApp.Models.Dtos;

namespace TaskApp.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string name { get; set; }

        //np
        public List<MyTask>? Tasks { get; set; }

        public static explicit operator ApplicationUser(RegisterUserDto user)
        {
            return new ApplicationUser
            {
                name= user.Name,    
                UserName = user.Email,
                Email = user.Email,

            };
        }

    }
}
