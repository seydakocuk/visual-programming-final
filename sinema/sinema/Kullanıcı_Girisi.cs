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
    public partial class Kullanıcı_Girisi : Form
    {
        public Kullanıcı_Girisi()
        {
            InitializeComponent();
        }
        public MySqlConnection conn = new MySqlConnection("Server=localhost;Database=sinema_bileti;Uid=root;Pwd='';");
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız..");
            }
            else
            {
                conn.Open();

                string user;
                string password;
                user = textBox1.Text;
                password = textBox2.Text;

                MySqlCommand komut = new MySqlCommand("select*from kullanici_girisi where kullanici_adi ='" + user + "' and sifre='" + password + "'", conn);
                MySqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    MessageBox.Show("Giriş Başarılı..");
                    frmSeansListele giris = new frmSeansListele();
                    giris.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı kullanıcı veya şifre girişi..");
                }

                conn.Close();

            }       }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız..");
            }
            else
            {
                conn.Open();
                string user;
                string password;
                user = textBox1.Text;
                password = textBox2.Text;
                MySqlCommand komut = new MySqlCommand("select*from kullanici_girisi where kullanici_adi ='" + user + "'", conn);
                MySqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    MessageBox.Show("Bu kullanıcı adı kullanılıyor, lütfen başka kullanıcı adı belirleyiniz..");
                }
                else
                {
                    oku.Close();
                    MySqlCommand ekle = new MySqlCommand("insert into kullanici_girisi( kullanici_adi,sifre) VALUES ('" + user + "' , '" + password + "')", conn);
                    ekle.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Oldunuz , Seanslara yönlendiriliyorsunuz..");
                    frmSeansListele giris = new frmSeansListele();
                    giris.Show();
                    this.Hide();
                }

            }
       



        conn.Close();
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

            private void Kullanıcı_Girisi_Load(object sender, EventArgs e)
        {

        }
    }
}
