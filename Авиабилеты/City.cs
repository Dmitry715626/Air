using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Авиабилеты
{
    class City
    {
        string nameCity;
        public string NameCity
        {
            get
            {
                return nameCity;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    nameCity = value;
                }
            }
        }

        int price;
        public int Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value > 0)
                {
                    price = value;
                }
            }
        }

        public City(string Name, int Price)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                nameCity = Name;
            }

            if (Price > 0)
            {
                price = Price;
            }
        }
    }
}
