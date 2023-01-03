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


namespace sinema
{
    public partial class frmFilmEkle : Form
    {
        public frmFilmEkle()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
        public MySqlConnection conn = new MySqlConnection("Server=localhost;Database=sinema_bileti;Uid=root;Pwd='';");
        //public MySqlConnection conn = new MySqlConnection("Server=localhost;Database=sinema_bileti;Uid=root;Pwd='';");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand filmEkle = new MySqlCommand("insert into film_bilgileri(FilmAdi,Yönetmen,FilmTuru,FilmSuresi,tarih,YapimYili,Resim) VALUES ('" + textBox5.Text + "' ,'" + textBox6.Text + "' , '" + comboBox1.Text + "', '" + textBox7.Text + "' ,'" + dateTimePicker1.Text + "','" + textBox8.Text + "' , '" + pictureBox1.ImageLocation + "' )", conn);
                
                conn.Open();
                if (filmEkle.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Film başarıyla eklendi", "Kayıt");
                    
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Aynı filmi daha önce eklediniz!!!", "Uyarı");


                conn.Close();

            }
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            comboBox1.Text = "";
            pictureBox1.ImageLocation = "";

            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            openFileDialog1.ShowDialog();//geçiş yapsın
            pictureBox1.ImageLocation = openFileDialog1.FileName; //seçilen resmi pictureboxa aktarır
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmFilmEkle_Load(object sender, EventArgs e)
        {
            
        }

        private void frmFilmEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
        }
    }
}
