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
    public partial class UyeSil : Form
    {
        public UyeSil()
        {
            InitializeComponent();
        }

        private void UyeSil_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;

            UyeBL uyeBL = new UyeBL();

            DataTable datatable = new DataTable();
            datatable = uyeBL.GetUyeAktif();
            dataGridView1.DataSource = datatable;
        }

        private void btn_Pasif_Click(object sender, EventArgs e)
        {
            if (label_Tc.Text != "")
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    dataGridView1.DataSource = null;
                    UyeBL uyeBL = new UyeBL();
                    uyeBL.UyelikPasifYap(label_Tc.Text);
                    DataTable datatable = new DataTable();
                    datatable = uyeBL.GetUyeAktif();
                    dataGridView1.DataSource = datatable;
                }
                else
                {
                    dataGridView1.DataSource = null;
                    UyeBL uyeBL = new UyeBL();
                    uyeBL.UyelikAktifYap(label_Tc.Text);
                    DataTable datatable = new DataTable();
                    datatable = uyeBL.GetUyePasif();
                    dataGridView1.DataSource = datatable;
                }


            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgvRow = dataGridView1.Rows[e.RowIndex];
                label_Tc.Text = dgvRow.Cells[0].Value.ToString();
                string ad = dgvRow.Cells[1].Value.ToString();
                string soyad = dgvRow.Cells[2].Value.ToString();
                label_AdSoyad.Text = ad + " " + soyad;

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Aktif Üyeler")
            {
                dataGridView1.DataSource = null;
                UyeBL uyeBL = new UyeBL();
                DataTable datatable = new DataTable();
                datatable = uyeBL.GetUyeAktif();
                dataGridView1.DataSource = datatable;
                label_aciklama.Text = "Aşağıdaki üyenin üyelik durumu pasif duruma getirilecektir!";
                btn_Pasif.Text = "Pasif Yap";

            }
            else if (comboBox1.Text == "Pasif Üyeler")
            {
                dataGridView1.DataSource = null;
                UyeBL uyeBL = new UyeBL();
                DataTable datatable = new DataTable();
                datatable = uyeBL.GetUyePasif();
                dataGridView1.DataSource = datatable;
                label_aciklama.Text = "Aşağıdaki üyenin üyelik durumu aktif duruma getirilecektir!";
                btn_Pasif.Text = "Aktif Yap";
            }
            else { }
        }
    }
}
