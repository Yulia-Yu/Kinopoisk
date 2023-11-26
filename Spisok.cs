using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Курсовой_Проект
{
    class Spisok
    {
        public Actor act = new Actor();
        public Spisok next;
        public Spisok prev;

        Spisok start;
        public Spisok()
        {

        }

        //public Spisok(Actor a)
        //{
        //    act = a;
        //    next = null;
        //    prev = null;
        //}
        public void Add(Actor fil, AVL.Node tree)
        {
            start = tree.coun;
            if (start.act.f == null)
            {
                start.act.f = fil.f;
                start.act.i = fil.i;
                start.act.o = fil.o;
                start.act.name_f = fil.name_f;
                start.act.day = fil.day;
                start.act.month = fil.month;
                start.act.years = fil.years;
                start.next = start;
                start.prev = start;
                tree.coun = start;
            }
            else if (start != null)
            {
                Spisok tmp = null;
                tmp = new Spisok();
                tmp.act.f = fil.f;
                tmp.act.i = fil.i;
                tmp.act.o = fil.o;
                tmp.act.name_f = fil.name_f;
                tmp.act.day = fil.day;
                tmp.act.month = fil.month;
                tmp.act.years = fil.years;
                start.prev.next = tmp;
                tmp.prev = start.prev;
                start.prev = tmp;
                tmp.next = start;
            }

        }

        //public void Del(Actor a, AVL.Node tree)
        //{
        //    if (tree.key.f == a.f && tree.key.i == a.i && tree.key.o == a.o) //&& tree.key.name_f == a.name_f
        //    {
        //        tree.key = start.act;
        //        if (start.next == start)
        //        {
        //            tree.coun = null;
        //        }
        //        else
        //        {
        //            Spisok cur, tmp;
        //            tmp = start.prev;
        //            cur = start;
        //            start = start.next;
        //            start.prev = tmp;
        //            cur = null;
        //        }

        //    }
        //    else if (start.next == start && a.f == start.act.f && a.i == start.act.i && a.o == start.act.o) //&& a.name_f == start.act.name_f
        //    {
        //        tree.coun = null;
        //    }
        //    else
        //    {
        //        Spisok tmp;
        //        tmp = start;
        //        while (tmp != start.prev)
        //        {
        //            if (a.f == tmp.act.f && a.i == tmp.act.i && a.o == tmp.act.o && a.name_f == tmp.act.name_f && a.day == tmp.act.day && a.month == tmp.act.month && a.years == tmp.act.years)
        //            {
        //                if (tmp == start)
        //                {
        //                    Spisok cur, current;
        //                    current = start.prev;
        //                    cur = start;
        //                    start = start.next;
        //                    start.prev = current;
        //                    cur = null;
        //                    break;
        //                }
        //                else
        //                {
        //                    tmp.prev.next = tmp.next;
        //                    tmp.next.prev = tmp.prev;
        //                    tmp = null;
        //                    break;
        //                }

        //            }
        //            tmp = tmp.next;
        //        }
        //        if (tmp == start.prev && a.f == tmp.act.f && a.i == tmp.act.i && a.o == tmp.act.o && a.name_f == tmp.act.name_f && a.day == tmp.act.day && a.month == tmp.act.month && a.years == tmp.act.years)
        //        {
        //            Spisok cur;
        //            cur = start.prev;
        //            start.prev = start.prev.prev;
        //            start.prev.next = start;
        //            cur = null;
        //        }
        //    }
        //}


        public void Del_Ver(AVL.Node tree)
        {
            tree.key = start.act;
            if (start.next == start)
            {
                tree.coun = null;
            }
            else
            {
                Spisok cur, tmp;
                tmp = start.prev;
                cur = start;
                start = start.next;
                start.prev = tmp;
                cur = null;
            }
        }

        public void Del_F(string f, AVL.Node tree)
        {
            if (start.next == start && start.act.name_f == f)
            {
                tree.coun = new Spisok();
            }
            else
            {
                Spisok tmp;
                tmp = start;
                while (tmp != start.prev)
                {
                    if (tmp.act.name_f == f)
                    {
                        if (tmp == start)
                        {
                            Spisok cur, current;
                            current = start.prev;
                            cur = start;
                            start = start.next;
                            start.prev = current;
                            cur = null;
                            break;
                        }
                        else
                        {
                            tmp.prev.next = tmp.next;
                            tmp.next.prev = tmp.prev;
                            tmp = null;
                            break;
                        }

                    }
                    tmp = tmp.next;
                }
                if (tmp == start.prev && tmp.act.name_f == f)
                {
                    Spisok cur;
                    cur = start.prev;
                    start.prev = start.prev.prev;
                    start.prev.next = start;
                    cur = null;
                }
            }
        }

        public void Find(string[] mas)
        {
            int i = 1;
            Spisok tmp;
            if (start != null)
            {
                tmp = start;
                while (tmp != start.prev)
                {
                    mas[i] = tmp.act.name_f;
                    tmp = tmp.next;
                    i++;
                    Program.count++;
                }
                if (tmp == start.prev)
                {
                    mas[i] = tmp.act.name_f;
                    Program.count++;
                }
            }
        }

        public void Find_A(Actor[] mas)
        {
            int i = 1;
            Spisok tmp;
            if (start != null)
            {
                tmp = start;
                while (tmp != start.prev)
                {
                    mas[i] = tmp.act;
                    tmp = tmp.next;
                    i++;
                }
                if (tmp == start.prev)
                {
                    mas[i] = tmp.act;
                }
            }
        }


        public void view_begin() // Вывод списка
        {
            Spisok tmp;
            if (start != null)
            {
                tmp = start;
                while (tmp != start.prev)
                {
                    AVL.mas[AVL.ind] = tmp.act;
                    AVL.ind++;
                    tmp = tmp.next;
                }
                AVL.mas[AVL.ind] = start.prev.act;
                AVL.ind++;

            }
        }

        public void view_begin_file() // Вывод списка
        {
            Spisok tmp;
            if (start != null)
            {
                tmp = start;
                while (tmp != start.prev)
                {
                    string str = tmp.act.i + " | " + tmp.act.f + " | " + tmp.act.o + " | " + tmp.act.name_f + " | " + tmp.act.day + "." + tmp.act.month + "." + tmp.act.years + "\n";
                    File.AppendAllText("Актеры.txt", str);
                    tmp = tmp.next;
                }
                File.AppendAllText("Актеры.txt", start.prev.act.i + " | " + start.prev.act.f + " | " + start.prev.act.o + " | " + start.prev.act.name_f + " | " + start.prev.act.day + "." + start.prev.act.month + "." + start.prev.act.years + "\n");
            }
        }

        public void Clear(AVL.Node tree)
        {
            Spisok s = new Spisok();
            tree.coun = s;
        }
    }
}
