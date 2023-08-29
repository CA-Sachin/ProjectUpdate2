using System.ComponentModel.DataAnnotations;

namespace ProjectUpdateApp.Dto
{
    public class UserDto
    { public Guid Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]

        public string Password { get; set; }
        public string Repeat_Password { get; set; }

       
    }
}
