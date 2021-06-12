using System;
using System.ComponentModel.DataAnnotations;

namespace Meetup.Models
{
    public class UpdateMeetDto
    {
        [Required]
        public string Name { get; set; }
        public string InformationAboutMeet { get; set; }
        [Required]
        public DateTime DateMeet { get; set; }

    }
}
