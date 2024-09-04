using System.ComponentModel.DataAnnotations;

namespace UserLogin.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required] 
        [MaxLength(10, ErrorMessage="Length must be leass then 10 chareacters")]
        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
      

    }
}
