using System.ComponentModel.DataAnnotations;

namespace PL.Models.Account
{
    public class RegistrationModel
    {
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Address { get; set; }
        [Required]
        public string Name { get; set; }
    }
}