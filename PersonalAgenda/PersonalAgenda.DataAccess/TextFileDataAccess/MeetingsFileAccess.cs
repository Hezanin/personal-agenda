using PersonalAgenda.Domain.Entities;
using System.Configuration;
using System.Globalization;
using PersonalAgenda.DataAccess.Interfaces;

namespace PersonalAgenda.DataAccess.TextFileDataAccess
{
    public class MeetingsFileAccess : IMeetingsFileAccess
    {
        private readonly string filePath;

        private static string LoadFilePath(string id = "MeetingsFile")
        {
            return ConfigurationManager.AppSettings[id];
        }

        public MeetingsFileAccess()
        {
            filePath = LoadFilePath();

            if (filePath == null)
            {
                throw new ArgumentNullException();
            }
        }

        public IEnumerable<Meeting> LoadMeetings()
        {
            List<Meeting> meetings = new List<Meeting>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] values = line.Split(',');

                    var newMeeting = new Meeting()
                    {
                        Name = values[0],
                        Description = values[1],
                        Location = values[2],
                        DateAndTime = DateTime.ParseExact(values[3], "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        City = values[4],
                        CompanyName = values[5]
                    };

                    meetings.Add(newMeeting);
                }
            }

            return meetings;
        }

        public void AddMeeting(Meeting newMeeting)
        {
            if (newMeeting == null)
            {
                throw new ArgumentNullException();
            }

            string finalMeeting = $"{newMeeting.Name},{newMeeting.Description},{newMeeting.Location}," +
                $"{newMeeting.DateAndTime.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)},{newMeeting.City},{newMeeting.CompanyName}";

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(finalMeeting);
            }
        }
    }
}
