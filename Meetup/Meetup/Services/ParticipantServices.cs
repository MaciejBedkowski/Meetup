using AutoMapper;
using Meetup.Entities;
using Meetup.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Services
{
    public interface IParticipantService
    {
        bool Update(int id, UpdateParticipantDto dto);
        bool Delete(int id);
        ParticipantDto GetById(int id);
        IEnumerable<ParticipantDto> GetAll();
        int Create(CreateParticipantDto dto);
    }
    public class ParticipantServices : IParticipantService
    {
        private readonly MeetupDBContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<ParticipantServices> _logger;

        public ParticipantServices(MeetupDBContext dbContext, IMapper mapper, ILogger<ParticipantServices> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public bool Update(int id, UpdateParticipantDto dto)
        {
            var user = _dbContext
                .Participants
                .FirstOrDefault(x => x.Id == id);

            if (user is null)
                return false;

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.EMail = dto.EMail;

            _dbContext.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            _logger.LogError($"Meet with id: {id} DELETE action invoked");

            var user = _dbContext
                .Participants
                .FirstOrDefault(x => x.Id == id);

            if (user is null)
                return false;

            _dbContext.Participants.Remove(user);
            _dbContext.SaveChanges();

            return true;

        }

        public ParticipantDto GetById(int id)
        {
            var user = _dbContext
                .Participants
                .FirstOrDefault(x => x.Id == id);

            if (user is null)
                return null;

            var result = _mapper.Map<ParticipantDto>(user);
            return result;
        }

        public IEnumerable<ParticipantDto> GetAll()
        {
            var users = _dbContext
               .Participants
               .ToList();

            //Mapping
            var usersDtos = _mapper.Map<List<ParticipantDto>>(users);

            return usersDtos;
        }

        public int Create(CreateParticipantDto dto)
        {
            var user = _mapper.Map<Participant>(dto);
            _dbContext.Participants.Add(user);
            _dbContext.SaveChanges();

            return user.Id;
        }
    }
}
