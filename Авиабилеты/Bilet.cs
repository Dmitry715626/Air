using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Авиабилеты
{
    class Bilet
    {
        public string name { get; set; }
        public string fam;
        public string oth;
        public DateTime time;
        public bool child;
        string city;
        int age;
        public int sale;

        public string City
        {
            get
            {
                return city;
            }

            set
            {
                city = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                age = AGE(time);
            }
        }


        public Bilet(string Name, string Fam, string Oth, DateTime Time, bool Child)
        {
            name = Name;
            fam = Fam;
            oth = Oth;
            time = Time;
            age = AGE(Time);
            child = Child;
            sale = child == true ? CreateSale(age) : 0;
        }

        private int AGE(DateTime time)
        {
            return DateTime.Today.Year - time.Year;
        }

        public int CreateSale(int age)
        {
            if (age < 2)
            {
                return 100;
            }
            else if (age >= 2 && age <= 12)
            {
                return 50;
            }
            else
            {
                return 0;
            }
        }

        public string[] ShowTicket(int i)
        {
            string[] arr = new string[6];
            arr[0] = BiletList.Show(i).fam;
            arr[1] = BiletList.Show(i).name;
            arr[2] = BiletList.Show(i).oth;
            arr[3] = Convert.ToString(BiletList.Show(i).age);
            arr[4] = Convert.ToString(BiletList.Show(i).sale);
            arr[5] = Convert.ToString(BiletList.Show(i).child);

            return arr;
        }

        public string ShowTicket(int i, int j)
        {
            string[] arr = new string[6];
            arr[0] = BiletList.Show(i).fam;
            arr[1] = BiletList.Show(i).name;
            arr[2] = BiletList.Show(i).oth;
            arr[3] = Convert.ToString(BiletList.Show(i).age);
            arr[4] = Convert.ToString(BiletList.Show(i).sale);
            arr[5] = Convert.ToString(BiletList.Show(i).child);

            return arr[j];
        }
    }
}
