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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string numara;
        SqlConnection baglantı = new SqlConnection(@"Data Source=LAPTOP-9MADQ7Q9\SQLEXPRESS01;Initial Catalog=Mesajlaşma Sistemi;Integrated Security=True");

       public void gelenkutusu()
        {
            SqlDataAdapter da1=new SqlDataAdapter("Select*From TBLMESAJLAR WHERE alıcı="+numara,baglantı);
            DataTable dt1=new DataTable();
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }
        public void gidenkutusu()
        {
            SqlDataAdapter da2 = new SqlDataAdapter("Select*From TBLMESAJLAR WHERE gonderen=" + numara, baglantı);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            LblNumara.Text= numara;
            gelenkutusu();
            gidenkutusu();

            //Ad Soyad Çekme
            SqlCommand komut = new SqlCommand("Select AD,SOYAD,from TBLKISILER where numara=" + numara, baglantı);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0]+" "+dr[1];
            }
            baglantı.Close();   

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("insert into TBLMESAJLAR(GONDEREN,ALICI,BASLIK,ICERIK values(@p1,@p2,@p3,@p4)", baglantı);
            komut.Parameters.AddWithValue("@p1", numara);
            komut.Parameters.AddWithValue("@p2", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p3", textBox1.Text);
            komut.Parameters.AddWithValue("@p4", richTextBox1.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Mesajınız İletildi");
            gidenkutusu();
            
        }
    }
}
