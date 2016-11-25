using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

//Rostyslav Gordin - ISYS 350 - Section 05
namespace Assignment_6
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double trymonths;
                trymonths = double.Parse(textBox3.Text);
                if (trymonths < 6 || trymonths > 48)
                {
                    MessageBox.Show("Oops! We don't finance a vehicle for less than 6 months or more than 48 months!");
                }
                else
                {
                    
                }
            }
            catch
            {
                MessageBox.Show("Oops! Enter the number of months to finance the vehicle for!");
            }

            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].HeaderText = "Payment #";
            dataGridView1.Columns[1].HeaderText = "Monthly Payment";
            dataGridView1.Columns[2].HeaderText = "Amount to Interest";
            dataGridView1.Columns[3].HeaderText = "Amount to Principal";
            dataGridView1.Columns[4].HeaderText = "Remaining Balance";
            double cost, downpayment, months, rate, topayoff, PPmt, remaining, topayoff2;
            if (radioButton1.Checked)
            {
                rate = 0.069;
            }
            else
            {
                rate = 0.085;
            }
            cost = double.Parse(textBox1.Text);
            downpayment = double.Parse(textBox2.Text);
            months = double.Parse(textBox3.Text);
            topayoff = cost - downpayment;
            topayoff2 = topayoff;
            dataGridView1.Rows.Clear();
            textBox4.Text = rate.ToString((rate) + "%");
            for (int payment = 1; payment <= months; payment++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[payment - 1].Cells[0].Value = payment.ToString();
                dataGridView1.Rows[payment - 1].Cells[1].Value = Financial.Pmt(rate / 12, months, -topayoff2).ToString("C");
                dataGridView1.Rows[payment - 1].Cells[2].Value = Financial.IPmt(rate / 12, 1, months, -topayoff).ToString("C");
                PPmt = Financial.Pmt(rate / 12, months, -topayoff2) - Financial.IPmt(rate / 12, 1, months, -topayoff);
                dataGridView1.Rows[payment - 1].Cells[3].Value = PPmt.ToString("C");
                remaining = topayoff - PPmt;
                dataGridView1.Rows[payment - 1].Cells[4].Value = remaining.ToString("C");
                topayoff = remaining;
                
                if (payment % 2 == 0)
                {
                    dataGridView1.Rows[payment - 1].DefaultCellStyle.BackColor = Color.SkyBlue;
                }
                else
                {
                    dataGridView1.Rows[payment - 1].DefaultCellStyle.BackColor = Color.White;
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            radioButton1.Checked = true;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
