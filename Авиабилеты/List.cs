using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Авиабилеты
{
    static class List
    {
        static List<City> City = new List<City>();

        public static List<City> ListCity { get { return City; } set { City = value; } }

        public static City chosenCity;

        public static void Add(City city)
        {
            if (city != null)
            {
                ListCity.Add(city);
            }
        }

        public static string Show(int i)
        {
            return City.ElementAt(i).NameCity;
        }
    }
}
