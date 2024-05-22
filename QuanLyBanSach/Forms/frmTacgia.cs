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
    public partial class frmTacgia : Form
    {
        DataTable tblTacgia;
        public frmTacgia()
        {
            InitializeComponent();
        }

        private void frmTacgia_Load(object sender, EventArgs e)
        {
            Class.Functions.ketnoi();
            txtMatacgia.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            load_datagrid();
        }

        private void load_datagrid()
        {
            string sql;
            sql = "SELECT Matacgia, Tentacgia FROM tblTacgia";
            tblTacgia = Class.Functions.GetDataToTables(sql);
            datagridviewTacgia.DataSource = tblTacgia;
            datagridviewTacgia.Columns[0].HeaderText = "Mã tác giả";
            datagridviewTacgia.Columns[1].HeaderText = "Tên tác giả";
            datagridviewTacgia.Columns[0].Width = 30;
            datagridviewTacgia.Columns[1].Width = 250;
            datagridviewTacgia.AllowUserToAddRows = false;
            datagridviewTacgia.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ResetValues()
        {
            txtMatacgia.Text = "";
            txtTentacgia.Text = "";
        }

        private void datagridviewTacgia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTentacgia.Focus();
                return;
            }
            if (tblTacgia.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Information);
                return;
            }
            txtTentacgia.Text = datagridviewTacgia.CurrentRow.Cells["Tentacgia"].Value.ToString();
            txtMatacgia.Text = datagridviewTacgia.CurrentRow.Cells["Matacgia"].Value.ToString();

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
            if (txtTentacgia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên tác giả", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Warning);
                txtTentacgia.Focus();
                return;
            }

            sql = "SELECT Tentacgia FROM tblTacgia WHERE Tentacgia=N'" + txtTentacgia.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Tác giả này đã có", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTentacgia.Focus();
                txtTentacgia.Text = "";
                return;
            }

            sql = "INSERT INTO tblTacgia(Tentacgia) VALUES(N'" + txtTentacgia.Text.Trim() + "')";
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
            if (txtTentacgia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên tác giả", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Warning);
                txtTentacgia.Focus();
                return;
            }

            sql = "SELECT Tentacgia FROM tblTacgia WHERE Tentacgia=N'" + txtTentacgia.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Tác giả này đã có", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTentacgia.Focus();
                txtTentacgia.Text = "";
                return;
            }

            sql = "UPDATE tblTacgia SET Tentacgia=N'" + txtTentacgia.Text.ToString() + "' WHERE Matacgia='" + txtMatacgia.Text.ToString() + "'";
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
            if (tblTacgia.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Information);
                return;
            }
            if (txtTentacgia.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo",
MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblTacgia WHERE Matacgia=N'" + txtMatacgia.Text + "'";
                Functions.RunSqlDel(sql);
                load_datagrid();
                ResetValues();
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            txtMatacgia.Enabled = true;
            string sql;
            if ((txtMatacgia.Text == "") && (txtTentacgia.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblTacgia WHERE 1=1";
            if (txtMatacgia.Text != "")
                sql = sql + " AND Matacgia Like N'%" + txtMatacgia.Text + "%'";
            if (txtTentacgia.Text != "")
                sql = sql + " AND Tentacgia Like N'%" + txtTentacgia.Text + "%'";
            

            tblTacgia = Functions.GetDataToTable(sql);
            if (tblTacgia.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblTacgia.Rows.Count + " bản ghi thỏa mãn điều kiện!!!",
"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            datagridviewTacgia.DataSource = tblTacgia;
            ResetValues();
        }

        private void txtMatacgia_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
