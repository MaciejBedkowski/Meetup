using AutoMapper;
using Meetup.Entities;
using Meetup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup
{
    public class MeetMappingProfile : Profile
    {
        public MeetMappingProfile()
        {
            CreateMap<Meet, MeetDto>();

            CreateMap<Participant, ParticipantDto>();

            CreateMap<CreateMeetDto, Meet>();

            CreateMap<CreateParticipantDto, Participant>();

            CreateMap<Meet, CreateMeetDto>();

            CreateMap<ParticipantDto, CreateParticipantDto>();

        }
    }
}
