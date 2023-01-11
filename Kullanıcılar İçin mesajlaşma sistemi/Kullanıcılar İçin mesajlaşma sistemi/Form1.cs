using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Kullanıcılar_İçin_mesajlaşma_sistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //Data Source=LAPTOP-9MADQ7Q9\SQLEXPRESS01;Initial Catalog=Mesajlaşma Sistemi;Integrated Security=True
        SqlConnection baglantı = new SqlConnection(@"Data Source=LAPTOP-9MADQ7Q9\SQLEXPRESS01;Initial Catalog=Mesajlaşma Sistemi;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut=new SqlCommand("Select*From TBLKISILER where NUMARA=@P1 AND SIFRE=@P2",baglantı);
            komut.Parameters.AddWithValue("@P1", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@P2", textBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Form2 frm = new Form2();
                frm.numara = maskedTextBox1.Text; //numara değişkenine maskedtextbox değerini ata
                frm.Show();
            }
            else
            {
                MessageBox.Show("Hatalı Bilgi");
            }

        }
    }
}
