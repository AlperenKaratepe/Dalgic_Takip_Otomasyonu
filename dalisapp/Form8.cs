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
using System.IO;

namespace dalisapp
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            if(textBox1.Text!=null)
            {
                con.Open();
                string kayit = "SELECT *FROM ogr where adsoyad=@adsoyad";
                SQLiteCommand cmd = new SQLiteCommand(kayit, con);
                cmd.Parameters.AddWithValue("@adsoyad", textBox1.Text);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                SQLiteDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    label7.Text = dr["tc"].ToString();
                    textBox2.Text = dr["adsoyad"].ToString();
                    textBox3.Text = dr["ogrencino"].ToString();
                    comboBox1.Text = dr["kangrubu"].ToString();
                    textBox4.Text = dr["telno"].ToString();
                    textBox5.Text = dr["resim"].ToString();

                   
                    pictureBox1.ImageLocation = textBox5.Text;
                    





                }
                else
                {
                    MessageBox.Show("Kayıt bulunamadı.");
                    con.Close();

                }

                con.Close();
            }
        }
        SQLiteConnection con = new SQLiteConnection(Form3.DB_PATH);

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            textBox5.Text = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string kayit = "delete from ogr where adsoyad=@adsoyad";
            SQLiteCommand cmd = new SQLiteCommand(kayit, con);
            cmd.Parameters.AddWithValue("@adsoyad", textBox2.Text);
            cmd.Parameters.AddWithValue("@ogrencino", textBox3.Text);
            cmd.Parameters.AddWithValue("@kangrubu", comboBox1.Text);
            cmd.Parameters.AddWithValue("@telno", textBox4.Text);
            cmd.Parameters.AddWithValue("@resim", textBox5.Text);
            cmd.Parameters.AddWithValue("@tc", label7.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Silindi.");
        }

       
    }
}
