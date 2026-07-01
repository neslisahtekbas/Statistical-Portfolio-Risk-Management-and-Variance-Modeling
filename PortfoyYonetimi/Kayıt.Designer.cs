namespace PortfoyYonetimi
{
    partial class Kayıt : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kayıt));
            this.kayit = new System.Windows.Forms.Button();
            this.sifregir = new System.Windows.Forms.Label();
            this.kullaniciad = new System.Windows.Forms.Label();
            this.buttongirisedon = new System.Windows.Forms.Button();
            this.txtYeniSifre = new System.Windows.Forms.TextBox();
            this.txtYeniKullanici = new System.Windows.Forms.TextBox();
            this.yeniad = new System.Windows.Forms.Label();
            this.txtAdSoyad = new System.Windows.Forms.TextBox();
            this.btngoster = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // kayit
            // 
            this.kayit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kayit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kayit.Location = new System.Drawing.Point(170, 206);
            this.kayit.Name = "kayit";
            this.kayit.Size = new System.Drawing.Size(85, 26);
            this.kayit.TabIndex = 11;
            this.kayit.Text = "Kayıt Ol";
            this.kayit.UseVisualStyleBackColor = true;
            this.kayit.Click += new System.EventHandler(this.kayit_Click);
            // 
            // sifregir
            // 
            this.sifregir.AutoSize = true;
            this.sifregir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sifregir.Location = new System.Drawing.Point(76, 144);
            this.sifregir.Name = "sifregir";
            this.sifregir.Size = new System.Drawing.Size(50, 16);
            this.sifregir.TabIndex = 10;
            this.sifregir.Text = "Şifreniz";
            // 
            // kullaniciad
            // 
            this.kullaniciad.AutoSize = true;
            this.kullaniciad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kullaniciad.Location = new System.Drawing.Point(47, 41);
            this.kullaniciad.Name = "kullaniciad";
            this.kullaniciad.Size = new System.Drawing.Size(79, 16);
            this.kullaniciad.TabIndex = 9;
            this.kullaniciad.Text = "Kullanıcı Adı";
            // 
            // buttongirisedon
            // 
            this.buttongirisedon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttongirisedon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttongirisedon.Location = new System.Drawing.Point(35, 206);
            this.buttongirisedon.Name = "buttongirisedon";
            this.buttongirisedon.Size = new System.Drawing.Size(115, 26);
            this.buttongirisedon.TabIndex = 8;
            this.buttongirisedon.Text = "Giriş Ekrarına Dön";
            this.buttongirisedon.UseVisualStyleBackColor = true;
            this.buttongirisedon.Click += new System.EventHandler(this.buttongirisedon_Click);
            // 
            // txtYeniSifre
            // 
            this.txtYeniSifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtYeniSifre.Location = new System.Drawing.Point(134, 138);
            this.txtYeniSifre.Name = "txtYeniSifre";
            this.txtYeniSifre.PasswordChar = '●';
            this.txtYeniSifre.Size = new System.Drawing.Size(121, 26);
            this.txtYeniSifre.TabIndex = 7;
            this.txtYeniSifre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtYeniSifre_KeyDown);
            this.txtYeniSifre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYeniSifre_KeyPress);
            // 
            // txtYeniKullanici
            // 
            this.txtYeniKullanici.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtYeniKullanici.Location = new System.Drawing.Point(134, 35);
            this.txtYeniKullanici.Name = "txtYeniKullanici";
            this.txtYeniKullanici.Size = new System.Drawing.Size(121, 26);
            this.txtYeniKullanici.TabIndex = 6;
            this.txtYeniKullanici.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtYeniKullanici_KeyDown);
            this.txtYeniKullanici.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYeniKullanici_KeyPress);
            // 
            // yeniad
            // 
            this.yeniad.AutoSize = true;
            this.yeniad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.yeniad.Location = new System.Drawing.Point(23, 92);
            this.yeniad.Name = "yeniad";
            this.yeniad.Size = new System.Drawing.Size(105, 16);
            this.yeniad.TabIndex = 13;
            this.yeniad.Text = "Adınız Soyadınız";
            // 
            // txtAdSoyad
            // 
            this.txtAdSoyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAdSoyad.Location = new System.Drawing.Point(134, 86);
            this.txtAdSoyad.Name = "txtAdSoyad";
            this.txtAdSoyad.Size = new System.Drawing.Size(121, 26);
            this.txtAdSoyad.TabIndex = 12;
            this.txtAdSoyad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAdSoyad_KeyDown);
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
            this.btngoster.Location = new System.Drawing.Point(230, 138);
            this.btngoster.Name = "btngoster";
            this.btngoster.Size = new System.Drawing.Size(25, 24);
            this.btngoster.TabIndex = 14;
            this.btngoster.Text = "👁️";
            this.btngoster.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btngoster.UseVisualStyleBackColor = false;
            this.btngoster.Click += new System.EventHandler(this.btngoster_Click);
            // 
            // Kayıt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(301, 259);
            this.Controls.Add(this.btngoster);
            this.Controls.Add(this.yeniad);
            this.Controls.Add(this.txtAdSoyad);
            this.Controls.Add(this.kayit);
            this.Controls.Add(this.sifregir);
            this.Controls.Add(this.kullaniciad);
            this.Controls.Add(this.buttongirisedon);
            this.Controls.Add(this.txtYeniSifre);
            this.Controls.Add(this.txtYeniKullanici);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Kayıt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NF Yatırım Danışmanlık | Kayıt Ekranı";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button kayit;
        private System.Windows.Forms.Label sifregir;
        private System.Windows.Forms.Label kullaniciad;
        private System.Windows.Forms.Button buttongirisedon;
        private System.Windows.Forms.TextBox txtYeniSifre;
        private System.Windows.Forms.TextBox txtYeniKullanici;
        private System.Windows.Forms.Label yeniad;
        private System.Windows.Forms.TextBox txtAdSoyad;
        private System.Windows.Forms.Button btngoster;
    }
}