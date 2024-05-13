using System.ComponentModel.DataAnnotations;

namespace API.DTOs 
{
    // LoginDto (Data Transfer Object) is used to encapsulate the data involved in logging in a user.
    public class LoginDto 
    {
        [Required]
        public string Username {get; set; }
        [Required]
        public string Password {get; set; }
    }
}