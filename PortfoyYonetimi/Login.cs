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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttongiris_Click(object sender, EventArgs e)
        {
            string kullanici = txtKullanici.Text.Trim();
            string sifre = txtSifre.Text.Trim();

            if (string.IsNullOrEmpty(kullanici) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Lütfen kullanıcı adı ve şifre alanlarını doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = $@"SELECT * FROM Kullanicilar 
                      WHERE KullaniciAdi = '{kullanici}' AND Sifre = '{sifre}'";

            DataSet ds = DB.makeDBOperations(query);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                string yetkiSeviyesi = ds.Tables[0].Rows[0]["YetkiSeviyesi"].ToString();

                MessageBox.Show($"Hoş Geldiniz! {yetkiSeviyesi}\n\nSisteme başarıyla giriş yapıldı, terminal başlatılıyor...",
                                "Giriş Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form1 anaForm = new Form1();

                anaForm.AktifKullanici = kullanici;
                anaForm.AktifYetki = yetkiSeviyesi;

                anaForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Yetkisiz Erişim! Kullanıcı adı veya şifre hatalı.", "Güvenlik Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSifre.Clear();
                txtKullanici.Focus();
            }
        }

        private void kayit_Click(object sender, EventArgs e)
        {
            Kayıt kayitEkrani = new Kayıt();
            kayitEkrani.ShowDialog(); 
        }

        private void txtKullanici_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
                txtSifre.Focus();       
            }
        }

        private void txtSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                buttongiris.PerformClick();
            }
        }

        private void Login_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabelsifre_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifremiUnuttum sifreForm = new SifremiUnuttum();
            sifreForm.ShowDialog(); 
        }

        private void txtKullanici_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
        }

        private void txtSifre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
        }

        private void btngoster_Click(object sender, EventArgs e)
        {
            if (txtSifre.PasswordChar == '●')
            {
                txtSifre.PasswordChar = '\0';
                btngoster.Text = "🙈";
            }
            else
            {
                txtSifre.PasswordChar = '●';
                btngoster.Text = "👁️"; 
            }

            txtSifre.Focus();
        }
    }
}