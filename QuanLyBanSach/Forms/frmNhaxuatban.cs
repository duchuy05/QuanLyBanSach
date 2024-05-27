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
    public partial class frmNhaxuatban : Form
    {
        DataTable tblNXB;
        public frmNhaxuatban()
        {
            InitializeComponent();
        }

        private void frmNhaxuatban_Load(object sender, EventArgs e)
        {
            Class.Functions.ketnoi();
            txtManxb.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            LoadDataGridView();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            txtManxb.Enabled = true;
            txtManxb.Focus();
            txtDiachinxb.Enabled = true;
            mskSdtnxb.Enabled = true;
            string sql;
            if ((txtManxb.Text == "") && (txtTennxb.Text == "") && (txtDiachinxb.Text == "") && (mskSdtnxb.Text == "(   )    -"))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from tblNxb WHERE 1=1";
            if (txtManxb.Text != "")
                sql += " AND Manxb LIKE N'%" + txtManxb.Text + "%'";
            if (txtTennxb.Text != "")
                sql += " AND Tennxb LIKE N'%" + txtTennxb.Text + "%'";
            if (txtDiachinxb.Text != "")
                sql += " AND Diachi LIKE N'%" + txtDiachinxb.Text + "%'";
            if (mskSdtnxb.Text != "")
                sql += " AND Sdt LIKE N'%" + mskSdtnxb.Text + "%'";
            tblNXB = Functions.GetDataToTable(sql);
            if (tblNXB.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + tblNXB.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            datagridviewNXB.DataSource = tblNXB;
            ResetValues();
            datagridviewNXB.Refresh();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnBoqua.Enabled = true;
            ResetValues();
            txtManxb.Enabled = true;
            txtManxb.Focus();
            LoadDataGridView();
        }
        private void ResetValues()
        {
            txtManxb.Text = "";
            txtTennxb.Text = "";
            txtDiachinxb.Text = "";
            mskSdtnxb.Text = "";
        }
        
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from tblNxb";
            tblNXB = Functions.GetDataToTable(sql); //Lấy dữ liệu từ bảng
            datagridviewNXB.DataSource = tblNXB; //Hiển thị vào dataGridView
            datagridviewNXB.Columns[0].HeaderText = "Mã nhà xuất bản";
            datagridviewNXB.Columns[1].HeaderText = "Tên nhà xuất bản";
            datagridviewNXB.Columns[2].HeaderText = "Địa chỉ";
            datagridviewNXB.Columns[3].HeaderText = "Điện thoại";
            datagridviewNXB.Columns[0].Width = 100;
            datagridviewNXB.Columns[1].Width = 120;
            datagridviewNXB.Columns[2].Width = 120;
            datagridviewNXB.Columns[3].Width = 120;
            datagridviewNXB.AllowUserToAddRows = false;
            datagridviewNXB.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtManxb.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhà xuất bản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtManxb.Focus();
                return;
            }
            if (txtTennxb.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhà xuất bản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTennxb.Focus();
                return;
            }
            if (txtDiachinxb.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiachinxb.Focus();
                return;
            }
            if (mskSdtnxb.Text == "(  )    -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskSdtnxb.Focus();
                return;
            }
            //Kiểm tra đã tồn tại mã khách chưa
            sql = "SELECT Manxb FROM tblNxb WHERE Manxb=N'" + txtManxb.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nhà xuất bản này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtManxb.Focus();
                return;
            }
            //Chèn thêm
            sql = "INSERT INTO tblNxb VALUES (N'" + txtManxb.Text.Trim() +
                "',N'" + txtTennxb.Text.Trim() + "',N'" + txtDiachinxb.Text.Trim() + "','" + mskSdtnxb.Text + "')";
            Functions.RunSql(sql);
            LoadDataGridView();
            ResetValues();

            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtManxb.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNXB.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtManxb.Text == "")
            {
                MessageBox.Show("Bạn phải chọn bản ghi cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTennxb.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhà xuất bản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTennxb.Focus();
                return;
            }
            if (txtDiachinxb.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiachinxb.Focus();
                return;
            }
            if (mskSdtnxb.Text == "(  )    -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskSdtnxb.Focus();
                return;
            }
            sql = "UPDATE tblNxb SET Tennxb=N'" + txtTennxb.Text.Trim().ToString() + "',Diachi=N'" +
                txtDiachinxb.Text.Trim().ToString() + "',Sdt='" + mskSdtnxb.Text.ToString() +
                "' WHERE Manxb=N'" + txtManxb.Text + "'";
            Functions.RunSql(sql);
            LoadDataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNXB.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtManxb.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblNxb WHERE Manxb=N'" + txtManxb.Text + "'";
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
            txtManxb.Enabled = false;
        }

        private void datagridviewNXB_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtManxb.Focus();
                return;
            }
            if (tblNXB.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtManxb.Text = datagridviewNXB.CurrentRow.Cells["Manxb"].Value.ToString();
            txtTennxb.Text = datagridviewNXB.CurrentRow.Cells["Tennxb"].Value.ToString();
            txtDiachinxb.Text = datagridviewNXB.CurrentRow.Cells["Diachi"].Value.ToString();
            mskSdtnxb.Text = datagridviewNXB.CurrentRow.Cells["Sdt"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }
    }
}
