using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortfoyYonetimi
{
    public partial class Kayıt : Form
    {
        public Kayıt()
        {

            InitializeComponent();
        }

        private void kayit_Click(object sender, EventArgs e)
        { 
            string yeniKullanici = txtYeniKullanici.Text.Trim();
            string yeniSifre = txtYeniSifre.Text.Trim();
            string adSoyad = txtAdSoyad.Text.Trim(); 

            if (string.IsNullOrEmpty(yeniKullanici) || string.IsNullOrEmpty(yeniSifre) || string.IsNullOrEmpty(adSoyad))
            {
                MessageBox.Show("Lütfen tüm alanları (Ad Soyad dahil) eksiksiz doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string checkQuery = $"SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAdi = '{yeniKullanici}'";
            DataSet dsCheck = DB.makeDBOperations(checkQuery);

            if (dsCheck != null && dsCheck.Tables[0].Rows[0][0].ToString() != "0")
            {
                MessageBox.Show("Bu kullanıcı adı zaten sistemde kayıtlı! Lütfen başka bir kullanıcı adı seçin.", "Kayıt Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string insertQuery = $"INSERT INTO Kullanicilar (KullaniciAdi, Sifre, YetkiSeviyesi, KayitTarihi) VALUES ('{yeniKullanici}', '{yeniSifre}', N'{adSoyad}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')";
            DB.makeDBOperations(insertQuery);

            MessageBox.Show("Kaydınız başarıyla tamamlanmıştır!\n\nSisteme giriş yapmak için yönlendiriliyorsunuz...",
                            "Kayıt Başarılı",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            this.Close();
        }

        private void buttongirisedon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtYeniKullanici_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtAdSoyad.Focus();
            }
        }

        private void txtAdSoyad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtYeniSifre.Focus();
            }
        }

        private void txtYeniSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                kayit.PerformClick();
            }
        }

        private void txtYeniKullanici_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true; 
            }
        }

        private void txtYeniSifre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
        }

        private void btngoster_Click(object sender, EventArgs e)
        {
            if (txtYeniSifre.PasswordChar == '●')
            {
                txtYeniSifre.PasswordChar = '\0';
                btngoster.Text = "🙈";
            }
            else
            {
                txtYeniSifre.PasswordChar = '●';
                btngoster.Text = "👁️";
            }

            txtYeniSifre.Focus();
        }
    }
}