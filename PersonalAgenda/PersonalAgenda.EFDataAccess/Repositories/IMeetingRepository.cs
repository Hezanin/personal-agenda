using PersonalAgenda.Domain.Entities;
using PersonalAgenda.Interfaces;

namespace PersonalAgenda.EFDataAccess.Repositories
{
    public interface IMeetingRepository : IRepository<Meeting>
    {
        public Task<IEnumerable<Meeting>> GetMeetingByNameAsync(string meetingName);
    }
}