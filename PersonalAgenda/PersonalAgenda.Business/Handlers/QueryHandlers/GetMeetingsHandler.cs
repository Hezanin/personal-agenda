using AutoMapper;
using MediatR;
using PersonalAgenda.Business.Queries;
using PersonalAgenda.Domain.Dtos;
using PersonalAgenda.Domain.Entities;
using PersonalAgenda.EFDataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAgenda.Business.Handlers.QueryHandlers
{
    public class GetMeetingsHandler : IRequestHandler<GetMeetingsQuery, IEnumerable<MeetingDto>>
    {
        private readonly IMeetingRepository meetingRepository;
        private readonly IMapper mapper;

        public GetMeetingsHandler(IMeetingRepository meetingRepository, IMapper mapper)
        {
            this.meetingRepository = meetingRepository ?? throw new ArgumentNullException(nameof(meetingRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<MeetingDto>> Handle(GetMeetingsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<MeetingDto> meetingDtos = mapper.Map<IEnumerable<MeetingDto>>
                (await meetingRepository.GetAllAsync());

            return meetingDtos;
        }
    }
}
