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
    public partial class frmTimKiemHDB : Form
    {
        public frmTimKiemHDB()
        {
            InitializeComponent();
        }

        private void frmTimKiemHDB_Load(object sender, EventArgs e)
        {
            Class.Functions.ketnoi();
            ResetValues();
            dgridTimHDB.DataSource = null;

        }
        private void ResetValues()
        {
            txtSohdx.Text = "";
            txtMaNV.Text = "";
            txtThang.Text = "";
            txtNam.Text = "";
            txtMaKH.Text = "";
            txtTong.Text = "";
        }
        private void Load_DataGridView()
        {
            dgridTimHDB.Columns[0].HeaderText = "Số hóa đơn xuất";
            dgridTimHDB.Columns[1].HeaderText = "Mã nhân viên";
            dgridTimHDB.Columns[2].HeaderText = "Ngày bán";
            dgridTimHDB.Columns[3].HeaderText = "Mã khách hàng";
            dgridTimHDB.Columns[4].HeaderText = "Tổng tiền";
            dgridTimHDB.Columns[0].Width = 100;
            dgridTimHDB.Columns[1].Width = 80;
            dgridTimHDB.Columns[2].Width = 80;
            dgridTimHDB.Columns[3].Width = 80;
            dgridTimHDB.Columns[4].Width = 80;
            dgridTimHDB.AllowUserToAddRows = false;
            dgridTimHDB.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtSohdx.Text == "") && (txtThang.Text == "") && (txtNam.Text == "") && (txtMaNV.Text == "") && (txtMaKH.Text == "") && (txtTong.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm", "Yêu cầu nhập lại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblHoadonxuat WHERE 1=1";
            if (txtSohdx.Text != "")
                sql = sql + " AND Sohdx Like N'%" + txtSohdx.Text + "%'";
            if (txtThang.Text != "")
                sql = sql + " AND MONTH(Ngayban) =" + txtThang.Text;
            if (txtNam.Text != "")
                sql = sql + " AND YEAR(Ngayban) =" + txtNam.Text;
            if (txtMaNV.Text != "")
                sql = sql + " AND Manv Like N'%" + txtMaNV.Text + "%'";
            if (txtMaKH.Text != "")
                sql = sql + " AND Makh Like N'%" + txtMaKH.Text + "%'";
            if (txtTong.Text != "")
                sql = sql + " AND Tongtien <=" + txtTong.Text;
            DataTable tblTimHDB = Class.Functions.GetDataToTable(sql);
            if (tblTimHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
            }
            else
                MessageBox.Show("Có " + tblTimHDB.Rows.Count + " bản ghi thỏa mãn điều kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dgridTimHDB.DataSource = tblTimHDB;
            Load_DataGridView();
        }

        private void btnTimLai_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgridTimHDB.DataSource = null;
        }

        private void txtTong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == '.') || (e.KeyChar == '-') || (Convert.ToInt32(e.KeyChar) == 8) || (Convert.ToInt32(e.KeyChar) == 13))
                e.Handled = false;
            else
                e.Handled = true;

        }

       

        private void dgridTimHDB_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sohdx;
                sohdx = dgridTimHDB.CurrentRow.Cells["Sohdx"].Value.ToString();
                frmHoadonban frm = new frmHoadonban();
                frm.MaHDBan = sohdx;
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
