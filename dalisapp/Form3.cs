using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace dalisapp
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        public static string dalgic_FOLDER = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Dalgic");
        public static string DB_PATH = "Data Source=" + dalgic_FOLDER + "\\dalgic.sqlite";
        SQLiteConnection con = new SQLiteConnection(DB_PATH);
        bool durum=true;
        private void kayitkontrol()
        {
            con.Open();
            SQLiteCommand cmd2 = new SQLiteCommand("select *from ogr",con);
            SQLiteDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                if (textBox1.Text==dr[0].ToString())
                {
                    durum = false;
                }
            }
            con.Close();
        }
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
                ekle.SubItems.Add(dr["resim"].ToString());
               // ekle.SubItems.Add(dr["id"].ToString());
              

                listView1.Items.Add(ekle);
            }
            con.Close();

        }
     

        private void button1_Click(object sender, EventArgs e)
        {
            kayitkontrol();
            if (durum == true)
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand("insert into ogr(tc,adsoyad,ogrencino,kangrubu,telno,resim) values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                verigoster();
            }
            else
            {
                MessageBox.Show("Hata! 1.Bu bilgi(ler)de kayıt mevcut./2.Bilgi girişi yapılmadı veya eksik giriş yapıldı.Kontrol ediniz.");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.textBox7.Text = textBox2.Text;
            this.Hide();
            frm4.ShowDialog();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            textBox5.Text = openFileDialog1.FileName;



        }
        //long tc;
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //tc = long.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[5].Text;
            pictureBox1.ImageLocation = listView1.SelectedItems[0].SubItems[5].Text;
        }
       
        private void button4_Click(object sender, EventArgs e)
        {

           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            verigoster();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
