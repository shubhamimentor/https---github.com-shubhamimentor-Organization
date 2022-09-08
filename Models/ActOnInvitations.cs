using Org.Models;
using System;
namespace Org.Models
{
    public class ActOnInvitations 
    {
        public Guid Id { get; set; }
        public string Username { get; set; }

        public InvitationAction Response { get; set; }
        public string? Remark { get; set; }
      
    }
}
