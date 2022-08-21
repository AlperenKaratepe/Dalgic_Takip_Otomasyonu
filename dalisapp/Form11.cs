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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
           if(textBox1!=null)
            {
                listView1.Items.Clear();
                con.Open();
                string kayit = "SELECT *FROM db where adsoyad=@adsoyad";
                SQLiteCommand cmd = new SQLiteCommand(kayit, con);
                cmd.Parameters.AddWithValue("@adsoyad", textBox1.Text);
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
                    ekle.SubItems.Add(dr["adsoyad"].ToString());


                    listView1.Items.Add(ekle);

                }


                con.Close();
            }

        }
        SQLiteConnection con = new SQLiteConnection(Form3.DB_PATH);

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            con.Open();
            string kayit = "SELECT *FROM db where adsoyad=@adsoyad";
            SQLiteCommand cmd = new SQLiteCommand(kayit, con);
            cmd.Parameters.AddWithValue("@adsoyad", textBox1.Text);
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
                ekle.SubItems.Add(dr["adsoyad"].ToString());


                listView1.Items.Add(ekle);

            }


            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form9 frm9 = new Form9();
            frm9.textBox1.Text = textBox1.Text;
            frm9.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form10 frm10 = new Form10();
            frm10.textBox1.Text = textBox1.Text;
            frm10.ShowDialog();
        }
    }
}
