using AutoMapper;
using Meetup.Entities;
using Meetup.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Meetup.Services
{
    public interface IMeetService
    {
        bool Update(int id, UpdateMeetDto dto);
        bool Delete(int id);
        MeetDto GetById(int id);
        IEnumerable<MeetDto> GetAll();
        int Create(CreateMeetDto dto);
    }
    public class MeetServices : IMeetService
    {
        private readonly MeetupDBContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<MeetServices> _logger;
        public MeetServices(MeetupDBContext dbContext, IMapper mapper, ILogger<MeetServices> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public bool Update(int id, UpdateMeetDto dto)
        {
            var meet = _dbContext
                .Meets
                .FirstOrDefault(x => x.Id == id);

            if (meet is null)
                return false;

            meet.Name = dto.Name;
            meet.InformationAboutMeet = dto.InformationAboutMeet;
            meet.DateMeet = dto.DateMeet;

            _dbContext.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            _logger.LogError($"Meet with id: {id} DELETE action invoked");

            var meet = _dbContext
                .Meets
                .FirstOrDefault(x => x.Id == id);

            //var users = _dbContext
            //    .Participants
            //    .All(y => y.MeetId == id);

            if (meet is null)
                return false;

            //foreach(var user in users)
            var allParticipant = _dbContext.Participants.Where(x => x.MeetId == id);

            foreach(var user in allParticipant)
            {
                _dbContext.Participants.Remove(user);
            }

            _dbContext.Meets.Remove(meet);
            _dbContext.SaveChanges();

            return true;

        }
        public MeetDto GetById (int id)
        {
            var meet = _dbContext
                .Meets
                .FirstOrDefault(x => x.Id == id);

            if (meet is null) 
                return null;

            var result = _mapper.Map<MeetDto>(meet);
            return result;
        }

        public IEnumerable<MeetDto> GetAll()
        {
            var meets = _dbContext
               .Meets
               .ToList();

            //Mapping
            var meetsDtos = _mapper.Map<List<MeetDto>>(meets);

            return meetsDtos;
        }

        public int Create(CreateMeetDto dto)
        {
            var meet = _mapper.Map<Meet>(dto);
            _dbContext.Meets.Add(meet);
            _dbContext.SaveChanges();

            return meet.Id;
        }
    }
}
