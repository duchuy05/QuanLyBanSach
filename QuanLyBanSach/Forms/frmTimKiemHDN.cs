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
    public partial class frmTimKiemHDN : Form
    {
        public frmTimKiemHDN()
        {
            InitializeComponent();
        }

        private void frmTimKiemHDN_Load(object sender, EventArgs e)
        {
            Class.Functions.ketnoi();
            ResetValues();
            dgridTimHDN.DataSource = null;
        }
        private void ResetValues()
        {
            txtSohdn.Text = "";
            txtMaNV.Text = "";
            txtThang.Text = "";
            txtNam.Text = "";
            txtMaNCC.Text = "";
            txtTong.Text = "";
        }
        private void Load_DataGridView()
        {
            dgridTimHDN.Columns[0].HeaderText = "Số hóa đơn nhập";
            dgridTimHDN.Columns[1].HeaderText = "Mã nhân viên";
            dgridTimHDN.Columns[2].HeaderText = "Ngày bán";
            dgridTimHDN.Columns[3].HeaderText = "Mã nhà cung cấp";
            dgridTimHDN.Columns[4].HeaderText = "Tổng tiền";
            dgridTimHDN.Columns[0].Width = 100;
            dgridTimHDN.Columns[1].Width = 80;
            dgridTimHDN.Columns[2].Width = 80;
            dgridTimHDN.Columns[3].Width = 80;
            dgridTimHDN.Columns[4].Width = 80;
            dgridTimHDN.AllowUserToAddRows = false;
            dgridTimHDN.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtSohdn.Text == "") && (txtThang.Text == "") && (txtNam.Text == "") && (txtMaNV.Text == "") && (txtMaNCC.Text == "") && (txtTong.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm", "Yêu cầu nhập lại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblHoadonnhap WHERE 1=1";
            if (txtSohdn.Text != "")
                sql = sql + " AND Sohdn Like N'%" + txtSohdn.Text + "%'";
            if (txtThang.Text != "")
                sql = sql + " AND MONTH(Ngayban) =" + txtThang.Text;
            if (txtNam.Text != "")
                sql = sql + " AND YEAR(Ngayban) =" + txtNam.Text;
            if (txtMaNV.Text != "")
                sql = sql + " AND Manv Like N'%" + txtMaNV.Text + "%'";
            if (txtMaNCC.Text != "")
                sql = sql + " AND Mancc Like N'%" + txtMaNCC.Text + "%'";
            if (txtTong.Text != "")
                sql = sql + " AND Tongtien <=" + txtTong.Text;
            DataTable tblTimHDN = Class.Functions.GetDataToTable(sql);
            if (tblTimHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
            }
            else
                MessageBox.Show("Có " + tblTimHDN.Rows.Count + " bản ghi thỏa mãn điều kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dgridTimHDN.DataSource = tblTimHDN;
            Load_DataGridView();
        }

        private void btnTimLai_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgridTimHDN.DataSource = null;
        }

        private void txtTong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == '.') || (e.KeyChar == '-') || (Convert.ToInt32(e.KeyChar) == 8) || (Convert.ToInt32(e.KeyChar) == 13))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void dgridTimHDN_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sohdn;
                sohdn = dgridTimHDN.CurrentRow.Cells["Sohdx"].Value.ToString();
                frmHoadonnhap frm = new frmHoadonnhap();
                frm.MaHDNhap = sohdn;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
