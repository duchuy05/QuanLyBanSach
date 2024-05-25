using System;

namespace QuanLyBanSach.Forms
{
    partial class frmthietke
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmthietke));
            this.panelLeft = new Guna.UI2.WinForms.Guna2Panel();
            this.btnBaocaoban = new Guna.UI2.WinForms.Guna2Button();
            this.btnTaikhoan = new Guna.UI2.WinForms.Guna2Button();
            this.btnHDnhap = new Guna.UI2.WinForms.Guna2Button();
            this.btnHDxuat = new Guna.UI2.WinForms.Guna2Button();
            this.btnLogout = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnKhach = new Guna.UI2.WinForms.Guna2Button();
            this.btnNhanvien = new Guna.UI2.WinForms.Guna2Button();
            this.btnNxb = new Guna.UI2.WinForms.Guna2Button();
            this.btnLoaisach = new Guna.UI2.WinForms.Guna2Button();
            this.btnSach = new Guna.UI2.WinForms.Guna2Button();
            this.btnTacgia = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.panelContent = new Guna.UI2.WinForms.Guna2Panel();
            this.panelTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lbl_val = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.Navy;
            this.panelLeft.Controls.Add(this.btnBaocaoban);
            this.panelLeft.Controls.Add(this.btnTaikhoan);
            this.panelLeft.Controls.Add(this.btnHDnhap);
            this.panelLeft.Controls.Add(this.btnHDxuat);
            this.panelLeft.Controls.Add(this.btnLogout);
            this.panelLeft.Controls.Add(this.btnKhach);
            this.panelLeft.Controls.Add(this.btnNhanvien);
            this.panelLeft.Controls.Add(this.btnNxb);
            this.panelLeft.Controls.Add(this.btnLoaisach);
            this.panelLeft.Controls.Add(this.btnSach);
            this.panelLeft.Controls.Add(this.btnTacgia);
            this.panelLeft.Controls.Add(this.guna2PictureBox1);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(2);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(223, 641);
            this.panelLeft.TabIndex = 0;
            // 
            // btnBaocaoban
            // 
            this.btnBaocaoban.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBaocaoban.ForeColor = System.Drawing.Color.White;
            this.btnBaocaoban.Location = new System.Drawing.Point(3, 514);
            this.btnBaocaoban.Name = "btnBaocaoban";
            this.btnBaocaoban.Size = new System.Drawing.Size(220, 45);
            this.btnBaocaoban.TabIndex = 0;
            this.btnBaocaoban.Text = "Báo cáo bán hàng";
            this.btnBaocaoban.Click += new System.EventHandler(this.btnBaocaoban_Click);
            // 
            // btnTaikhoan
            // 
            this.btnTaikhoan.BackColor = System.Drawing.Color.RosyBrown;
            this.btnTaikhoan.BorderColor = System.Drawing.Color.PowderBlue;
            this.btnTaikhoan.BorderThickness = 2;
            this.btnTaikhoan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTaikhoan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTaikhoan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTaikhoan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTaikhoan.FillColor = System.Drawing.Color.LightSteelBlue;
            this.btnTaikhoan.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaikhoan.ForeColor = System.Drawing.Color.Black;
            this.btnTaikhoan.Location = new System.Drawing.Point(-6, 444);
            this.btnTaikhoan.Margin = new System.Windows.Forms.Padding(2);
            this.btnTaikhoan.Name = "btnTaikhoan";
            this.btnTaikhoan.Size = new System.Drawing.Size(235, 42);
            this.btnTaikhoan.TabIndex = 6;
            this.btnTaikhoan.Text = "Quản lý tài khoản";
            this.btnTaikhoan.Click += new System.EventHandler(this.btnTaikhoan_Click);
            // 
            // btnHDnhap
            // 
            this.btnHDnhap.BackColor = System.Drawing.Color.RosyBrown;
            this.btnHDnhap.BorderColor = System.Drawing.Color.PowderBlue;
            this.btnHDnhap.BorderThickness = 2;
            this.btnHDnhap.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHDnhap.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHDnhap.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHDnhap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHDnhap.FillColor = System.Drawing.Color.LightSteelBlue;
            this.btnHDnhap.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHDnhap.ForeColor = System.Drawing.Color.Black;
            this.btnHDnhap.Location = new System.Drawing.Point(-5, 251);
            this.btnHDnhap.Margin = new System.Windows.Forms.Padding(2);
            this.btnHDnhap.Name = "btnHDnhap";
            this.btnHDnhap.Size = new System.Drawing.Size(233, 42);
            this.btnHDnhap.TabIndex = 4;
            this.btnHDnhap.Text = "Quản lý hóa đơn nhập";
            this.btnHDnhap.Click += new System.EventHandler(this.btnHDnhap_Click);
            // 
            // btnHDxuat
            // 
            this.btnHDxuat.BackColor = System.Drawing.Color.RosyBrown;
            this.btnHDxuat.BorderColor = System.Drawing.Color.PowderBlue;
            this.btnHDxuat.BorderThickness = 2;
            this.btnHDxuat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHDxuat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHDxuat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHDxuat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHDxuat.FillColor = System.Drawing.Color.LightSteelBlue;
            this.btnHDxuat.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHDxuat.ForeColor = System.Drawing.Color.Black;
            this.btnHDxuat.Location = new System.Drawing.Point(-6, 297);
            this.btnHDxuat.Margin = new System.Windows.Forms.Padding(2);
            this.btnHDxuat.Name = "btnHDxuat";
            this.btnHDxuat.Size = new System.Drawing.Size(234, 42);
            this.btnHDxuat.TabIndex = 5;
            this.btnHDxuat.Text = "Quản lý hóa đơn xuất";
            // 
            // btnLogout
            // 
            this.btnLogout.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogout.FillColor = System.Drawing.Color.MintCream;
            this.btnLogout.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.Black;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.Location = new System.Drawing.Point(55, 658);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnLogout.Size = new System.Drawing.Size(89, 44);
            this.btnLogout.TabIndex = 11;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnKhach
            // 
            this.btnKhach.BackColor = System.Drawing.Color.RosyBrown;
            this.btnKhach.BorderColor = System.Drawing.Color.PowderBlue;
            this.btnKhach.BorderThickness = 2;
            this.btnKhach.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnKhach.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnKhach.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnKhach.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnKhach.FillColor = System.Drawing.Color.LightSteelBlue;
            this.btnKhach.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhach.ForeColor = System.Drawing.Color.Black;
            this.btnKhach.Location = new System.Drawing.Point(-5, 389);
            this.btnKhach.Margin = new System.Windows.Forms.Padding(2);
            this.btnKhach.Name = "btnKhach";
            this.btnKhach.Size = new System.Drawing.Size(233, 42);
            this.btnKhach.TabIndex = 9;
            this.btnKhach.Text = "Quản lý khách hàng";
            // 
            // btnNhanvien
            // 
            this.btnNhanvien.BackColor = System.Drawing.Color.RosyBrown;
            this.btnNhanvien.BorderColor = System.Drawing.Color.PowderBlue;
            this.btnNhanvien.BorderThickness = 2;
            this.btnNhanvien.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNhanvien.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNhanvien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNhanvien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNhanvien.FillColor = System.Drawing.Color.LightSteelBlue;
            this.btnNhanvien.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhanvien.ForeColor = System.Drawing.Color.Black;
            this.btnNhanvien.Location = new System.Drawing.Point(-7, 343);
            this.btnNhanvien.Margin = new System.Windows.Forms.Padding(2);
            this.btnNhanvien.Name = "btnNhanvien";
            this.btnNhanvien.Size = new System.Drawing.Size(239, 42);
            this.btnNhanvien.TabIndex = 8;
            this.btnNhanvien.Text = "Quản lý nhân viên";
            this.btnNhanvien.Click += new System.EventHandler(this.btnNhanvien_Click);
            // 
            // btnNxb
            // 
            this.btnNxb.BackColor = System.Drawing.Color.RosyBrown;
            this.btnNxb.BorderColor = System.Drawing.Color.PowderBlue;
            this.btnNxb.BorderThickness = 2;
            this.btnNxb.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNxb.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNxb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNxb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNxb.FillColor = System.Drawing.Color.LightSteelBlue;
            this.btnNxb.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNxb.ForeColor = System.Drawing.Color.Black;
            this.btnNxb.Location = new System.Drawing.Point(-7, 205);
            this.btnNxb.Margin = new System.Windows.Forms.Padding(2);
            this.btnNxb.Name = "btnNxb";
            this.btnNxb.Size = new System.Drawing.Size(239, 42);
            this.btnNxb.TabIndex = 3;
            this.btnNxb.Text = "Quản lý nhà xuất bản";
            this.btnNxb.Click += new System.EventHandler(this.btnNxb_Click);
            // 
            // btnLoaisach
            // 
            this.btnLoaisach.BackColor = System.Drawing.Color.RosyBrown;
            this.btnLoaisach.BorderColor = System.Drawing.Color.PowderBlue;
            this.btnLoaisach.BorderThickness = 2;
            this.btnLoaisach.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLoaisach.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLoaisach.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLoaisach.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLoaisach.FillColor = System.Drawing.Color.LightSteelBlue;
            this.btnLoaisach.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoaisach.ForeColor = System.Drawing.Color.Black;
            this.btnLoaisach.Location = new System.Drawing.Point(-7, 113);
            this.btnLoaisach.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoaisach.Name = "btnLoaisach";
            this.btnLoaisach.Size = new System.Drawing.Size(239, 42);
            this.btnLoaisach.TabIndex = 2;
            this.btnLoaisach.Text = "Quản lý loại sách";
            this.btnLoaisach.Click += new System.EventHandler(this.btnLoaisach_Click);
            // 
            // btnSach
            // 
            this.btnSach.BackColor = System.Drawing.Color.RosyBrown;
            this.btnSach.BorderColor = System.Drawing.Color.PowderBlue;
            this.btnSach.BorderThickness = 2;
            this.btnSach.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSach.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSach.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSach.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSach.FillColor = System.Drawing.Color.LightSteelBlue;
            this.btnSach.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSach.ForeColor = System.Drawing.Color.Black;
            this.btnSach.Image = ((System.Drawing.Image)(resources.GetObject("btnSach.Image")));
            this.btnSach.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnSach.ImageSize = new System.Drawing.Size(40, 40);
            this.btnSach.Location = new System.Drawing.Point(-7, 66);
            this.btnSach.Margin = new System.Windows.Forms.Padding(2);
            this.btnSach.Name = "btnSach";
            this.btnSach.Size = new System.Drawing.Size(239, 43);
            this.btnSach.TabIndex = 0;
            this.btnSach.Text = "Quản lý sách";
            this.btnSach.BackColorChanged += new System.EventHandler(this.btnSach_BackColorChanged);
            this.btnSach.Click += new System.EventHandler(this.btnSach_Click);
            // 
            // btnTacgia
            // 
            this.btnTacgia.BackColor = System.Drawing.Color.Cyan;
            this.btnTacgia.BorderColor = System.Drawing.Color.PowderBlue;
            this.btnTacgia.BorderThickness = 2;
            this.btnTacgia.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTacgia.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTacgia.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTacgia.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTacgia.FillColor = System.Drawing.Color.LightSteelBlue;
            this.btnTacgia.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTacgia.ForeColor = System.Drawing.Color.Black;
            this.btnTacgia.Location = new System.Drawing.Point(-5, 159);
            this.btnTacgia.Margin = new System.Windows.Forms.Padding(2);
            this.btnTacgia.Name = "btnTacgia";
            this.btnTacgia.Size = new System.Drawing.Size(237, 42);
            this.btnTacgia.TabIndex = 1;
            this.btnTacgia.Text = "Quản lý tác giả";
            this.btnTacgia.Click += new System.EventHandler(this.btnTacgia_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.ErrorImage = null;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(-30, -49);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(301, 158);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.Click += new System.EventHandler(this.guna2PictureBox1_Click_2);
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.AliceBlue;
            this.panelContent.Location = new System.Drawing.Point(227, 38);
            this.panelContent.Margin = new System.Windows.Forms.Padding(2);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(961, 603);
            this.panelContent.TabIndex = 0;
            this.panelContent.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContent_Paint);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Navy;
            this.panelTop.Controls.Add(this.lbl_val);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(223, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(961, 39);
            this.panelTop.TabIndex = 1;
            this.panelTop.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // lbl_val
            // 
            this.lbl_val.BackColor = System.Drawing.Color.Transparent;
            this.lbl_val.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_val.ForeColor = System.Drawing.Color.White;
            this.lbl_val.Location = new System.Drawing.Point(510, 12);
            this.lbl_val.Name = "lbl_val";
            this.lbl_val.Size = new System.Drawing.Size(102, 27);
            this.lbl_val.TabIndex = 1;
            this.lbl_val.Text = "Trang chủ";
            // 
            // frmthietke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 641);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelLeft);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmthietke";
            this.Text = "Quản lý bán Sách";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmthietke_FormClosed);
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        private void lbl_val_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnHDxuat_Click_1(object sender, EventArgs e)
        {
            lbl_val.Text = btnHDxuat.Text;

            container(new frmHoadonban());
        }

        private void btnNxb_Click(object sender, EventArgs e)
        {
            lbl_val.Text = btnNxb.Text;

            container(new frmNhaxuatban());
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelLeft;
        private Guna.UI2.WinForms.Guna2Panel panelContent;
        private Guna.UI2.WinForms.Guna2Button btnSach;
        private Guna.UI2.WinForms.Guna2Panel panelTop;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl_val;
        private Guna.UI2.WinForms.Guna2Button btnTacgia;
        private Guna.UI2.WinForms.Guna2Button btnNxb;
        private Guna.UI2.WinForms.Guna2Button btnLoaisach;
        private Guna.UI2.WinForms.Guna2Button btnKhach;
        private Guna.UI2.WinForms.Guna2Button btnNhanvien;
        private Guna.UI2.WinForms.Guna2Button btnBaocaoban;
        private Guna.UI2.WinForms.Guna2Button btnTaikhoan;
        private Guna.UI2.WinForms.Guna2Button btnHDxuat;
        private Guna.UI2.WinForms.Guna2Button btnHDnhap;
        private Guna.UI2.WinForms.Guna2CircleButton btnLogout;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}