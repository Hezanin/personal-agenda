using AutoMapper;
using MediatR;
using PersonalAgenda.Business.Queries;
using PersonalAgenda.Domain.Dtos;
using PersonalAgenda.Domain.Entities;
using PersonalAgenda.EFDataAccess.Repositories;
using PersonalAgenda.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAgenda.Business.Handlers.QueryHandlers
{
    public class GetMeetupsHandler : IRequestHandler<GetMeetupsQuery, IEnumerable<MeetupDto>>
    {
        private readonly IRepository<Meetup> meetupRepository;
        private readonly IMapper mapper;

        public GetMeetupsHandler(IRepository<Meetup> repository, IMapper mapper)
        {
            meetupRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IEnumerable<MeetupDto>> Handle(GetMeetupsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<MeetupDto> meetupDtos = mapper.Map<IEnumerable<MeetupDto>>
                (await meetupRepository.GetAllAsync());

            return meetupDtos;
        }
    }
}
