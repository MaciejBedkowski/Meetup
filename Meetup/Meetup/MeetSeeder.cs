using Meetup.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Meetup
{
    public class MeetSeeder
    {
        private readonly MeetupDBContext _dbContext;
        public MeetSeeder(MeetupDBContext dbContext )
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if(_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Meets.Any())
                {
                    //adding a primary meet if there is no meet in the database
                    var meets = GetMeets();
                    _dbContext.Meets.AddRange(meets);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Meet> GetMeets()
        {
            var meets = new List<Meet>()
            {
                new Meet()
            {
                Name = "Common room",
                DateMeet = DateTime.Now,
                InformationAboutMeet = "If you want to meet and study",
                FirstNameLecturer = "Maciej",
                LastNameLecturer = "Będkowski"
            }
                };

            return meets;
        }
    }
}
