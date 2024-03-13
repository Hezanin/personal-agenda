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
    class CreateShoppingViewModel : Screen  
    {
        private ShoppingsFileAccess shoppingsFileAccess= new();
        private string nameTextBox;
        private string descriptionTextBox;
        private string locationTextBox;
        private string budgetTextBox;

        public string BudgetTextBox
        {
            get { return budgetTextBox; }
            set { budgetTextBox = value; }
        }

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

        public bool CanSaveButton(string nameTextBox, string descriptionTextBox, string locationTextBox,
            string budgetTextBox)
        {
            string pattern = @"^\d+(\.\d+)?$";

            return !String.IsNullOrWhiteSpace(nameTextBox) && !String.IsNullOrWhiteSpace(descriptionTextBox) &&
                !String.IsNullOrWhiteSpace(locationTextBox) && !String.IsNullOrWhiteSpace(budgetTextBox) &&
                Regex.IsMatch(budgetTextBox, pattern);
        }

        public void SaveButton(string nameTextBox, string descriptionTextBox, string locationTextBox,
            string budgetTextBox)
        {            
            try
            {
                this.shoppingsFileAccess.AddShopping(new Domain.Entities.Shopping()
                {
                    Name = NameTextBox,
                    Description = DescriptionTextBox,
                    Location = LocationTextBox,
                    Budget = Decimal.Parse(BudgetTextBox, CultureInfo.InvariantCulture)
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
