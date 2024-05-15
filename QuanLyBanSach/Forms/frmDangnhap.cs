using QuanLyBanSach.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanSach.Forms
{
    public partial class frmDangnhap : Form
    {
        public frmDangnhap()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = "SELECT * from tblTaikhoan where tentaikhoan = '" + txtTaikhoan.Text + "' AND matkhau = '" + txtMatkhau.Text + "'";

            sqlcmd.Connection = Class.Functions.conn;

            SqlDataReader data = sqlcmd.ExecuteReader();

            if (data.Read() == true)
            {
                frmthietke f = new frmthietke();
                f.Show();
                this.Hide();
                f.DangXuat += F_DangXuat;
            }
            else
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng");
                txtTaikhoan.Focus();
            }

            data.Close();
        }

        private void F_DangXuat(object sender, EventArgs e)
        {
            (sender as frmthietke).logouted = false;
            (sender as frmthietke).Close();
            this.Show();
        }

        private void frmDangnhap_Load(object sender, EventArgs e)
        {
            Functions.ketnoi();
            txtTaikhoan.Enabled = true;
            txtMatkhau.Enabled = true;
        }
    }
}
