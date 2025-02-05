using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Mail;
using iTextSharp.text;
using iTextSharp.text.pdf;
using BL;

namespace MehmetCan
{
    public partial class BorcSorgula : Form
    {
        public BorcSorgula()
        {
            InitializeComponent();
        }

        private void btn_pdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.OverwritePrompt = false;
            save.Title = "PDF Dosyaları";
            save.DefaultExt = "pdf";
            save.Filter = "PDF Dosyaları (*.pdf)|*.pdf|Tüm Dosyalar(*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK)
            {
                PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);

                // Bu alanlarla oynarak tasarımı iyileştirebilirsiniz.
                pdfTable.DefaultCell.Padding = 3; // hücre duvarı ve veri arasında mesafe
                pdfTable.WidthPercentage = 80; // hücre genişliği
                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT; // yazı hizalaması
                pdfTable.DefaultCell.BorderWidth = 1; // kenarlık kalınlığı
                // Bu alanlarla oynarak tasarımı iyileştirebilirsiniz.

                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240); // hücre arka plan rengi
                    pdfTable.AddCell(cell);
                }
                try
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            pdfTable.AddCell(cell.Value.ToString());
                        }
                    }
                    MessageBox.Show("PDF Başarıyla Oluşturuldu.");
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                }
                using (FileStream stream = new FileStream(save.FileName + ".pdf", FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);// sayfa boyutu.
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(pdfTable);
                    pdfDoc.Close();
                    stream.Close();
                }
            }
        }
        private const int MaxCharacters = 250;
        private void txt_mail_TextChanged(object sender, EventArgs e)
        {
            if (txt_mail.Text.Length > MaxCharacters)
            {
                txt_mail.Text = txt_mail.Text.Substring(0, MaxCharacters);
                txt_mail.SelectionStart = MaxCharacters;
            }
        }

        private void txt_mail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_mail.Text.Length >= MaxCharacters && e.KeyChar != '\b') // '\b' Backspace karakteridir
            {
                // 250 karakter sınırını aştığında ve geri tuşuna basılmadığında yazma işlemini engelle
                e.Handled = true;
            }
        }

        private void btn_mail_Click(object sender, EventArgs e)
        {
            // tablodaki satır sayısı kadar 
            // DataGridView'deki satır sayısını alın
            string aliciMailAdresi = "";
            int rowCount = dataGridView1.RowCount;

            // Satırları sırasıyla okuyun
            for (int i = 0; i < rowCount; i++)
            {
                // Satırdaki her hücreyi sırasıyla okuyun

                // Hücre değerini alın
                object cellValue = dataGridView1.Rows[i].Cells[2].Value;
                aliciMailAdresi = cellValue.ToString();
                if (aliciMailAdresi != "" && txt_mail.Text != "")
                {
                    mailGonder(txt_mail.Text, aliciMailAdresi);
                }
                else
                {
                    MessageBox.Show("Mail içeriği veya Mail adresi hatalı! Lütfen mesaj girmeyi unutmayınız!");
                }

            }
        }
        void mailGonder(string mailIcerigi, string aliciMail)
        {

            try
            {
                string pdfstring = mailIcerigi;
                MailMessage mesajım = new MailMessage();
                SmtpClient istemci = new SmtpClient();
                istemci.Credentials = new System.Net.NetworkCredential("demirtasmehmetcan705@outlook.com", "M.can2121");
                istemci.DeliveryMethod = SmtpDeliveryMethod.Network;
                istemci.Port = 587;
                istemci.Host = "smtp-mail.outlook.com";
                istemci.EnableSsl = true;
                istemci.UseDefaultCredentials = false;
                mesajım.To.Add(aliciMail);
                mesajım.From = new MailAddress("demirtasmehmetcan705@outlook.com");
                mesajım.Subject = "Dernek Borç Mesajı";
                mesajım.Body = pdfstring;// ana mesaj
                istemci.Send(mesajım);
                MessageBox.Show("Mail başarıyla gönderilmiştir.");
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Mail gönderme işlemi başarısız: {ex.Message}");

            }


        }

        private void BorcSorgula_Load(object sender, EventArgs e)
        {
            UyeBL uyeBL = new UyeBL();

            DataTable datatable = new DataTable();
            datatable = uyeBL.GetBorc();
            dataGridView1.DataSource = datatable;
        }
    }
}
