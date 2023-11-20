using Microsoft.AspNetCore.Identity;

namespace TaskApp.Models
{
    public class ApplicationUser: IdentityUser
    {

        //np
        public List<MyTask>? Tasks { get; set; }

    }
}
