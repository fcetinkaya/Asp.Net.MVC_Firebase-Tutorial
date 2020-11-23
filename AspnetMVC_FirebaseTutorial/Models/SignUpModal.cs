using System.ComponentModel.DataAnnotations;

namespace AspnetMVC_FirebaseTutorial.Models
{
    public class SignUpModal
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name ="Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }
}