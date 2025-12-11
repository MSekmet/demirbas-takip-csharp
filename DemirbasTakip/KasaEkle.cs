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
    public partial class KasaEkle : Form
    {
        MySqlConnection baglanti = new MySqlConnection("Server = localhost; Database = demirbastakip; user = root; Pwd =");
        private int sicilno;
        private int id;

        public KasaEkle()
        {
            InitializeComponent();
        }

        public KasaEkle(int id, int sicilno)
        {
            this.id = id;
            this.sicilno = sicilno;
        }

        public int KID
        {
            get { return id; }
            set { id = value; }
        }

        public int SID
        {
            get { return sicilno; }
            set { sicilno = value; }
        }

        private void KasaEkle_Load(object sender, EventArgs e)
        {
            txtSicilno.Text = sicilno.ToString();
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
            this.Close();
        }
    }
}
