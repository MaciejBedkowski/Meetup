using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Models
{
    public class MeetDto
    {
        //sensitive data can not be presented and not shared with api clients
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateMeet { get; set; }
        public string InformationAboutMeet { get; set; }
        public string FirstNameLecturer { get; set; }
        public string LastNameLecturer { get; set; }

        public List<ParticipantDto> Participants { get; set; }
    }
}
