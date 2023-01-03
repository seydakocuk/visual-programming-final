using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;

namespace sinema
{
    public partial class frmSeansEkle : Form
    {
        public frmSeansEkle()
        {
            InitializeComponent();
        }

        public MySqlConnection conn = new MySqlConnection("Server=localhost;Database=sinema_bileti;Uid=root;Pwd='';");

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {

        }
        string seans = "";

        private void RadioButtonSeciliyse()
        {
            if (radioButton1.Checked == true) seans = radioButton1.Text;
            else if (radioButton2.Checked == true) seans = radioButton2.Text;
            else if (radioButton3.Checked == true) seans = radioButton3.Text;
            else if (radioButton4.Checked == true) seans = radioButton4.Text;
            else if (radioButton5.Checked == true) seans = radioButton5.Text;
            else if (radioButton6.Checked == true) seans = radioButton6.Text;
            else if (radioButton7.Checked == true) seans = radioButton7.Text;
            else if (radioButton8.Checked == true) seans = radioButton8.Text;
            else if (radioButton9.Checked == true) seans = radioButton9.Text;
            else if (radioButton10.Checked == true) seans = radioButton10.Text;
            else if (radioButton11.Checked == true) seans = radioButton11.Text;
            else if (radioButton12.Checked == true) seans = radioButton12.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RadioButtonSeciliyse();
            try {
                MySqlCommand seansEkle = new MySqlCommand("insert into seans_bilgileri(FilmAdi,SalonAdi,tarih,Seans) VALUES ( '" + comboBox4.Text + "' , '" + comboBox2.Text + "' , '" + dateTimePicker1.Text + "' , '" + seans + "' )", conn);
                conn.Open();
                if (seans != "" )
                {
                  if(  seansEkle.ExecuteNonQuery() == 1)
                   
                    MessageBox.Show("Seans başarıyla eklendi", "Kayıt");
                  
                }        
        
        }
            catch 
            {
                seans = "";
             

                MessageBox.Show("Senas Seçimi Yapmadınız!!!", "Uyarı");
                conn.Close();
            }
            comboBox2.Text = "";
            comboBox4.Text = "";
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();

        }

        private void frmSeansEkle_Load(object sender, EventArgs e)
        {
            FilmveSalonGoster(comboBox4 , "select * from film_bilgileri" , "FilmAdi" );
            FilmveSalonGoster(comboBox2, "select * from salon_bilgileri", "SalonAdi");
        }
        private void FilmveSalonGoster(ComboBox combo , string sql1, string sql2)
        {
            conn.Open();
            MySqlCommand komut = new MySqlCommand(sql1 ,conn);
            MySqlDataReader read = komut.ExecuteReader();
            while (read.Read() == true)
            {
                combo.Items.Add(read[sql2].ToString());
            }
            conn.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            foreach (Control item3 in groupBox1.Controls)
            {
                item3.Enabled = true;
            } 
            DateTime bugün = DateTime.Parse(DateTime.Now.ToShortDateString());
            DateTime yeni = DateTime.Parse(dateTimePicker1.Text);
            if(yeni == bugün)
            {
                foreach (Control item in groupBox1.Controls)
                {
                    if (DateTime.Parse(DateTime.Now.ToShortTimeString()) > DateTime.Parse(item.Text))
                    {
                        item.Enabled = false;
                    }
                }
                TarihiKarşılaştır();
            }
            else if (yeni > bugün)
            {
                TarihiKarşılaştır();
            }
            else if (yeni < bugün)
            {
                MessageBox.Show("Geriye Dönük İşlem Yapılamaz!!!", "Uyarı");
                dateTimePicker1.Text = DateTime.Now.ToShortDateString();
            }

        }

        private void TarihiKarşılaştır()
        {
            conn.Open();
            MySqlCommand komut = new MySqlCommand("select * from seans_bilgileri where SalonAdi = '" + comboBox2.Text + "' and tarih = '" + dateTimePicker1.Text + "'  ", conn);
            MySqlDataReader read = komut.ExecuteReader();
            while (read.Read() == true)
            {
                foreach (Control item2 in groupBox1.Controls)
                {
                    if (read["seans"].ToString() == item2.Text)
                    {
                        item2.Enabled = false;
                    }
                }
            }
            conn.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();
        }

        private void frmSeansEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
        }
    }
}
