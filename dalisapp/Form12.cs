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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            label4.Hide();
            listView2.Height = 650;
            


        }
        SQLiteConnection con = new SQLiteConnection(Form3.DB_PATH);

        private void button1_Click(object sender, EventArgs e)
        {
            verigoster();
            verigoster2();
            textBox1.Hide();
            
            button1.Hide();
            if (listView2.Items.Count > 0 && listView2.Items.Count < 2)
            {
               // pictureBox4.Hide();
               // pictureBox6.Hide();
               // pictureBox7.Hide();
               // pictureBox3.Hide();

            }
            else if (listView2.Items.Count >= 2 && listView2.Items.Count < 70)
            {
               // pictureBox5.Hide();
              // pictureBox6.Hide();
                //pictureBox7.Hide();
                //pictureBox3.Hide();
            }
            else if (listView2.Items.Count >= 70 && listView2.Items.Count < 100)
            {

               // pictureBox6.Hide();
               // pictureBox7.Hide();
               // pictureBox3.Hide();
            }
            else if (listView2.Items.Count >= 100 && listView2.Items.Count < 135)
            {

               // pictureBox7.Hide();
               // pictureBox3.Hide();
            }
            else if (listView2.Items.Count >= 135 && listView2.Items.Count < 170)
            {

               // pictureBox3.Hide();
            }
            else if (listView2.Items.Count >= 170 && listView2.Items.Count < 10000)
            {

            }
        }
        private void verigoster()
        {
             listView1.Items.Clear();
            con.Open();
            string kayit = "SELECT *FROM ogr where adsoyad=@adsoyad";
            SQLiteCommand cmd = new SQLiteCommand(kayit, con);
            cmd.Parameters.AddWithValue("@adsoyad", textBox1.Text);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = dr["tc"].ToString();
                //  ekle.SubItems.Add(dr["tc"].ToString());
                ekle.SubItems.Add(dr["adsoyad"].ToString());
                ekle.SubItems.Add(dr["ogrencino"].ToString());
                ekle.SubItems.Add(dr["kangrubu"].ToString());
                ekle.SubItems.Add(dr["telno"].ToString());
                ekle.SubItems.Add(dr["tc"].ToString());
                // ekle.SubItems.Add(dr["resim"].ToString());               
               label4.Text = dr["resim"].ToString();
                pictureBox1.ImageLocation = label4.Text;
                listView1.Items.Add(ekle);

            }



            con.Close();
        }
        private void verigoster2()
        {
            listView2.Items.Clear();
            con.Open();
            string kayit = "SELECT *FROM db where adsoyad=@adsoyad";
            SQLiteCommand cmd = new SQLiteCommand(kayit, con);
            cmd.Parameters.AddWithValue("@adsoyad", textBox1.Text);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = dr["dalis"].ToString();
                 ekle.Text = dr["adsoyad"].ToString();
                //   ekle.SubItems.Add(dr["dalis"].ToString());
                ekle.SubItems.Add(dr["ekipman"].ToString());
                ekle.SubItems.Add(dr["su"].ToString());
                ekle.SubItems.Add(dr["derinlik"].ToString());
                ekle.SubItems.Add(dr["süre"].ToString());
                ekle.SubItems.Add(dr["sicaklik"].ToString());
                ekle.SubItems.Add(dr["partner"].ToString());
                ekle.SubItems.Add(dr["kaptan"].ToString());
                ekle.SubItems.Add(dr["tarih"].ToString());
                ekle.SubItems.Add(dr["aciklama"].ToString());
                ekle.SubItems.Add(dr["dalis"].ToString());
                // ekle.SubItems.Add(dr["adsoyad"].ToString());


                listView2.Items.Add(ekle);

            }


            con.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Hide();
            
            printDocument1.Print();
            button2.Show();
        ;
           

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            yazdir2(sender, e);
                   
        }
       
        
        private void yazdir2(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {   Font myFont = new Font("Calibri", 8);
            SolidBrush sbrush = new SolidBrush(Color.Black);
            Bitmap bm = new Bitmap(this.panel1.Width, this.panel1.Height);
            panel1.DrawToBitmap(bm,new Rectangle(0, 0, this.panel1.Width, this.panel1.Height));
         
            e.Graphics.DrawImage(bm, 0, 0);
         

            if (panel1.Height < listView2.Items.Count) {  e.HasMorePages = true;  }else { e.HasMorePages = false;  }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView2.Items.Clear();
            con.Open();
            string kayit = "SELECT *FROM db where tarih=@tarih";
            SQLiteCommand cmd = new SQLiteCommand(kayit, con);
            cmd.Parameters.AddWithValue("@tarih", dateTimePicker1.Text);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = dr["dalis"].ToString();
                 ekle.Text = dr["adsoyad"].ToString();
                //   ekle.SubItems.Add(dr["dalis"].ToString());
                ekle.SubItems.Add(dr["ekipman"].ToString());
                ekle.SubItems.Add(dr["su"].ToString());
                ekle.SubItems.Add(dr["derinlik"].ToString());
                ekle.SubItems.Add(dr["süre"].ToString());
                ekle.SubItems.Add(dr["sicaklik"].ToString());
                ekle.SubItems.Add(dr["partner"].ToString());
                ekle.SubItems.Add(dr["kaptan"].ToString());
                ekle.SubItems.Add(dr["tarih"].ToString());
                ekle.SubItems.Add(dr["aciklama"].ToString());
                ekle.SubItems.Add(dr["dalis"].ToString());
                // ekle.SubItems.Add(dr["adsoyad"].ToString());


                listView2.Items.Add(ekle);

            }
            

            con.Close();
        }

        private void verigoster3()
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
        private void verigoster4()
        {
            listView2.Items.Clear();
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand("Select *from db", con);
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem ekle = new ListViewItem();

                // ekle.Text = dr["tc"].ToString();
                ekle.Text = dr["dalis"].ToString();
                ekle.Text = dr["adsoyad"].ToString();
                // ekle.SubItems.Add(dr["dalis"].ToString());
                // ekle.SubItems.Add(dr["adsoyad"].ToString()); //burayla alakalı değil 
                ekle.SubItems.Add(dr["ekipman"].ToString());
                ekle.SubItems.Add(dr["su"].ToString());
                ekle.SubItems.Add(dr["derinlik"].ToString());
                ekle.SubItems.Add(dr["süre"].ToString());
                ekle.SubItems.Add(dr["sicaklik"].ToString());
                ekle.SubItems.Add(dr["partner"].ToString());
                ekle.SubItems.Add(dr["kaptan"].ToString());
                ekle.SubItems.Add(dr["tarih"].ToString());
                ekle.SubItems.Add(dr["aciklama"].ToString());
                // ekle.SubItems.Add(dr["tc"].ToString());


                listView2.Items.Add(ekle);

            }


            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            verigoster3();
            verigoster4();


            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView2.Items.Clear();
            con.Open();
            string kayit = "SELECT * FROM db where tarih=@tarih and adsoyad=@adsoyad";
            SQLiteCommand cmd = new SQLiteCommand(kayit, con);
            cmd.Parameters.AddWithValue("@tarih", dateTimePicker2.Text);
            cmd.Parameters.AddWithValue("@adsoyad", textBox2.Text);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
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


                listView2.Items.Add(ekle);

            }


            con.Close();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
                

    }

