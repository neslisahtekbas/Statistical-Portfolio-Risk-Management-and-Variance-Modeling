using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PortfoyYonetimi
{
    public partial class Form1 : Form
    {
        public string AktifKullanici = "";
        public string AktifYetki = "";
        int anlikHesaplananKar = 0; 
        int toplamPortfoyKari = 0;  

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblYetki.Text = "👤 " + AktifYetki;
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Hisse Kodu";
            dataGridView1.Columns[1].Name = "Liste Türü";
            dataGridView1.Columns[2].Name = "Sistem Notu";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView2.ColumnCount = 3;
            dataGridView2.Columns[0].Name = "Hisse Kodu";
            dataGridView2.Columns[1].Name = "Liste Türü";
            dataGridView2.Columns[2].Name = "Sistem Notu";
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.Visible = false;
            dataGridView2.Visible = false;

            cmbArama.Items.Clear();
            cmbArama.Items.Add("Hisse Seçiniz...");

            DataSet dsHisseler = DB.makeDBOperations("SELECT DISTINCT Hisse_Kodu FROM HisseAnaliz ORDER BY Hisse_Kodu");
            if (dsHisseler != null)
            {
                foreach (DataRow row in dsHisseler.Tables[0].Rows)
                {
                    cmbArama.Items.Add(row["Hisse_Kodu"].ToString());
                }
            }
            cmbArama.SelectedIndex = 0;

            DateTime bugun = DateTime.Now;
            DateTime dun = bugun.AddDays(-1);
            DateTime onceki = bugun.AddDays(-2);

            tabControl1.TabPages[0].Text = $"Bugün";
            tabControl1.TabPages[1].Text = dun.ToString("dd.MM dddd");
            tabControl1.TabPages[2].Text = onceki.ToString("dd.MM dddd");

            LoadTableFromSQL("Bugün", dgvBugun);
            LoadTableFromSQL("Dün", dgvDun);
            LoadTableFromSQL("Önceki", dgvOnceki);

            dgvBugun.CellClick += Tablo_CellClick;
            dgvDun.CellClick += Tablo_CellClick;
            dgvOnceki.CellClick += Tablo_CellClick;

            if (dgvBugun.Rows.Count > 0)
            {
                string ilkSembol = dgvBugun.Rows[0].Cells["Symbol"].Value?.ToString();
                TrendGrafiginiCiz(ilkSembol);
            }

            tabControl1.SizeMode = TabSizeMode.Fixed;
            int sekmeGenisligi = (tabControl1.Width / tabControl1.TabCount) - 3;
            tabControl1.ItemSize = new Size(sekmeGenisligi, 18);

            dgvBugun.ClearSelection();
            dgvBugun.CurrentCell = null;

            SektorVerileri();

            Timer saatTimer = new Timer();
            saatTimer.Interval = 1000;
            saatTimer.Tick += SaatTimer_Tick;
            SaatTimer_Tick(null, null);
            saatTimer.Start();

            dataGridView2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            KullaniciVerileriniYukle();
        }

        private void Tablo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridView tiklananTablo = (DataGridView)sender;

                string secilenSembol = tiklananTablo.Rows[e.RowIndex].Cells["Symbol"].Value?.ToString();

                TrendGrafiginiCiz(secilenSembol);
            }
        }

        private void TrendGrafiginiCiz(string secilenSembol)
        {
            chartTrend.Legends[0].DockedToChartArea = chartTrend.ChartAreas[0].Name;
            chartTrend.Legends[0].IsDockedInsideChartArea = false;
            chartTrend.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            chartTrend.Legends[0].Alignment = System.Drawing.StringAlignment.Far;
            chartTrend.Legends[0].BorderWidth = 0;
            chartTrend.Legends[0].BackColor = Color.Transparent;
            chartTrend.ChartAreas[0].AxisX.LabelStyle.IsStaggered = false;
            chartTrend.ChartAreas[0].AxisX.LabelStyle.Angle = 0;

            if (string.IsNullOrEmpty(secilenSembol)) return;

            chartTrend.Series.Clear();
            string belirlenenIsim = "";

            if (secilenSembol.Contains("GOLD"))
            {
                belirlenenIsim = "GOLD Trendi";
            }
            else if (secilenSembol.Contains("DOLAR"))
            {
                belirlenenIsim = "DOLAR Trendi";
            }
            else if (secilenSembol.Contains("EURO"))
            {
                belirlenenIsim = "EURO Trendi";
            }
            else
            {
                string temizSembol = secilenSembol.Replace("ᴛʀʏ ", "")
                                                  .Replace("ᴜsᴅ ", "")
                                                  .Replace("ᴇᴜʀ ", "");
                belirlenenIsim = temizSembol + " Trendi";
            }

            var series = chartTrend.Series.Add(belirlenenIsim);

            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series.BorderWidth = 4;
            double minFiyat = double.MaxValue;
            double maxFiyat = double.MinValue;
            bool veriVar = false;

            foreach (TabPage tab in tabControl1.TabPages)
            {
                string tarih = tab.Text;
                DataGridView dgv = (DataGridView)tab.Controls[0];

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    string symbol = row.Cells["Symbol"].Value?.ToString();

                    if (symbol != null && symbol == secilenSembol)
                    {
                    string priceValue = row.Cells["Price"].Value?.ToString();

                        if (!string.IsNullOrEmpty(priceValue))
                        {
                             priceValue = priceValue.Replace("$", "")   
                                                    .Replace("€", "") 
                                                    .Replace("₺", "")  
                                                    .Replace(" ", "")   
                                                    .Replace(",", "."); 

                             if (double.TryParse(priceValue, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double fiyat))
                             {
                                series.Points.AddXY(tarih, fiyat);

                                if (fiyat < minFiyat) minFiyat = fiyat;
                                if (fiyat > maxFiyat) maxFiyat = fiyat;
                                    veriVar = true;
                             }
                        }
                    }
                }
            }

            if (veriVar)
            {
                double margin = (maxFiyat - minFiyat) * 0.2;
                if (margin == 0) margin = maxFiyat * 0.01;  

                chartTrend.ChartAreas[0].AxisY.Minimum = Math.Round(minFiyat - margin, 2);
                chartTrend.ChartAreas[0].AxisY.Maximum = Math.Round(maxFiyat + margin, 2);
            }
        }

        private void SaatTimer_Tick(object sender, EventArgs e)
        {
            lblTarih.Text = DateTime.Now.ToString("dd.MM.yyyy ddd  🕓HH:mm:ss");
        }

        Form aktifDetayPenceresi = null;

        private void cmbArama_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender != cmbArama) return;
            if (cmbArama.SelectedIndex == 0 || cmbArama.SelectedIndex == -1) return;

            lblTavsiye.Text = "Analiz Bekleniyor...";
            lblTavsiye.ForeColor = System.Drawing.Color.Gray;
            anlikHesaplananKar = 0;

            string secilenHisse = cmbArama.SelectedItem.ToString();

            string query = $@"
            SELECT Sektör, Tarih, Fiyat, Hacim, Volatilite, Piyasa_Değeri, PD_DD, F_K, GWP, Zarar, Teknik_Kâr 
            FROM HisseAnaliz 
            WHERE Hisse_Kodu = N'{secilenHisse}' 
            ORDER BY Tarih DESC";

            DataSet ds = DB.makeDBOperations(query);

            DataTable dtPivot = new DataTable();
            dtPivot.Columns.Add("Metrik / Tarih", typeof(string));

            string sektorAdi = "Bilinmiyor";

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                sektorAdi = ds.Tables[0].Rows[0]["Sektör"].ToString();

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    DateTime t = Convert.ToDateTime(row["Tarih"]);
                    dtPivot.Columns.Add(t.ToString("dd.MM.yyyy"), typeof(string));
                }

                string[] metrikler = { "Fiyat", "Hacim", "Volatilite", "Piyasa_Değeri", "PD_DD", "F_K", "GWP", "Zarar", "Teknik_Kâr" };

                foreach (string metrik in metrikler)
                {
                    DataRow newRow = dtPivot.NewRow();
                    if (metrik == "PD_DD")
                    {
                        newRow[0] = "PD/DD";
                    }
                    else if (metrik == "F_K")
                    {
                        newRow[0] = "F/K";
                    }
                    else
                    {
                        newRow[0] = metrik.Replace("_", " ");
                    }

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        object hamVeri = ds.Tables[0].Rows[i][metrik];

                        if (hamVeri != DBNull.Value && hamVeri != null && double.TryParse(hamVeri.ToString(), out double sayi))
                        {
                            if (metrik != "Hacim")
                            {
                                sayi = sayi / 100;
                            }

                            if (metrik == "Hacim")
                            {
                                newRow[i + 1] = sayi.ToString("N0");
                            }
                            else if (metrik == "Volatilite")
                            {
                                newRow[i + 1] = "% " + sayi.ToString("N2");
                            }
                            else
                            {
                                newRow[i + 1] = sayi.ToString("N2");
                            }
                        }
                        else
                        {
                            newRow[i + 1] = hamVeri.ToString();
                        }
                    }
                    dtPivot.Rows.Add(newRow);
                }
            }
            else
            {
                dtPivot.Columns.Add("Hata");
                dtPivot.Rows.Add("Veri", "Bulunamadı");
            }

            if (aktifDetayPenceresi != null && !aktifDetayPenceresi.IsDisposed)
            {
                aktifDetayPenceresi.Text = "🎯 " + secilenHisse + " - Detaylı Analiz Raporu |  Sektör: " + sektorAdi;

                DataGridView dgv = (DataGridView)aktifDetayPenceresi.Controls["dgvTarihsel"];
                if (dgv != null) dgv.DataSource = dtPivot;

                aktifDetayPenceresi.BringToFront();
            }
            else
            {
                aktifDetayPenceresi = new Form();
                aktifDetayPenceresi.Text = "🎯 " + secilenHisse + " - Detaylı Analiz Raporu |  Sektör: " + sektorAdi;
                aktifDetayPenceresi.Size = new System.Drawing.Size(750, 400);
                aktifDetayPenceresi.StartPosition = FormStartPosition.CenterScreen;
                aktifDetayPenceresi.ShowIcon = false;
                aktifDetayPenceresi.MaximizeBox = false;
                aktifDetayPenceresi.FormBorderStyle = FormBorderStyle.FixedSingle;

                panelKontrol.Parent = aktifDetayPenceresi;
                panelKontrol.Dock = DockStyle.Bottom;
                panelKontrol.Visible = true;

                DataGridView dgvTarihsel = new DataGridView();
                dgvTarihsel.Name = "dgvTarihsel";
                dgvTarihsel.DataSource = dtPivot;
                foreach (DataGridViewColumn col in dgvTarihsel.Columns)
                {
                    if (col.Index > 0)
                    {
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }
                dgvTarihsel.Parent = aktifDetayPenceresi;
                dgvTarihsel.Dock = DockStyle.Fill;
                dgvTarihsel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 
                dgvTarihsel.AllowUserToAddRows = false;
                dgvTarihsel.AllowUserToResizeColumns = false;
                dgvTarihsel.AllowUserToResizeRows = false;
                dgvTarihsel.ReadOnly = true;
                dgvTarihsel.RowHeadersVisible = false;
                dgvTarihsel.BackgroundColor = panelKontrol.BackColor;
                dgvTarihsel.BorderStyle = BorderStyle.None;

                dgvTarihsel.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
                dgvTarihsel.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;

                aktifDetayPenceresi.FormClosing += (s, args) =>
                {
                    panelKontrol.Parent = this;
                    panelKontrol.Visible = false;
                };

                aktifDetayPenceresi.Shown += (s, args) =>
                {
                    dgvTarihsel.ClearSelection();
                };

                aktifDetayPenceresi.Show();
            }
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            if (cmbArama.SelectedIndex == 0 || cmbArama.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen hesaplama yapmak için önce bir hisse seçin!");
                return;
            }

            string secilenHisse = cmbArama.SelectedItem.ToString();

            string checkQuery = $"SELECT COUNT(*) FROM HisseAnaliz WHERE Hisse_Kodu = N'{secilenHisse}'";
            DataSet dsCheck = DB.makeDBOperations(checkQuery);

            if (dsCheck == null || dsCheck.Tables[0].Rows[0][0].ToString() == "0")
            {
                MessageBox.Show($"{secilenHisse} hissesi için sistemde yeterli tarihsel veri bulunmuyor. Sağlıklı bir hesaplama yapılamaz!", "Veri Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                lblTavsiye.Text = "Analiz Bekleniyor...";
                lblTavsiye.ForeColor = System.Drawing.Color.Gray;

                return; 
            }

            int seed = 0;
            foreach (char c in secilenHisse) seed += (int)c;
            Random rnd = new Random(seed);

            int karYuzdesi = rnd.Next(-20, 50);
            anlikHesaplananKar = karYuzdesi;

            if (karYuzdesi >= 15)
            {
                lblTavsiye.Text = $"Kâr Beklentisi: +%{karYuzdesi}\nSistem Önerisi: AL";
                lblTavsiye.ForeColor = System.Drawing.Color.Green;
            }
            else if (karYuzdesi >= 0 && karYuzdesi < 15)
            {
                lblTavsiye.Text = $"Kâr Beklentisi: +%{karYuzdesi}\nSistem Önerisi: TUT";
                lblTavsiye.ForeColor = System.Drawing.Color.DarkOrange;
            }
            else
            {
                lblTavsiye.Text = $"Zarar Riski: %{karYuzdesi}\nSistem Önerisi: SAT";
                lblTavsiye.ForeColor = System.Drawing.Color.Red;
            }
            lblTavsiye.Refresh();
        }

        private void btnTakiplisteEkle_Click(object sender, EventArgs e)
        {
            if (cmbArama.SelectedIndex <= 0) return;

            string hisse = cmbArama.SelectedItem.ToString().Trim().ToUpper();

            string tavsiyeNotu = "📢 " + lblTavsiye.Text.Replace("\n", " | ");

            bool hisseVarMi = false;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells[0].Value?.ToString().Trim().ToUpper() == hisse)
                {
                    row.Cells[2].Value = tavsiyeNotu; 
                    hisseVarMi = true;
                    break;
                }
            }

            if (!hisseVarMi)
            {
                dataGridView2.Rows.Add(hisse, "👀 TAKİP", tavsiyeNotu);
            }
        }

        private void btnPortfoyEkle_Click(object sender, EventArgs e)
        {
            if (cmbArama.SelectedIndex <= 0) return;

            string hisse = cmbArama.SelectedItem.ToString();
            string sadeceTavsiye = "📢 " + lblTavsiye.Text.Replace("\n", " | ");

            bool hisseVarMi = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value?.ToString() == hisse)
                {
                    row.Cells[2].Value = sadeceTavsiye;
                    hisseVarMi = true; break;
                }
            }
            if (!hisseVarMi)
            {
                dataGridView1.Rows.Add(hisse, "💼 PORTFÖY", sadeceTavsiye);
            }
            PortfoyKariGuncelle();
        }

        Form aktifPortfoyPenceresi = null;
        Form aktifTakipPenceresi = null;

        private void btnPortfoy_Click(object sender, EventArgs e)
        {
            if (aktifPortfoyPenceresi != null && !aktifPortfoyPenceresi.IsDisposed)
            {
                aktifPortfoyPenceresi.BringToFront(); 
                if (aktifPortfoyPenceresi.WindowState == FormWindowState.Minimized)
                    aktifPortfoyPenceresi.WindowState = FormWindowState.Normal; 
                return;
            }

            aktifPortfoyPenceresi = new Form();
            aktifPortfoyPenceresi.Text = "Portföyüm";
            aktifPortfoyPenceresi.Size = new System.Drawing.Size(800, 500);
            aktifPortfoyPenceresi.StartPosition = FormStartPosition.CenterScreen;
            aktifPortfoyPenceresi.Icon = System.Drawing.Icon.FromHandle(Properties.Resources.Icons8_Ios7_Household_Toolbox_Filled.GetHicon());

            dataGridView1.Parent = aktifPortfoyPenceresi;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Visible = true;

            lblTotalKar.Parent = aktifPortfoyPenceresi;
            lblTotalKar.Dock = DockStyle.Bottom;
            lblTotalKar.Visible = true;

            lblTotalKar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblTotalKar.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);
            lblTotalKar.Padding = new System.Windows.Forms.Padding(10);

            aktifPortfoyPenceresi.FormClosing += (s, args) =>
            {
                dataGridView1.Parent = this;
                dataGridView1.Visible = false;

                lblTotalKar.Parent = this;
                lblTotalKar.Visible = false;
            };

            aktifPortfoyPenceresi.Shown += (s, args) =>
            {
                dataGridView1.ClearSelection();
                dataGridView1.CurrentCell = null;
            };


            aktifPortfoyPenceresi.Show();
        }

        private void btnTakipListesi_Click(object sender, EventArgs e)
        {
            if (aktifTakipPenceresi != null && !aktifTakipPenceresi.IsDisposed)
            {
                aktifTakipPenceresi.BringToFront();
                if (aktifTakipPenceresi.WindowState == FormWindowState.Minimized)
                    aktifTakipPenceresi.WindowState = FormWindowState.Normal;
                return;
            }

            aktifTakipPenceresi = new Form();
            aktifTakipPenceresi.Text = "Takip Listem";
            aktifTakipPenceresi.Size = new System.Drawing.Size(800, 500);
            aktifTakipPenceresi.StartPosition = FormStartPosition.CenterScreen;
            aktifTakipPenceresi.Icon = System.Drawing.Icon.FromHandle(Properties.Resources.money_bag.GetHicon());

            dataGridView2.Parent = aktifTakipPenceresi;
            dataGridView2.Dock = DockStyle.Fill;
            dataGridView2.Visible = true;

            aktifTakipPenceresi.FormClosing += (s, args) =>
            {
                dataGridView2.Parent = this;
                dataGridView2.Visible = false;
            };

            aktifTakipPenceresi.Shown += (s, args) =>
            {
                dataGridView2.ClearSelection();
                dataGridView2.CurrentCell = null;
            };

            aktifTakipPenceresi.Show();
        }

        private void PortfoyKariGuncelle()
        {
            toplamPortfoyKari = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow || row.Cells[0].Value == null) continue;
                string analizNotu = row.Cells[2].Value?.ToString() ?? "";

                if (analizNotu.Contains("Analiz Bekleniyor")) continue;
                string hisse = row.Cells[0].Value.ToString();

                int seed = 0;
                foreach (char c in hisse) seed += (int)c;
                Random rnd = new Random(seed);
                toplamPortfoyKari += rnd.Next(-20, 50);
            }

            if (toplamPortfoyKari > 0)
            {
                lblTotalKar.Text = $"TOPLAM PORTFÖY BEKLENTİSİ: +%{toplamPortfoyKari} KÂR 📈";
                lblTotalKar.ForeColor = System.Drawing.Color.Green;
            }
            else if (toplamPortfoyKari < 0)
            {
                lblTotalKar.Text = $"TOPLAM PORTFÖY BEKLENTİSİ: %{toplamPortfoyKari} ZARAR 📉";
                lblTotalKar.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblTotalKar.Text = "TOPLAM PORTFÖY BEKLENTİSİ: %0";
                lblTotalKar.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void takipListesineTaşıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.IsNewRow) return;

            DialogResult cevap = MessageBox.Show("Bu hisseyi Takip Listesine taşımak istediğinizden emin misiniz?", "Transfer Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                string hisse = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string analiz = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                bool zatenVarMi = false;

                foreach (DataGridViewRow tRow in dataGridView2.Rows)
                {
                    if (tRow.Cells[0].Value?.ToString().Trim().ToUpper() == hisse)
                    {
                        tRow.Cells[2].Value = analiz; 
                        zatenVarMi = true;
                        break;
                    }
                }

                if (!zatenVarMi)
                {
                    dataGridView2.Rows.Add(hisse, "👀 TAKİP", analiz);
                }

                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);

                PortfoyKariGuncelle();
                MessageBox.Show(hisse + " Takip Listesine geri çekildi. ⏳", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void portföydenSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.IsNewRow) return;

            DialogResult cevap = MessageBox.Show("Bu hisseyi portföyden tamamen silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (cevap == DialogResult.Yes)
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                PortfoyKariGuncelle();
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Bu hisseyi tamamen silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (cevap == DialogResult.No)
            {
                e.Cancel = true; 
            }
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            PortfoyKariGuncelle();
        }

        private void portföyeEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow == null || dataGridView2.CurrentRow.IsNewRow) return;

            DialogResult cevap = MessageBox.Show("Bu hisseyi Portföye taşımak istediğinizden emin misiniz?", "Transfer Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (cevap == DialogResult.Yes)
            {
                string hisse = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                string analiz = dataGridView2.CurrentRow.Cells[2].Value.ToString();

                bool zatenVarMi = false;

                foreach (DataGridViewRow pRow in dataGridView1.Rows)
                {
                    if (pRow.Cells[0].Value?.ToString().Trim().ToUpper() == hisse)
                    {
                        pRow.Cells[2].Value = analiz; 
                        zatenVarMi = true;
                        break;
                    }
                }

                if (!zatenVarMi)
                {
                    dataGridView1.Rows.Add(hisse, "💼 PORTFÖY", analiz);
                }

                dataGridView2.Rows.Remove(dataGridView2.CurrentRow);
                PortfoyKariGuncelle();

                MessageBox.Show(hisse + " başarıyla Portföyünüze taşındı! 🚀", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void takipListesindenSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow == null || dataGridView2.CurrentRow.IsNewRow) return;

            DialogResult cevap = MessageBox.Show("Bu hisseyi takip listesinden tamamen silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (cevap == DialogResult.Yes)
            {
                dataGridView2.Rows.Remove(dataGridView2.CurrentRow);
            }
        }
        private void LoadTableFromSQL(string kategori, DataGridView hedefTablo)
        {
            hedefTablo.ClearSelection();
            hedefTablo.CurrentCell = null;

            string query = $"SELECT Symbol, Price, PriceChange FROM MarketData WHERE Category = '{kategori}'";
            DataSet ds = DB.makeDBOperations(query);

            if (ds != null)
            {
                hedefTablo.DataSource = ds.Tables[0];

                hedefTablo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                hedefTablo.RowHeadersVisible = false;     
                hedefTablo.AllowUserToAddRows = false;   
                hedefTablo.ReadOnly = true;             
                hedefTablo.BackgroundColor = Color.White;
                hedefTablo.BorderStyle = BorderStyle.None;

                hedefTablo.Columns[0].HeaderText = "Borsa";
                hedefTablo.Columns[1].HeaderText = "Fiyat";
                hedefTablo.Columns[2].HeaderText = "Değişim (%)";

                hedefTablo.ClearSelection();
                hedefTablo.CurrentCell = null;

            }
        }

        private void SektorVerileri()
        {
            string query = @"
            SELECT 
            Sektör, 
            Tarih,
            Toplam_Hacim AS [Toplam Hacim], 
            Ort_Volatilite AS [Ortalama Volatilite], 
            Ort_FK AS [Ortalama F/K],
            Ort_Teknik_Kâr AS [Ortalama Teknik Kâr]
            FROM SektörData";

            DataSet ds = DB.makeDBOperations(query);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                dgvSektor.DataSource = ds.Tables[0];

                dgvSektor.ClearSelection();
                dgvSektor.CurrentCell = null;
            }

            dgvSektor.Columns["Toplam Hacim"].DefaultCellStyle.Format = "N0";
            dgvSektor.Columns["Ortalama Teknik Kâr"].DefaultCellStyle.Format = "N0";

            dgvSektor.Columns["Ortalama Volatilite"].DefaultCellStyle.Format = "N2";
            dgvSektor.Columns["Ortalama F/K"].DefaultCellStyle.Format = "N2";

            if (dgvSektor.Columns.Contains("Tarih"))
            {
                dgvSektor.Columns["Tarih"].DefaultCellStyle.Format = "dd.MM.yyyy";
            }

            dgvSektor.Columns["Toplam Hacim"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSektor.Columns["Ortalama Teknik Kâr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSektor.Columns["Ortalama F/K"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSektor.Columns["Ortalama Volatilite"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            btnHesapla_Click(null, null);

            string arananHisse = cmbArama.SelectedItem.ToString();
            string yeniNot = "📢 " + lblTavsiye.Text.Replace("\n", " | ");

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value?.ToString() == arananHisse)
                {
                    row.Cells[2].Value = yeniNot;
                }
            }

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells[0].Value?.ToString() == arananHisse)
                {
                    row.Cells[2].Value = yeniNot;
                }
            }
            PortfoyKariGuncelle();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDun.ClearSelection();
            dgvDun.CurrentCell = null;

            dgvOnceki.ClearSelection();
            dgvOnceki.CurrentCell = null;
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dataGridView2.HitTest(dataGridView2.PointToClient(MousePosition).X,dataGridView2.PointToClient(MousePosition).Y).RowIndex < 0)
            {
                e.Cancel = true;
            }
        }

        private void contextMenuStrip2_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(dataGridView1.HitTest(dataGridView1.PointToClient(MousePosition).X,dataGridView1.PointToClient(MousePosition).Y).RowIndex < 0)
            {
                e.Cancel = true;
            }
        }

        private void KullaniciVerileriniKaydet()
        {
            try
            {
                string guvenliKullaniciAdi = AktifKullanici.Trim().Replace(" ", "_");
                string portfoyDosyasi = Path.Combine(Application.StartupPath, guvenliKullaniciAdi + "_Portfoy.txt");
                string takipDosyasi = Path.Combine(Application.StartupPath, guvenliKullaniciAdi + "_Takip.txt");

                using (StreamWriter sw = new StreamWriter(portfoyDosyasi, false, System.Text.Encoding.UTF8))
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow && row.Cells[0].Value != null)
                        {
                            sw.WriteLine(row.Cells[0].Value.ToString() + "~~" + row.Cells[2].Value.ToString());
                        }
                    }
                }

                using (StreamWriter sw = new StreamWriter(takipDosyasi, false, System.Text.Encoding.UTF8))
                {
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        if (!row.IsNewRow && row.Cells[0].Value != null)
                        {
                            sw.WriteLine(row.Cells[0].Value.ToString() + "~~" + row.Cells[2].Value.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya kaydedilirken hata oluştu:\n" + ex.Message, "Kayıt Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KullaniciVerileriniYukle()
        {
            try
            {
                string guvenliKullaniciAdi = AktifKullanici.Trim().Replace(" ", "_");
                string portfoyDosyasi = Path.Combine(Application.StartupPath, guvenliKullaniciAdi + "_Portfoy.txt");
                string takipDosyasi = Path.Combine(Application.StartupPath, guvenliKullaniciAdi + "_Takip.txt");

                if (File.Exists(portfoyDosyasi))
                {
                    string[] portfoySatirlar = File.ReadAllLines(portfoyDosyasi, System.Text.Encoding.UTF8);
                    foreach (string satir in portfoySatirlar)
                    {
                        string[] parcalar = satir.Split(new string[] { "~~" }, StringSplitOptions.None);
                        if (parcalar.Length == 2)
                        {
                            dataGridView1.Rows.Add(parcalar[0], "💼 PORTFÖY", parcalar[1]);
                        }
                    }
                    PortfoyKariGuncelle();
                }

                if (File.Exists(takipDosyasi))
                {
                    string[] takipSatirlar = File.ReadAllLines(takipDosyasi, System.Text.Encoding.UTF8);
                    foreach (string satir in takipSatirlar)
                    {
                        string[] parcalar = satir.Split(new string[] { "~~" }, StringSplitOptions.None);
                        if (parcalar.Length == 2)
                        {
                            dataGridView2.Rows.Add(parcalar[0], "👀 TAKİP", parcalar[1]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler yüklenirken hata oluştu:\n" + ex.Message, "Yükleme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            KullaniciVerileriniKaydet(); 
            Application.Exit();
        }

        private void cikis_Click(object sender, EventArgs e)
        {
            DialogResult yanit = MessageBox.Show("Oturumu kapatıp giriş ekranına dönmek istediğinize emin misiniz?",
                                                 "Güvenli Çıkış",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

            if (yanit == DialogResult.Yes)
            {
                KullaniciVerileriniKaydet();

                System.Diagnostics.Process.Start(Application.ExecutablePath);
                Environment.Exit(0);
            }
        }
        private void ayarlar_Click(object sender, EventArgs e)
        {
            Ayarlar ayarFormu = new Ayarlar();
            ayarFormu.AktifKullanici = this.AktifKullanici;
            ayarFormu.ShowDialog();
        }
    }
}