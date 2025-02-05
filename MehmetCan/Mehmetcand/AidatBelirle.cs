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
    public partial class AidatBelirle : Form
    {
        public AidatBelirle()
        {
            InitializeComponent();
        }
        private string[] aylar = new string[12];
        private void AidatBelirle_Load(object sender, EventArgs e)
        {
            UyeBL uyeBL = new UyeBL();
            DataTable datatable = new DataTable();
            datatable = uyeBL.GetAidats();
            dataGridView1.DataSource = datatable;

            for (int i = 0; i < 12; i++)
            {
                int cell = i + 1;
                aylar[i] = dataGridView1.Rows[0].Cells[cell].Value.ToString();
            }
            dataGridView1.DataSource = null;
            txt_Ocak.Text = aylar[0];
            txt_Subat.Text = aylar[1];
            txt_Mart.Text = aylar[2];
            txt_Nisan.Text = aylar[3];
            txt_Mayis.Text = aylar[4];
            txt_Haziran.Text = aylar[5];
            txt_Temmuz.Text = aylar[6];
            txt_Agustos.Text = aylar[7];
            txt_Eylul.Text = aylar[8];
            txt_Ekim.Text = aylar[9];
            txt_Kasim.Text = aylar[10];
            txt_Aralik.Text = aylar[11];
        }

        private void btn_Guncelle_Click(object sender, EventArgs e)
        {
            UyeBL aidat = new UyeBL();
            int Sonuc = aidat.AidatBelirle(txt_Ocak.Text,
            txt_Subat.Text,
            txt_Mart.Text,
            txt_Nisan.Text,
            txt_Mayis.Text,
            txt_Haziran.Text,
            txt_Temmuz.Text,
            txt_Agustos.Text,
            txt_Eylul.Text,
            txt_Ekim.Text,
            txt_Kasim.Text,
            txt_Aralik.Text);

            if (Sonuc == 1)
            {
                MessageBox.Show("Aidatlar güncellenmiştir.");
            }

            this.Hide();
        }
    }
}
