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
    public partial class frmLoaisach : Form
    {
        DataTable tblLoaisach;
        public frmLoaisach()
        {
            InitializeComponent();
        }
        private void frmLoaisach_Load(object sender, EventArgs e)
        {
            Class.Functions.ketnoi();
            txtMaloai.Enabled = false;
            txtTenloai.Focus();
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
            resetvalues();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "select * FROM tblLoaisach";
            tblLoaisach = Class.Functions.GetDataToTable(sql);
            dgridLoaisach.DataSource = tblLoaisach;
            dgridLoaisach.Columns[0].HeaderText = "Mã loại sách";
            dgridLoaisach.Columns[1].HeaderText = "Tên loại sách";
            dgridLoaisach.Columns[0].Width = 30;
            dgridLoaisach.Columns[1].Width = 100;
            dgridLoaisach.AllowUserToAddRows = false;
            dgridLoaisach.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void resetvalues()
        {
            txtMaloai.Text = "";
            txtTenloai.Text = "";
        }

        private void dgridLoaisach_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaloai.Focus();
                return;
            }
            if (tblLoaisach.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaloai.Text = dgridLoaisach.CurrentRow.Cells["maloai"].Value.ToString();
            txtTenloai.Text = dgridLoaisach.CurrentRow.Cells["tenloai"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            resetvalues();
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnSua.Enabled = false;
            txtMaloai.Enabled = true;
            txtMaloai.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaloai.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã loại sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaloai.Focus();
                return;
            }
            if (txtTenloai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên loại sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenloai.Focus();
                return;
            }
            string sql;
            sql = "SELECT Maloai FROM tblLoaisach WHERE Maloai=N'" + txtMaloai.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã loại sách này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaloai.Focus();
                txtMaloai.Text = "";
                return;
            }
            //Insert vào CSDL
            sql = "insert into tblLoaisach(maloai, tenloai) values(N'" + txtMaloai.Text.Trim() + "',N'" + txtTenloai.Text.Trim() + "')";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            resetvalues();
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaloai.Enabled = false;
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtMaloai.Enabled = false;
            btnLuu.Enabled = false;
            resetvalues();
            Load_DataGridView();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaloai.Text == "")
            {
                MessageBox.Show("Chưa chọn bản ghi nào", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dgridLoaisach.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để sửa", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenloai.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên loại sách", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenloai.Focus();
                return;
            }
            string sql;
            sql = "update tblLoaisach set tenloai=N'" + txtTenloai.Text.Trim() + "' where maloai = N'" + txtMaloai.Text.Trim() + "' ";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            resetvalues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaloai.Text == "")
            {
                MessageBox.Show("Chưa chọn bản ghi nào", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dgridLoaisach.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xóa", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string sql;
                sql = "delete tblLoaisach where maloai = N'" + txtMaloai.Text.Trim() + "' ";
                Class.Functions.RunSql(sql);
                Load_DataGridView();
                resetvalues();
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            txtMaloai.Enabled = true;
            string sql;
            if ((txtTenloai.Text == "") && (txtMaloai.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblLoaisach WHERE 1=1";
            if (txtTenloai.Text != "")
                sql = sql + " AND Tenloai Like N'%" + txtTenloai.Text + "%'";
            if (txtMaloai.Text != "")
                sql = sql + " AND Maloai Like N'%" + txtMaloai.Text + "%'";
            tblLoaisach = Class.Functions.GetDataToTables(sql);
            if (tblLoaisach.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblLoaisach.Rows.Count + " bản ghi thỏa mãn điều kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            dgridLoaisach.DataSource = tblLoaisach;
            resetvalues();
            btnBoqua.Enabled = true;
        }
    }
}
