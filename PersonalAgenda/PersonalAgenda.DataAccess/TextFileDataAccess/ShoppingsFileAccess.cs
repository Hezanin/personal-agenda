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
    public class ShoppingsFileAccess : IShoppingsFileAccess
    {
        private readonly string filePath;

        private static string LoadFilePath(string id = "ShoppingsFile")
        {
            return ConfigurationManager.AppSettings[id];
        }

        public ShoppingsFileAccess()
        {
            filePath = LoadFilePath();

            if (filePath == null)
            {
                throw new ArgumentNullException();
            }
        }

        public IEnumerable<Shopping> LoadShoppings()
        {
            List<Shopping> shoppings = new List<Shopping>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] values = line.Split(',');

                    var newShopping = new Shopping()
                    {
                        Name = values[0],
                        Description = values[1],
                        Location = values[2],
                        Budget = decimal.Parse(values[3], CultureInfo.InvariantCulture)
                    };

                    shoppings.Add(newShopping);
                }
            }

            return shoppings;
        }

        public void AddShopping(Shopping newShopping)
        {
            if (newShopping == null)
            {
                throw new ArgumentNullException();
            }

            string finalShopping = $"{newShopping.Name},{newShopping.Description}," +
                $"{newShopping.Location},{newShopping.Budget.ToString(CultureInfo.InvariantCulture)}";

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(finalShopping);
            }
        }
    }
}
