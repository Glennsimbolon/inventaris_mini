namespace aplikasinventorismini
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Panels
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelContainer; // container untuk panel aktif (dashboard/barang/transaksi)

        // Dashboard / Pages
        private System.Windows.Forms.Panel panelDashboard;
        private System.Windows.Forms.Panel panelBarang;
        private System.Windows.Forms.Panel panelTransaksi;

        // Sidebar buttons
        private System.Windows.Forms.Button btnMenuDashboard;
        private System.Windows.Forms.Button btnMenuBarang;
        private System.Windows.Forms.Button btnMenuTransaksi;

        // Barang controls (dideklarasikan di designer supaya Designer aware)
        private System.Windows.Forms.Label lblBarangTitle;
        private System.Windows.Forms.TextBox txtNamaBarang;
        private System.Windows.Forms.ComboBox cmbJenisBarang;
        private System.Windows.Forms.NumericUpDown numJumlah;
        private System.Windows.Forms.Button btnBarangMasuk;
        private System.Windows.Forms.Button btnBarangKeluar;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.DataGridView dgvBarang;

        // Transaksi controls
        private System.Windows.Forms.TextBox txtNamaBarangTransaksi;
        private System.Windows.Forms.TextBox txtJenisBarangTransaksi;
        private System.Windows.Forms.NumericUpDown numHarga;
        private System.Windows.Forms.NumericUpDown numJumlahTransaksi;
        private System.Windows.Forms.Button btnTambahTransaksi;
        private System.Windows.Forms.Button btnHapusTransaksi;
        private System.Windows.Forms.DataGridView dgvTransaksi;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // Inisialisasi Kontrol
            panelSidebar = new Panel();
            lblLogo = new Label();
            btnMenuDashboard = new Button();
            btnMenuBarang = new Button();
            btnMenuTransaksi = new Button();
            panelContainer = new Panel();
            panelBarang = new Panel();
            lblBarangTitle = new Label();
            panelTransaksi = new Panel();
            panelDashboard = new Panel();
            lblDashboardTitle = new Label();

            // Kontrol Barang
            txtNamaBarang = new TextBox();
            cmbJenisBarang = new ComboBox();
            numJumlah = new NumericUpDown();
            btnBarangMasuk = new Button();
            btnBarangKeluar = new Button();
            txtCari = new TextBox();
            btnCari = new Button();
            dgvBarang = new DataGridView();

            // Kontrol Transaksi
            txtNamaBarangTransaksi = new TextBox();
            txtJenisBarangTransaksi = new TextBox();
            numHarga = new NumericUpDown();
            numJumlahTransaksi = new NumericUpDown();
            btnTambahTransaksi = new Button();
            btnHapusTransaksi = new Button();
            dgvTransaksi = new DataGridView();

            // Start Layout
            panelSidebar.SuspendLayout();
            panelContainer.SuspendLayout();
            panelBarang.SuspendLayout();
            panelTransaksi.SuspendLayout(); // Transaksi juga perlu Suspend/Resume/PerformLayout
            panelDashboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numJumlah).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBarang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numHarga).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numJumlahTransaksi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTransaksi).BeginInit();
            SuspendLayout();

            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(30, 41, 59);
            panelSidebar.Controls.Add(lblLogo);
            panelSidebar.Controls.Add(btnMenuDashboard);
            panelSidebar.Controls.Add(btnMenuBarang);
            panelSidebar.Controls.Add(btnMenuTransaksi);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(260, 776);
            panelSidebar.TabIndex = 1;

            // 
            // lblLogo
            // 
            lblLogo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(20, 20);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(220, 48);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "📦 INVENTARIS MINI";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // btnMenuDashboard
            // 
            btnMenuDashboard.BackColor = Color.FromArgb(51, 65, 85);
            btnMenuDashboard.FlatAppearance.BorderSize = 0;
            btnMenuDashboard.FlatStyle = FlatStyle.Flat;
            btnMenuDashboard.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnMenuDashboard.ForeColor = Color.White;
            btnMenuDashboard.Location = new Point(20, 100);
            btnMenuDashboard.Name = "btnMenuDashboard";
            btnMenuDashboard.Padding = new Padding(15, 0, 0, 0);
            btnMenuDashboard.Size = new Size(220, 48);
            btnMenuDashboard.TabIndex = 1;
            btnMenuDashboard.Text = "🏠 Dashboard";
            btnMenuDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnMenuDashboard.UseVisualStyleBackColor = false;

            // 
            // btnMenuBarang
            // 
            btnMenuBarang.BackColor = Color.FromArgb(51, 65, 85);
            btnMenuBarang.FlatAppearance.BorderSize = 0;
            btnMenuBarang.FlatStyle = FlatStyle.Flat;
            btnMenuBarang.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnMenuBarang.ForeColor = Color.White;
            btnMenuBarang.Location = new Point(20, 160);
            btnMenuBarang.Name = "btnMenuBarang";
            btnMenuBarang.Padding = new Padding(15, 0, 0, 0);
            btnMenuBarang.Size = new Size(220, 48);
            btnMenuBarang.TabIndex = 2;
            btnMenuBarang.Text = "📦 Barang";
            btnMenuBarang.TextAlign = ContentAlignment.MiddleLeft;
            btnMenuBarang.UseVisualStyleBackColor = false;

            // 
            // btnMenuTransaksi
            // 
            btnMenuTransaksi.BackColor = Color.FromArgb(51, 65, 85);
            btnMenuTransaksi.FlatAppearance.BorderSize = 0;
            btnMenuTransaksi.FlatStyle = FlatStyle.Flat;
            btnMenuTransaksi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnMenuTransaksi.ForeColor = Color.White;
            btnMenuTransaksi.Location = new Point(20, 220);
            btnMenuTransaksi.Name = "btnMenuTransaksi";
            btnMenuTransaksi.Padding = new Padding(15, 0, 0, 0);
            btnMenuTransaksi.Size = new Size(220, 48);
            btnMenuTransaksi.TabIndex = 3;
            btnMenuTransaksi.Text = "💰 Transaksi";
            btnMenuTransaksi.TextAlign = ContentAlignment.MiddleLeft;
            btnMenuTransaksi.UseVisualStyleBackColor = false;

            // 
            // panelContainer
            // 
            panelContainer.BackColor = Color.FromArgb(240, 244, 248);
            panelContainer.Controls.Add(panelBarang);
            panelContainer.Controls.Add(panelTransaksi);
            panelContainer.Controls.Add(panelDashboard);
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(260, 0);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(1181, 776);
            panelContainer.TabIndex = 0;

            // 
            // panelBarang
            // ** PERBAIKAN: MENAMBAH SEMUA KONTROL BARANG KE PANEL **
            // 
            panelBarang.Controls.Add(dgvBarang);
            panelBarang.Controls.Add(btnCari);
            panelBarang.Controls.Add(txtCari);
            panelBarang.Controls.Add(btnBarangKeluar);
            panelBarang.Controls.Add(btnBarangMasuk);
            panelBarang.Controls.Add(numJumlah);
            panelBarang.Controls.Add(cmbJenisBarang);
            panelBarang.Controls.Add(txtNamaBarang);
            panelBarang.Controls.Add(lblBarangTitle);

            panelBarang.Dock = DockStyle.Fill;
            panelBarang.Location = new Point(0, 0); // Diubah dari (20, 60) karena sudah ada padding
            panelBarang.Name = "panelBarang";
            panelBarang.Padding = new Padding(20);
            panelBarang.Size = new Size(1181, 776);
            panelBarang.TabIndex = 0;

            // 
            // lblBarangTitle
            // 
            lblBarangTitle.AutoSize = true;
            lblBarangTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblBarangTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblBarangTitle.Location = new Point(20, 20); // Disesuaikan dengan padding 20
            lblBarangTitle.Name = "lblBarangTitle";
            lblBarangTitle.Size = new Size(236, 32);
            lblBarangTitle.TabIndex = 0;
            lblBarangTitle.Text = "Manajemen Barang";

            // 
            // panelTransaksi
            // 
            // ** PERBAIKAN: MENAMBAH SEMUA KONTROL TRANSAKSI KE PANEL **
            panelTransaksi.Controls.Add(dgvTransaksi);
            panelTransaksi.Controls.Add(btnHapusTransaksi);
            panelTransaksi.Controls.Add(btnTambahTransaksi);
            panelTransaksi.Controls.Add(numJumlahTransaksi);
            panelTransaksi.Controls.Add(numHarga);
            panelTransaksi.Controls.Add(txtJenisBarangTransaksi);
            panelTransaksi.Controls.Add(txtNamaBarangTransaksi);

            panelTransaksi.Dock = DockStyle.Fill;
            panelTransaksi.Location = new Point(0, 0);
            panelTransaksi.Name = "panelTransaksi";
            panelTransaksi.Padding = new Padding(20);
            panelTransaksi.Size = new Size(1181, 776);
            panelTransaksi.TabIndex = 1;

            // 
            // panelDashboard
            // 
            panelDashboard.Controls.Add(lblDashboardTitle);
            panelDashboard.Dock = DockStyle.Fill;
            panelDashboard.Location = new Point(0, 0);
            panelDashboard.Name = "panelDashboard";
            panelDashboard.Padding = new Padding(20);
            panelDashboard.Size = new Size(1181, 776);
            panelDashboard.TabIndex = 0;

            // 
            // lblDashboardTitle
            // 
            lblDashboardTitle.AutoSize = true;
            lblDashboardTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblDashboardTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblDashboardTitle.Location = new Point(20, 20);
            lblDashboardTitle.Name = "lblDashboardTitle";
            lblDashboardTitle.Size = new Size(373, 32);
            lblDashboardTitle.TabIndex = 0;
            lblDashboardTitle.Text = "Dashboard - Statistik Inventaris";

            // 
            // txtNamaBarang
            // ** PERBAIKAN POSISI INPUT BARANG (KIRI) **
            // 
            txtNamaBarang.Location = new Point(20, 70); // Di bawah title
            txtNamaBarang.Name = "txtNamaBarang";
            txtNamaBarang.PlaceholderText = "Nama Barang";
            txtNamaBarang.Size = new Size(380, 23);
            txtNamaBarang.TabIndex = 0;

            // 
            // cmbJenisBarang
            // ** PERBAIKAN POSISI INPUT BARANG (KIRI) **
            // 
            cmbJenisBarang.Location = new Point(20, 140);
            cmbJenisBarang.Name = "cmbJenisBarang";
            cmbJenisBarang.Size = new Size(380, 23);
            cmbJenisBarang.TabIndex = 0;
            // 
            // numJumlah
            // ** PERBAIKAN POSISI INPUT BARANG (KIRI) **
            // 
            numJumlah.Location = new Point(20, 210);
            numJumlah.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numJumlah.Name = "numJumlah";
            numJumlah.Size = new Size(380, 23);
            numJumlah.TabIndex = 0;

            // 
            // btnBarangMasuk
            // ** PERBAIKAN POSISI BUTTON (KIRI) **
            // 
            btnBarangMasuk.BackColor = Color.FromArgb(34, 197, 94);
            btnBarangMasuk.FlatStyle = FlatStyle.Flat;
            btnBarangMasuk.ForeColor = Color.White;
            btnBarangMasuk.Location = new Point(20, 270);
            btnBarangMasuk.Name = "btnBarangMasuk";
            btnBarangMasuk.Size = new Size(380, 40);
            btnBarangMasuk.TabIndex = 0;
            btnBarangMasuk.Text = "➕ Barang Masuk";
            btnBarangMasuk.UseVisualStyleBackColor = false;

            // 
            // btnBarangKeluar
            // ** PERBAIKAN POSISI BUTTON (KIRI) **
            // 
            btnBarangKeluar.BackColor = Color.FromArgb(239, 68, 68);
            btnBarangKeluar.FlatStyle = FlatStyle.Flat;
            btnBarangKeluar.ForeColor = Color.White;
            btnBarangKeluar.Location = new Point(20, 320);
            btnBarangKeluar.Name = "btnBarangKeluar";
            btnBarangKeluar.Size = new Size(380, 40);
            btnBarangKeluar.TabIndex = 0;
            btnBarangKeluar.Text = "➖ Barang Keluar";
            btnBarangKeluar.UseVisualStyleBackColor = false;

            // 
            // txtCari
            // ** PERBAIKAN POSISI PENCARIAN (KANAN) **
            // 
            txtCari.Location = new Point(480, 70);
            txtCari.Name = "txtCari";
            txtCari.PlaceholderText = "Cari barang...";
            txtCari.Size = new Size(300, 23);
            txtCari.TabIndex = 0;

            // 
            // btnCari
            // ** PERBAIKAN POSISI PENCARIAN (KANAN) **
            // 
            btnCari.BackColor = Color.FromArgb(59, 130, 246);
            btnCari.FlatStyle = FlatStyle.Flat;
            btnCari.ForeColor = Color.White;
            btnCari.Location = new Point(790, 67);
            btnCari.Name = "btnCari";
            btnCari.Size = new Size(90, 30);
            btnCari.TabIndex = 0;
            btnCari.Text = "Cari";
            btnCari.UseVisualStyleBackColor = false;

            // 
            // dgvBarang
            // ** PERBAIKAN POSISI DAN DOCK DGV BARANG (KANAN) **
            // 
            dgvBarang.AllowUserToAddRows = false;
            dgvBarang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBarang.BackgroundColor = Color.White;
            dgvBarang.BorderStyle = BorderStyle.None;
            // 🛑 DockStyle.Fill DIHAPUS agar tidak menutupi kontrol lain!
            dgvBarang.Location = new Point(480, 110);
            dgvBarang.Name = "dgvBarang";
            dgvBarang.RowTemplate.Height = 35;
            dgvBarang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBarang.Size = new Size(680, 600); // Ukuran DGV yang cukup besar
            dgvBarang.TabIndex = 0;

            // 
            // txtNamaBarangTransaksi
            // 
            txtNamaBarangTransaksi.Location = new Point(20, 70);
            txtNamaBarangTransaksi.Name = "txtNamaBarangTransaksi";
            txtNamaBarangTransaksi.PlaceholderText = "Nama Barang";
            txtNamaBarangTransaksi.Size = new Size(380, 23);
            txtNamaBarangTransaksi.TabIndex = 0;

            // 
            // txtJenisBarangTransaksi
            // 
            txtJenisBarangTransaksi.Location = new Point(20, 140);
            txtJenisBarangTransaksi.Name = "txtJenisBarangTransaksi";
            txtJenisBarangTransaksi.PlaceholderText = "Jenis barang";
            txtJenisBarangTransaksi.Size = new Size(380, 23);
            txtJenisBarangTransaksi.TabIndex = 0;

            // 
            // numHarga
            // 
            numHarga.Location = new Point(20, 210);
            numHarga.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numHarga.Name = "numHarga";
            numHarga.Size = new Size(380, 23);
            numHarga.TabIndex = 0;

            // 
            // numJumlahTransaksi
            // 
            numJumlahTransaksi.Location = new Point(20, 280);
            numJumlahTransaksi.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numJumlahTransaksi.Name = "numJumlahTransaksi";
            numJumlahTransaksi.Size = new Size(380, 23);
            numJumlahTransaksi.TabIndex = 0;

            // 
            // btnTambahTransaksi
            // 
            btnTambahTransaksi.BackColor = Color.FromArgb(147, 51, 234);
            btnTambahTransaksi.FlatStyle = FlatStyle.Flat;
            btnTambahTransaksi.ForeColor = Color.White;
            btnTambahTransaksi.Location = new Point(20, 340);
            btnTambahTransaksi.Name = "btnTambahTransaksi";
            btnTambahTransaksi.Size = new Size(380, 40);
            btnTambahTransaksi.TabIndex = 0;
            btnTambahTransaksi.Text = "➕ Tambah Transaksi";
            btnTambahTransaksi.UseVisualStyleBackColor = false;

            // 
            // btnHapusTransaksi
            // 
            btnHapusTransaksi.BackColor = Color.FromArgb(244, 63, 94);
            btnHapusTransaksi.FlatStyle = FlatStyle.Flat;
            btnHapusTransaksi.ForeColor = Color.White;
            btnHapusTransaksi.Location = new Point(20, 390);
            btnHapusTransaksi.Name = "btnHapusTransaksi";
            btnHapusTransaksi.Size = new Size(380, 40);
            btnHapusTransaksi.TabIndex = 0;
            btnHapusTransaksi.Text = "🗑️ Hapus Transaksi";
            btnHapusTransaksi.UseVisualStyleBackColor = false;

            // 
            // dgvTransaksi
            // 
            dgvTransaksi.AllowUserToAddRows = false;
            dgvTransaksi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransaksi.BackgroundColor = Color.White;
            dgvTransaksi.BorderStyle = BorderStyle.None;
            dgvTransaksi.Dock = DockStyle.None; // Diubah ke None agar tidak menutupi input
            dgvTransaksi.Location = new Point(480, 70);
            dgvTransaksi.Name = "dgvTransaksi";
            dgvTransaksi.RowTemplate.Height = 35;
            dgvTransaksi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransaksi.Size = new Size(680, 600);
            dgvTransaksi.TabIndex = 0;

            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(240, 244, 248);
            ClientSize = new Size(1441, 776);
            Controls.Add(panelContainer);
            Controls.Add(panelSidebar);
            Font = new Font("Segoe UI", 9F);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Aplikasi Inventaris Mini";
            WindowState = FormWindowState.Maximized;

            // Final Layout
            panelSidebar.ResumeLayout(false);
            panelContainer.ResumeLayout(false);

            panelBarang.ResumeLayout(false);
            panelBarang.PerformLayout();

            panelTransaksi.ResumeLayout(false);
            panelTransaksi.PerformLayout(); // Tambahkan PerformLayout untuk Transaksi

            panelDashboard.ResumeLayout(false);
            panelDashboard.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)numJumlah).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBarang).EndInit();
            ((System.ComponentModel.ISupportInitialize)numHarga).EndInit();
            ((System.ComponentModel.ISupportInitialize)numJumlahTransaksi).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTransaksi).EndInit();
            ResumeLayout(false);
        }

        private Label lblLogo;
        private Label lblDashboardTitle;
    }
}
