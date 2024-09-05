using System.ComponentModel.DataAnnotations;

namespace UserLogin.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="Name is Required.")] 
        [MaxLength(10, ErrorMessage="Length must be leass then 10 chareacters")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Email is Required.")]
        [EmailAddress(ErrorMessage = "Invaild Email Format.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is Required.")]
        [MinLength(6, ErrorMessage ="Password Must be atleast 6 characters.")]
        public string? Password { get; set; }
      

    }
}
