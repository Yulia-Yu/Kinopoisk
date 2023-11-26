using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовой_Проект
{
    class Film
    {
        public string name_f;
        public string genre;
        public int date;
        public int status;


        public Film()
        {
            name_f = " ";
            genre = " ";
            date = 0;
            status = 0;
        }

        public Film(string nf, string g, int d)
        {
            name_f = nf;
            genre = g;
            date = d;
        }

        public void WriteF()
        {
            Console.WriteLine("\"" + name_f + "\"" + " " + genre + " " + date);
        }
    }
}
