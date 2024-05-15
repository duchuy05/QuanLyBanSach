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
    public partial class frmSach : Form
    {
        DataTable tblSach;
        public frmSach()
        {
            InitializeComponent();
        }

        private void frmSach_Load(object sender, EventArgs e)
        {
            Class.Functions.ketnoi();
            txtMasach.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Functions.FillCombo("SELECT Maloai, Tenloai FROM tblLoaisach", cboMaloai, "Maloai", "Tenloai");
            cboMaloai.SelectedIndex = -1;
            Functions.FillCombo("SELECT Matacgia, Tentacgia FROM tblTacgia", cboMatacgia, "Matacgia", "Tentacgia");
            cboMatacgia.SelectedIndex = -1;
            Functions.FillCombo("SELECT Manxb, Tennxb FROM tblNxb", cboManxb, "Manxb", "Tennxb");
            cboManxb.SelectedIndex = -1;
            load_datagrid();
        }

        private void load_datagrid()
        {
            string sql;
            sql = "SELECT Masach, Tensach, Soluong, Gianhap, Giaban, Maloai, Matacgia, Manxb, Anh, Sotrang  FROM tblSach";
            tblSach = Class.Functions.GetDataToTables(sql);
            datagridviewSach.DataSource = tblSach;
            datagridviewSach.Columns[0].HeaderText = "Mã sách";
            datagridviewSach.Columns[1].HeaderText = "Tên sách";
            datagridviewSach.Columns[2].HeaderText = "Số lượng";
            datagridviewSach.Columns[3].HeaderText = "Giá nhập";
            datagridviewSach.Columns[4].HeaderText = "Giá bán";
            datagridviewSach.Columns[5].HeaderText = "Mã loại";
            datagridviewSach.Columns[6].HeaderText = "Mã tác giả";
            datagridviewSach.Columns[7].HeaderText = "Mã nhà xuất bản";
            datagridviewSach.Columns[8].HeaderText = "Ảnh";
            datagridviewSach.Columns[9].HeaderText = "Số trang";
            datagridviewSach.Columns[0].Width = 80;
            datagridviewSach.Columns[1].Width = 140;
            datagridviewSach.Columns[2].Width = 80;
            datagridviewSach.Columns[3].Width = 80;
            datagridviewSach.Columns[4].Width = 80;
            datagridviewSach.Columns[5].Width = 80;
            datagridviewSach.Columns[6].Width = 80;
            datagridviewSach.Columns[7].Width = 100;
            datagridviewSach.Columns[8].Width = 80;
            datagridviewSach.Columns[9].Width = 80;
            datagridviewSach.AllowUserToAddRows = false;
            datagridviewSach.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ResetValues()
        {
            txtMasach.Text = "";
            txtTensach.Text = "";
            cboMaloai.SelectedIndex = -1;
            cboMatacgia.SelectedIndex = -1;
            cboManxb.SelectedIndex = -1;
            txtSoluong.Text = "0";
            txtGianhap.Text = "0";
            txtGiaban.Enabled = false;  
            txtSoluong.Enabled = false;
            txtGianhap.Enabled = false;
            txtSotrang.Text = "";
            txtAnh.Text = "";
            picAnh.Image = null;
        }

        private void datagridviewSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string maloai, matacgia, manxb;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMasach.Focus();
                return;
            }
            if (tblSach.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Information);
                return;
            }
            txtMasach.Text = datagridviewSach.CurrentRow.Cells["Masach"].Value.ToString();
            txtTensach.Text = datagridviewSach.CurrentRow.Cells["Tensach"].Value.ToString();
            txtSoluong.Text = datagridviewSach.CurrentRow.Cells["Soluong"].Value.ToString();
            txtGianhap.Text = datagridviewSach.CurrentRow.Cells["Gianhap"].Value.ToString();
            txtGiaban.Text = datagridviewSach.CurrentRow.Cells["Giaban"].Value.ToString();
            txtSotrang.Text = datagridviewSach.CurrentRow.Cells["Sotrang"].Value.ToString();
            maloai = datagridviewSach.CurrentRow.Cells["Maloai"].Value.ToString();
            matacgia = datagridviewSach.CurrentRow.Cells["Matacgia"].Value.ToString();
            manxb = datagridviewSach.CurrentRow.Cells["Manxb"].Value.ToString();
            txtAnh.Text = Functions.GetFieldValues("SELECT Anh FROM tblSach WHERE Masach = N'" + txtMasach.Text + "'");
            if (!string.IsNullOrWhiteSpace(txtAnh.Text))
            {
                // Load the image if the file exists
                picAnh.Image = Image.FromFile(txtAnh.Text);
            }
            else
            {
                // Clear the image if the file does not exist or the path is empty
                picAnh.Image = null;
            }
            cboMaloai.Text = Class.Functions.GetFieldValues("SELECT Tenloai FROM tblLoaisach WHERE Maloai = N'" + maloai + "'");
            cboMatacgia.Text = Class.Functions.GetFieldValues("SELECT Tentacgia FROM tblTacgia WHERE Matacgia = N'" + matacgia + "'");
            cboManxb.Text = Class.Functions.GetFieldValues("SELECT Tennxb FROM tblNxb WHERE Manxb = N'" + manxb + "'");
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
            txtMasach.Enabled = true;
            txtMasach.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMasach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sách", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Warning);
                txtMasach.Focus();
                return;
            }

            if (txtTensach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên sách", "Thông báo", MessageBoxButtons.OK,
 MessageBoxIcon.Warning);
                txtTensach.Focus();
                return;
            }

            if (cboMaloai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập loại sách", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaloai.Focus();
                return;
            }

            if (cboMatacgia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tác giả", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMatacgia.Focus();
                return;
            }

            if (cboManxb.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập nhà xuất bản", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboManxb.Focus();
                return;
            }

            if (txtSotrang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số trang", "Thông báo", MessageBoxButtons.OK,
 MessageBoxIcon.Warning);
                txtSotrang.Focus();
                return;
            }

            sql = "SELECT Masach FROM tblSach WHERE Masach=N'" + txtMasach.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMasach.Focus();
                txtMasach.Text = "";
                return;
            }

            if (txtAnh.Text.Trim().Length == 0)
            {
                txtAnh.Text = "";
            }

            sql = "INSERT INTO tblSach(Masach,Tensach,Maloai, Matacgia, Manxb, Soluong, Gianhap, Giaban, Anh, Sotrang) VALUES(N'" + txtMasach.Text.Trim() +
