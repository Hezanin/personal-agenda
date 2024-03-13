using PersonalAgenda.Domain.Entities;

namespace PersonalAgenda.DataAccess.Interfaces
{
    public interface IMeetingsFileAccess
    {
        void AddMeeting(Meeting newMeeting);
        IEnumerable<Meeting> LoadMeetings();
    }
}