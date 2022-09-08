using System.ComponentModel.DataAnnotations;
using System.Data;
namespace Org.Models
{
    public class Authenticate
    {
        
        public int id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
