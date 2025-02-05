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
    public partial class BorcEkle : Form
    {
        public BorcEkle()
        {
            InitializeComponent();
        }

        private string[] aylar = new string[12];

        private void BorcEkle_Load(object sender, EventArgs e)
        {
            label_tc.Text = "";
            label_adsoyad.Text = "";


            UyeBL uyeBL = new UyeBL();

            DataTable datatableee = new DataTable();
            datatableee = uyeBL.GetAidats();
            dataGridView1.DataSource = datatableee;

            for (int i = 0; i < 12; i++)
            {
                int cell = i + 1;
                aylar[i] = dataGridView1.Rows[0].Cells[cell].Value.ToString();
            }
            dataGridView1.DataSource = null;



            dataGridView1.DataSource = null;
            DataTable datatable = new DataTable();
            datatable = uyeBL.GetUyeAktif();
            dataGridView1.DataSource = datatable;

            label_aidat.Text = label_aidat.Text + " " + aylar[DateTime.Now.Month - 1];
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgvRow = dataGridView1.Rows[e.RowIndex];
                label_tc.Text = dgvRow.Cells[0].Value.ToString();
                label_adsoyad.Text = dgvRow.Cells[1].Value.ToString() + " " + dgvRow.Cells[2].Value.ToString();

            }
        }
        public int borc = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            UyeBL uyeBL = new UyeBL();
            if (label_tc.Text != "")
            {
                dataGridView1.DataSource = null;
                DataTable datatablee = new DataTable();
                datatablee = uyeBL.BorcVeriAl(label_tc.Text);
                dataGridView1.DataSource = datatablee;
                borc = int.Parse(dataGridView1.Rows[0].Cells[1].Value.ToString());
                int yeniborc = borc + int.Parse(aylar[DateTime.Now.Month - 1]);
                uyeBL.UyeBorcEkle(label_tc.Text, yeniborc.ToString());

               // MessageBox.Show("Eski Borç: " + borc + " Güncel Borç: " + yeniborc.ToString());
                MessageBox.Show(label_adsoyad.Text + " kişisine " + aylar[DateTime.Now.Month - 1] + "TL tutarında borç eklenmiştir.");


            }
            label_tc.Text = "";
            label_adsoyad.Text = "";


            dataGridView1.DataSource = null;
            DataTable datatable = new DataTable();
            datatable = uyeBL.GetUyeAktif();
            dataGridView1.DataSource = datatable;
        }
    }
}
