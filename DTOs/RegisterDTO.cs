using System;
using System.ComponentModel.DataAnnotations;

namespace Org.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int OrgId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public long Password { get; set; }
        [Required]
        public long ConfirmPassword { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public long Phonenumber { get; set; }
        [Required]
        public string Location { get; set; }
       
    }
}
