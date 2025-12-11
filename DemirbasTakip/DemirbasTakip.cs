using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IlterFehmiAtaulusoy_22194484_Proje
{
    public partial class DemirbasTakip : Form
    {
        MySqlConnection baglanti = new MySqlConnection("Server = localhost; Database = demirbastakip; user = root; Pwd =");
        private int id;
        private int kasaid;
        private int sicilno;

        public DemirbasTakip()
        {
            InitializeComponent();
        }

        public DemirbasTakip(int id)
        {
            this.id = id;
        }

        public int ID 
        {
            get { return id; }
            set { id = value; }
        }

        private void yazdir()
        {
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand();
            komut.CommandText = "SELECT * FROM kullanicilar WHERE kullanici_id = @id";
            komut.Parameters.AddWithValue("@id", id);
            komut.Connection = baglanti;
            MySqlDataReader okuyucu = komut.ExecuteReader();
            okuyucu.Read();
            txtAd.Text = okuyucu["ad"].ToString();
            txtSoyad.Text = okuyucu["soyad"].ToString();
            txtSicilno.Text = okuyucu["sicilno"].ToString();
            sicilno = Convert.ToInt32(okuyucu["sicilno"]);
            lblSicil.Text = okuyucu["sicilno"].ToString();
            cmbUnvan.Text = okuyucu["unvan"].ToString();
            cmbBolum.Text = okuyucu["bolum"].ToString();
            txtMail.Text = okuyucu["mail"].ToString();
            txtOdano.Text = okuyucu["odano"].ToString();
            txtTarih.Text = okuyucu["baslamatarih"].ToString();
            rtxtAciklama.Text = okuyucu["aciklama"].ToString();
            komut.Dispose();
            baglanti.Close();
        }

        private void DemirbasTakip_Load(object sender, EventArgs e)
        {
            yazdir();
            listele();
            string yol = Environment.GetEnvironmentVariable("HOMEDRIVE") + Environment.GetEnvironmentVariable("HOMEPATH");
            pbxIkon.Image = Image.FromFile(yol+@"\\source\\repos\\IlterFehmiAtaulusoy_22194484_Proje\\IlterFehmiAtaulusoy_22194484_Proje\\Resources\\" + id+".jpg");
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand();
            komut.CommandText = "UPDATE kullanicilar SET ad=@ad, soyad=@soyad, sicilno=@sicilno, unvan=@unvan, bolum=@bolum, mail=@mail, odano=@odano, baslamatarih=@baslamatarih, aciklama=@aciklama WHERE kullanici_id = @id";
            komut.Parameters.AddWithValue("@ad", txtAd.Text);
            komut.Parameters.AddWithValue("@soyad", txtSoyad.Text);
            komut.Parameters.AddWithValue("@sicilno", txtSicilno.Text);
            komut.Parameters.AddWithValue("@unvan", cmbUnvan.Text);
            komut.Parameters.AddWithValue("@bolum", cmbBolum.Text);
            komut.Parameters.AddWithValue("@mail", txtMail.Text);
            komut.Parameters.AddWithValue("@odano", txtOdano.Text);
            komut.Parameters.AddWithValue("@baslamatarih", txtTarih.Text);
            komut.Parameters.AddWithValue("@aciklama", rtxtAciklama.Text);
            komut.Parameters.AddWithValue("@id", id);
            komut.Connection = baglanti;
            komut.ExecuteNonQuery();
            komut.Dispose();
            baglanti.Close();
            yazdir();

        }
        private void listele()
        {
            baglanti.Open();
            MySqlDataAdapter adaptor = new MySqlDataAdapter("SELECT urun_id as 'Ürün id', marka as 'Marka', model as 'Model', aciklama as 'Açıklama', tarih as 'Verildiği Tarih' FROM urunler WHERE k_id=@id", baglanti);
            adaptor.SelectCommand.Parameters.AddWithValue("@id", id);
            DataTable dt = new DataTable();

            dt.Clear();
            adaptor.Fill(dt); // Tabloyu doldur doldur
            dataGridView1.DataSource = dt; //Datagrid doldur
                                           //Datagrid doldur
            adaptor.Dispose(); //Adaptor ü kapat
            baglanti.Close(); // Bağlantıyı kapat 
        }

        private void btnKasa_Click(object sender, EventArgs e)
        {
            if (lblkasakontrol.Text == null || lblkasakontrol.Text == ".")
            {
                MessageBox.Show("Lütfen geçerli bir kasa seçiniz!");
            }
            else
            {
                KasaBilgi kasaBilgi = new KasaBilgi();
                kasaBilgi.KASAID = kasaid;
                kasaBilgi.IDD = id;
                this.Hide();
                kasaBilgi.ShowDialog();
                this.Show();
                listele();
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            kasaid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Ürün id"].Value.ToString());
            lblkasakontrol.Text = kasaid.ToString();
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            KasaEkle kasaEkle = new KasaEkle();
            kasaEkle.KID = id;
            kasaEkle.SID = sicilno;
            this.Hide();
            kasaEkle.ShowDialog();
            this.Show();
            listele();
        }
    }
}
