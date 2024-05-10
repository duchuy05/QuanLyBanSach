﻿using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanSach.Forms
{
    public partial class frmthietke : Form
    {
        public bool logouted = true;
        public frmthietke()
        {
            InitializeComponent();
            this.Resize += new EventHandler(ResizeForm);
        }

        public event EventHandler DangXuat;

        private void ResizeForm(object sender, EventArgs e)
        {
            // Điều chỉnh kích thước của panel bên trong
            AdjustPanelSize();
        }

        private void AdjustPanelSize()
        {
            // Thiết lập kích thước của panel là kích thước mới của form
            // trừ đi các viền của form
            panelContent.Size = new System.Drawing.Size(this.ClientSize.Width - SystemInformation.VerticalScrollBarWidth,
                                                   this.ClientSize.Height - SystemInformation.HorizontalScrollBarHeight);
            panelContent.SizeChanged += panelContent_SizeChanged;
        }

        private void panelContent_SizeChanged(object sender, EventArgs e)
        {
            // Cập nhật kích thước của các nội dung bên trong Panel
            foreach (Control control in panelContent.Controls)
            {
                // Cập nhật kích thước của Control theo kích thước mới của Panel
                control.Width = panelContent.ClientSize.Width;
                control.Height = panelContent.ClientSize.Height;
            }
        }

        private void btnSach_Click(object sender, EventArgs e)
        {
            lbl_val.Text = btnSach.Text;

            container(new frmSach());

        }


        private void container(object _form)
        {
            if (panelContent.Controls.Count > 0) panelContent.Controls.Clear();

            Form fm = _form as Form;
            fm.TopLevel = false;
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(fm);
            panelContent.Tag = fm;
            fm.Show();
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTacgia_Click(object sender, EventArgs e)
        {
            lbl_val.Text = btnTacgia.Text;

            container(new frmTacgia());
        }

        private void btnSach_BackColorChanged(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DangXuat(this, new EventArgs());

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click_2(object sender, EventArgs e)
        {

        }

        private void btnLoaisach_Click(object sender, EventArgs e)
        {

        }

        private void btnHDnhap_Click(object sender, EventArgs e)
        {

        }

        private void btnNhanvien_Click(object sender, EventArgs e)
        {

        }

        private void frmthietke_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (logouted)
                Application.Exit();
        }
    }
}
