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

namespace IlterFehmiAtaulusoy_22194484_Proje
{
    public partial class KasaBilgi : Form
    {
        MySqlConnection baglanti = new MySqlConnection("Server = localhost; Database = demirbastakip; user = root; Pwd =");
        private int kasaid;
        private int id;

        public KasaBilgi()
        {
            InitializeComponent();
        }

        public KasaBilgi(int kasaid, int id)
        {
            this.kasaid = kasaid;
            this.id = id;
        }

        public int KASAID
        {
            get { return kasaid; } 
            set { kasaid = value; }
        }

        public int IDD
        {
            get { return id; }
            set { id = value; }
        }

        private void yazdir()
        {
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand();
            komut.CommandText = "SELECT * FROM urunler WHERE urun_id = @kasaid";
            komut.Parameters.AddWithValue("@kasaid", kasaid);
            komut.Connection = baglanti;
            MySqlDataReader okuyucu = komut.ExecuteReader();
            okuyucu.Read();
            int kullanicino = Convert.ToInt32(okuyucu["k_id"].ToString());
            MySqlCommand komut1 = new MySqlCommand();
            komut1.CommandText = "SELECT sicilno FROM kullanicilar WHERE kullanici_id = @kullanicino";
            komut1.Parameters.AddWithValue("@kullanicino", kullanicino);
            komut1.Connection = baglanti;

            txtKasano.Text = okuyucu["urun_id"].ToString();
            okuyucu.Close();
            okuyucu = komut1.ExecuteReader();
            okuyucu.Read();
            txtSicilno.Text = okuyucu["sicilno"].ToString();
            okuyucu.Close();
            okuyucu = komut.ExecuteReader();
            okuyucu.Read();
            txtMarka.Text = okuyucu["marka"].ToString();
            txtModel.Text = okuyucu["model"].ToString();
            txtAciklama.Text = okuyucu["aciklama"].ToString();
            txtTarih.Text = okuyucu["tarih"].ToString();
            txtIslemci.Text = okuyucu["islemci"].ToString();
            txtRam.Text = okuyucu["ram"].ToString();
            txtDisk.Text = okuyucu["disk"].ToString();
            txtEkranKarti.Text = okuyucu["ekrankarti"].ToString();
            txtMonitor.Text = okuyucu["monitorboyut"].ToString();
            okuyucu.Close();
            komut.Dispose();
            komut1.Dispose();
            baglanti.Close();
        }

        private void KasaBilgi_Load(object sender, EventArgs e)
        {
            yazdir();
            btnEkle.Enabled = false;
            txtKasano.ReadOnly = true;
            txtSicilno.ReadOnly = true;
        }

        private void btnKaydiSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand komut3 = new MySqlCommand();
            komut3.CommandText = "DELETE FROM urunler WHERE urun_id = @kasaid";
            komut3.Parameters.AddWithValue("@kasaid", kasaid);
            komut3.Connection = baglanti;
            komut3.ExecuteNonQuery();
            komut3.Dispose();
            baglanti.Close() ;
            this.Close();
            
        }

        private void urunUpdate()
        {
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand();
            komut.CommandText = "UPDATE urunler SET marka=@marka, model=@model, tarih=@tarih, aciklama=@aciklama, islemci=@islemci, ram=@ram, disk=@disk, ekrankarti=@ekrankarti, monitorboyut=@monitorboyut WHERE urun_id = @id";
            komut.Parameters.AddWithValue("@marka", txtMarka.Text);
            komut.Parameters.AddWithValue("@model", txtModel.Text);
            komut.Parameters.AddWithValue("@tarih", txtTarih.Text);
            komut.Parameters.AddWithValue("@aciklama", txtAciklama.Text);
            komut.Parameters.AddWithValue("@islemci", txtIslemci.Text);
            komut.Parameters.AddWithValue("@ram", txtRam.Text);
            komut.Parameters.AddWithValue("@disk", txtDisk.Text);
            komut.Parameters.AddWithValue("@ekrankarti", txtEkranKarti.Text);
            komut.Parameters.AddWithValue("@monitorboyut", txtMonitor.Text);
            komut.Parameters.AddWithValue("@id", kasaid);
            komut.Connection = baglanti;
            komut.ExecuteNonQuery();
            komut.Dispose();
            baglanti.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            urunUpdate();
            yazdir();
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            btnKaydet.Enabled = false;
            btnEkle.Enabled = true;
            btnYeni.Enabled = false;
            btnKaydiSil.Enabled = false;
            txtKasano.Text = "";
            txtSicilno.Text = "";
            txtMarka.Text = "";
            txtModel.Text = "";
            txtAciklama.Text = "";
            txtTarih.Text = "";
            txtIslemci.Text = "";
            txtRam.Text = "";
            txtDisk.Text = "";
            txtEkranKarti.Text = "";
            txtMonitor.Text = "";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand();
            komut.CommandText = "INSERT INTO `urunler` (`urun_id`, `marka`, `model`, `tarih`, `aciklama`, `islemci`, `ram`, `disk`, `ekrankarti`, `monitorboyut`, `k_id`) VALUES (NULL, @marka, @model, @tarih, @aciklama, @islemci, @ram, @disk, @ekrankarti, @monitorboyut, @id)";
            komut.Parameters.AddWithValue("@marka", txtMarka.Text);
            komut.Parameters.AddWithValue("@model", txtModel.Text);
            komut.Parameters.AddWithValue("@tarih", txtTarih.Text);
            komut.Parameters.AddWithValue("@aciklama", txtAciklama.Text);
            komut.Parameters.AddWithValue("@islemci", txtIslemci.Text);
            komut.Parameters.AddWithValue("@ram", txtRam.Text);
            komut.Parameters.AddWithValue("@disk", txtDisk.Text);
            komut.Parameters.AddWithValue("@ekrankarti", txtEkranKarti.Text);
            komut.Parameters.AddWithValue("@monitorboyut", txtMonitor.Text);
            komut.Parameters.AddWithValue("@id", id);
            komut.Connection = baglanti;
            komut.ExecuteNonQuery();
            komut.Dispose();
            baglanti.Close();
            btnKaydet.Enabled = true;
            btnYeni.Enabled = false;
            btnEkle.Enabled = false;
            btnKaydiSil.Enabled = true;
        }
    }
}
