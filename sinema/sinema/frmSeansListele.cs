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
    public partial class frmSeansListele : Form
    {
        public frmSeansListele()
        {
            InitializeComponent();
        }
        public MySqlConnection conn = new MySqlConnection("Server=localhost;Database=sinema_bileti;Uid=root;Pwd='';");
        DataTable tablo = new DataTable();
        private void SeansListesi(string mysql)
        {
            conn.Open();
            MySqlDataAdapter adtr = new MySqlDataAdapter(mysql ,conn);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            conn.Close();
        }


        private void frmSeansListele_Load(object sender, EventArgs e)
        {
            tablo.Clear();
            string sorgu = "select * from seans_bilgileri where tarih like '"+dateTimePicker1.Text+"'";
            SeansListesi(sorgu);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            tablo.Clear();
            string sorgu = "select * from seans_bilgileri where tarih like '" + dateTimePicker1.Text + "'";
            SeansListesi(sorgu);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tablo.Clear();
            string sorgu = "select * from seans_bilgileri";
            SeansListesi(sorgu);
        }

        private void frmSeansListele_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
        }
    }
}
