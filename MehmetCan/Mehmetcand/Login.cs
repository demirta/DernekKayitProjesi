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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            LoginBL loginBL = new LoginBL();
            DernekYonetim dernekMain = new DernekYonetim();

            if (txt_username.Text == "" || txt_password.Text == "")
            {
                MessageBox.Show("Lütfen kullanıcı adı veya şifre alanlarını doldurunuz.");
            }
            else
            {


                DataTable datatable = new DataTable();
                //datatable = loginBL.LoginKontrolAdmin(txt_username.Text, txt_password.Text);
                int sonuc = int.Parse(loginBL.GirişKontrolAdmin(txt_username.Text, txt_password.Text));

                if (/*datatable.Rows.Count*/sonuc > 0)
                {
                    datatable = loginBL.GirisYapaninBilgileri(txt_username.Text, txt_password.Text);

                    foreach (DataRow row in datatable.Rows)
                    {


                        dernekMain.isim = row.Field<string>("Ad");
                        dernekMain.soyisim = row.Field<string>("Soyad");
                    }
                    dernekMain.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı veya Parola Hatalı.");
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
