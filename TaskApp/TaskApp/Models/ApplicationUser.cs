using Microsoft.AspNetCore.Identity;
using TaskApp.Models.Dtos;

namespace TaskApp.Models
{
    public class ApplicationUser: IdentityUser
    {

        //np
        public List<MyTask>? Tasks { get; set; }

        public static explicit operator ApplicationUser(RegisterUserDto user)
        {
            return new ApplicationUser
            {
                UserName = user.Name,
                Email = user.Email,
                PhoneNumber = user.Phone,

            };
        }

    }
}
