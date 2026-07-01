namespace PortfoyYonetimi
{
    partial class Ayarlar : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ayarlar));
            this.Portfoysil = new System.Windows.Forms.Button();
            this.Takiplistsil = new System.Windows.Forms.Button();
            this.Hesapbilgileri = new System.Windows.Forms.Button();
            this.HesapSİL = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Portfoysil
            // 
            this.Portfoysil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Portfoysil.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Portfoysil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Portfoysil.Location = new System.Drawing.Point(65, 36);
            this.Portfoysil.Name = "Portfoysil";
            this.Portfoysil.Size = new System.Drawing.Size(151, 40);
            this.Portfoysil.TabIndex = 0;
            this.Portfoysil.Text = "Portföyümü Temizle";
            this.Portfoysil.UseVisualStyleBackColor = true;
            this.Portfoysil.Click += new System.EventHandler(this.Portfoysil_Click);
            // 
            // Takiplistsil
            // 
            this.Takiplistsil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Takiplistsil.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Takiplistsil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Takiplistsil.Location = new System.Drawing.Point(65, 95);
            this.Takiplistsil.Name = "Takiplistsil";
            this.Takiplistsil.Size = new System.Drawing.Size(151, 40);
            this.Takiplistsil.TabIndex = 1;
            this.Takiplistsil.Text = "Takip Listemi Temizle";
            this.Takiplistsil.UseVisualStyleBackColor = true;
            this.Takiplistsil.Click += new System.EventHandler(this.Takiplistsil_Click);
            // 
            // Hesapbilgileri
            // 
            this.Hesapbilgileri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Hesapbilgileri.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Hesapbilgileri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Hesapbilgileri.Location = new System.Drawing.Point(65, 157);
            this.Hesapbilgileri.Name = "Hesapbilgileri";
            this.Hesapbilgileri.Size = new System.Drawing.Size(151, 44);
            this.Hesapbilgileri.TabIndex = 2;
            this.Hesapbilgileri.Text = "Hesap Bilgilerimi Görüntüle";
            this.Hesapbilgileri.UseVisualStyleBackColor = true;
            this.Hesapbilgileri.Click += new System.EventHandler(this.Hesapbilgileri_Click);
            // 
            // HesapSİL
            // 
            this.HesapSİL.BackColor = System.Drawing.Color.Red;
            this.HesapSİL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HesapSİL.FlatAppearance.BorderSize = 0;
            this.HesapSİL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.HesapSİL.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.HesapSİL.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.HesapSİL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.HesapSİL.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.HesapSİL.Location = new System.Drawing.Point(65, 232);
            this.HesapSİL.Name = "HesapSİL";
            this.HesapSİL.Size = new System.Drawing.Size(151, 35);
            this.HesapSİL.TabIndex = 3;
            this.HesapSİL.Text = "Hesabımı Sil";
            this.HesapSİL.UseVisualStyleBackColor = false;
            this.HesapSİL.Click += new System.EventHandler(this.HesapSİL_Click);
            // 
            // Ayarlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(289, 294);
            this.Controls.Add(this.HesapSİL);
            this.Controls.Add(this.Hesapbilgileri);
            this.Controls.Add(this.Takiplistsil);
            this.Controls.Add(this.Portfoysil);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Ayarlar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hesap Ayarları";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Portfoysil;
        private System.Windows.Forms.Button Takiplistsil;
        private System.Windows.Forms.Button Hesapbilgileri;
        private System.Windows.Forms.Button HesapSİL;
    }
}