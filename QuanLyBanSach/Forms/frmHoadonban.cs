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
    public partial class frmHoadonban : Form
    {
        DataTable tblCTHDB;
        public frmHoadonban()
        {
            InitializeComponent();
        }

        private void frmHoadonban_Load(object sender, EventArgs e)
        {
            Class.Functions.ketnoi();
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            txtMaHDBan.ReadOnly = true;
            txtDonGiaBan.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            txtGiamGia.Text = "0";
            txtThanhTien.Text = "0";
            Functions.FillCombo("SELECT Makh, Tenkhach FROM tblKhach", cboMaKhach, "Makh", "Tenkhach");
            cboMaKhach.SelectedIndex = -1;
            Functions.FillCombo("SELECT Manv, Tennv FROM tblNhanvien", cboMaNhanVien, "Manv", "Tennv");
            cboMaNhanVien.SelectedIndex = -1;
            Functions.FillCombo("SELECT Masach, Tensach FROM tblSach", cboMasach, "Masach", "Tensach");
            cboMasach.SelectedIndex = -1;
            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
            if (txtMaHDBan.Text != "")
            {
                LoadInfoHoaDon();
                btnXoa.Enabled = true;
            }
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT a.Masach, b.Tensach, a.Soluongxuat, b.Giaban, a.Khuyenmai,a.Thanhtien FROM tblChitiethdx AS a, tblSach AS b WHERE a.Sohdx = N'" + txtMaHDBan.Text + "' AND a.Masach=b.Masach";
            tblCTHDB = Functions.GetDataToTable(sql);
            dgvHDBanHang.DataSource = tblCTHDB;
            dgvHDBanHang.Columns[0].HeaderText = "Mã sách";
            dgvHDBanHang.Columns[1].HeaderText = "Tên sách";
            dgvHDBanHang.Columns[2].HeaderText = "Số lượng";
            dgvHDBanHang.Columns[3].HeaderText = "Đơn giá";
            dgvHDBanHang.Columns[4].HeaderText = "Giảm giá %";
            dgvHDBanHang.Columns[5].HeaderText = "Thành tiền";
            dgvHDBanHang.Columns[0].Width = 80;
            dgvHDBanHang.Columns[1].Width = 130;
            dgvHDBanHang.Columns[2].Width = 80;
            dgvHDBanHang.Columns[3].Width = 90;
            dgvHDBanHang.Columns[4].Width = 90;
            dgvHDBanHang.Columns[5].Width = 90;
            dgvHDBanHang.AllowUserToAddRows = false;
            dgvHDBanHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void LoadInfoHoaDon()
        {
            string str;
            str = "SELECT Ngayban FROM tblHoadonxuat WHERE Sohdx = N'" + txtMaHDBan.Text + "'";
            txtNgayBan.Text = Functions.GetFieldValues(str);
            str = "SELECT Manv FROM tblHoadonxuat WHERE Sohdx = N'" + txtMaHDBan.Text + "'";
            cboMaNhanVien.Text = Functions.GetFieldValues(str);
            str = "SELECT Makh FROM tblHoadonxuat WHERE Sohdx = N'" + txtMaHDBan.Text + "'";
            cboMaKhach.Text = Functions.GetFieldValues(str);
            str = "SELECT Tongtien FROM tblHoadonxuat WHERE Sohdx = N'" + txtMaHDBan.Text + "'";
            txtThanhTien.Text = Functions.GetFieldValues(str);

        }

        private void datagridviewBan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboMasach_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void txtSohoadonban_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void cboMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel9_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi số lượng thì thực hiện tính lại thành tiền
            double tt, sl, dg, gg;
            if (txtSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoluong.Text);
            if (txtGiamGia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamGia.Text);
            if (txtDonGiaBan.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGiaBan.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhTien.Text = tt.ToString();
        }

        private void cboMasach_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string str;
            if (cboMasach.Text == "")
            {
                txtDonGiaBan.Text = "";
            }
            // Khi chọn mã hàng thì các thông tin về hàng hiện ra
            str = "SELECT Giaban FROM tblSach WHERE Masach =N'" + cboMasach.SelectedValue + "'";
            txtDonGiaBan.Text = Functions.GetFieldValues(str);
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi giảm giá thì tính lại thành tiền
            double tt, sl, dg, gg;
            if (txtSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoluong.Text);
            if (txtGiamGia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamGia.Text);
            if (txtDonGiaBan.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGiaBan.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhTien.Text = tt.ToString();
        }

        private void txtThanhTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboMaKhach_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaHDBan.Text = Functions.CreateKey("HDB");
            LoadDataGridView();
        }
        private void ResetValues()
        {
            txtMaHDBan.Text = "";
            txtNgayBan.Text = "";
            cboMaNhanVien.Text = "";
            cboMaKhach.Text = "";
            txtThanhTien.Text = "0";
            cboMasach.Text = "";
            txtSoluong.Text = "";
            txtGiamGia.Text = "0";
            txtThanhTien.Text = "0";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;
            sql = "SELECT Sohdx FROM tblHoadonxuat WHERE Sohdx=N'" + txtMaHDBan.Text + "'";
            if (!Functions.CheckKey(sql))
            {
                if (txtNgayBan.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNgayBan.Focus();
                    return;
                }
                if (cboMaNhanVien.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaNhanVien.Focus();
                    return;
                }
                if (cboMaKhach.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaKhach.Focus();
                    return;
                }
                sql = "INSERT INTO tblHoadonxuat(Sohdx, Ngayban, Manv, Makh, Tongtien) VALUES (N'" + txtMaHDBan.Text.Trim() + "','" +
                        txtNgayBan.Text.Trim() + "',N'" + cboMaNhanVien.SelectedValue + "',N'" +
                        cboMaKhach.SelectedValue + "'," + txtThanhTien.Text + ")";
                Functions.RunSql(sql);
            }
            // Lưu thông tin của các mặt hàng
            if (cboMasach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMasach.Focus();
                return;
            }
            if ((txtSoluong.Text.Trim().Length == 0) || (txtSoluong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
            }
            if (txtGiamGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiamGia.Focus();
                return;
            }
            sql = "SELECT Masach FROM tblChitiethdx WHERE Masach=N'" + cboMasach.SelectedValue + "' AND Sohdx = N'" + txtMaHDBan.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValuesHang();
                cboMasach.Focus();
                return;
            }
            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
            sl = Convert.ToDouble(Functions.GetFieldValues("SELECT Soluong FROM tblSach WHERE Masach = N'" + cboMasach.SelectedValue + "'"));
            if (Convert.ToDouble(txtSoluong.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
            }
            sql = "INSERT INTO tblChitiethdx(Sohdx,Masach,Soluongxuat,Khuyenmai,Thanhtien) VALUES(N'" + txtMaHDBan.Text.Trim() + "',N'" + cboMasach.SelectedValue + "'," + txtSoluong.Text + "," + txtGiamGia.Text + "," + txtThanhTien.Text + ")";
            Functions.RunSql(sql);
            LoadDataGridView();
            // Cập nhật lại số lượng của mặt hàng vào bảng tblHang
            SLcon = sl - Convert.ToDouble(txtSoluong.Text);
            sql = "UPDATE tblSach SET Soluong =" + SLcon + " WHERE Masach= N'" + cboMasach.SelectedValue + "'";
            Functions.RunSql(sql);
            // Cập nhật lại tổng tiền cho hóa đơn bán
            tong = Convert.ToDouble(Functions.GetFieldValues("SELECT Tongtien FROM tblHoadonxuat WHERE Sohdx = N'" + txtMaHDBan.Text + "'"));
            Tongmoi = tong + Convert.ToDouble(txtThanhTien.Text);
            sql = "UPDATE tblHoadonxuat SET Tongtien =" + Tongmoi + " WHERE Sohdx = N'" + txtMaHDBan.Text + "'";
            Functions.RunSql(sql);
            txtThanhTien.Text = Tongmoi.ToString();
            ResetValuesHang();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
        }
        private void ResetValuesHang()
        {
            cboMasach.Text = "";
            txtSoluong.Text = "";
            txtGiamGia.Text = "0";
            txtThanhTien.Text = "0";
        }

        private void frmHoadonban_DoubleClick(object sender, EventArgs e)
        {
            string MaHangxoa, sql;
            Double ThanhTienxoa, SoLuongxoa, sl, slcon, tong, tongmoi;
            if (tblCTHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                MaHangxoa = dgvHDBanHang.CurrentRow.Cells["Masach"].Value.ToString();
                SoLuongxoa = Convert.ToDouble(dgvHDBanHang.CurrentRow.Cells["Soluongxuat"].Value.ToString());
                ThanhTienxoa = Convert.ToDouble(dgvHDBanHang.CurrentRow.Cells["Thanhtien"].Value.ToString());
                sql = "DELETE tblChitiethdx WHERE Sohdx=N'" + txtMaHDBan.Text + "' AND Masach = N'" + MaHangxoa + "'";
                Functions.RunSql(sql);
                // Cập nhật lại số lượng cho các mặt hàng
                sl = Convert.ToDouble(Functions.GetFieldValues("SELECT Soluong FROM tblSach WHERE Masach = N'" + MaHangxoa + "'"));
                slcon = sl + SoLuongxoa;
                sql = "UPDATE tblSach SET Soluong =" + slcon + " WHERE Masach= N'" + MaHangxoa + "'";
                Functions.RunSql(sql);
                // Cập nhật lại tổng tiền cho hóa đơn bán
                tong = Convert.ToDouble(Functions.GetFieldValues("SELECT Tongtien FROM tblHoadonxuat WHERE Sohdx = N'" + txtMaHDBan.Text + "'"));
                tongmoi = tong - ThanhTienxoa;
                sql = "UPDATE tblHoadonxuat SET Tongtien =" + tongmoi + " WHERE Sohdx = N'" + txtMaHDBan.Text + "'";
                Functions.RunSql(sql);
                txtThanhTien.Text = tongmoi.ToString();
                LoadDataGridView();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            double sl, slcon, slxoa;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "SELECT Masach,Soluong FROM tblChitiethdx WHERE Sohdx = N'" + txtMaHDBan.Text + "'";
                DataTable tblHang = Functions.GetDataToTable(sql);
                for (int hang = 0; hang <= tblHang.Rows.Count - 1; hang++)
                {
                    // Cập nhật lại số lượng cho các mặt hàng
                    sl = Convert.ToDouble(Functions.GetFieldValues("SELECT Soluong FROM tblSach WHERE Masach = N'" + tblHang.Rows[hang][0].ToString() + "'"));
                    slxoa = Convert.ToDouble(tblHang.Rows[hang][1].ToString());
                    slcon = sl + slxoa;
                    sql = "UPDATE tblSach SET Soluong =" + slcon + " WHERE Masach= N'" + tblHang.Rows[hang][0].ToString() + "'";
                    Functions.RunSql(sql);
                }

                //Xóa chi tiết hóa đơn
                sql = "DELETE tblChitienhdx WHERE Sohdx=N'" + txtMaHDBan.Text + "'";
                Functions.RunSqlDel(sql);

                //Xóa hóa đơn
                sql = "DELETE tblHoadonxuat WHERE Sohdx=N'" + txtMaHDBan.Text + "'";
                Functions.RunSqlDel(sql);
                ResetValues();
                LoadDataGridView();
                btnXoa.Enabled = false;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cboMaHDBan.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaHDBan.Focus();
                return;
            }
            txtMaHDBan.Text = cboMaHDBan.Text;
            LoadInfoHoaDon();
            LoadDataGridView();
            btnXoa.Enabled = true;
            btnLuu.Enabled = true;
            cboMaHDBan.SelectedIndex = -1;
        }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void cboMaHDBan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboMaHDBan_DropDown(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT Sohdx FROM tblHoadonxuat", cboMaHDBan, "Sohdx", "Sohdx");
            cboMaHDBan.SelectedIndex = -1;
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else    e.Handled = true;
        }
    }
}
