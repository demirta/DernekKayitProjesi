
namespace MehmetCan
{
    partial class UyeSil
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
            this.btn_Pasif = new System.Windows.Forms.Button();
            this.label_AdSoyad = new System.Windows.Forms.Label();
            this.label_Tc = new System.Windows.Forms.Label();
            this.label_aciklama = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Pasif
            // 
            this.btn_Pasif.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_Pasif.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Pasif.Location = new System.Drawing.Point(347, 467);
            this.btn_Pasif.Name = "btn_Pasif";
            this.btn_Pasif.Size = new System.Drawing.Size(127, 41);
            this.btn_Pasif.TabIndex = 11;
            this.btn_Pasif.Text = "Pasif Yap";
            this.btn_Pasif.UseVisualStyleBackColor = false;
            this.btn_Pasif.Click += new System.EventHandler(this.btn_Pasif_Click);
            // 
            // label_AdSoyad
            // 
            this.label_AdSoyad.AutoSize = true;
            this.label_AdSoyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_AdSoyad.Location = new System.Drawing.Point(356, 413);
            this.label_AdSoyad.Name = "label_AdSoyad";
            this.label_AdSoyad.Size = new System.Drawing.Size(0, 16);
            this.label_AdSoyad.TabIndex = 10;
            // 
            // label_Tc
            // 
            this.label_Tc.AutoSize = true;
            this.label_Tc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_Tc.Location = new System.Drawing.Point(356, 376);
            this.label_Tc.Name = "label_Tc";
            this.label_Tc.Size = new System.Drawing.Size(0, 16);
            this.label_Tc.TabIndex = 9;
            // 
            // label_aciklama
            // 
            this.label_aciklama.AutoSize = true;
            this.label_aciklama.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_aciklama.Location = new System.Drawing.Point(123, 326);
            this.label_aciklama.Name = "label_aciklama";
            this.label_aciklama.Size = new System.Drawing.Size(574, 25);
            this.label_aciklama.TabIndex = 8;
            this.label_aciklama.Text = "Aşağıdaki üyenin üyelik durumu pasif duruma getirilecektir!";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(121, 85);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(576, 227);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Aktif Üyeler",
            "Pasif Üyeler"});
            this.comboBox1.Location = new System.Drawing.Point(288, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(203, 33);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // UyeSil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(803, 515);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btn_Pasif);
            this.Controls.Add(this.label_AdSoyad);
            this.Controls.Add(this.label_Tc);
            this.Controls.Add(this.label_aciklama);
            this.Controls.Add(this.dataGridView1);
            this.Name = "UyeSil";
            this.Text = "UyeSil";
            this.Load += new System.EventHandler(this.UyeSil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Pasif;
        private System.Windows.Forms.Label label_AdSoyad;
        private System.Windows.Forms.Label label_Tc;
        private System.Windows.Forms.Label label_aciklama;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}