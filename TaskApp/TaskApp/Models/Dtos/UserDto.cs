using System.ComponentModel.DataAnnotations;

namespace TaskApp.Models.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
     
    }
    public class LoginDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        //public bool RememberMe { get; set; }
    }

    public class RegisterUserDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwords Are Not Identical")]
		[Display(Name = "Confirm Password")]
		public string ConfirmPassword { get; set; }
        
    }
}
