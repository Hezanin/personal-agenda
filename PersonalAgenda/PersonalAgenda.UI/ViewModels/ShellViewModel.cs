using Caliburn.Micro;
using PersonalAgenda.DataAccess.TextFileDataAccess;
using PersonalAgenda.Domain.Enums;
using PersonalAgenda.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAgenda.UI.ViewModels
{
    public class ShellViewModel : Screen
    {
        private WindowManager WindowManager = new();
        private MeetingsFileAccess meetingsFileAccess = new();
        private MeetupsFileAccess meetupsFileAccess = new();
        private ShoppingsFileAccess shoppingsFileAccess = new();

        private ErrandsEnum selectedErrandType;
        private BindableCollection<ErrandsEnum> errandTypeListComboBox;
        private BindableCollection<IErrand> errandsListBox;

        public BindableCollection<ErrandsEnum> ErrandTypeListComboBox
        {
            get { return errandTypeListComboBox; }
            set { errandTypeListComboBox = value; }
        }
        public BindableCollection<IErrand> ErrandsListBox
        {
            get { return errandsListBox; }
            set { errandsListBox = value;
                NotifyOfPropertyChange(() => ErrandsListBox);
            }
        }
        public ErrandsEnum SelectedErrandType
        {
            get { return selectedErrandType; }
            set { selectedErrandType = value;
                NotifyOfPropertyChange (() => SelectedErrandType);
            }
        }

        public ShellViewModel()
        {
           Init();
        }

        private void Init()
        {
            ErrandTypeListComboBox = new BindableCollection<ErrandsEnum>
                (Enum.GetValues(typeof(ErrandsEnum)).Cast<ErrandsEnum>());
            ErrandsListBox = new BindableCollection<IErrand>();
        }

        public void OpenNewMeetingWindow()
        {
            this.WindowManager.ShowWindowAsync(new CreateMeetingViewModel());
        }

        public void OpenNewMeetupWindow()
        {
            this.WindowManager.ShowWindowAsync(new CreateMeetupViewModel());
        }

        public void OpenNewShoppingWindow()
        {
            this.WindowManager.ShowWindowAsync(new CreateShoppingViewModel());
        }

        public void LoadErrandsButton()
        {
            ErrandsListBox.Clear();

            switch (SelectedErrandType)
            {
                case ErrandsEnum.Meeting:

                    var meetingsList = meetingsFileAccess.LoadMeetings();

                    if (meetingsList == null)
                    {
                        return;
                    }

                    ErrandsListBox.AddRange(meetingsList);

                    break;
                case ErrandsEnum.Meetup:

                    var meetupsList = meetupsFileAccess.LoadMeetups();

                    if (meetupsList == null)
                    {
                        return;
                    }

                    ErrandsListBox.AddRange(meetupsList);

                    break;
                case ErrandsEnum.Shopping:

                    var shoppingsList = shoppingsFileAccess.LoadShoppings();

                    if (shoppingsList == null)
                    {
                        return;
                    }

                    ErrandsListBox.AddRange(shoppingsList);

                    break;
                default:
                    break;
            }
        }
    }
}
