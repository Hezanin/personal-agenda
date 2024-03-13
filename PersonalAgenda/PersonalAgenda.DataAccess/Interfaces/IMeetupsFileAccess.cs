using PersonalAgenda.Domain.Entities;

namespace PersonalAgenda.DataAccess.Interfaces
{
    public interface IMeetupsFileAccess
    {
        void AddMeetup(Meetup newMeetup);
        IEnumerable<Meetup> LoadMeetups();
    }
}