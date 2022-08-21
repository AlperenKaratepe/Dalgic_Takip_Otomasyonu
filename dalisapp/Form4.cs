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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
       

        private void Form4_Load(object sender, EventArgs e)
        {
           
        }
        SQLiteConnection con = new SQLiteConnection(Form3.DB_PATH);
        bool durum = true;
        private void bosmu()
        {
            con.Open();
            SQLiteCommand cmd2 = new SQLiteCommand("select *from db", con);
            SQLiteDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                if ((radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false) || textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 || textBox5.Text.Length == 0 || textBox6.Text.Length == 0 || textBox7.Text.Length == 0)
                {
                    durum = false;
                }
               else if(radioButton1.Text==dr[1].ToString()&&comboBox4.Text==dr[3].ToString()&&textBox1.Text==dr[4].ToString()&&textBox2.Text==dr[5].ToString()&&textBox3.Text==dr[6].ToString()&&textBox4.Text==dr[7].ToString()&&textBox5.Text==dr[8].ToString()&&textBox6.Text==dr[10].ToString()&&textBox1.Text==dr[0].ToString())
                {
                    durum = true;
                    MessageBox.Show("Benzer Kayıt mevcut, doğru ise devam edebilirsiniz!");
                }
            }
            con.Close();
        }
        private void verigoster()
        {
            listView1.Items.Clear();
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand("Select *from db", con);
            SQLiteDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ListViewItem ekle = new ListViewItem();

                ekle.Text = dr["adsoyad"].ToString();
                ekle.SubItems.Add(dr["dalis"].ToString());
                ekle.SubItems.Add(dr["ekipman"].ToString());
                ekle.SubItems.Add(dr["su"].ToString());
                ekle.SubItems.Add(dr["derinlik"].ToString());
                ekle.SubItems.Add(dr["süre"].ToString());
                ekle.SubItems.Add(dr["sicaklik"].ToString());
                ekle.SubItems.Add(dr["partner"].ToString());
                ekle.SubItems.Add(dr["kaptan"].ToString());
                ekle.SubItems.Add(dr["tarih"].ToString());
                ekle.SubItems.Add(dr["aciklama"].ToString());
                ekle.SubItems.Add(dr["adsoyad"].ToString());


                listView1.Items.Add(ekle);
            }
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bosmu();
            if (durum == true)
            {

                    if (radioButton1.Checked == true)
                    {
                        con.Open();
                        SQLiteCommand cmd = new SQLiteCommand("insert into db(adsoyad,dalis,ekipman,su,derinlik,süre,sicaklik,partner,kaptan,tarih,aciklama) values('" + textBox7.Text.ToString() + "','" + radioButton1.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + comboBox4.Text.ToString() + "','" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + dateTimePicker1.Text.ToString() + "','" + textBox6.Text.ToString() + "')", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        verigoster();
                    }
                    else if (radioButton2.Checked == true)
                    {
                        con.Open();
                        SQLiteCommand cmd = new SQLiteCommand("insert into db(adsoyad,dalis,ekipman,su,derinlik,süre,sicaklik,partner,kaptan,tarih,aciklama) values('" + textBox7.Text.ToString() + "','" + radioButton2.Text.ToString() + "','" + comboBox2.Text.ToString() + "','" + comboBox4.Text.ToString() + "','" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + dateTimePicker1.Text.ToString() + "','" + textBox6.Text.ToString() + "')", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        verigoster();

                    }
                    else if (radioButton3.Checked == true)
                    {

                        con.Open();
                        SQLiteCommand cmd = new SQLiteCommand("insert into db(adsoyad,dalis,ekipman,su,derinlik,süre,sicaklik,partner,kaptan,tarih,aciklama) values('" + textBox7.Text.ToString() + "','" + radioButton3.Text.ToString() + "','" + comboBox3.Text.ToString() + "','" + comboBox4.Text.ToString() + "','" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + dateTimePicker1.Text.ToString() + "','" + textBox6.Text.ToString() + "')", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        verigoster();
                    }
                
            }
            else
            {
                MessageBox.Show("Tüm alanları doldurmalısınız!");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}