using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Курсовой_Проект
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form = new Form2();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form = new Form3();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form = new Form4();
            form.Show();
        }

        private bool Proverka(string str)
        {
            if (str[0] <= 1071 && str[0] >= 1040)
            {
                for (int j = 1; j < str.Length; j++)
                {
                    if (str[j] < 1072 && str[j] > 1103)
                    {
                        return true;
                    }
                }
                
            }
            else return true;
            return false;
        }

        private bool Proverka_ch(string str)
        {
            bool flag = false;
            if (str != "")
            {
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] >= 48 && str[j] <= 57)
                    {
                        flag = false;
                    }
                    else
                    {
                        flag = true;
                        break;
                    }
                }
            }
            else return true;
            return flag;  
        }
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            string i = textBox1.Text;
            string f = textBox2.Text;
            string o = textBox3.Text;
            string y_1 = textBox4.Text;
            string y_2 = textBox5.Text;
            bool flag_y1 = Proverka_ch(y_1);
            bool flag_y2 = Proverka_ch(y_2);
            if (i != "" && o != "" && f != "" && flag_y1 != true && flag_y2 != true)
            {
                int y1 = Convert.ToInt32(y_1);
                int y2 = Convert.ToInt32(y_2);
                bool flag_i = Proverka(i);
                bool flag_o = Proverka(o);
                bool flag_f = Proverka(f);
                if (flag_i == false && flag_o == false && flag_f == false && y1 <= y2 && y1 <= 2022 && y1 >= 1946 && y2 <= 2022 && y2 >= 1946)
                {
                    string[] mas = new string[1000];

                    Program.count = 0;
                    Actor a = new Actor(f, i, o);
                    Program.tree.Find(a, mas);
                    foreach (string k in mas)
                    {
                        if (k != null)
                        {
                            int ind = Program.table.Search_(k);
                            Program.count++;
                            if (Program.table.h[ind].date >= y1 && Program.table.h[ind].date <= y2)
                            {
                                dataGridView1.Rows.Add(Program.table.h[ind].name_f, Program.table.h[ind].genre, Program.table.h[ind].date);
                            }
                        }

                    }
                    mas = null;
                }
                else
                {
                    Eror form = new Eror();
                    form.Show();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                }
            }
            else
            {
                Eror form = new Eror();
                form.Show();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            File.WriteAllText("report.txt", "");
            string i = textBox1.Text;
            string f = textBox2.Text;
            string o = textBox3.Text;
            string y_1 = textBox4.Text;
            string y_2 = textBox5.Text;
            if (i != "" && o != "" && f != "" && y_1 != "" && y_2 != "")
            {
                int y1 = Convert.ToInt32(y_1);
                int y2 = Convert.ToInt32(y_2);
                bool flag_i = Proverka(i);
                bool flag_o = Proverka(o);
                bool flag_f = Proverka(f);
                if (flag_i == false && flag_o == false && flag_f == false && y1 <= y2 && y1 <= 2022 && y1 >= 1946 && y2 <= 2022 && y2 >= 1946)
                {
                    string[] mas = new string[1000];
                    Program.S_Act_File(i, f, o, y1, y2, mas);
                    mas = null;
                }
                else
                {
                    Eror form = new Eror();
                    form.Show();
                }
            }
            else
            {
                Eror form = new Eror();
                form.Show();
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
    }
}
