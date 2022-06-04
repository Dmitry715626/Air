using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Авиабилеты
{
    static class BiletList
    {
        static List<Bilet> listBilet = new List<Bilet>();


        public static int numberOfPeople;
        public static int numberOfChildren;
        public static void Add(Bilet ticket)
        {
            listBilet.Add(ticket);
        }

        public static Bilet Show(int i)
        {
            return listBilet.ElementAt(i);
        }

        public static int TicketListCount()
        {
            return listBilet.Count;
        }
    }
}
