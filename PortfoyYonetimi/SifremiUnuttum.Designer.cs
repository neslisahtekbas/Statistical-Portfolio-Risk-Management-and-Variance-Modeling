namespace PortfoyYonetimi
{
    partial class SifremiUnuttum : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SifremiUnuttum));
            this.guvenliksorusu = new System.Windows.Forms.Label();
            this.txtAdSoyad = new System.Windows.Forms.TextBox();
            this.yenile = new System.Windows.Forms.Button();
            this.yenisifregir = new System.Windows.Forms.Label();
            this.kullaniciadyeni = new System.Windows.Forms.Label();
            this.txtYeniSifre = new System.Windows.Forms.TextBox();
            this.txtKullanici = new System.Windows.Forms.TextBox();
            this.buttongirisedon = new System.Windows.Forms.Button();
            this.btngoster = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // guvenliksorusu
            // 
            this.guvenliksorusu.AutoSize = true;
            this.guvenliksorusu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.guvenliksorusu.Location = new System.Drawing.Point(12, 31);
            this.guvenliksorusu.Name = "guvenliksorusu";
            this.guvenliksorusu.Size = new System.Drawing.Size(370, 16);
            this.guvenliksorusu.TabIndex = 21;
            this.guvenliksorusu.Text = "Sistemimize kaydolurken kullandığınız adınız soyadınız nedir?";
            // 
            // txtAdSoyad
            // 
            this.txtAdSoyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAdSoyad.Location = new System.Drawing.Point(48, 54);
            this.txtAdSoyad.Name = "txtAdSoyad";
            this.txtAdSoyad.Size = new System.Drawing.Size(287, 26);
            this.txtAdSoyad.TabIndex = 14;
            this.txtAdSoyad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAdSoyad_KeyDown);
            // 
            // yenile
            // 
            this.yenile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yenile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.yenile.Location = new System.Drawing.Point(215, 196);
            this.yenile.Name = "yenile";
            this.yenile.Size = new System.Drawing.Size(97, 26);
            this.yenile.TabIndex = 19;
            this.yenile.Text = "Şifremi Yenile";
            this.yenile.UseVisualStyleBackColor = true;
            this.yenile.Click += new System.EventHandler(this.yenile_Click);
            // 
            // yenisifregir
            // 
            this.yenisifregir.AutoSize = true;
            this.yenisifregir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.yenisifregir.Location = new System.Drawing.Point(110, 146);
            this.yenisifregir.Name = "yenisifregir";
            this.yenisifregir.Size = new System.Drawing.Size(64, 16);
            this.yenisifregir.TabIndex = 18;
            this.yenisifregir.Text = "Yeni Şifre";
            // 
            // kullaniciadyeni
            // 
            this.kullaniciadyeni.AutoSize = true;
            this.kullaniciadyeni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kullaniciadyeni.Location = new System.Drawing.Point(94, 96);
            this.kullaniciadyeni.Name = "kullaniciadyeni";
            this.kullaniciadyeni.Size = new System.Drawing.Size(79, 16);
            this.kullaniciadyeni.TabIndex = 17;
            this.kullaniciadyeni.Text = "Kullanıcı Adı";
            // 
            // txtYeniSifre
            // 
            this.txtYeniSifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtYeniSifre.Location = new System.Drawing.Point(180, 140);
            this.txtYeniSifre.Name = "txtYeniSifre";
            this.txtYeniSifre.PasswordChar = '●';
            this.txtYeniSifre.Size = new System.Drawing.Size(121, 26);
            this.txtYeniSifre.TabIndex = 16;
            this.txtYeniSifre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtYeniSifre_KeyDown_1);
            this.txtYeniSifre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYeniSifre_KeyPress);
            // 
            // txtKullanici
            // 
            this.txtKullanici.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKullanici.Location = new System.Drawing.Point(180, 90);
            this.txtKullanici.Name = "txtKullanici";
            this.txtKullanici.Size = new System.Drawing.Size(121, 26);
            this.txtKullanici.TabIndex = 15;
            this.txtKullanici.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKullanici_KeyDown);
            this.txtKullanici.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKullanici_KeyPress);
            // 
            // buttongirisedon
            // 
            this.buttongirisedon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttongirisedon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttongirisedon.Location = new System.Drawing.Point(74, 196);
            this.buttongirisedon.Name = "buttongirisedon";
            this.buttongirisedon.Size = new System.Drawing.Size(116, 26);
            this.buttongirisedon.TabIndex = 22;
            this.buttongirisedon.Text = "Giriş Ekrarına Dön";
            this.buttongirisedon.UseVisualStyleBackColor = true;
            this.buttongirisedon.Click += new System.EventHandler(this.buttongirisedon_Click);
            // 
            // btngoster
            // 
            this.btngoster.BackColor = System.Drawing.Color.White;
            this.btngoster.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btngoster.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btngoster.FlatAppearance.BorderSize = 0;
            this.btngoster.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btngoster.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btngoster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngoster.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btngoster.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btngoster.Location = new System.Drawing.Point(276, 141);
            this.btngoster.Name = "btngoster";
            this.btngoster.Size = new System.Drawing.Size(25, 24);
            this.btngoster.TabIndex = 23;
            this.btngoster.Text = "👁️";
            this.btngoster.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btngoster.UseVisualStyleBackColor = false;
            this.btngoster.Click += new System.EventHandler(this.btngoster_Click);
            // 
            // SifremiUnuttum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(399, 250);
            this.Controls.Add(this.btngoster);
            this.Controls.Add(this.buttongirisedon);
            this.Controls.Add(this.guvenliksorusu);
            this.Controls.Add(this.txtAdSoyad);
            this.Controls.Add(this.yenile);
            this.Controls.Add(this.yenisifregir);
            this.Controls.Add(this.kullaniciadyeni);
            this.Controls.Add(this.txtYeniSifre);
            this.Controls.Add(this.txtKullanici);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SifremiUnuttum";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Şifremi Unuttum";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label guvenliksorusu;
        private System.Windows.Forms.TextBox txtAdSoyad;
        private System.Windows.Forms.Button yenile;
        private System.Windows.Forms.Label yenisifregir;
        private System.Windows.Forms.Label kullaniciadyeni;
        private System.Windows.Forms.TextBox txtYeniSifre;
        private System.Windows.Forms.TextBox txtKullanici;
        private System.Windows.Forms.Button buttongirisedon;
        private System.Windows.Forms.Button btngoster;
    }
}