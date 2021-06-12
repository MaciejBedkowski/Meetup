using Meetup.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Models
{
    public class ParticipantDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(25)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string EMail { get; set; }

        public int MeetId { get; set; }
        public virtual Meet Meet { get; set; }
    }
}
