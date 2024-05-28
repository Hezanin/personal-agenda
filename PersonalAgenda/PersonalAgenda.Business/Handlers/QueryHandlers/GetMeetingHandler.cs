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
    public class GetMeetingHandler : IRequestHandler<GetMeetingQuery, MeetingDto>
    {
        private readonly IMeetingRepository meetingRepository;
        private readonly IMapper mapper;

        public GetMeetingHandler(IMeetingRepository meetingRepository, IMapper mapper)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.meetingRepository = meetingRepository ?? throw new ArgumentNullException(nameof(meetingRepository));
        }

        public async Task<MeetingDto> Handle(GetMeetingQuery request, CancellationToken cancellationToken)
        {
            Meeting meeting = await meetingRepository.GetByIdAsync(request.Id);

            return mapper.Map<MeetingDto>(meeting);
        }
    }
}
