using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace aplikasinventorismini
{
    public partial class Form1 : Form
    {
        private DataTable dtBarang;
        private DataTable dtTransaksi;

        private string connStr = "server=localhost;uid=root;pwd=;database=inventaris_mini;";

        public Form1()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;

            BuildLayout();
            InitializeData();
            WireEvents();

            ShowDashboard();
        }

        // -------------------------------------------------------
        // MYSQL CONNECTION
        // -------------------------------------------------------
        private MySqlConnection GetConn()
        {
            return new MySqlConnection(connStr);
        }

        // -------------------------------------------------------
        // LAYOUT
        // -------------------------------------------------------

        private void BuildLayout()
        {
            panelSidebar.Padding = new Padding(10);

            var flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 190,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Padding = new Padding(0, 10, 0, 0)
            };
            panelDashboard.Controls.Add(flow);

            flow.Controls.Add(CreateStatCard("📥 Total Barang Masuk", Color.FromArgb(34, 197, 94)));
            flow.Controls.Add(CreateStatCard("📤 Total Barang Keluar", Color.FromArgb(239, 68, 68)));
            flow.Controls.Add(CreateStatCard("📊 Sisa Stok Barang", Color.FromArgb(59, 130, 246)));

            StyleDataGridView(dgvBarang);
            StyleDataGridView(dgvTransaksi);
        }

        private Panel CreateStatCard(string title, Color color)
        {
            var card = new Panel
            {
                Size = new Size(300, 150),
                Margin = new Padding(10),
                BackColor = Color.White,
                Tag = title
            };

            card.Paint += (s, e) => DrawRoundedPanel(card, e);

            var lblTitle = new Label
            {
                Text = title,
                Location = new Point(20, 20),
                Size = new Size(260, 25),
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };

            var lblValue = new Label
            {
                Text = "0",
                Location = new Point(20, 50),
                Size = new Size(260, 70),
                Font = new Font("Segoe UI", 30, FontStyle.Bold),
                ForeColor = color
            };

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblValue);
            return card;
        }

        private void DrawRoundedPanel(Panel panel, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var path = new GraphicsPath();
            int radius = 15;

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(panel.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(panel.Width - radius, panel.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, panel.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            e.Graphics.FillPath(Brushes.White, path);
        }

        private void StyleDataGridView(DataGridView dgv)
        {
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgv.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 65, 85);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgv.ColumnHeadersHeight = 40;
            dgv.RowTemplate.Height = 30;
        }

        // -------------------------------------------------------
        // DATA INITIALIZATION
        // -------------------------------------------------------
        private void InitializeData()
        {
            dtBarang = new DataTable();
            dtTransaksi = new DataTable();

            dtTransaksi.Columns.Add("Nama Barang");
            dtTransaksi.Columns.Add("Jenis Barang");
            dtTransaksi.Columns.Add("Harga", typeof(decimal));
            dtTransaksi.Columns.Add("Jumlah", typeof(int));
            dtTransaksi.Columns.Add("Total", typeof(decimal));
            dtTransaksi.Columns.Add("Tanggal", typeof(DateTime));

            dgvTransaksi.DataSource = dtTransaksi;

            cmbJenisBarang.Items.AddRange(new string[]
            {
                "Elektronik", "Makanan", "Minuman", "Pakaian", "Alat Tulis", "Furniture", "Lainnya"
            });

            LoadBarangFromDB();
        }

        // -------------------------------------------------------
        // LOAD FROM DATABASE
        // -------------------------------------------------------
        private void LoadBarangFromDB()
        {
            using (var conn = GetConn())
            {
                conn.Open();
                string query = "SELECT nama AS 'Nama Barang', jenis AS 'Jenis Barang', barang_masuk AS 'Barang Masuk', barang_keluar AS 'Barang Keluar', sisa AS 'Sisa Barang' FROM barang";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                dtBarang = new DataTable();
                da.Fill(dtBarang);

                dgvBarang.DataSource = dtBarang;
            }
        }

        // -------------------------------------------------------
        // NAVIGASI PANEL
        // -------------------------------------------------------
        private void ShowDashboard()
        {
            panelDashboard.Visible = true;
            panelBarang.Visible = false;
            panelTransaksi.Visible = false;
            UpdateDashboard();
        }

        private void ShowBarang()
        {
            panelDashboard.Visible = false;
            panelBarang.Visible = true;
            panelTransaksi.Visible = false;

            LoadBarangFromDB();
        }

        private void ShowTransaksi()
        {
            panelDashboard.Visible = false;
            panelBarang.Visible = false;
            panelTransaksi.Visible = true;
        }

        // -------------------------------------------------------
        // DASHBOARD UPDATE
        // -------------------------------------------------------
        private void UpdateDashboard()
        {
            int totalMasuk = dtBarang.AsEnumerable().Sum(r => r.Field<int>("Barang Masuk"));
            int totalKeluar = dtBarang.AsEnumerable().Sum(r => r.Field<int>("Barang Keluar"));
            int totalSisa = dtBarang.AsEnumerable().Sum(r => r.Field<int>("Sisa Barang"));

            foreach (Control c in panelDashboard.Controls)
            {
                if (c is FlowLayoutPanel flp)
                {
                    foreach (Panel card in flp.Controls)
                    {
                        string title = card.Tag.ToString();
                        Label valueLabel = card.Controls.OfType<Label>().Last();

                        if (title.Contains("Masuk")) valueLabel.Text = totalMasuk.ToString();
                        else if (title.Contains("Keluar")) valueLabel.Text = totalKeluar.ToString();
                        else if (title.Contains("Sisa")) valueLabel.Text = totalSisa.ToString();
                    }
                }
            }
        }

        // -------------------------------------------------------
        // BARANG MASUK (MYSQL)
        // -------------------------------------------------------
        private void BtnBarangMasuk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNamaBarang.Text) || numJumlah.Value <= 0)
            {
                MessageBox.Show("Lengkapi data!", "Peringatan");
                return;
            }

            string nama = txtNamaBarang.Text;
            string jenis = cmbJenisBarang.Text;
            int jumlah = (int)numJumlah.Value;

            using (var conn = GetConn())
            {
                conn.Open();

                string checkQuery = "SELECT COUNT(*) FROM barang WHERE nama = @nama";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@nama", nama);

                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count > 0)
                {
                    string updateQuery = @"
                        UPDATE barang 
                        SET barang_masuk = barang_masuk + @masuk,
                            sisa = sisa + @masuk
                        WHERE nama = @nama";

                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@masuk", jumlah);
                    updateCmd.Parameters.AddWithValue("@nama", nama);
                    updateCmd.ExecuteNonQuery();
                }
                else
                {
                    string insertQuery = @"
                        INSERT INTO barang (nama, jenis, barang_masuk, barang_keluar, sisa)
                        VALUES (@nama, @jenis, @masuk, 0, @masuk)";

                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@nama", nama);
                    insertCmd.Parameters.AddWithValue("@jenis", jenis);
                    insertCmd.Parameters.AddWithValue("@masuk", jumlah);
                    insertCmd.ExecuteNonQuery();
                }
            }

            ClearBarangInput();
            LoadBarangFromDB();
            UpdateDashboard();
        }

        // -------------------------------------------------------
        // BARANG KELUAR (MYSQL)
        // -------------------------------------------------------
        private void BtnBarangKeluar_Click(object sender, EventArgs e)
        {
            string nama = txtNamaBarang.Text;
            int jumlah = (int)numJumlah.Value;

            using (var conn = GetConn())
            {
                conn.Open();

                string getSisa = "SELECT sisa FROM barang WHERE nama = @nama";
                MySqlCommand cmd = new MySqlCommand(getSisa, conn);
                cmd.Parameters.AddWithValue("@nama", nama);

                object result = cmd.ExecuteScalar();

                if (result == null)
                {
                    MessageBox.Show("Barang tidak ditemukan!");
                    return;
                }

                int sisa = Convert.ToInt32(result);

                if (jumlah > sisa)
                {
                    MessageBox.Show("Stok tidak cukup!");
                    return;
                }

                string query = @"
                    UPDATE barang 
                    SET barang_keluar = barang_keluar + @keluar,
                        sisa = sisa - @keluar
                    WHERE nama = @nama";

                MySqlCommand update = new MySqlCommand(query, conn);
                update.Parameters.AddWithValue("@keluar", jumlah);
                update.Parameters.AddWithValue("@nama", nama);
                update.ExecuteNonQuery();
            }

            ClearBarangInput();
            LoadBarangFromDB();
            UpdateDashboard();
        }

        // -------------------------------------------------------
        // CARI BARANG
        // -------------------------------------------------------
        private void BtnCari_Click(object sender, EventArgs e)
        {
            string keyword = txtCari.Text.Replace("'", "''");

            if (string.IsNullOrEmpty(keyword))
            {
                dtBarang.DefaultView.RowFilter = "";
            }
            else
            {
                dtBarang.DefaultView.RowFilter =
                    $"[Nama Barang] LIKE '%{keyword}%' OR [Jenis Barang] LIKE '%{keyword}%'";
            }
        }

        // -------------------------------------------------------
        // TRANSAKSI
        // -------------------------------------------------------
        private void BtnTambahTransaksi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNamaBarangTransaksi.Text) || numJumlahTransaksi.Value <= 0)
            {
                MessageBox.Show("Lengkapi data transaksi!", "Peringatan");
                return;
            }

            decimal harga = numHarga.Value;
            int jumlah = (int)numJumlahTransaksi.Value;
            decimal total = harga * jumlah;
            string nama = txtNamaBarangTransaksi.Text.Trim();

            // DITAMBAHKAN KE DATATABLE (kode kamu tetap)
            dtTransaksi.Rows.Add(
                txtNamaBarangTransaksi.Text,
                txtJenisBarangTransaksi.Text,
                harga,
                jumlah,
                total,
                DateTime.Now
            );

            try
            {
                using (var conn = GetConn())
                {
                    conn.Open();

                    string cekQuery = "SELECT sisa FROM barang WHERE LOWER(nama) = LOWER(@nama)";
                    using (MySqlCommand cmdCek = new MySqlCommand(cekQuery, conn))
                    {
                        cmdCek.Parameters.AddWithValue("@nama", nama);

                        object result = cmdCek.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show("Barang tidak ditemukan di database!");
                            return;
                        }

                        int stok = Convert.ToInt32(result);

                        if (stok < jumlah)
                        {
                            MessageBox.Show("Stok tidak mencukupi!");
                            return;
                        }
                    }

                    string updateQuery = @"
            UPDATE barang 
            SET barang_keluar = barang_keluar + @keluar,
                sisa = sisa - @keluar
            WHERE nama = @nama";

                    using (MySqlCommand cmdUpdate = new MySqlCommand(updateQuery, conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@keluar", jumlah);
                        cmdUpdate.Parameters.AddWithValue("@nama", nama);
                        cmdUpdate.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Transaksi berhasil & stok diperbarui", "Sukses");

                LoadBarangFromDB();
                UpdateDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void BtnHapusTransaksi_Click(object sender, EventArgs e)
        {
            if (dgvTransaksi.SelectedRows.Count > 0)
            {
                dgvTransaksi.Rows.RemoveAt(dgvTransaksi.SelectedRows[0].Index);
            }
        }

        // -------------------------------------------------------
        // ETC
        // -------------------------------------------------------
        private void ClearBarangInput()
        {
            txtNamaBarang.Clear();
            cmbJenisBarang.SelectedIndex = -1;
            numJumlah.Value = 0;
        }

        private void WireEvents()
        {
            btnMenuDashboard.Click += (s, e) => ShowDashboard();
            btnMenuBarang.Click += (s, e) => ShowBarang();
            btnMenuTransaksi.Click += (s, e) => ShowTransaksi();

            btnBarangMasuk.Click += BtnBarangMasuk_Click;
            btnBarangKeluar.Click += BtnBarangKeluar_Click;
            btnCari.Click += BtnCari_Click;
            txtCari.TextChanged += BtnCari_Click;

            btnTambahTransaksi.Click += BtnTambahTransaksi_Click;
            btnHapusTransaksi.Click += BtnHapusTransaksi_Click;
        }
    }
}
