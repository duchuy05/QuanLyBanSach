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
using System.Data;
using System.Data.SqlClient;

namespace QuanLyBanSach.Forms
{
    public partial class frmNhanvien : Form
    {
        public frmNhanvien()
        {
            InitializeComponent();
        }

        private void frmNhanvien_Load(object sender, EventArgs e)
        {
            Class.Functions.ketnoi();
            txtManv.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            LoadDataGridView();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnBoqua.Enabled = true;
            ResetValues();
            txtManv.Enabled = true;
            txtManv.Focus();
            LoadDataGridView();
        }
        private void ResetValues()
        {
            txtManv.Text = "";
            txtTennv.Text = "";
            txtDiachinv.Text = "";
            mskSdtnv.Text = "";
        }
        DataTable tblNV;
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from tblNhanvien";
            tblNV = Functions.GetDataToTable(sql); //Lấy dữ liệu từ bảng
            datagridviewNV.DataSource = tblNV; //Hiển thị vào dataGridView
            datagridviewNV.Columns[0].HeaderText = "Mã nhân viên";
            datagridviewNV.Columns[1].HeaderText = "Tên nhân viên";
            datagridviewNV.Columns[2].HeaderText = "Địa chỉ";
            datagridviewNV.Columns[3].HeaderText = "Điện thoại";
            datagridviewNV.Columns[0].Width = 100;
            datagridviewNV.Columns[1].Width = 120;
            datagridviewNV.Columns[2].Width = 120;
            datagridviewNV.Columns[3].Width = 120;
            datagridviewNV.AllowUserToAddRows = false;
            datagridviewNV.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtManv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtManv.Focus();
                return;
            }
            if (txtTennv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTennv.Focus();
                return;
            }
            if (txtDiachinv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiachinv.Focus();
                return;
            }
            if (mskSdtnv.Text == "(  )    -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskSdtnv.Focus();
                return;
            }
            sql = "SELECT Manv FROM tblNxb WHERE Manv=N'" + txtManv.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nhân viên này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtManv.Focus();
                return;
            }
            //Chèn thêm
            sql = "INSERT INTO tblNhanvien VALUES (N'" + txtManv.Text.Trim() +
                "',N'" + txtTennv.Text.Trim() + "',N'" + txtDiachinv.Text.Trim() + "','" + mskSdtnv.Text + "')";
            Functions.RunSql(sql);
            LoadDataGridView();
            ResetValues();

            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtManv.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtManv.Text == "")
            {
                MessageBox.Show("Bạn phải chọn bản ghi cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTennv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhà xuất bản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTennv.Focus();
                return;
            }
            if (txtDiachinv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiachinv.Focus();
                return;
            }
            if (mskSdtnv.Text == "(  )    -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskSdtnv.Focus();
                return;
            }
            sql = "UPDATE tblNhanvien SET Tennv=N'" + txtTennv.Text.Trim().ToString() + "',Diachi=N'" +
                txtDiachinv.Text.Trim().ToString() + "',Sdt='" + mskSdtnv.Text.ToString() +
                "' WHERE Manv=N'" + txtManv.Text + "'";
            Functions.RunSql(sql);
            LoadDataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtManv.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblNhanvien WHERE Manv=N'" + txtManv.Text + "'";
                Functions.RunSqlDel(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtManv.Enabled = false;
        }

        private void datagridviewNV_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtManv.Focus();
                return;
            }
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtManv.Text = datagridviewNV.CurrentRow.Cells["Manv"].Value.ToString();
            txtTennv.Text = datagridviewNV.CurrentRow.Cells["Tennv"].Value.ToString();
            txtDiachinv.Text = datagridviewNV.CurrentRow.Cells["Diachi"].Value.ToString();
            mskSdtnv.Text = datagridviewNV.CurrentRow.Cells["Sdt"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            txtManv.Enabled = true;
            txtManv.Focus();
            txtDiachinv.Enabled = false;
            mskSdtnv.Enabled=false;
            string sql;
            if ((txtManv.Text == "")&&(txtTennv.Text=="")&&(txtDiachinv.Text=="")) 
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from tblNhanvien WHERE 1=1";
            if (txtManv.Text != "")
                sql += " AND Manv LIKE N'%" + txtManv.Text + "%'";
            if (txtTennv.Text != "")
                sql += " AND Tennv LIKE N'%" + txtTennv.Text + "%'";
            if(txtDiachinv.Text != "")
                sql += " AND Diachi LIKE N'%" + txtDiachinv.Text + "%'";
            tblNV = Functions.GetDataToTable(sql);
            if (tblNV.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + tblNV.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            datagridviewNV.DataSource = tblNV;
            ResetValues();
            datagridviewNV.Refresh();
        }
    }
}
