using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;


namespace MehmetCan
{
    public partial class UyeEkle : Form
    {
        public UyeEkle()
        {
            InitializeComponent();
        }

        private void btn_Ekle_Click(object sender, EventArgs e)
        {
            UyeBL UyeIslemleri = new UyeBL();

            if (txt_Ad.Text == "" || txt_Soyad.Text == "" || txt_TcNo.Text == "" || cb_Sehir.Text == "" || txt_Eposta.Text == ""
              || txt_TelNo.Text == "" || cb_KanGrubu.Text == "")
            {
                MessageBox.Show("Lütfen eksik alanları doldurunuz.");
            }
            else if (txt_TcNo.Text.Length != 11)
            {
                MessageBox.Show("Tc No 11 karakterden kısa veya uzun olamaz.");
            }
            else if (txt_TelNo.Text.Length != 10)
            {
                MessageBox.Show("Telefon No 10 karakterden kısa veya uzun olamaz.");
            }
            else if (!this.txt_Eposta.Text.Contains('@') || !this.txt_Eposta.Text.Contains('.'))//Mail adresi kısmında @ ve . karakterlerinin bulunmaması durumunda çalışır.
            {
                MessageBox.Show("Lütfen Mail adresi alanını mail formatında doldurunuz.");
            }
            else
            {
                int ay = DateTime.Now.Month;
                int Sonuc = UyeIslemleri.AddUser(txt_TcNo.Text, txt_Ad.Text, txt_Soyad.Text, cb_Sehir.Text, txt_Eposta.Text, cb_KanGrubu.Text, txt_TelNo.Text);
                UyeIslemleri.UyeEkleBorcBaslangic(txt_TcNo.Text, txt_Eposta.Text);
                MessageBox.Show(Sonuc + " Üye eklenmiştir.");
                this.Hide();


                DernekYonetim.holder = 1;
                



            }
        }

        private void txt_TcNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_Ad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void txt_Soyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void txt_TelNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_TelNo.Text.Length == 1)
            {
                if (txt_TelNo.Text == "0")
                {
                    txt_TelNo.Text = txt_TelNo.Text.Substring(1);
                }
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
