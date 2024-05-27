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
    public partial class frmNhacungcap : Form
    {
        DataTable tblNcc;
        public frmNhacungcap()
        {
            InitializeComponent();
        }

        private void frmNhacungcap_Load(object sender, EventArgs e)
        {
            Class.Functions.ketnoi();
            txtMancc.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from tblNcc";
            tblNcc = Functions.GetDataToTable(sql); //Lấy dữ liệu từ bảng
            datagridviewNcc.DataSource = tblNcc; //Hiển thị vào dataGridView
            datagridviewNcc.Columns[0].HeaderText = "Mã nhà cung cấp";
            datagridviewNcc.Columns[1].HeaderText = "Tên nhà cung cấp";
            datagridviewNcc.Columns[2].HeaderText = "Địa chỉ";
            datagridviewNcc.Columns[3].HeaderText = "Điện thoại";
            datagridviewNcc.Columns[0].Width = 100;
            datagridviewNcc.Columns[1].Width = 120;
            datagridviewNcc.Columns[2].Width = 120;
            datagridviewNcc.Columns[3].Width = 120;
            datagridviewNcc.AllowUserToAddRows = false;
            datagridviewNcc.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetValues()
        {
            txtMancc.Text = "";
            txtTenncc.Text = "";
            txtDiachi.Text = "";
            mskSdt.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnBoqua.Enabled = true;
            txtMancc.Enabled = true;
            txtMancc.Focus();
            ResetValues();
            LoadDataGridView();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMancc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMancc.Focus();
                return;
            }
            if (txtTenncc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenncc.Focus();
                return;
            }
            if (txtDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiachi.Focus();
                return;
            }
            if (mskSdt.Text == "(  )    -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskSdt.Focus();
                return;
            }
            sql = "SELECT Mancc FROM tblNcc WHERE Mancc=N'" + txtMancc.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nhà cung cấp này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMancc.Focus();
                return;
            }
            //Chèn thêm
            sql = "INSERT INTO tblNcc (Mancc, Tenncc, Diachi, Sdt) VALUES (N'" + txtMancc.Text.Trim() +
                "',N'" + txtTenncc.Text.Trim() + "',N'" + txtDiachi.Text.Trim() + "','" + mskSdt.Text.Trim() + "')";
            Functions.RunSql(sql);
            LoadDataGridView();
            ResetValues();

            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMancc.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNcc.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMancc.Text == "")
            {
                MessageBox.Show("Bạn phải chọn bản ghi cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenncc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenncc.Focus();
                return;
            }
            if (txtDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiachi.Focus();
                return;
            }
            if (mskSdt.Text == "(  )    -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskSdt.Focus();
                return;
            }
            sql = "UPDATE tblNcc SET Tenncc=N'" + txtTenncc.Text.Trim().ToString() + "',Diachi=N'" +
                txtDiachi.Text.Trim().ToString() + "',Sdt='" + mskSdt.Text.Trim().ToString() +
                "' WHERE Mancc=N'" + txtMancc.Text.Trim() + "'";
            Functions.RunSql(sql);
            LoadDataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void datagridviewNcc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMancc.Focus();
                return;
            }
            if (tblNcc.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMancc.Text = datagridviewNcc.CurrentRow.Cells["Mancc"].Value.ToString();
            txtTenncc.Text = datagridviewNcc.CurrentRow.Cells["Tenncc"].Value.ToString();
            txtDiachi.Text = datagridviewNcc.CurrentRow.Cells["Diachi"].Value.ToString();
            mskSdt.Text = datagridviewNcc.CurrentRow.Cells["Sdt"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNcc.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMancc.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblNcc WHERE Mancc=N'" + txtMancc.Text.Trim() + "'";
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
            txtMancc.Enabled = false;
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            txtMancc.Enabled = true;
            txtMancc.Focus();
            txtDiachi.Enabled = false;
            mskSdt.Enabled = false;
            string sql;
            if ((txtMancc.Text == "") && (txtTenncc.Text == ""))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from tblNcc WHERE 1=1";
            if (txtMancc.Text != "")
                sql += " AND Mancc LIKE N'%" + txtMancc.Text + "%'";
            if (txtTenncc.Text != "")
                sql += " AND Tenncc LIKE N'%" + txtTenncc.Text + "%'";
            tblNcc = Functions.GetDataToTable(sql);
            if (tblNcc.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + tblNcc.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            datagridviewNcc.DataSource = tblNcc;
            ResetValues();
            datagridviewNcc.Refresh();
        }
    }
}
