using System.ComponentModel.DataAnnotations;

namespace Meetup.Models
{
    public class UpdateParticipantDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string EMail { get; set; }
    }
}
