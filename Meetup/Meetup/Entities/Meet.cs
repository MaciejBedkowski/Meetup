using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Entities
{
    public class Meet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateMeet { get; set; }
        public string InformationAboutMeet { get; set; }
        public string FirstNameLecturer { get; set; }
        public string LastNameLecturer { get; set; }
        public virtual List<Participant> Participant {get; set;}
    }
}
