namespace Org.Models
{
    public class Cancelnvitation
    {
        public int ToOrgId { get; set; }

        public string Relationship_type { get; set; }

        public IsCancelled Response { get; set; }
    }
}
