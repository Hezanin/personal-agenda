using AutoMapper;
using PersonalAgenda.Domain.Dtos;
using PersonalAgenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAgenda.Business
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Meeting, MeetingDto>();
            CreateMap<MeetupDto, Meeting>();

            CreateMap<Meetup, MeetupDto>();
            CreateMap<MeetupDto, Meetup>();
            
            CreateMap<Shopping, ShoppingDto>();
            CreateMap<ShoppingDto, Shopping>();
        }
    }
}
