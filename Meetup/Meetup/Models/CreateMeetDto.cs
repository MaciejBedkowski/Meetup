using System;

namespace Meetup.Models
{
    public class CreateMeetDto
    {
        public string Name { get; set; }
        public DateTime DateMeet { get; set; }
        public string InformationAboutMeet { get; set; }
        public string FirstNameLecturer { get; set; }
        public string LastNameLecturer { get; set; }
    }
}