"',N'" + txtTensach.Text.Trim() + "',N'" + cboMaloai.SelectedValue.ToString() + "',N'" + cboMatacgia.SelectedValue.ToString()  + "',N'" + cboManxb.SelectedValue.ToString() + "','" + txtSoluong.Text.Trim() + "','" + txtGianhap.Text.Trim() + "','"  + txtGiaban.Text.Trim() + "','" + txtAnh.Text + "','" + txtSotrang.Text.Trim() + "')";
            Functions.RunSql(sql);
            load_datagrid();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMasach.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblSach.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Information);
                return;
            }
            if (txtMasach.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTensach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên sách", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTensach.Focus();
                return;
            }
            if (txtSotrang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số trang", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSotrang.Focus();
                return;
            }

            if (cboMaloai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập loại sách", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaloai.Focus();
                return;
            }

            if (cboManxb.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập nhà xuất bản", "Thông báo", MessageBoxButtons.OK,
 MessageBoxIcon.Warning);
                cboManxb.Focus();
                return;
            }

            if (cboMatacgia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tác giả", "Thông báo", MessageBoxButtons.OK,
 MessageBoxIcon.Warning);
                cboMatacgia.Focus();
                return;
            }

            sql = "UPDATE tblSach SET Tensach=N'" + txtTensach.Text.ToString() + "', Maloai = N'" + cboMaloai.SelectedValue.ToString() + "', Matacgia = N'" + cboMatacgia.SelectedValue.ToString() + "', Manxb = N'" + cboManxb.SelectedValue.ToString() + "', Sotrang = '" + txtSotrang.Text.Trim() + "',Anh = '" + txtAnh.Text +
"' WHERE Masach=N'" + txtMasach.Text + "'";
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
            txtMasach.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblSach.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Information);
                return;
            }
            if (txtMasach.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo",
MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblSach WHERE Masach=N'" + txtMasach.Text + "'";
                Functions.RunSqlDel(sql);
                load_datagrid();
                ResetValues();
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            txtMasach.Enabled = true;
            string sql;
            if ((txtMasach.Text == "") && (txtTensach.Text == "") && (cboMaloai.Text =="") && (cboManxb.Text =="") && (cboMatacgia.Text == "") && (txtSotrang.Text == "") && (txtGiaban.Text == "") && (txtGianhap.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblSach WHERE 1=1";
            if (txtMasach.Text != "")
                sql = sql + " AND Masach Like N'%" + txtMasach.Text + "%'";
            if (txtTensach.Text != "")
                sql = sql + " AND Tensach Like N'%" + txtTensach.Text + "%'";
            if (cboMaloai.Text != "")
                sql = sql + " AND Maloai Like N'%" + cboMaloai.SelectedValue + "%'";
            if (cboManxb.Text != "")
                sql = sql + " AND Manxb Like N'%" + cboManxb.SelectedValue + "%'";
            if (cboMatacgia.Text != "")
                sql = sql + " AND Matacgia Like N'%" + cboMatacgia.SelectedValue + "%'";
            if (txtSotrang.Text != "")
                sql = sql + " AND Sotrang Like N'%" + txtSotrang.Text + "%'";
            if (txtGiaban.Text != "")
                sql = sql + " AND Giaban Like N'%" + txtGiaban.Text + "%'";
            if (txtGianhap.Text != "")
                sql = sql + " AND Gianhap Like N'%" + txtGianhap.Text + "%'";
            tblSach = Functions.GetDataToTable(sql);
            if (tblSach.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblSach.Rows.Count + " bản ghi thỏa mãn điều kiện!!!",
"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            datagridviewSach.DataSource = tblSach;
            ResetValues();

        }

        private void btnOpen_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "bitmap(*.bmp)|*.bmp|Gif(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.InitialDirectory = "D:\\";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chon hinh anh de hien thi";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
                txtAnh.Text = dlgOpen.FileName;
            }
        }

        private void datagridviewSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
