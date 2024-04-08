using Microsoft.EntityFrameworkCore;
using PersonalAgenda.Domain.Entities;
using PersonalAgenda.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAgenda.EFDataAccess.Repositories
{
    public class MeetingRepository : Repository<Meeting>, IMeetingRepository
    {
        public MeetingRepository(PersonalAgendaContext personalAgendaContext) : base(personalAgendaContext)
        {
        }

        public async Task<IEnumerable<Meeting>> GetMeetingByNameAsync(string meetingName)
        {
            if (meetingName == null)
            {
                throw new ArgumentNullException();
            }

            IQueryable<Meeting> allMeetings = await GetAllAsync();

            return allMeetings.Where(m => m.Name == meetingName).ToList();
        }
    }
}
