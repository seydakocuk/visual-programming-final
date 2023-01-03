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
using MySql.Data.MySqlClient;


namespace sinema
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        int sayac = 0;
        private void FilmveSalonGetir(ComboBox combo , string mysql1 ,string mysql2)
        {
            conn.Open();
            MySqlCommand komut = new MySqlCommand(mysql1,conn);
            MySqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                combo.Items.Add(read[mysql2].ToString());
            }
            conn.Close();
        }
        private void FilmAfisiGoster()
        {
            conn.Open();
            MySqlCommand komut = new MySqlCommand("select*from film_bilgileri where FilmAdi= '"+comboBox1.SelectedItem+"'" , conn);
            MySqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                pictureBox1.ImageLocation = read["resim"].ToString();
            }
            conn.Close();
        }
        private void Combo_Dolu_Koltuklar()
        {
            comboBox5.Items.Clear();
            comboBox5.Text = "";
            foreach (Control item in panel1.Controls)
            {
                if (item is Button)
                {
                    if (item.BackColor == Color.Red)
                    {
                        comboBox5.Items.Add(item.Text);
                    }
                }

            }

        }
        private void YenidenRenklendir()
        {
            foreach (Control item in panel1.Controls)
            {
                if(item is Button)
                {
                    item.BackColor = Color.White;
                }

            }
        }
        public MySqlConnection conn = new MySqlConnection("Server=localhost;Database=sinema_bileti;Uid=root;Pwd='';");
        private void VeriTabani_Dolu_Koltuklar()
        {

            conn.Open();
         
            string salonadi;
            string filmadi;
            string filmtarihi;
            string saat;
          
          
            salonadi = comboBox2.Text;
            filmadi = comboBox1.Text;
            filmtarihi = comboBox4.Text;
            saat = comboBox3.Text;
            

            MySqlCommand komut = new MySqlCommand("select * from satis_bilgileri where SalonAdi = '"+salonadi+"' and FilmAdi = '" +filmadi+"'  and tarih='"+filmtarihi+"' and saat ='"+saat+"'",conn);
            MySqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                foreach(Control item in panel1.Controls)
                {
                    if (item is Button)
                    {
                        if (read["KoltukNo"].ToString()==item.Text)
                        {
                            item.BackColor = Color.Red;
                          
                        }               
                    }
                }

            }
            conn.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Boş_Koltuklar();
            FilmveSalonGetir(comboBox1,"select*from film_bilgileri","FilmAdi");
            FilmveSalonGetir(comboBox2, "select*from salon_bilgileri", "SalonAdi");


        }

        private void Boş_Koltuklar()
        {
            sayac = 1;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(30, 30);//buton yükseklik
                    btn.BackColor = Color.White;
                    btn.Location = new Point(j * 30 + 20, i * 30 + 30); //buton konum
                    btn.Name = sayac.ToString();
                    btn.Text = sayac.ToString();
                    if (j == 4)
                    {
                        continue; //burayı atla
                    }
                    sayac++;
                    this.panel1.Controls.Add(btn);//kontrolleri panele ekle

                    btn.Click += Btn_Click;
                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;//dinamik butonlara b ismini verdim
            if (b.BackColor == Color.Red)
            {
                textBox1.Text = b.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSalonEkle ekle = new frmSalonEkle();
            ekle.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmFilmEkle ekle = new frmFilmEkle();
            ekle.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmSeansEkle ekle = new frmSeansEkle();
            ekle.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmSatısListeleme satis = new frmSatısListeleme();
            satis.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmSeansListele seans = new frmSeansListele();
            seans.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        
        {
                comboBox3.Items.Clear();
                comboBox4.Items.Clear();
                comboBox3.Text = "";
                comboBox4.Text = "";
                comboBox2.Text = "";
            foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";
                FilmAfisiGoster();
                YenidenRenklendir();
                Combo_Dolu_Koltuklar();           
        }
       

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text !="")
            {
                try
                {
                    conn.Open();
                    MySqlCommand komut = new MySqlCommand("insert into (satis_bilgileri) KoltukNo,SalonAdi,FilmAdi,tarih,Saat,Ad,Soyad,Ucret VALUES('" + textBox1.Text + "' , '" + comboBox2.SelectedItem + "' , '" + comboBox1.SelectedItem + "' ,'" + comboBox4.SelectedItem + "' ,'" + comboBox3.SelectedItem + "'  ,'" + textBox2.Text + "' , '" + textBox3.Text + "' , '" + textBox4.Text + "' , '" + DateTime.Now.ToString() + "')", conn);
                    foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";
                    YenidenRenklendir();
                    VeriTabani_Dolu_Koltuklar();
                    Combo_Dolu_Koltuklar();


                }
                catch (Exception hata)
                {

                    MessageBox.Show("Hata Oluştu" +hata.Message , "Uyarı");
                }
            }
            else
            {
                MessageBox.Show("Koltuk Seçimi Yapmadınız.", "Uyarı");
            }
            conn.Close();
        }
        private void Film_Tarihi_Getir()
        {
            comboBox4.Text = "";
            comboBox3.Text = "";
            comboBox4.Items.Clear();
            comboBox3.Items.Clear();
            conn.Open();
            MySqlCommand komut = new MySqlCommand("SELECT * FROM seans_bilgileri WHERE  FilmAdi = '"+comboBox1.SelectedItem+"' and SalonAdi = '"+comboBox2.SelectedItem+"' ", conn);
            MySqlDataReader read = komut.ExecuteReader();
            while (read.Read()) 
            {
                if (DateTime.Parse(read["tarih"].ToString())>=DateTime.Parse(DateTime.Now.ToShortDateString())) 
                {
                    if (!comboBox4.Items.Contains(read["tarih"].ToString()))
                    {
                        comboBox4.Items.Add(read["tarih"].ToString());
                    }
                   

                }
               
            }
            conn.Close();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Film_Tarihi_Getir();

        }
        private void Film_Seansi_Getir()
        {
            comboBox3.Text = "";
            comboBox3.Items.Clear();
            conn.Open();
            MySqlCommand komut = new MySqlCommand("SELECT * FROM seans_bilgileri WHERE  FilmAdi = '" + comboBox1.SelectedItem + "' and SalonAdi = '" + comboBox2.SelectedItem + "' and tarih= '"+comboBox4.SelectedItem+"' ", conn);
            MySqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (DateTime.Parse(read["tarih"].ToString()) == DateTime.Parse(DateTime.Now.ToShortDateString()))
                {
                    if (DateTime.Parse(read["seans"].ToString())>DateTime.Parse(DateTime.Now.ToShortTimeString()))
                    {
                        comboBox3.Items.Add(read["seans"].ToString());
                    }
                  
                   


                }
              else if (DateTime.Parse(read["tarih"].ToString()) >   DateTime.Parse(DateTime.Now.ToShortDateString()))
                {
                    
                        comboBox3.Items.Add(read["seans"].ToString());
                    
                }

                }
            conn.Close();


        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Film_Seansi_Getir();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            YenidenRenklendir();
            VeriTabani_Dolu_Koltuklar();
            Combo_Dolu_Koltuklar();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (comboBox5.Text != "")
            {
                try
                {
                    conn.Open();
                    MySqlCommand sil = new MySqlCommand("Delete FROM satis_bilgileri WHERE  FilmAdi = '" + comboBox1.SelectedItem + "' and SalonAdi = '" + comboBox2.SelectedItem + "' and tarih= '" + comboBox4.SelectedItem + "' and Saat='" + comboBox3.SelectedItem + "' and KoltukNo='" + comboBox5.SelectedItem + "'  ", conn);
                    sil.ExecuteNonQuery();
                    YenidenRenklendir();
                    VeriTabani_Dolu_Koltuklar();
                    Combo_Dolu_Koltuklar();
                }

                catch (Exception hata)
                {
                    MessageBox.Show("Hata Oluştu.."+hata.Message, "Uyarı");
                }
            }

            else
            {
                MessageBox.Show("Koltuk Seçimi Yapmadınız..", "Uyarı");
            }
            conn.Close();
            

        }
    }
}
