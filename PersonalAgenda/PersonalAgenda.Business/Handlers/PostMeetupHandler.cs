using AutoMapper;
using MediatR;
using PersonalAgenda.Business.Commands;
using PersonalAgenda.Domain.Dtos;
using PersonalAgenda.Domain.Entities;
using PersonalAgenda.EFDataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAgenda.Business.Handlers
{
    public class PostMeetupHandler : IRequestHandler<PostMeetupCommand, MeetupDto>
    {
        private readonly IRepository<Meetup> meetupRepository;
        private readonly IMapper mapper;

        public PostMeetupHandler(IRepository<Meetup> meetupRepository, IMapper mapper)
        {
            this.meetupRepository = meetupRepository ?? throw new ArgumentNullException(nameof(meetupRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<MeetupDto> Handle(PostMeetupCommand request, CancellationToken cancellationToken)
        {
            if (request.RequestedMeetup == null)
            {
                throw new ArgumentNullException(nameof(request.RequestedMeetup));
            }

            Meetup meetup = mapper.Map<Meetup>(request.RequestedMeetup); 

            return this.mapper.Map<MeetupDto>(await this.meetupRepository.AddAsync(meetup));
        }
    }
}
