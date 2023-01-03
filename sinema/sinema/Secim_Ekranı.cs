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
    public partial class Secim_Ekranı : Form
    {
        public Secim_Ekranı()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin_Girisi giris = new Admin_Girisi();
            giris.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kullanıcı_Girisi giris = new Kullanıcı_Girisi();
            giris.Show();
            this.Hide();
        }
    }
}
