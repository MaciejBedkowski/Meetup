namespace Meetup.Models
{
    public class CreateParticipantDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public int MeetId { get; set; }
    }
}
