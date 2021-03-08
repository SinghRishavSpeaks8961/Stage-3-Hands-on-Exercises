using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string pattern = @"\d";

            bool isValid1 = Regex.IsMatch(FirstNumber.Text, pattern);
            bool isValid2 = Regex.IsMatch(SecondNumber.Text, pattern);
            if(isValid1 && isValid2)
            {
                int firstNumber = int.Parse(FirstNumber.Text);
                int secondnumber = int.Parse(SecondNumber.Text);
                if (Add.Checked)
                {
                    int result = firstNumber + secondnumber;
                    MessageBox.Show("The Result is "+result.ToString());
                }
                else if (Substract.Checked)
                {
                    int result = firstNumber - secondnumber;
                    MessageBox.Show("The Result is " + result.ToString());
                }
                else if (Multiply.Checked)
                {
                    int result = firstNumber * secondnumber;
                    MessageBox.Show("The Result is " + result.ToString());
                }
                else
                {
                    int result = firstNumber / secondnumber;
                    MessageBox.Show("The Result is " + result.ToString());
                }

            }
            else
            {
                MessageBox.Show("Please enter a valid number");
            }
        }
    }
}
