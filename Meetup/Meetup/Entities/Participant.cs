namespace Meetup.Entities
{
    public class Participant
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }

        //foreign key
        public int MeetId { get; set; }
        public virtual Meet Meet { get; set; }
    }
}
