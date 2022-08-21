using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace dalisapp
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form8 frm8 = new Form8();
            frm8.textBox1.Text = textBox1.Text;
            frm8.ShowDialog();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            label2.Hide();
            button5.Hide();
        }
        SQLiteConnection con = new SQLiteConnection(Form3.DB_PATH);
        // SqlConnection con = new SqlConnection("Data Source=DESKTOP-I8BTM9L;Initial Catalog=dalisapp;Integrated Security=True");
        private void verigoster()
        {
            listView1.Items.Clear();
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand("Select *from ogr", con);
            SQLiteDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = dr["tc"].ToString();
                //ekle.SubItems.Add(dr["tc"].ToString());
                ekle.SubItems.Add(dr["adsoyad"].ToString());
                ekle.SubItems.Add(dr["ogrencino"].ToString());
                ekle.SubItems.Add(dr["kangrubu"].ToString());
                ekle.SubItems.Add(dr["telno"].ToString());
                // ekle.SubItems.Add(dr["resim"].ToString());


                listView1.Items.Add(ekle);
            }
            con.Close();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            verigoster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 frm7 = new Form7();
            frm7.textBox1.Text = textBox1.Text;
            frm7.ShowDialog();
        }

       // static string constring1 = "Data Source=DESKTOP-I8BTM9L;Initial Catalog=dalisapp;Integrated Security=True";
        //SqlConnection cont = new SqlConnection(constring1);
      
        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();   
            con.Open();
            string kayit = "SELECT *FROM ogr where adsoyad=@adsoyad"   ;// adsoyad=@adsoyad"
            SQLiteCommand cmd = new SQLiteCommand(kayit, con);       
            cmd.Parameters.AddWithValue("@adsoyad", textBox1.Text);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            SQLiteDataReader dr = cmd.ExecuteReader();
            if (dr.Read())    
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = dr["tc"].ToString();
                //ekle.SubItems.Add(dr["tc"].ToString());
                ekle.SubItems.Add(dr["adsoyad"].ToString());
                ekle.SubItems.Add(dr["ogrencino"].ToString());
                ekle.SubItems.Add(dr["kangrubu"].ToString());
                ekle.SubItems.Add(dr["telno"].ToString());
                // ekle.SubItems.Add(dr["resim"].ToString());


                listView1.Items.Add(ekle);

            }
            else
            {
                MessageBox.Show("Kayıt bulunamadı.");
                con.Close();

            }

            con.Close();


        }
    
      
       

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            label2.Show();
            button5.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form11 frm11 = new Form11();
            frm11.textBox1.Text = textBox1.Text;
            frm11.ShowDialog();
        }
    }
}


