using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortfoyYonetimi
{
    public partial class Ayarlar : Form
    {
        public string AktifKullanici = "";
        public Ayarlar()
        {
            InitializeComponent();
        }

        private void Hesapbilgileri_Click(object sender, EventArgs e)
        {
            try
            {
                string sorgu = $"SELECT * FROM Kullanicilar WHERE KullaniciAdi = '{AktifKullanici}'";
                DataSet ds = DB.makeDBOperations(sorgu);

                if (ds == null || ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show($"'{AktifKullanici}' isimli kullanıcı bulunamadı!", "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string mevcutSifre = ds.Tables[0].Rows[0]["Sifre"].ToString();
                string mevcutYetkiSeviyesi = ds.Tables[0].Rows[0]["YetkiSeviyesi"].ToString();
                string uyelikMetni = "Kayıt tarihi bilgisi yok.";

                if (ds.Tables[0].Columns.Contains("KayitTarihi") && ds.Tables[0].Rows[0]["KayitTarihi"] != DBNull.Value)
                {
                    DateTime kayitTarihi = Convert.ToDateTime(ds.Tables[0].Rows[0]["KayitTarihi"]);
                    int gunSayisi = (DateTime.Now - kayitTarihi).Days;
                    if (gunSayisi == 0) uyelikMetni = $"🎉 Aramıza bugün katıldınız!";
                    else uyelikMetni = $"🎉 Tam {gunSayisi} gündür bizimlesiniz!\nİlk Kayıt Tarihiniz: {kayitTarihi.ToString("dd.MM.yyyy")}";
                }

                Form bilgiForm = new Form();
                bilgiForm.Text = "👤 Hesap Bilgilerim";
                bilgiForm.Size = new Size(350, 410);
                bilgiForm.StartPosition = FormStartPosition.CenterScreen;
                bilgiForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                bilgiForm.MaximizeBox = false; bilgiForm.MinimizeBox = false;
                bilgiForm.BackColor = Color.White;

                Label lblSure = new Label() { Text = uyelikMetni, Left = 20, Top = 20, Width = 300, Height = 40, Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.SeaGreen };

                Label lblKullanici = new Label() { Text = "Kullanıcı Adı (Değiştirilemez):", Left = 20, Top = 70, Width = 300 };
                TextBox txtKullanici = new TextBox() { Text = AktifKullanici, Left = 20, Top = 90, Width = 290, ReadOnly = true, BackColor = Color.WhiteSmoke, ForeColor = Color.Gray, TabStop = false, Cursor = Cursors.No };

                Label lblYetkiSeviyesi = new Label() { Text = "Ad Soyad:", Left = 20, Top = 130, Width = 300 };
                TextBox txtYetkiSeviyesi = new TextBox() { Text = mevcutYetkiSeviyesi, Left = 20, Top = 150, Width = 290 };

                txtKullanici.GotFocus += (s, ev) => { txtYetkiSeviyesi.Focus(); };
                txtKullanici.MouseDown += (s, ev) => { txtYetkiSeviyesi.Focus(); };

                Label lblEskiSifre = new Label() { Text = "Mevcut Şifreniz:", Left = 20, Top = 190, Width = 300, ForeColor = Color.DarkRed };
                TextBox txtEskiSifre = new TextBox() { Text = "", Left = 20, Top = 210, Width = 290, PasswordChar = '●' };

                Label lblSifre = new Label() { Text = "Yeni Şifreniz (Değiştirmeyecekseniz Mevcut Şifrenizi girin!):", Left = 20, Top = 250, Width = 300, ForeColor = Color.Blue };
                TextBox txtSifre = new TextBox() { Text = "", Left = 20, Top = 270, Width = 250, PasswordChar = '●' };
                Button btnYeniGoster = new Button(){ Text = "👁️", Left = 275, Top = 268, Width = 35, Height = 25, FlatStyle = FlatStyle.Flat, BackColor = Color.White, Cursor = Cursors.Hand };

                btnYeniGoster.Font = new Font("Segoe UI Emoji", 11F, FontStyle.Regular);
                btnYeniGoster.FlatAppearance.BorderSize = 0;
                btnYeniGoster.FlatAppearance.MouseOverBackColor = Color.White;
                btnYeniGoster.FlatAppearance.MouseDownBackColor = Color.White;
                btnYeniGoster.Click += (s, ev) => {
                    if (txtSifre.PasswordChar == '●')
                    {
                        txtSifre.PasswordChar = '\0';
                        btnYeniGoster.Text = "🙈";
                    }
                    else
                    {
                        txtSifre.PasswordChar = '●';
                        btnYeniGoster.Text = "👁️";
                    }
                    txtSifre.Focus();
                };

                Button btnGuncelle = new Button() { Text = "💾 Bilgilerimi Güncelle", Left = 20, Top = 320, Width = 290, Height = 40, BackColor = Color.SteelBlue, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };

                bilgiForm.Shown += (s, ev) => { txtYetkiSeviyesi.Focus(); };

                txtYetkiSeviyesi.KeyDown += (s, ev) =>
                {
                    if (ev.KeyCode == Keys.Enter) { ev.SuppressKeyPress = true; txtEskiSifre.Focus(); }
                };

                txtEskiSifre.KeyDown += (s, ev) =>
                {
                    if (ev.KeyCode == Keys.Enter) { ev.SuppressKeyPress = true; txtSifre.Focus(); }
                };

                txtSifre.KeyDown += (s, ev) =>
                {
                    if (ev.KeyCode == Keys.Enter) { ev.SuppressKeyPress = true; btnGuncelle.PerformClick(); }
                };

                btnGuncelle.Click += (s, ev) =>
                {
                    if (string.IsNullOrWhiteSpace(txtSifre.Text) || string.IsNullOrWhiteSpace(txtYetkiSeviyesi.Text))
                    {
                        MessageBox.Show("Yeni Şifre veya Ad Soyad alanı boş bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (txtEskiSifre.Text != mevcutSifre)
                    {
                        MessageBox.Show("Mevcut şifrenizi yanlış girdiniz! Güvenlik nedeniyle işlem iptal edildi.", "Yetkisiz İşlem", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtEskiSifre.Clear();
                        txtEskiSifre.Focus();
                        return; 
                    }

                    string updateSorgu = $"UPDATE Kullanicilar SET Sifre = N'{txtSifre.Text}', YetkiSeviyesi = N'{txtYetkiSeviyesi.Text}' WHERE KullaniciAdi = '{AktifKullanici}'";
                    DB.makeDBOperations(updateSorgu);

                    Form anaForm = Application.OpenForms["Form1"];
                    if (anaForm != null)
                    {
                        Control[] labelBul = anaForm.Controls.Find("lblYetki", true);
                        if (labelBul.Length > 0 && labelBul[0] is Label lbl)
                        {
                            lbl.Text = "👤 " + txtYetkiSeviyesi.Text;
                        }
                        ((Form1)anaForm).AktifYetki = txtYetkiSeviyesi.Text;
                    }

                    MessageBox.Show("Hesap bilgileriniz güvenli bir şekilde güncellendi! 🚀", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bilgiForm.Close();
                };

                bilgiForm.Controls.Add(lblSure);
                bilgiForm.Controls.Add(lblKullanici);
                bilgiForm.Controls.Add(txtKullanici);
                bilgiForm.Controls.Add(btnYeniGoster);
                bilgiForm.Controls.Add(lblYetkiSeviyesi);
                bilgiForm.Controls.Add(txtYetkiSeviyesi);
                bilgiForm.Controls.Add(lblEskiSifre);
                bilgiForm.Controls.Add(txtEskiSifre);
                bilgiForm.Controls.Add(lblSifre);
                bilgiForm.Controls.Add(txtSifre);
                bilgiForm.Controls.Add(btnGuncelle);

                bilgiForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Detayı: " + ex.Message, "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Portfoysil_Click(object sender, EventArgs e)
        {
            DialogResult onay = MessageBox.Show(
                "Bu işlem geri alınamaz! Portföy listenizdeki tüm veriler kalıcı olarak silinecektir.\n\nTamam mı, devam mı?",
                "⚠️ Geri Dönüşü Olmayan İşlem", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (onay == DialogResult.Yes)
            {
                try
                {
                    string guvenliKullaniciAdi = AktifKullanici.Trim().Replace(" ", "_");
                    string portfoyDosyasi = Path.Combine(Application.StartupPath, guvenliKullaniciAdi + "_Portfoy.txt");
                    if (File.Exists(portfoyDosyasi)) File.WriteAllText(portfoyDosyasi, "", System.Text.Encoding.UTF8);

                    foreach (Form frm in Application.OpenForms)
                    {
                        Control[] dgvBul = frm.Controls.Find("dataGridView1", true);
                        if (dgvBul.Length > 0 && dgvBul[0] is DataGridView dgv)
                        {
                            dgv.Rows.Clear(); 
                        }

                        Control[] lblBul = frm.Controls.Find("lblTotalKar", true);
                        if (lblBul.Length > 0 && lblBul[0] is Label lbl)
                        {
                            lbl.Text = "TOPLAM PORTFÖY BEKLENTİSİ: %0";
                            lbl.ForeColor = Color.Black;
                        }
                    }

                    MessageBox.Show("Portföy listeniz başarıyla temizlendi! 💼", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Temizleme işlemi sırasında hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Takiplistsil_Click(object sender, EventArgs e)
        {
            DialogResult onay = MessageBox.Show(
                "Bu işlem geri alınamaz! Takip listenizdeki tüm veriler kalıcı olarak silinecektir.\n\nDevam edelim mi?",
                "⚠️ Geri Dönüşü Olmayan İşlem", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (onay == DialogResult.Yes)
            {
                try
                {
                    string guvenliKullaniciAdi = AktifKullanici.Trim().Replace(" ", "_");
                    string takipDosyasi = Path.Combine(Application.StartupPath, guvenliKullaniciAdi + "_Takip.txt");
                    if (File.Exists(takipDosyasi)) File.WriteAllText(takipDosyasi, "", System.Text.Encoding.UTF8);

                    foreach (Form frm in Application.OpenForms)
                    {
                        Control[] dgvBul = frm.Controls.Find("dataGridView2", true);
                        if (dgvBul.Length > 0 && dgvBul[0] is DataGridView dgv)
                        {
                            dgv.Rows.Clear(); 
                        }
                    }

                    MessageBox.Show("Takip listeniz başarıyla temizlendi! 👀", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Temizleme işlemi sırasında hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void HesapSİL_Click(object sender, EventArgs e)
        {
            DialogResult ilkOnay = MessageBox.Show(
                "Hesabınızı ve tüm verilerinizi kalıcı olarak silmek üzeresiniz. Devam etmek istiyor musunuz?",
                "Kritik Hesap İmha İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

            if (ilkOnay != DialogResult.Yes) return;

            Form sifreFormu = new Form();
            sifreFormu.Text = "🔒 Güvenlik Doğrulaması";
            sifreFormu.Size = new Size(350, 160);
            sifreFormu.StartPosition = FormStartPosition.CenterScreen;
            sifreFormu.FormBorderStyle = FormBorderStyle.FixedDialog;
            sifreFormu.MaximizeBox = false; sifreFormu.MinimizeBox = false;

            Label lblMesaj = new Label() { Left = 20, Top = 15, Text = "İşlemi onaylamak için lütfen mevcut şifrenizi girin:", Width = 300 };
            TextBox txtSifreGiris = new TextBox() { Left = 20, Top = 40, Width = 290, PasswordChar = '●' }; 
            Button btnOnayla = new Button() { Text = "Hesabımı Kalıcı Olarak Sil", Left = 20, Top = 80, Width = 290, Height = 30, DialogResult = DialogResult.OK };

            sifreFormu.Controls.Add(lblMesaj);
            sifreFormu.Controls.Add(txtSifreGiris);
            sifreFormu.Controls.Add(btnOnayla);
            sifreFormu.AcceptButton = btnOnayla; 

            if (sifreFormu.ShowDialog() == DialogResult.OK)
            {
                string girilenSifre = txtSifreGiris.Text;

                string sorgu = $"SELECT Sifre FROM Kullanicilar WHERE KullaniciAdi = '{AktifKullanici}'";
                DataSet ds = DB.makeDBOperations(sorgu);

                string gercekSifre = "";
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    gercekSifre = ds.Tables[0].Rows[0]["Sifre"].ToString();
                }

                if (girilenSifre == gercekSifre && !string.IsNullOrEmpty(gercekSifre))
                {
                    string silmeSorgusu = $"DELETE FROM Kullanicilar WHERE KullaniciAdi = '{AktifKullanici}'";
                    DB.makeDBOperations(silmeSorgusu);

                    string guvenliKullaniciAdi = AktifKullanici.Trim().Replace(" ", "_");
                    string portfoyDosyasi = Path.Combine(Application.StartupPath, guvenliKullaniciAdi + "_Portfoy.txt");
                    string takipDosyasi = Path.Combine(Application.StartupPath, guvenliKullaniciAdi + "_Takip.txt");

                    if (File.Exists(portfoyDosyasi)) File.Delete(portfoyDosyasi);
                    if (File.Exists(takipDosyasi)) File.Delete(takipDosyasi);

                    MessageBox.Show("Kimliğiniz doğrulandı. Hesabınız ve tüm ilişkili verileriniz başarıyla sistemden temizlendi.",
                                    "Hesap İmha Edildi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    System.Diagnostics.Process.Start(Application.ExecutablePath);
                    Environment.Exit(0);
                }
                else
                {
                    MessageBox.Show("Hatalı şifre girdiniz! Güvenlik nedeniyle hesap silme işlemi durduruldu.",
                                    "❌ Erişim Engellendi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
    }
}