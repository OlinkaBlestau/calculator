using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        double bet, bet1, sum, monthlySum, AllSum;
        int years = 0; 
        String resultM, resultA;
        
        public Form1()
        {
            InitializeComponent();
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            try
            {
                Convert.ToInt32(textBox2.Text);
            }
            
            catch 
            {
                MessageBox.Show("Не вірні роки");
            }
            sum = Convert.ToDouble(textBox1.Text);
            years = Convert.ToInt32(textBox2.Text);

            if ((sum < 1000) || (sum <= 0) || (years <= 0 ))
            {
                MessageBox.Show("Маленька сума кредиту, або невірне ведення даних");

            }

            if (sum >= 40000)
            {

                MessageBox.Show("Сума обговорюється індивідуально");
            }

            if (years >= 10)
            {
                MessageBox.Show("Роки обговорюються індивідуально");
            }

            if (sum >= 1000 && sum < 40000 && years < 10 )
            {
                bet = Convert.ToDouble(numericUpDown1.Text);
                bet1 = bet / 1200;
                years = Convert.ToInt32(textBox2.Text);
                sum = Convert.ToDouble(textBox1.Text);
                monthlySum = sum * bet1 / (1 - 1 / Math.Pow(1 + bet1, years * 12));


                resultM = Convert.ToString(monthlySum);
                CultureInfo ci = new CultureInfo("ua-ua");
                resultM = String.Format(ci, "{0:C}", monthlySum);
                textBox3.Text = (resultM);


                AllSum = monthlySum * years * 12;
                resultA = String.Format(ci, "{0:C}", AllSum);
                textBox4.Text = (resultA);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
      
        }
    }
}
