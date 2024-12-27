using System.ComponentModel.DataAnnotations;

namespace OnlineEdu.WebUI.DTOs.UserDtos
{
    public class UserRegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Passowrd { get; set; }

        [Compare("Passowrd",ErrorMessage ="Şifreler Birbiriyle uyumlu değildir.")]
        public string ConfirmPassword { get; set; }
    }
}
