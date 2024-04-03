using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanSach
{
    public partial class frmTaotk : Form
    {
        public frmTaotk()
        {
            InitializeComponent();
        }

        private void btnDongy_Click(object sender, EventArgs e)
        {
            if (txtTentk.Text == "" || txtMatkhau.Text == "")
            {
                MessageBox.Show("Bạn phải nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("Bạn đã đăng ký thành công" + "\n" + "Tài khoản: " + txtTentk.Text + "\n" + "Mật khẩu: " + txtMatkhau.Text, "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtTentk.Text = "";
                txtMatkhau.Text = "";
            }
        }
    }
}
