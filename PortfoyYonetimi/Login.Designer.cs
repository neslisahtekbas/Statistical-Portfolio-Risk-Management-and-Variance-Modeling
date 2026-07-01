namespace PortfoyYonetimi
{
    partial class Login : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.txtKullanici = new System.Windows.Forms.TextBox();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.buttongiris = new System.Windows.Forms.Button();
            this.kullanici = new System.Windows.Forms.Label();
            this.sifre = new System.Windows.Forms.Label();
            this.kayit = new System.Windows.Forms.Button();
            this.linkLabelsifre = new System.Windows.Forms.LinkLabel();
            this.btngoster = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtKullanici
            // 
            this.txtKullanici.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKullanici.Location = new System.Drawing.Point(127, 40);
            this.txtKullanici.Name = "txtKullanici";
            this.txtKullanici.Size = new System.Drawing.Size(121, 26);
            this.txtKullanici.TabIndex = 0;
            this.txtKullanici.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKullanici_KeyDown);
            this.txtKullanici.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKullanici_KeyPress);
            // 
            // txtSifre
            // 
            this.txtSifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSifre.Location = new System.Drawing.Point(128, 95);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '●';
            this.txtSifre.Size = new System.Drawing.Size(121, 26);
            this.txtSifre.TabIndex = 1;
            this.txtSifre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSifre_KeyDown);
            this.txtSifre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSifre_KeyPress);
            // 
            // buttongiris
            // 
            this.buttongiris.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttongiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttongiris.Location = new System.Drawing.Point(163, 163);
            this.buttongiris.Name = "buttongiris";
            this.buttongiris.Size = new System.Drawing.Size(85, 26);
            this.buttongiris.TabIndex = 2;
            this.buttongiris.Text = "Giriş Yap";
            this.buttongiris.UseVisualStyleBackColor = true;
            this.buttongiris.Click += new System.EventHandler(this.buttongiris_Click);
            // 
            // kullanici
            // 
            this.kullanici.AutoSize = true;
            this.kullanici.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kullanici.Location = new System.Drawing.Point(40, 46);
            this.kullanici.Name = "kullanici";
            this.kullanici.Size = new System.Drawing.Size(79, 16);
            this.kullanici.TabIndex = 3;
            this.kullanici.Text = "Kullanıcı Adı";
            // 
            // sifre
            // 
            this.sifre.AutoSize = true;
            this.sifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sifre.Location = new System.Drawing.Point(84, 101);
            this.sifre.Name = "sifre";
            this.sifre.Size = new System.Drawing.Size(34, 16);
            this.sifre.TabIndex = 4;
            this.sifre.Text = "Şifre";
            // 
            // kayit
            // 
            this.kayit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kayit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kayit.Location = new System.Drawing.Point(43, 163);
            this.kayit.Name = "kayit";
            this.kayit.Size = new System.Drawing.Size(85, 26);
            this.kayit.TabIndex = 5;
            this.kayit.Text = "Kayıt Ol";
            this.kayit.UseVisualStyleBackColor = true;
            this.kayit.Click += new System.EventHandler(this.kayit_Click);
            // 
            // linkLabelsifre
            // 
            this.linkLabelsifre.AutoSize = true;
            this.linkLabelsifre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabelsifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.linkLabelsifre.LinkColor = System.Drawing.Color.Red;
            this.linkLabelsifre.Location = new System.Drawing.Point(125, 124);
            this.linkLabelsifre.Name = "linkLabelsifre";
            this.linkLabelsifre.Size = new System.Drawing.Size(96, 15);
            this.linkLabelsifre.TabIndex = 6;
            this.linkLabelsifre.TabStop = true;
            this.linkLabelsifre.Text = "Şifremi Unuttum";
            this.linkLabelsifre.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelsifre_LinkClicked);
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
            this.btngoster.Location = new System.Drawing.Point(223, 95);
            this.btngoster.Name = "btngoster";
            this.btngoster.Size = new System.Drawing.Size(25, 24);
            this.btngoster.TabIndex = 7;
            this.btngoster.Text = "👁️";
            this.btngoster.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btngoster.UseVisualStyleBackColor = false;
            this.btngoster.Click += new System.EventHandler(this.btngoster_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(301, 218);
            this.Controls.Add(this.btngoster);
            this.Controls.Add(this.linkLabelsifre);
            this.Controls.Add(this.kayit);
            this.Controls.Add(this.sifre);
            this.Controls.Add(this.kullanici);
            this.Controls.Add(this.buttongiris);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.txtKullanici);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NF Yatırım Danışmanlık | Giriş Ekranı";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKullanici;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Button buttongiris;
        private System.Windows.Forms.Label kullanici;
        private System.Windows.Forms.Label sifre;
        private System.Windows.Forms.Button kayit;
        private System.Windows.Forms.LinkLabel linkLabelsifre;
        private System.Windows.Forms.Button btngoster;
    }
}