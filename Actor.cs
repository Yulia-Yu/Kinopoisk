using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовой_Проект
{
    class Actor
    {
        public string f;
        public string i;
        public string o;

        public string name_f;

        public int day;
        public int month;
        public int years;

        public Actor()
        {
            f = null;
            i = null;
            o = null;
            name_f = null;
            day = 0;
            month = 0;
            years = 0;
        }
        public Actor(string im, string ot, string fam, string nf, int d, int m, int y)
        {
            f = fam;
            i = im;
            o = ot;
            name_f = nf;
            day = d;
            month = m;
            years = y;
        }

        public Actor(string fam, string im, string ot)
        {
            f = fam;
            i = im;
            o = ot;
            name_f = " ";
            day = 0;
            month = 0;
            years = 0;
        }

        public Actor(string fam, string im, string ot, string n)
        {
            f = fam;
            i = im;
            o = ot;
            name_f = n;
            day = 0;
            month = 0;
            years = 0;
        }
    }
}
