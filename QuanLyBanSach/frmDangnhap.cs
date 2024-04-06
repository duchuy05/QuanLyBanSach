﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanSach
{
    public partial class frmDangnhap : Form
    {
        string connectstring = @"Data Source=""192.168.20.104, 1435"";Initial Catalog=QLBS;Persist Security Info=True;User ID=sa;Password=1";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adt;
        DataTable dt = new DataTable();
        public frmDangnhap()
        {
            InitializeComponent();
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        { 

            if (txtTaikhoan.Text == "ddh" && txtMatkhau.Text == "1")
            {
                MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmTongquat a = new frmTongquat();
                a.Show();
                this.Hide();
            } else
            {
                MessageBox.Show("Đăng nhập thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmDangnhap_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(connectstring);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            try { 
                con.Open();
                cmd = new SqlCommand("select * from Sach", con);
                adt = new SqlDataAdapter(cmd);
                adt.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);    
            }
        }
    }
}
