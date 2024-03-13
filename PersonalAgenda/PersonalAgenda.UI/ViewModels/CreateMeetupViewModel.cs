using Caliburn.Micro;
using PersonalAgenda.DataAccess.TextFileDataAccess;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace PersonalAgenda.UI.ViewModels
{
    class CreateMeetupViewModel : Screen
    {
        private MeetupsFileAccess meetupsFileAccess= new();
        private string nameTextBox;
        private string descriptionTextBox;
        private string locationTextBox;
        private string dateTimeTextBox;
        private string cityTextBox;

        public string NameTextBox
        {
            get { return nameTextBox; }
            set
            {
                nameTextBox = value;
                NotifyOfPropertyChange(() => NameTextBox);
            }
        }

        public string DescriptionTextBox
        {
            get { return descriptionTextBox; }
            set
            {
                descriptionTextBox = value;
                NotifyOfPropertyChange(() => DescriptionTextBox);
            }
        }

        public string LocationTextBox
        {
            get { return locationTextBox; }
            set
            {
                locationTextBox = value;
                NotifyOfPropertyChange(() => LocationTextBox);
            }
        }

        public string DateTimeTextBox
        {
            get { return dateTimeTextBox; }
            set
            {
                dateTimeTextBox = value;
                NotifyOfPropertyChange(() => DateTimeTextBox);
            }
        }

        public string CityTextBox
        {
            get { return cityTextBox; }
            set
            {
                cityTextBox = value;
                NotifyOfPropertyChange(() => CityTextBox);
            }
        }

        public bool CanSaveButton(string nameTextBox, string descriptionTextBox, string locationTextBox,
            string cityTextBox, string dateTimeTextBox)
        {
            string pattern = @"^\d{1,2}/\d{1,2}/\d{4}\s+\d{1,2}:\d{2}:\d{2}\s+(?:AM|PM)$";

            return !String.IsNullOrWhiteSpace(nameTextBox) && !String.IsNullOrWhiteSpace(descriptionTextBox) &&
                !String.IsNullOrWhiteSpace(locationTextBox) && !String.IsNullOrWhiteSpace(cityTextBox) &&
                !String.IsNullOrWhiteSpace(dateTimeTextBox) && Regex.IsMatch(dateTimeTextBox, pattern);
        }

        public void SaveButton(string nameTextBox, string descriptionTextBox, string locationTextBox,
            string cityTextBox, string dateTimeTextBox, string companyNameTextBox)
        {
            try
            {

                this.meetupsFileAccess.AddMeetup(new Domain.Entities.Meetup()
                {
                    Name = NameTextBox,
                    Description = DescriptionTextBox,
                    DateAndTime = DateTime.ParseExact(DateTimeTextBox, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                    Location = LocationTextBox,
                    City = CityTextBox,
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
