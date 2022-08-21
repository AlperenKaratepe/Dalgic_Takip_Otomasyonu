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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            if(textBox1!=null)
            {
                con.Open();
                string kayit = "SELECT *FROM db where adsoyad=@adsoyad";
                SQLiteCommand cmd = new SQLiteCommand(kayit, con);
                cmd.Parameters.AddWithValue("@adsoyad", textBox1.Text);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                SQLiteDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    label11.Text = dr["adsoyad"].ToString();
                    comboBox1.Text = dr["dalis"].ToString();
                    comboBox2.Text = dr["ekipman"].ToString();
                    comboBox3.Text = dr["su"].ToString();
                    textBox2.Text = dr["derinlik"].ToString();
                    textBox3.Text = dr["süre"].ToString();
                    textBox4.Text = dr["sicaklik"].ToString();
                    textBox5.Text = dr["partner"].ToString();
                    textBox6.Text = dr["kaptan"].ToString();
                    dateTimePicker1.Text = dr["tarih"].ToString();
                    textBox7.Text = dr["aciklama"].ToString();


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


        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string kayit = "delete from db where adsoyad=@adsoyad";
            SQLiteCommand cmd = new SQLiteCommand(kayit, con);
            cmd.Parameters.AddWithValue("@dalis", comboBox1.Text);
            cmd.Parameters.AddWithValue("@ekipman", comboBox2.Text);
            cmd.Parameters.AddWithValue("@su", comboBox3.Text);
            cmd.Parameters.AddWithValue("@derinlik", textBox2.Text);
            cmd.Parameters.AddWithValue("@süre", textBox3.Text);
            cmd.Parameters.AddWithValue("@sicaklik", textBox4.Text);
            cmd.Parameters.AddWithValue("@partner", textBox5.Text);
            cmd.Parameters.AddWithValue("@kaptan", textBox6.Text);
            cmd.Parameters.AddWithValue("@tarih", dateTimePicker2.Text);
            cmd.Parameters.AddWithValue("@aciklama", textBox7.Text);
            cmd.Parameters.AddWithValue("@adsoyad", label11.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Silindi.");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
