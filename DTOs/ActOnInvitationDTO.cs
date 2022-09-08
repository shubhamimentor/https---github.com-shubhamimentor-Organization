using System;
using System.ComponentModel.DataAnnotations;
using Org.Models;
using AutoMapper;
namespace Org.DTOs

{
    public class ActOnInvitationDTO
    {
        
        [Required]
        public Guid Id{ get; set; }
        [Required]
        public InvitationAction Response { get; set; }
        public string Username { get; set; }

        public String? Remark { get; set; }

    }
}
