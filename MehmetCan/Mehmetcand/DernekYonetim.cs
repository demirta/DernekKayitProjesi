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
    public partial class DernekYonetim : Form
    {
        public DernekYonetim()
        {
            InitializeComponent();
        }
        public string isim;
        public string soyisim;

        public static int holder = 0;
        private void DernekYonetim_Load(object sender, EventArgs e)
        {
            login_NameSurname.Text = "Hoş Geldiniz Sayın " + isim + " " + soyisim;

            UyeBL uyeBL = new UyeBL();

            DataTable datatable = new DataTable();
            datatable = uyeBL.GetUyeAktif();
            dataGridView1.DataSource = datatable;

        }

        private void DernekYonetim_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btn_UyeEkle_Click(object sender, EventArgs e)
        {
            UyeEkle uyeEkle = new UyeEkle();
            uyeEkle.ShowDialog();
        }

        private void btn_UyeSil_Click(object sender, EventArgs e)
        {
            UyeSil uyeSil = new UyeSil();
            uyeSil.ShowDialog();
        }

        private void btn_UyeListe_Click(object sender, EventArgs e)
        {
            UyeListele uyeListele = new UyeListele();
            uyeListele.ShowDialog();
        }

        private void DernekYonetim_MouseEnter(object sender, EventArgs e)
        {
            if(holder == 1)
            {
                UyeBL uyeBL = new UyeBL();

                DataTable datatable = new DataTable();
                datatable = uyeBL.GetUyeAktif();
                dataGridView1.DataSource = datatable;

                holder = 0;
            }
        }

        private void btn_Borc_Click(object sender, EventArgs e)
        {
            BorcSorgula borcSorgula = new BorcSorgula();
            borcSorgula.ShowDialog(); 
        }

        private void btn_BorcEkle_Click(object sender, EventArgs e)
        {
            BorcEkle borcEkle = new BorcEkle();
            borcEkle.ShowDialog();
        }

        private void btn_aidatbelirle_Click(object sender, EventArgs e)
        {
            AidatBelirle aidatBelirle = new AidatBelirle();
            aidatBelirle.ShowDialog(); 
        }

        private void btn_Grafik_Click(object sender, EventArgs e)
        {
            Grafikler grafikler = new Grafikler();
            grafikler.ShowDialog();
        }
    }
}
