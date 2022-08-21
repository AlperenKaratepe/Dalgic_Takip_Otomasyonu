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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
        SQLiteConnection con = new SQLiteConnection(Form3.DB_PATH);
       

        private void button1_Click(object sender, EventArgs e)
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

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string kayit = "SELECT *FROM db where tc=@tc";
            SQLiteCommand cmd = new SQLiteCommand(kayit, con);
            cmd.Parameters.AddWithValue("@tc", textBox1.Text);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem ekle = new ListViewItem();

                // ekle.Text = dr["tc"].ToString();
                ekle.Text = dr["dalis"].ToString();
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

        private void button3_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }
        int i = 0;
        private void yazdir(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            List<int> liste = new List<int>() { 0, 120, 240, 360, 420 };
            System.Drawing.Font yazici = new Font("Verdana", 12);
            //int sayfaSatirSayaci = 0;
            //float soldaNerede = e.MarginBounds.Left;
            //float ustteNerede = e.MarginBounds.Top;
            //float sayfaGenisligi = e.MarginBounds.Width;
            //float satirSayisi = e.MarginBounds.Height / yazici.GetHeight(e.Graphics);
            //float yKoordinati = ustteNerede + yazici.GetHeight(e.Graphics);
            //int yaziSatirSayisi = listView1.Items.Count;
            PointF nokta = new PointF(e.MarginBounds.Left, e.MarginBounds.Top);

            while (i < listView1.Items.Count)
            {
                for (int j = 0; j < this.listView1.Items[i].SubItems.Count; j++)
                {
                    e.Graphics.DrawString(this.listView1.Items[i].SubItems[j].Text, yazici, Brushes.Black, nokta.X + liste[j], nokta.Y);
                }
                nokta.Y += yazici.Height;
                i++;
                if (nokta.Y > e.MarginBounds.Bottom) { break; } //diğer sayfaya geçiş
            }

            if (i < listView1.Items.Count) { e.HasMorePages = true; } else { e.HasMorePages = false; i = 0; }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            yazdir(sender, e);
        }
    }
}
