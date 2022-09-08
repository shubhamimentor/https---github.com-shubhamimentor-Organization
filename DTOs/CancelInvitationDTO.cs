using Org.Models;

namespace Org.DTOs
{
    public class CancelInvitationDTO
    {
        public int ToOrgId { get; set; }

        public string Relationship_type { get; set; }

        public IsCancelled Response { get; set; }
    }
}
