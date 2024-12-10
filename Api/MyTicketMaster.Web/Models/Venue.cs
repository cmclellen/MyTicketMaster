using System.ComponentModel.DataAnnotations;

namespace MyTicketMaster.Web.Models
{
    public class Venue
    {
        [Required]
        public string? Name { get; set; }
    }
}
