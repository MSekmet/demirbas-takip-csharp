using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IlterFehmiAtaulusoy_22194484_Proje
{
    public partial class Form1 : Form
    {
        MySqlConnection baglanti = new MySqlConnection("Server = localhost; Database = demirbastakip; user = root; Pwd =");

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            String mail = txtMail.Text;
            String sifre = txtSifre.Text;
            baglanti.Open();

            MySqlCommand komut = new MySqlCommand();
            komut.CommandText = "SELECT * FROM kullanicilar WHERE mail = @mail AND sifre = @sifre";
            komut.Parameters.AddWithValue("@mail", mail);
            komut.Parameters.AddWithValue("@sifre", sifre);
            komut.Connection = baglanti;

            MySqlDataReader okuyucu = komut.ExecuteReader();

            if (okuyucu.Read())
            {
                lblUyari.Text = "";
                okuyucu.Read();
                int id = Convert.ToInt32(okuyucu["kullanici_id"].ToString());
                DemirbasTakip demirbasTakip = new DemirbasTakip();
                demirbasTakip.ID = id;
                komut.Dispose();
                baglanti.Close();
                this.Hide();
                demirbasTakip.ShowDialog();
                this.Show();
            }
            else
            {
                lblUyari.Text = "Mail ya da şifreniz yanlış, lütfen kontrol ediniz.";
                komut.Dispose ();
                baglanti.Close() ;
            }
            
        }
    }
}
