using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Rostyslav Gordin - ISYS 350 - Section 05
namespace Assignment_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].HeaderText = "Year";
            dataGridView1.Columns[1].HeaderText = "Value at the beggining of the year";
            dataGridView1.Columns[2].HeaderText = "Depreciation during the Year";
            dataGridView1.Columns[3].HeaderText = "Total depreciation at the end of the year";
            double propval, proplife, dep, totaldep = 0;
            propval = double.Parse(textBox1.Text);
            proplife = double.Parse(textBox2.Text);
            dataGridView1.Rows.Clear();
            for (int year = 1; year <= proplife; year++)
            {
                if (year < proplife)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[year - 1].Cells[0].Value = year;
                    dataGridView1.Rows[year - 1].Cells[1].Value = propval.ToString("C");
                    dataGridView1.Rows[year - 1].Cells[2].Value = (dep = propval * (2 / proplife)).ToString("C");
                    dataGridView1.Rows[year - 1].Cells[3].Value = (totaldep += dep).ToString("C");
                    propval -= dep;
                }
                else
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[year - 1].Cells[0].Value = year;
                    dataGridView1.Rows[year - 1].Cells[1].Value = propval.ToString("C");
                    dataGridView1.Rows[year - 1].Cells[2].Value = (dep = propval).ToString("C");
                    dataGridView1.Rows[year - 1].Cells[3].Value = (totaldep += dep).ToString("C");
                    propval -= dep;
                }
            }
        }
    }
}
