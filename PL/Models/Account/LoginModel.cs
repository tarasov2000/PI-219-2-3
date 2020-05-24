using System.ComponentModel.DataAnnotations;

namespace PL.Models.Account
{
    public class LoginModel
    {
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}