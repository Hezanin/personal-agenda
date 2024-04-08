using MediatR;
using PersonalAgenda.Business.Queries;
using PersonalAgenda.Domain.Dtos;
using PersonalAgenda.EFDataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAgenda.Business.Handlers
{
    public class GetMeetingsHandler : IRequestHandler<GetMeetingsQuery, IEnumerable<MeetingDto>>
    {
        public readonly IMeetingRepository meetingRepository;

        public GetMeetingsHandler(IMeetingRepository meetingRepository)
        {
            this.meetingRepository = meetingRepository ?? throw new ArgumentNullException(nameof(meetingRepository));
        }

        public Task<IEnumerable<MeetingDto>> Handle(GetMeetingsQuery request, CancellationToken cancellationToken)
        {
            
            throw new NotImplementedException();
        }
    }
}
