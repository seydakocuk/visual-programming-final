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
    public partial class Admin_Girisi : Form
    {
        public Admin_Girisi()
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

                MySqlCommand komut = new MySqlCommand("select*from admin_girisi where kullanici_adi ='" + user + "' and sifre='" + password + "'", conn);
                MySqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    MessageBox.Show("Giriş Başarılı..");
                    Form1 giris = new Form1();
                    giris.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı kullanıcı veya şifre girişi..");
                }

                conn.Close();
            }
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
    }
}
