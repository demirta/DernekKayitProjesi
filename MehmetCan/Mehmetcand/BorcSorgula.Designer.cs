
namespace MehmetCan
{
    partial class BorcSorgula
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_mail = new System.Windows.Forms.RichTextBox();
            this.btn_mail = new System.Windows.Forms.Button();
            this.btn_pdf = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_mail
            // 
            this.txt_mail.Location = new System.Drawing.Point(81, 391);
            this.txt_mail.Name = "txt_mail";
            this.txt_mail.Size = new System.Drawing.Size(314, 104);
            this.txt_mail.TabIndex = 7;
            this.txt_mail.Text = "";
            this.txt_mail.TextChanged += new System.EventHandler(this.txt_mail_TextChanged);
            this.txt_mail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_mail_KeyPress);
            // 
            // btn_mail
            // 
            this.btn_mail.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_mail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_mail.Location = new System.Drawing.Point(167, 337);
            this.btn_mail.Name = "btn_mail";
            this.btn_mail.Size = new System.Drawing.Size(122, 48);
            this.btn_mail.TabIndex = 6;
            this.btn_mail.Text = "MAİL GÖNDER";
            this.btn_mail.UseVisualStyleBackColor = false;
            this.btn_mail.Click += new System.EventHandler(this.btn_mail_Click);
            // 
            // btn_pdf
            // 
            this.btn_pdf.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_pdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_pdf.Location = new System.Drawing.Point(167, 276);
            this.btn_pdf.Name = "btn_pdf";
            this.btn_pdf.Size = new System.Drawing.Size(122, 48);
            this.btn_pdf.TabIndex = 5;
            this.btn_pdf.Text = "PDF OLUŞTUR";
            this.btn_pdf.UseVisualStyleBackColor = false;
            this.btn_pdf.Click += new System.EventHandler(this.btn_pdf_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(449, 258);
            this.dataGridView1.TabIndex = 4;
            // 
            // BorcSorgula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(472, 524);
            this.Controls.Add(this.txt_mail);
            this.Controls.Add(this.btn_mail);
            this.Controls.Add(this.btn_pdf);
            this.Controls.Add(this.dataGridView1);
            this.Name = "BorcSorgula";
            this.Text = "BorcSorgula";
            this.Load += new System.EventHandler(this.BorcSorgula_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txt_mail;
        private System.Windows.Forms.Button btn_mail;
        private System.Windows.Forms.Button btn_pdf;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}