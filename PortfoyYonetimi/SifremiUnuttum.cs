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
    public partial class SifremiUnuttum : Form
    {
        public SifremiUnuttum()
        {
            InitializeComponent();
        }

        private void yenile_Click(object sender, EventArgs e)
        {
            string kullanici = txtKullanici.Text.Trim();
            string adSoyad = txtAdSoyad.Text.Trim();
            string yeniSifre = txtYeniSifre.Text.Trim();

            if (string.IsNullOrEmpty(kullanici) || string.IsNullOrEmpty(adSoyad) || string.IsNullOrEmpty(yeniSifre))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string checkQuery = $"SELECT * FROM Kullanicilar WHERE KullaniciAdi = '{kullanici}' AND YetkiSeviyesi = '{adSoyad}'";
            DataSet ds = DB.makeDBOperations(checkQuery);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                string eskiSifre = ds.Tables[0].Rows[0]["Sifre"].ToString();

                if (eskiSifre == yeniSifre)
                {
                    MessageBox.Show("Yeni şifreniz eski şifrenizle aynı olamaz!\nLütfen güvenliğiniz için farklı bir şifre belirleyin.",
                                    "Güvenlik İhlali", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txtYeniSifre.Clear();
                    txtYeniSifre.Focus();
                    return;
                }

                string updateQuery = $"UPDATE Kullanicilar SET Sifre = '{yeniSifre}' WHERE KullaniciAdi = '{kullanici}'";
                DB.makeDBOperations(updateQuery);

                MessageBox.Show("Şifreniz başarıyla güncellendi!\nŞimdi yeni şifrenizle giriş yapabilirsiniz.",
                                "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show("Güvenlik Doğrulaması Başarısız!\nKullanıcı adınız veya Ad-Soyad bilginiz sistemle eşleşmiyor.",
                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtAdSoyad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtKullanici.Focus();
            }
        }

        private void txtKullanici_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtYeniSifre.Focus();
            }
        }

        private void txtYeniSifre_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                yenile.PerformClick();
            }
        }

        private void buttongirisedon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtKullanici_KeyPress(object sender, KeyPressEventArgs e)
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