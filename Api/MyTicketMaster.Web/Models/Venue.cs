using System.ComponentModel.DataAnnotations;

namespace MyTicketMaster.Web.Models
{
    public class Venue
    {
        public Guid Id { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}
