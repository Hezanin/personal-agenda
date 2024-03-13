using PersonalAgenda.DataAccess.Interfaces;
using PersonalAgenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAgenda.DataAccess.TextFileDataAccess
{
    public class MeetupsFileAccess : IMeetupsFileAccess
    {
        private readonly string filePath;

        private static string LoadFilePath(string id = "MeetupsFile")
        {
            return ConfigurationManager.AppSettings[id];
        }

        public MeetupsFileAccess()
        {
            filePath = LoadFilePath();

            if (filePath == null)
            {
                throw new ArgumentNullException();
            }
        }

        public IEnumerable<Meetup> LoadMeetups()
        {
            List<Meetup> meetups = new List<Meetup>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] values = line.Split(',');

                    var newMeetup = new Meetup()
                    {
                        Name = values[0],
                        Description = values[1],
                        DateAndTime = DateTime.Parse(values[2]),
                        City = values[3],
                        Location = values[4]
                    };

                    meetups.Add(newMeetup);
                }
            }

            return meetups;
        }

        public void AddMeetup(Meetup newMeetup)
        {
            if (newMeetup == null)
            {
                throw new ArgumentNullException();
            }

            string finalMeetup = $"{newMeetup.Name},{newMeetup.Description}," +
                $"{newMeetup.DateAndTime.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)},{newMeetup.City},{newMeetup.Location}";

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(finalMeetup);
            }
        }
    }
}
