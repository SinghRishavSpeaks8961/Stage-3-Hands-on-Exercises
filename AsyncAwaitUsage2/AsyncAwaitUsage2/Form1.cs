using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAwaitUsage2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            label1.Text= "Processing File Please Wait....";

            int count = await CountCharacterAsync();

            label1.Text=count.ToString()+ " characters in file";
        }

        public async Task<int> CountCharacterAsync()
        {
            int count = 0;
            using(StreamReader reader=new StreamReader("C:\\Users\\HP\\Downloads\\sample-2mb-text-file.txt"))
            {
                string content = await reader.ReadToEndAsync();
                count = content.Length;
                
            }
            return count;
        }
    }
}
