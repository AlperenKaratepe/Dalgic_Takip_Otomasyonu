using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dalisapp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="iste" && textBox2.Text=="dalış1080")
            {
                Form2 frm2 = new Form2();
                this.Hide();
                frm2.Show();
            }
            else
            {
                MessageBox.Show("Hatalı giriş yapıldı.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
