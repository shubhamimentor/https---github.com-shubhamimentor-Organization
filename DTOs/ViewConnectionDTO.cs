using System;
using System.ComponentModel.DataAnnotations;

namespace Org.DTOs
{
    public class ViewConnectionDTO
    {
        
        [Required]
        public string Username { get; set; }
        [Required]
        public string Relationship_type { get; set; }
    }
}
