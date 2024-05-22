using QuanLyBanSach.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace QuanLyBanSach.Forms
{
    public partial class frmHoadonnhap : Form
    {
        DataTable tblCTHDN;
        public frmHoadonnhap()
        {
            InitializeComponent();
        }

        private void frmHoadonnhap_Load(object sender, EventArgs e)
        {
            Class.Functions.ketnoi();
            txtSohoadonnhap.ReadOnly = true;
            txtThanhtien.ReadOnly = true;
            txtTongtien.ReadOnly = true;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            txtKhuyenmai.Text = "0";
            txtGianhap.Text = "0";
            txtTongtien.Text = "0";
            Functions.FillCombo("SELECT Mancc, Tenncc FROM tblNcc", cboMancc, "Mancc", "Tenncc");
            cboMancc.SelectedIndex = -1;
            Functions.FillCombo("SELECT Masach, Tensach FROM tblSach", cboMasach, "Masach", "Tensach");
            cboMasach.SelectedIndex = -1;
            Functions.FillCombo("SELECT Manv, Tennv FROM tblNhanvien", cboManv, "Manv", "Tennv");
            cboMasach.SelectedIndex = -1;
            Functions.FillCombo("SELECT Sohdn FROM tblChitiethdn", cboSohdn,
           "Sohdn", "Sohdn");
            cboSohdn.SelectedIndex = -1;

            if (txtSohoadonnhap.Text != "")
            {
                LoadInfoHoaDon();
                btnXoa.Enabled = true;
            }
            load_datagrid();
        }
        private void load_datagrid()
        {
            string sql;
            sql = "SELECT a.Masach, b.Tensach, a.Soluongnhap, a.Gianhap, a.Khuyenmai, a.Thanhtien  FROM tblChitiethdn AS a, tblSach AS b WHERE a.Sohdn = N'" +txtSohoadonnhap.Text + "' AND a.Masach=b.Masach";

            tblCTHDN = Class.Functions.GetDataToTables(sql);
            datagridviewNhap.DataSource = tblCTHDN;
            datagridviewNhap.Columns[0].HeaderText = "Mã sách";
            datagridviewNhap.Columns[1].HeaderText = "Tên sách";
            datagridviewNhap.Columns[2].HeaderText = "Số lượng";
            datagridviewNhap.Columns[3].HeaderText = "Giá nhập";
            datagridviewNhap.Columns[4].HeaderText = "Giảm giá %";
            datagridviewNhap.Columns[5].HeaderText = "Thành tiền";
            datagridviewNhap.Columns[0].Width = 80;
            datagridviewNhap.Columns[1].Width = 140;
            datagridviewNhap.Columns[2].Width = 80;
            datagridviewNhap.Columns[3].Width = 80;
            datagridviewNhap.Columns[4].Width = 80;
            datagridviewNhap.Columns[5].Width = 80;
            datagridviewNhap.AllowUserToAddRows = false;
            datagridviewNhap.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void LoadInfoHoaDon()
        {
            string str;
            str = "SELECT Ngaynhap FROM tblHoadonnhap WHERE Sohdn = N'" + txtSohoadonnhap.Text + "'";
            mskNgaynhap.Text = Functions.ConvertDateTime(Functions.GetFieldValues(str));
            str = "SELECT Manv FROM tblHoadonnhap WHERE Sohdn = N'" + txtSohoadonnhap.Text + "'";
            cboManv.Text = Functions.GetFieldValues(str);
            str = "SELECT Mancc FROM tblHoadonnhap WHERE Sohdn = N'" + txtSohoadonnhap.Text + "'";
            cboMancc.Text = Functions.GetFieldValues(str);
            str = "SELECT Tongtien FROM tblHoadonnhap WHERE Sohdn = N'" + txtSohoadonnhap.Text + "'";
            txtTongtien.Text = Functions.GetFieldValues(str);
            lblBangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(txtTongtien.Text);
        }
        private void ResetValues()
        {
            txtSohoadonnhap.Text = "";
            mskNgaynhap.Text = DateTime.Now.ToShortDateString();
            cboManv.Text = "";
            cboMancc.Text = "";
            txtTongtien.Text = "0";
            lblBangchu.Text = "Bằng chữ: ";
            cboMasach.Text = "";
            txtSoluong.Text = "";
            txtKhuyenmai.Text = "0";
            txtThanhtien.Text = "0";

        }

        private void txtGianhap_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi gía nhập thì tính lại thành tiền
            double tt, sl, dg, gg;
            if (txtSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoluong.Text);
            if (txtKhuyenmai.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtKhuyenmai.Text);
            if (txtGianhap.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtGianhap.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhtien.Text = tt.ToString();
        }

        private void txtSoluong_TextChanged_1(object sender, EventArgs e)
        {
            //Khi thay đổi số lượng thì thực hiện tính lại thành tiền
            double tt, sl, dg, gg;
            if (txtSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoluong.Text);
            if (txtKhuyenmai.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtKhuyenmai.Text);
            if (txtGianhap.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtGianhap.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhtien.Text = tt.ToString();
        }
        private void txtKhuyenmai_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi giảm giá thì tính lại thành tiền
            double tt, sl, dg, gg;
            if (txtSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoluong.Text);
            if (txtKhuyenmai.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtKhuyenmai.Text);
            if (txtGianhap.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtGianhap.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhtien.Text = tt.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtSohoadonnhap.Text = Functions.CreateKey("HDN");
            load_datagrid();
        }

        private void ResetValuesHang()
        {
            cboMasach.Text = "";
            txtSoluong.Text = "";
            txtKhuyenmai.Text = "0";
            txtThanhtien.Text = "0";
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLmoi, tong, Tongmoi, giablmoi;
            sql = "SELECT Sohdn FROM tblHoadonnhap WHERE Sohdn=N'" + txtSohoadonnhap.Text + "'";
            if (!Functions.CheckKey(sql))
            {
                if (mskNgaynhap.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mskNgaynhap.Focus();
                    return;
                }
                if (cboManv.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboManv.Focus();
                    return;
                }
                if (cboMancc.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMancc.Focus();
                    return;
                }
                sql = "INSERT INTO tblHoadonnhap(Sohdn, Ngaynhap, Manv, Mancc, Tongtien) VALUES (N'" + txtSohoadonnhap.Text.Trim() + "','" +
                        Functions.ConvertDateTime(mskNgaynhap.Text.Trim()) + "',N'" + cboManv.SelectedValue + "',N'" +
                        cboMancc.SelectedValue + "'," + txtTongtien.Text + ")";
                Functions.RunSql(sql);
            }
            // Lưu thông tin của các mặt hàng
            if (cboMasach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (txtKhuyenmai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtKhuyenmai.Focus();
                return;
            }
            sql = "SELECT Masach FROM tblChitiethdn WHERE Masach=N'" + cboMasach.SelectedValue + "' AND Sohdn = N'" + txtSohoadonnhap.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValuesHang();
                cboMasach.Focus();
                return;
            }
            sl = Convert.ToDouble(Functions.GetFieldValues("SELECT Soluong FROM tblSach WHERE Masach = N'" + cboMasach.SelectedValue + "'"));
            sql = "INSERT INTO tblChitiethdn(Sohdn,Masach,Soluongnhap, Gianhap, Khuyenmai,Thanhtien) VALUES(N'" + txtSohoadonnhap.Text.Trim() + "',N'" + cboMasach.SelectedValue + "'," + txtSoluong.Text + "," + txtGianhap.Text + "," + txtKhuyenmai.Text + "," + txtThanhtien.Text + ")";
            Functions.RunSql(sql);
            load_datagrid();
            double gianhap = Convert.ToDouble(txtGianhap.Text);
            // Cập nhật lại số lượng của mặt hàng vào bảng tblHang
            SLmoi = sl + Convert.ToDouble(txtSoluong.Text);
            giablmoi = gianhap * 1.1;
            sql = "UPDATE tblSach SET Soluong = " + SLmoi + ", Gianhap = " + txtGianhap.Text  + ", Giaban = " + giablmoi + " WHERE Masach = N'" + cboMasach.SelectedValue + "'";
            Functions.RunSql(sql);
            // Cập nhật lại tổng tiền cho hóa đơn nhập
            tong = Convert.ToDouble(Functions.GetFieldValues("SELECT Tongtien FROM tblHoadonnhap WHERE Sohdn = N'" + txtSohoadonnhap.Text + "'"));
            Tongmoi = tong + Convert.ToDouble(txtThanhtien.Text);
            sql = "UPDATE tblHoadonnhap SET Tongtien =" + Tongmoi + " WHERE Sohdn = N'" + txtSohoadonnhap.Text + "'";
            Functions.RunSql(sql);
            txtTongtien.Text = Tongmoi.ToString();
            lblBangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(Tongmoi.ToString());
            ResetValuesHang();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
        }

        private void cboSohdn_DropDown(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT Sohdn FROM tblHoadonnhap", cboSohdn, "Sohdn", "Sohdn");
            cboSohdn.SelectedIndex = -1;
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtKhuyenmai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void datagridviewNhap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string masach;
            Double Thanhtien;
            if (tblCTHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo",
MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                masach = datagridviewNhap.CurrentRow.Cells["Masach"].Value.ToString();
                DelHang(txtSohoadonnhap.Text, masach);
                // Cập nhật lại tổng tiền cho hóa đơn nhập
                Thanhtien = Convert.ToDouble(datagridviewNhap.CurrentRow.
Cells["Thanhtien"].Value.ToString());
                DelUpdateTongtien(txtSohoadonnhap.Text, Thanhtien);
                load_datagrid();
            }

        }
        private void DelHang(string Mahoadon, string Mahang)
        {
            Double s, sl, SLcon;
            string sql;
            sql = "SELECT Soluongnhap FROM tblChitiethdn WHERE Sohdn = N'" + Mahoadon + "' AND Masach = N'" + Mahang + "'";
            s = Convert.ToDouble(Functions.GetFieldValues(sql));
            sql = "DELETE tblChitiethdn WHERE Sohdn=N'" + Mahoadon + "' AND Masach = N'"
+ Mahang + "'";
            Functions.RunSqlDel(sql);
            // Cập nhật lại số lượng cho các mặt hàng
            sql = "SELECT Soluong FROM tblSach WHERE Masach = N'" + Mahang + "'";
            sl = Convert.ToDouble(Functions.GetFieldValues(sql));
            SLcon = sl - s;
            sql = "UPDATE tblSach SET Soluong =" + SLcon + " WHERE Masach= N'" + Mahang + "'";
            Functions.RunSql(sql);
        }

        private void DelUpdateTongtien(string Mahoadon, double Thanhtien)
        {
            Double Tong, Tongmoi;
            string sql;
            sql = "SELECT Tongtien FROM tblHoadonnhap WHERE Sohdn = N'" + Mahoadon + "'";
            Tong = Convert.ToDouble(Functions.GetFieldValues(sql));
            Tongmoi = Tong - Thanhtien;
            sql = "UPDATE tblHoadonnhap SET Tongtien =" + Tongmoi + " WHERE Sohdn = N'" +Mahoadon + "'";
            Functions.RunSql(sql);
            txtTongtien.Text = Tongmoi.ToString();
            lblBangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(Tongmoi.ToString());
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if (cboSohdn.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSohdn.Focus();
                return;
            }
            txtSohoadonnhap.Text = cboSohdn.Text;
            LoadInfoHoaDon();
            load_datagrid();
            btnXoa.Enabled = true;
            btnLuu.Enabled = true;
            cboSohdn.SelectedIndex = -1;

        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "DH Bookstore";

            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Đống Đa - Hà Nội";

            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (+84)393189119";


            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times new roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN NHẬP";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.Sohdn, a.Ngaynhap, a.Tongtien, b.Tenncc, b.Diachi, b.Sdt, c.Tennv " + " FROM tblHoadonnhap AS a, tblNcc AS b, tblNhanvien AS c WHERE a.Sohdn = N'" + txtSohoadonnhap.Text + "' AND a.Mancc = b.Mancc AND a.Manv = c.Manv";
            tblThongtinHD = Functions.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Nhà cung cấp:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblThongtinHD.Rows[0][5].ToString();
            //Lấy thông tin các mặt hàng
            sql = "SELECT b.Tensach, a.Soluongnhap, b.Gianhap, a.Khuyenmai, a.Thanhtien " + " FROM tblChitiethdn AS a , tblSach AS b WHERE a.Sohdn = N'" +txtSohoadonnhap.Text + "' AND a.Masach = b.Masach";
            tblThongtinHang = Functions.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên sách";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Giá nhập";
            exRange.Range["E11:E11"].Value = "Giảm giá";
            exRange.Range["F11:F11"].Value = "Thành tiền";
            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                    //Điền thông tin hàng từ cột thứ 2, dòng 12
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + Functions.ChuyenSoSangChu
 (tblThongtinHD.Rows[0][2].ToString());
            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][6];
            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true;

        }

        private void guna2HtmlLabel11_Click(object sender, EventArgs e)
        {

        }

        private void cboSohdn_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo",
MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string[] Mahang = new string[20];
                string sql;
                int n = 0;
                int i;
                sql = "SELECT Masach FROM tblChitiethdn WHERE Sohdn = N'" +
txtSohoadonnhap.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, Functions.conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Mahang[n] = reader.GetString(0).ToString();
                    n = n + 1;
                }
                reader.Close();
                //Xóa danh sách các mặt hàng của hóa đơn
                for (i = 0; i <= n - 1; i++)
                    DelHang(txtSohoadonnhap.Text, Mahang[i]);
                //Xóa hóa đơn
                sql = "DELETE tblHoadonnhap WHERE Sohdn=N'" + txtSohoadonnhap.Text + "'";
                Functions.RunSqlDel(sql);
                ResetValues();
                load_datagrid();
                btnXoa.Enabled = false;
                btnInHD.Enabled = false;
            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtTongtien_TextChanged(object sender, EventArgs e)
        {

        }

        private void mskNgaynhap_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
