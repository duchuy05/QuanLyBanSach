using QuanLyBanSach.Class;
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
    public partial class frmKhachhang : Form
    {
        DataTable tblKhach;
        public frmKhachhang()
        {
            InitializeComponent();
        }
        private void frmKhachhang_Load(object sender, EventArgs e)
        {
            Class.Functions.ketnoi();
            txtMakhach.Enabled = false;
            txtTenkhach.Focus();
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
            resetvalues();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "select makh, tenkhach, diachi, sdt FROM tblKhach";
            tblKhach = Class.Functions.GetDataToTable(sql);
            dgridKhachhang.DataSource = tblKhach;
            dgridKhachhang.Columns[0].HeaderText = "Mã khách";
            dgridKhachhang.Columns[1].HeaderText = "Tên khách";
            dgridKhachhang.Columns[2].HeaderText = "Địa chỉ";
            dgridKhachhang.Columns[3].HeaderText = "Số điện thoại";
            dgridKhachhang.Columns[0].Width = 50;
            dgridKhachhang.Columns[1].Width = 100;
            dgridKhachhang.Columns[2].Width = 130;
            dgridKhachhang.Columns[3].Width = 80;
            dgridKhachhang.AllowUserToAddRows = false;
            dgridKhachhang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void resetvalues()
        {
            txtMakhach.Text = "";
            txtTenkhach.Text = "";
            txtDiachi.Text = "";
            mskSodienthoai.Text = "";
        }

        private void dgridKhachhang_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMakhach.Focus();
                return;
            }
            if (tblKhach.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMakhach.Text = dgridKhachhang.CurrentRow.Cells["makh"].Value.ToString();
            txtTenkhach.Text = dgridKhachhang.CurrentRow.Cells["tenkhach"].Value.ToString();
            txtDiachi.Text = dgridKhachhang.CurrentRow.Cells["diachi"].Value.ToString();
            mskSodienthoai.Text = dgridKhachhang.CurrentRow.Cells["sdt"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            resetvalues();
            txtTenkhach.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (tblKhach.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMakhach.Text == "")
            {
                MessageBox.Show("Chưa chọn bản ghi nào để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenkhach.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenkhach.Focus();
                return;
            }
            if (txtDiachi.Text == "")
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiachi.Focus();
                return;
            }
            if (mskSodienthoai.Text == "(   )     ")
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mskSodienthoai.Focus();
                return;
            }
            string sql;
            sql = "update tblKhach set Tenkhach = N'" + txtTenkhach.Text.Trim() + "', Diachi ='" + txtDiachi.Text.Trim() + "', Sdt ='" + mskSodienthoai.Text.Trim() + "' where Makh = N'" + txtMakhach.Text.Trim() + "'";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            resetvalues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKhach.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMakhach.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblKhach WHERE Makh=N'" + txtMakhach.Text + "'";
                Class.Functions.RunSqlDel(sql);
                Load_DataGridView();
                resetvalues();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtTenkhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenkhach.Focus();
                return;
            }
            if (txtDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiachi.Focus();
                return;
            }
            if (mskSodienthoai.Text == "(   )     ")
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskSodienthoai.Focus();
                return;
            }
            sql = "INSERT INTO tblKhach(Tenkhach, Diachi, Sdt) VALUES(N'" + txtTenkhach.Text.Trim() + "',N'" + txtDiachi.Text.Trim() + "','" + mskSodienthoai.Text + "')";
            Functions.RunSql(sql);
            Load_DataGridView();
            resetvalues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMakhach.Enabled = false;
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            resetvalues();
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = false;
            txtMakhach.Enabled = false;
            btnLuu.Enabled = false;
            Load_DataGridView();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            txtMakhach.Enabled = true;
            if ((txtMakhach.Text == "") && (txtTenkhach.Text == "") && (txtDiachi.Text == "") && (mskSodienthoai.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblKhach WHERE 1=1";
            if (txtMakhach.Text != "")
                sql = sql + " AND Makh Like N'%" + txtMakhach.Text + "%'";
            if (txtTenkhach.Text != "")
                sql = sql + " AND Tenkhach Like N'%" + txtTenkhach.Text + "%'";
            if (txtDiachi.Text != "")
                sql = sql + " AND Diachi Like N'%" + txtDiachi.Text + "%'";
            if (mskSodienthoai.Text != "")
                sql = sql + " AND Sdt Like N'%" + mskSodienthoai.Text + "%'";
            tblKhach = Functions.GetDataToTable(sql);
            if (tblKhach.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblKhach.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dgridKhachhang.DataSource = tblKhach;
            resetvalues();
            btnBoqua.Enabled = true;
        }
    }
}
