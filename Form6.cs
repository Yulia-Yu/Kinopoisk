using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовой_Проект
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.Rows.Clear();

            Actor a = new Actor();
            string str = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            int ind = str.IndexOf(" ");
            while(ind == 0)
            {
                str = str.Remove(0, ind + 1);
                ind = str.IndexOf(" ");
            }
            a.i = str.Substring(0, ind);
            str = str.Remove(0, ind + 1);

            ind = str.IndexOf(" ");
            a.f = str.Substring(0, ind);
            str = str.Remove(0, ind + 1);

            ind = str.IndexOf(" ");
            a.o = str.Substring(0, ind);
            str = str.Remove(0, ind + 1);

            ind = str.IndexOf("\" ");
            str = str.Remove(0, ind + 1);

            string[] mas = new string[1000]; //Исправить на размер хеш таблицы
            Program.tree.Find(a, mas);
            
            for (int i = 1; i< 1000; i++)//Исправить на размер хеш таблицы
            {
                if(mas[i] != null)
                {
                    dataGridView2.Rows.Add(a.i + " " + a.f + " " + a.o + " \"" + mas[i] + "\" " + str);
                }
                else
                {
                    break;
                }
            }
            mas = null;
        }

        void EnterTree(AVL.Node tree, int h) // Печать дерева
        {
            string str = " ";
            if (tree != null)
            {
                Actor act = tree.key;
                EnterTree(tree.right, h + 4);
                for (int i = 0; i < h; i++) { str = str + " "; } //cout << " ";
                str = str + tree.key.i + " " + tree.key.f + " " + tree.key.o + " \"" + tree.key.name_f + "\" " + tree.key.day + "." + tree.key.month + "." + tree.key.years;
                dataGridView1.Rows.Add(str);                               //вывод дерева на экран
                EnterTree(tree.left, h + 4);
            }
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            //dataGridView1.AllowUserToAddRows = false;
            //dataGridView2.AllowUserToAddRows = false;
            EnterTree(Program.tree.root, 1);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
