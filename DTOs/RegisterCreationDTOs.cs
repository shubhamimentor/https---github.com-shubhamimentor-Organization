using System;
using System.ComponentModel.DataAnnotations;

namespace Org.DTOs
{
    public class RegisterCreationDTOs
    {
        [Required(ErrorMessage = "The field with name {0} is required")]
        
        public int OrgId { get; set; }

        [Required(ErrorMessage = "The field with name {0} is required")]
        [StringLength(50)]
        public string Username { get; set; }

        [Required(ErrorMessage = "The field with name {0} is required")]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }

       [Required(ErrorMessage = "The field with name {0} is required")]
       public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "The field with name {0} is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field with name {0} is required")]
        public long Phonenumber { get; set; }

        [Required(ErrorMessage = "The field with name {0} is required")]
        public string Location { get; set; }

       

    }
}
