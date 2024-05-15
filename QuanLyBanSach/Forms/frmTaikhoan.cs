using QuanLyBanSach.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace QuanLyBanSach.Forms
{
    public partial class frmTaikhoan : Form
    {
        DataTable tblTaikhoan;
        public frmTaikhoan()
        {
            InitializeComponent();
        }

        private void frmTaikhoan_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            Class.Functions.ketnoi();
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Functions.FillCombo("SELECT Manv, Tennv FROM tblNhanvien", cboManv, "Manv", "Tennv");
            cboManv.SelectedIndex = -1;
            load_datagrid();
        }

        private void load_datagrid()
        {
            string sql;
            sql = "SELECT id, tentaikhoan, matkhau, manv  FROM tblTaikhoan";
            tblTaikhoan = Class.Functions.GetDataToTables(sql);
            datagridviewTaikhoan.DataSource = tblTaikhoan;
            datagridviewTaikhoan.Columns[0].HeaderText = "ID";
            datagridviewTaikhoan.Columns[1].HeaderText = "Tên tài khoản";
            datagridviewTaikhoan.Columns[2].HeaderText = "Mật khẩu";
            datagridviewTaikhoan.Columns[3].HeaderText = "Mã Nhân viên";
            datagridviewTaikhoan.Columns[0].Width = 80;
            datagridviewTaikhoan.Columns[1].Width = 80;
            datagridviewTaikhoan.Columns[2].Width = 80;
            datagridviewTaikhoan.Columns[3].Width = 120;
            datagridviewTaikhoan.AllowUserToAddRows = false;
            datagridviewTaikhoan.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ResetValues()
        {
            txtId.Text = "";
            txtTaikhoan.Text = "";
            txtMatkhau.Text = "";
            cboManv.SelectedIndex = -1;
            
        }

        private void datagridviewTaikhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string manv;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTaikhoan.Focus();
                return;
            }
            if (tblTaikhoan.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Information);
                return;
            }
            txtTaikhoan.Text = datagridviewTaikhoan.CurrentRow.Cells["Tentaikhoan"].Value.ToString();
            txtId.Text = datagridviewTaikhoan.CurrentRow.Cells["id"].Value.ToString();
            txtMatkhau.Text = datagridviewTaikhoan.CurrentRow.Cells["Matkhau"].Value.ToString();
            manv = datagridviewTaikhoan.CurrentRow.Cells["Manv"].Value.ToString();
        
            //txtAnh.Text = Functions.GetFieldValues("SELECT Anh FROM tblSach WHERE Masach = N'" + txtMasach.Text + "'");
            //picAnh.Image = Image.FromFile(txtAnh.Text);
            cboManv.Text = Class.Functions.GetFieldValues("SELECT Tennv FROM tblNhanvien WHERE Manv = N'" + manv + "'");
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtTaikhoan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên tài khoản", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Warning);
                txtTaikhoan.Focus();
                return;
            }

            if (txtMatkhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu", "Thông báo", MessageBoxButtons.OK,
 MessageBoxIcon.Warning);
                txtMatkhau.Focus();
                return;
            }

            if (cboManv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn nhân viên", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboManv.Focus();
                return;
            }

            sql = "SELECT tentaikhoan FROM tblTaikhoan WHERE tentaikhoan=N'" + txtTaikhoan.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Tài khoản này đã có, bạn phải nhập tài khoản khác", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaikhoan.Focus();
                txtTaikhoan.Text = "";
                return;
            }

            sql = "INSERT INTO tblTaikhoan(tentaikhoan,matkhau, manv) VALUES('" + txtTaikhoan.Text.Trim() + "','" + txtMatkhau.Text.Trim() + "',N'" + cboManv.SelectedValue.ToString() +"')";
            Functions.RunSql(sql);
            load_datagrid();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtTaikhoan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên tài khoản", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Warning);
                txtTaikhoan.Focus();
                return;
            }

            if (txtMatkhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu", "Thông báo", MessageBoxButtons.OK,
 MessageBoxIcon.Warning);
                txtMatkhau.Focus();
                return;
            }

            if (cboManv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn nhân viên", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboManv.Focus();
                return;
            }

            sql = "SELECT tentaikhoan FROM tblTaikhoan WHERE tentaikhoan=N'" + txtTaikhoan.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Tài khoản này đã có, bạn phải nhập tài khoản khác", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaikhoan.Focus();
                txtTaikhoan.Text = "";
                return;
            }

            sql = "UPDATE tblTaikhoan SET tentaikhoan='" + txtTaikhoan.Text.ToString() + "', Manv = N'" + cboManv.SelectedValue.ToString() + "', Matkhau = '" + txtMatkhau.Text.ToString() +"' WHERE id='" + txtId.Text.ToString() + "'";
            Class.Functions.RunSql(sql);
            load_datagrid();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblTaikhoan.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Information);
                return;
            }
            if (txtTaikhoan.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo",
MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblTaikhoan WHERE id=N'" + txtId.Text + "'";
                Functions.RunSqlDel(sql);
                load_datagrid();
                ResetValues();
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            txtId.Enabled = true;
            string sql;
            if ((txtId.Text == "") && (txtTaikhoan.Text == "") && (txtMatkhau.Text == "") && (cboManv.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblTaikhoan WHERE 1=1";
            if (txtId.Text != "")
                sql = sql + " AND id Like N'%" + txtId.Text + "%'";
            if (txtTaikhoan.Text != "")
                sql = sql + " AND tentaikhoan Like N'%" + txtTaikhoan.Text + "%'";
            if (txtMatkhau.Text != "")
                sql = sql + " AND matkhau Like N'%" + txtMatkhau.Text + "%'";
            if (cboManv.Text != "")
                sql = sql + " AND manv Like N'%" + cboManv.SelectedValue + "%'";
            
            tblTaikhoan = Functions.GetDataToTable(sql);
            if (tblTaikhoan.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblTaikhoan.Rows.Count + " bản ghi thỏa mãn điều kiện!!!",
"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            datagridviewTaikhoan.DataSource = tblTaikhoan;
            ResetValues();
        }
    }
}
