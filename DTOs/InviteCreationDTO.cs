using Org.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Org.DTOs
{
    public class InviteCreationDTO
    {   [Key]
        public Guid Id { get; set; }
        [Required]
        public int FromOrgId { get; set; }
        [Required]
        public int ToOrgId { get; set; }
        [Required]
        public string Message { get;  set; }
        [Required]
        public string Relationship_type { get;  set; }
        [Required]
        public DateTime InviteDate { get; set; }
        public string Status { get; set; }

    }
}
