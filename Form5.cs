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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Clear();
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                if(dataGridView1.Rows[e.RowIndex].Cells["Column2"].Value.ToString() != " ")
                {
                    int ind = Program.table.First_HF(dataGridView1.Rows[e.RowIndex].Cells["Column2"].Value.ToString());
                    textBox1.Text = "Первичная: " + ind + ";  Вторичная: " + e.RowIndex;
                }
                
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            for (int i = 0; i < Program.table.size; i++)
            {
                dataGridView1.Rows.Add(i, Program.table.h[i].name_f, Program.table.h[i].genre, Program.table.h[i].date, Program.table.h[i].status);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
