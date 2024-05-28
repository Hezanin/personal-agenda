using MediatR;
using PersonalAgenda.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAgenda.Business.Commands
{
    public record PostMeetupCommand(MeetupDto RequestedMeetup) : IRequest<MeetupDto>;
}
