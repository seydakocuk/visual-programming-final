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

namespace sinema
{
    public partial class frmSalonEkle : Form
    {
        public frmSalonEkle()
        {
            InitializeComponent();
        }

        private void frmSalonEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
        }
        public MySqlConnection conn = new MySqlConnection("Server=localhost;Database=sinema_bileti;Uid=root;Pwd='';");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand salonEkle = new MySqlCommand("insert into salon_bilgileri(SalonAdi) VALUES ('" + textBox5.Text + "')", conn);
                conn.Open();
                if (salonEkle.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Salon başarıyla eklendi", "Kayıt");
                }
            }
            catch (Exception) {
                
                    MessageBox.Show("Aynı salonu daha önce eklediniz!!!", "Uyarı");

                
                conn.Close();
            }
            textBox5.Text = "";
        
    
        }

        private void frmSalonEkle_Load(object sender, EventArgs e)
        {
           
        }
    }
}
