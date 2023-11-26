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
    public partial class Form3 : Form
    {
        
        public Form3()
        {
            InitializeComponent();
            
        }
      
        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form = new Form2();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form = new Form4();
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            for(int i = 0; i < Program.table.size; i++)
            {
                if (Program.table.h[i].status == 1)
                {
                   dataGridView1.Rows.Add(Program.table.h[i].name_f, Program.table.h[i].genre, Program.table.h[i].date);
                }
            }
        }

        private bool Proverka_film(string str)
        {
            if (str[0] <= 1071 && str[0] >= 1040)
            {
                for (int j = 1; j < str.Length; j++)
                {
                    if (str[j] < 1072 && str[j] > 1103 && str[j] < 32 && str[j] > 59)
                    {
                        return true;
                    }
                }
                return false;
            }
            else return true;
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
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text; //Не проверяю может быть что угодно
            string g = textBox2.Text;//проверка на буквы русского алфавита //первая заглавная // + ,
            string years = textBox3.Text; //проверка на числа от 1946 до 2022
            bool flag_y1 = Proverka_ch(years);
            if (name!= "" && g != "" && flag_y1 != true)
            {
                bool flag_g = Proverka_film(g);
                int year = Convert.ToInt32(years);
                if(year <= 2022 && year >= 1946 && flag_g == false)
                {
                    if(dataGridView1.Rows.Count < 100)//1000
                    {
                        Film f = new Film(name, g, year);
                        bool flag = false;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.Cells["Column1"].Value.Equals(name))
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (flag == false)
                        {
                            dataGridView1.Rows.Add(name, g, year);
                        }
                        else
                        {
                            Erorr4 form = new Erorr4();
                            form.Show();
                        }
                        Program.Add_table(f);
                    }
                    else
                    {
                        Erorr2 form = new Erorr2();
                        form.Show();
                    }
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox5.Text;
            if (name != "" )
            {
                Program.Del_film(name);
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["Column1"].Value.Equals(name))
                    {
                        dataGridView1.Rows.RemoveAt(row.Index);
                        break;
                    }
                }
            }
            else
            {
                Eror form = new Eror();
                form.Show();
            }
            textBox5.Clear();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            for (int i = 0; i < Program.table.size; i++)
            {
                if (Program.table.h[i].status == 1)
                {
                    dataGridView1.Rows.Add(Program.table.h[i].name_f, Program.table.h[i].genre, Program.table.h[i].date);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            string name = textBox4.Text;
            if(name != "")
            {
                for(int i = 0; i < 100; i++)  ///Размер хеш таблицы
                {
                    if (Program.table.h[i].name_f == name)
                    {
                        dataGridView1.Rows.Add(Program.table.h[i].name_f, Program.table.h[i].genre, Program.table.h[i].date);
                    }
                }
            }
            else
            {
                Eror form = new Eror();
                form.Show();
            }
            textBox4.Clear();
        }
    }
}
