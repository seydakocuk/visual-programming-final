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
using MySqlX.XDevAPI.Relational;

namespace sinema
{
    public partial class frmSatısListeleme : Form
    {
        public frmSatısListeleme()
        {
            InitializeComponent();
        }



        public MySqlConnection conn = new MySqlConnection("Server=localhost;Database=sinema_bileti;Uid=root;Pwd='';");
        DataTable tablo = new DataTable();
        private void SatisListesi(string mysql)
        {
            conn.Open();
            MySqlDataAdapter adtr = new MySqlDataAdapter(mysql, conn);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            conn.Close();
        }


        private void frmSatısListeleme_Load(object sender, EventArgs e)
        {
       ;
        }

        private void ToplamUcretHesapla()
        {
            int ucrettoplami = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                ucrettoplami += Convert.ToInt32(dataGridView1.Rows[i].Cells["ucret"].Value);
            }
            label1.Text = "Toplam Satış=" + ucrettoplami + "TL";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from satis_bilgileri";
            SatisListesi(sorgu);

            ToplamUcretHesapla();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
     

           
        }

        private void frmSatısListeleme_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
        }
    }
}
