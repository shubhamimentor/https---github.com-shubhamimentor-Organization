using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;

namespace Org.Models
{
    public class Invite
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; }
        
        [Required]

        public int FromOrgId { get; set; }

        [Required]
        public int ToOrgId { get; set; }
        [Required]
        public string Message { get;  set; }

        public string Relationship_type { get;  set; }
        public DateTime InviteDate { get;  set; }

        public string Status { get; set; }

        
    }
}
