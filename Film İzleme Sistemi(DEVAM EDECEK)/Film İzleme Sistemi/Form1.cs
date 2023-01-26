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



namespace Film_İzleme_Sistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnÇıkışYap_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        //Data Source =LAPTOP-9MADQ7Q9\SQLEXPRESS01
        //Data Source=LAPTOP-9MADQ7Q9\SQLEXPRESS01
        SqlConnection baglantı = new SqlConnection(@"Data Source=LAPTOP-9MADQ7Q9\SQLEXPRESS01;Initial Catalog=Film Arşivim;Integrated Security=True");
        public void Filmler()
        {
           
            SqlDataAdapter da = new SqlDataAdapter("Select AD,Kategori,LINK from TBLFILMLER", baglantı);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;//Datagriedviewe verileri yazdır

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            Filmler();


        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("insert into TBLFILMLER (AD,Kategori,LINK)values(@p1,@p2,@p3)", baglantı);
            komut.Parameters.AddWithValue("@p1", TxtFilmAdı.Text);
            komut.Parameters.AddWithValue("@p2", TxtKategori.Text);
            komut.Parameters.AddWithValue("@p3", TxtLınk.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Kayıt İşlemi başarıyla gerçekleşti");

        }

        private void BtnHakkımızda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu proje Elif Özkan tarafından 24 Ocak 2023 tarihinde yapılmıştır", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int seçilen = dataGridView1.SelectedCells[0].RowIndex;
            string link = dataGridView1.Rows[seçilen].Cells[3].Value.ToString();
            webBrowser1.Navigate(link);
            
        }

        private void BtnRenkDegiştir_Click(object sender, EventArgs e)
        {
            //Formun arka plan rengini isteğe bağlı olarak değiştir
            string[] renkler = { "mavi", "turuncu", "mor", "beyaz", "siyah", "gri" };
        }
    }
}
