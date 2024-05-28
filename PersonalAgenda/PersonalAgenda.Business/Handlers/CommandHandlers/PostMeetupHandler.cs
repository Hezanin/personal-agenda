using AutoMapper;
using MediatR;
using PersonalAgenda.Business.Commands;
using PersonalAgenda.Domain.Dtos;
using PersonalAgenda.Domain.Entities;
using PersonalAgenda.EFDataAccess.Repositories;

namespace PersonalAgenda.Business.Handlers.CommandHandlers
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
            if (request.Meetup == null)
            {
                throw new ArgumentNullException(nameof(request.Meetup));
            }

            return mapper.Map<MeetupDto>(await meetupRepository
                .AddAsync(mapper.Map<Meetup>(request.Meetup)));
        }
    }
}
