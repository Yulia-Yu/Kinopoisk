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
    public partial class Form2 : Form
    {
       
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            Program.tree.DisplayTree();
            Actor[] act = AVL.mas;
            foreach (Actor k in act)
            {
                if (k != null && k.f != null)
                {
                    dataGridView1.Rows.Add(k.i, k.f, k.o, k.name_f, k.day + "." + k.month + "." + k.years);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form = new Form3();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form = new Form4();
            form.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private bool Proverka(string str)
        {
            if (str[0] <= 1071 && str[0] >= 1040)
            {
                for (int j = 1; j < str.Length; j++)
                {
                    if (str[j] <= 1072 && str[j] >= 1103)
                    {
                        return true;
                    }
                }
                return false;
            }
            else return true;
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

        
        private void button1_Click(object sender, EventArgs e)
        {
            string i = textBox8.Text;
            string f = textBox1.Text;
            string o = textBox2.Text;
            string name_f = textBox3.Text;
            if (i != "" && o != "" && f != "" && name_f != "")
            {
                bool flag_i = Proverka(i);
                bool flag_o = Proverka(o);
                bool flag_f = Proverka(f);
                if(flag_i == false && flag_o == false && flag_f == false)
                {
                    string str = dateTimePicker1.Value.ToString();

                    int ind = str.IndexOf(".");
                    string s = str.Substring(0, ind);
                    int day = int.Parse(s);
                    str = str.Remove(0, ind + 1);

                    ind = str.IndexOf(".");
                    s = str.Substring(0, ind);
                    int month = int.Parse(s);
                    str = str.Remove(0, ind + 1);

                    ind = str.IndexOf(" ");
                    s = str.Substring(0, ind);
                    int years = int.Parse(s);
                    str = null;

                    Actor act = new Actor(i, o, f, name_f, day, month, years);
                    if (Program.table.Search_(name_f) != -1)
                    {
                        dataGridView1.Rows.Add(i, f, o, name_f, day + "." + month + "." + years);
                    }
                    else
                    {
                        Erorr3 form = new Erorr3();
                        form.Show();
                    }
                    Program.Add_tree(act);
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
            textBox8.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            dateTimePicker1.ResetText();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string i = textBox8.Text;
            string f = textBox1.Text;
            string o = textBox2.Text;
            string name_f = textBox3.Text;
            if (i != "" && o != "" && f != "" && name_f != "")
            {
                bool flag_i = Proverka(i);
                bool flag_o = Proverka(o);
                bool flag_f = Proverka(f);
               // bool flag_name_f = Proverka_film(name_f);
                if (flag_i == false && flag_o == false && flag_f == false)//3 && flag_name_f == false
                {
                    Actor a = new Actor(f, i, o, name_f);
                    Program.tree.Delete_AF(a);
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["Column1"].Value.Equals(i) && row.Cells["Column2"].Value.Equals(f) && row.Cells["Column3"].Value.Equals(o) && row.Cells["Column4"].Value.Equals(name_f))
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
            }
            else
            {
                Eror form = new Eror();
                form.Show();
            }
            textBox8.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string i = textBox7.Text;
            string o = textBox6.Text;
            string f = textBox4.Text;
            if (i != "" && o != "" && f != "")
            {
                bool flag_i = Proverka(i);
                bool flag_o = Proverka(o);
                bool flag_f = Proverka(f);
                if (flag_i == false && flag_o == false && flag_f == false)
                {
                    Actor a = new Actor(f, i, o);
                    Program.tree.Delete(a);
                    bool flag = false;
                    for(int j = dataGridView1.DisplayedRowCount(flag) - 1; j >= 0; j-- )
                    {
                        DataGridViewRow row = dataGridView1.Rows[j];
                        if (row.Cells["Column1"].Value.Equals(i) && row.Cells["Column2"].Value.Equals(f) && row.Cells["Column3"].Value.Equals(o))
                        {
                            dataGridView1.Rows.RemoveAt(row.Index);
                        }

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
            textBox7.Clear();
            textBox6.Clear();
            textBox4.Clear();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            string i = textBox7.Text;
            string o = textBox6.Text;
            string f = textBox4.Text;
            if (i != "" && o != "" && f != "")
            {
                bool flag_i = Proverka(i);
                bool flag_o = Proverka(o);
                bool flag_f = Proverka(f);
                if (flag_i == false && flag_o == false && flag_f == false)
                {
                    Actor a = new Actor(f, i, o);
                    Actor[] mas = new Actor[1000];
                    for(int j = 0; j < 1000; j++)
                    {
                        mas[j] = new Actor();
                    }
                    Program.tree.Find_A(a, mas);
                    foreach (Actor k in mas)
                    {
                        if (k.f != null)
                        {
                            dataGridView1.Rows.Add(k.i, k.f, k.o, k.name_f, k.day + "." + k.month + "." + k.years);
                        }
                    }
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
            textBox7.Clear();
            textBox6.Clear();
            textBox4.Clear();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            Program.tree.DisplayTree();
            Actor[] act = AVL.mas;
            foreach (Actor k in act)
            {
                if (k != null && k.f != null)
                {
                    dataGridView1.Rows.Add(k.i, k.f, k.o, k.name_f, k.day + "." + k.month + "." + k.years);
                }
            }
        }
    }
}
