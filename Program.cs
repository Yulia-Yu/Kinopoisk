using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

//Исправить счетчик при поиске
//Сделать красивый вывод дерева
//Изменить фаил так чтобы жанров могло быть несколько(Поставить | черточку)
namespace Курсовой_Проект
{
    static class Program
    {
        static public HeshT table = new HeshT(100); // Не забыть поменять при проверке в форме 3 и форме 6
        static public AVL tree = new AVL();
        static string[] file_a = File.ReadAllLines("actor.txt");
        static string[] file_f = File.ReadAllLines("film.txt");
        static public int count = 0;
        static void Read_f1(Actor[] mas)
        {
            int coun = 0;
            foreach (string i in file_a)
            {
                int ind = i.IndexOf("|");
                mas[coun].i = i.Substring(0, ind - 1);
                string k = i.Remove(0, ind + 2);

                ind = k.IndexOf("|");
                mas[coun].f = k.Substring(0, ind - 1);
                k = k.Remove(0, ind + 2);

                ind = k.IndexOf("|");
                mas[coun].o = k.Substring(0, ind - 1);
                k = k.Remove(0, ind + 2);

                ind = k.IndexOf("|");
                mas[coun].name_f = k.Substring(0, ind - 1);
                k = k.Remove(0, ind + 2);

                ind = k.IndexOf(".");
                string str = k.Substring(0, ind);
                mas[coun].day = int.Parse(str);
                k = k.Remove(0, ind + 1);

                ind = k.IndexOf(".");
                str = k.Substring(0, ind);
                mas[coun].month = int.Parse(str);
                k = k.Remove(0, ind + 1);

                mas[coun].years = int.Parse(k);

                coun++;
            }
        }

        static void Read_f2(Film[] mas)
        {
            int coun = 0;
            foreach (string i in file_f)
            {
                int ind = i.IndexOf("|");
                mas[coun].name_f = i.Substring(0, ind - 1);
                string k = i.Remove(0, ind + 2);

                ind = k.IndexOf("|");
                mas[coun].genre = k.Substring(0, ind - 1);
                k = k.Remove(0, ind + 2);

                mas[coun].date = int.Parse(k);

                coun++;
            }
        }

        static public HeshT HTable()
        {
            int r_2 = file_f.Length;
            Film[] mas_f = new Film[r_2];
            for (int i = 0; i < r_2; i++)
            {
                mas_f[i] = new Film();
            }
            Read_f2(mas_f);
            //HeshT table = new HeshT(100);
            foreach (Film f in mas_f)
            {
                Add_table(f);
            }
            return table;
        }

        //static public HeshT HeshTable(HeshT t)
        //{
        //    HeshT table;
        //    table = t;
        //    t = null;
        //    return t;
        //}

        static public Actor[] Massive()
        {
            int r_1 = file_a.Length;
            Actor[] mas_a = new Actor[r_1];
            for (int i = 0; i < r_1; i++)
            {
                mas_a[i] = new Actor();
            }
            Read_f1(mas_a);
            return mas_a;
        }

        //static public void Init_tree()
        //{
        //    AVL.mas.
        //}

        static public AVL TreeAVL()
        {
            Actor[] mas_a = Massive();
            
            HeshT table = HTable();
            foreach (Actor a in mas_a)
            {
                Add_tree(a);
            }
            return tree;
        }
        //static public void S_Act(string i, string f, string o, int y1, int y2,  string[] mas)//AVL tree, HeshT table,
        //{
        //    // Исправить count он ничего не считает !!!!
        //    count = 0;
        //    Actor a = new Actor(f, i, o);
        //    tree.Find(a, mas);
        //    foreach (string k in mas)
        //    {
        //        if (k != null)
        //        {
        //            table.Search(k, y1, y2);
        //        }

        //    }
        //    //Console.WriteLine(count);
        //}
        static public void S_Act_File(string i, string f, string o, int y1, int y2, string[] mas)//AVL tree, HeshT table,
        {
            int count = 0;
            //Добавить ввод назвния файла и пути?!
            Actor a = new Actor(f, i, o);
            tree.Find(a, mas);
            File.WriteAllText("Отчет.txt", "");
            foreach (string k in mas)
            {
                if (k != null)
                {
                    table.Search_File(k, y1, y2);
                }

            }

        }

        static public void Add_table(Film f)//HeshT table
        {
            table.Add(f);
        }
        static public void Add_tree(Actor a)//, HeshT table, AVL tree
        {
            if (table.Search_(a.name_f) != -1)
            {
                tree.Add(a);
            }
            else Console.WriteLine("Сначало добавте фильм!!!");
        }
        static public void Del_film(string f)//, HeshT table, AVL tree //Удаление фильма
        {
            if (table.Del(f) != -1)
            {
                tree.Delete_F(f);
            }
        }

        

        [STAThread]
        static void Main()
        {
            HTable();
            TreeAVL();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form3());
        }
    }
}
