using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using Guna.UI2.WinForms; // Thêm dòng này để sử dụng Guna2DateTimePicker
using System.Data.SqlClient;
using COMExcel = Microsoft.Office.Interop.Excel;


namespace QuanLyBanSach.Forms
{
    public partial class frmBaocaoban : Form
    {
        private bool isFirstLoad = true;

        public frmBaocaoban()
        {
            InitializeComponent();
        }

        private void dtTuNgay_ValueChanged(object sender, EventArgs e)
        {
            if (!isFirstLoad && dtTuNgay.Value > dtDenNgay.Value)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtTuNgay.Value = dtDenNgay.Value;
                dtTuNgay.Focus();
            }
            if (rdTheoKhoang.Checked && dtTuNgay.Value != dtDenNgay.Value)
            {
                dtChonNgay.Enabled = false;
            }
            else
            {
                dtChonNgay.Enabled = true;
            }
        }
        private void dtDenNgay_ValueChanged(object sender, EventArgs e)
        {
            if (!isFirstLoad && dtDenNgay.Value < dtTuNgay.Value)
            {
                MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtDenNgay.Value = dtTuNgay.Value;
                dtDenNgay.Focus();
            }
            if (rdTheoKhoang.Checked && dtTuNgay.Value != dtDenNgay.Value)
            {
                dtChonNgay.Enabled = false;
            }
            else
            {
                dtChonNgay.Enabled = true;
            }
        }
        private void rdTheoKhoang_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTheoKhoang.Checked)
            {
                dtChonNgay.Enabled = false;
            }
            else
            {
                dtChonNgay.Enabled = true;
            }
        }

        private void rdTheoNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTheoNgay.Checked)
            {
                dtTuNgay.Enabled = false;
                dtDenNgay.Enabled = false;
            }
            else
            {
                dtTuNgay.Enabled = true;
                dtDenNgay.Enabled = true;
            }
        }
        private void frmBaocaoban_Load(object sender, EventArgs e)
        {
            Class.Functions.ketnoi();
            dtTuNgay.Value = DateTime.Now;
            dtDenNgay.Value = DateTime.Now;
            dtChonNgay.Value = DateTime.Now;
            isFirstLoad = false; // Đánh dấu là form đã được load lần đầu tiên
            Class.Functions.FillCombo("select Sohdx from tblHoadonxuat", cboSohdx, "Sohdx", "Sohdx");
            Class.Functions.FillCombo("select Masach,Tensach from tblSach", cboTenSP, "Masach", "Tensach");
            Class.Functions.FillCombo("select Makh,Tenkhach from tblKhach", cboTenKH, "Makh", "Tenkhach");
            Class.Functions.FillCombo("select Manv,Tennv from tblNhanvien", cboTenNV, "Manv", "Tennv");
            cboSohdx.SelectedIndex = -1;
            cboTenSP.SelectedIndex = -1;
            cboTenKH.SelectedIndex = -1;
            cboTenNV.SelectedIndex = -1;
            Load_dgridBCBan();
            Load_dgridTongSPBan();
        }
        DataTable tblbcx;
        private void Load_dgridBCBan()
        {
           string sql;
           sql= @"SELECT tblHoadonxuat.Sohdx, tblChitiethdx.Masach, Tensach, Soluongxuat, Giaban, Ngayban, Thanhtien, Tenkhach, Tennv  FROM tblHoadonxuat 
                join tblChitiethdx on tblHoadonxuat.Sohdx = tblChitiethdx.Sohdx 
                join tblSach on tblChitiethdx.Masach = tblSach.Masach 
                join tblKhach on tblHoadonxuat.Makh = tblKhach.Makh 
                join tblNhanvien on tblHoadonxuat.Manv = tblNhanvien.Manv";
            tblbcx = Class.Functions.GetDataToTables(sql);
            dgridBCBan.DataSource = tblbcx;
            dgridBCBan.Columns[0].HeaderText = "Số hóa đơn xuất";
            dgridBCBan.Columns[1].HeaderText = "Mã sách";
            dgridBCBan.Columns[2].HeaderText = "Tên sách";
            dgridBCBan.Columns[3].HeaderText = "Số lượng xuất";
            dgridBCBan.Columns[4].HeaderText = "Giá bán";
            dgridBCBan.Columns[5].HeaderText = "Ngày bán";
            dgridBCBan.Columns[6].HeaderText = "Thành tiền";
            dgridBCBan.Columns[7].HeaderText = "Tên khách hàng";
            dgridBCBan.Columns[8].HeaderText = "Tên nhân viên";
            dgridBCBan.Columns[0].Width = 80;
            dgridBCBan.Columns[1].Width = 80;
            dgridBCBan.Columns[2].Width = 80;
            dgridBCBan.Columns[3].Width = 80;
            dgridBCBan.Columns[4].Width = 80;
            dgridBCBan.Columns[5].Width = 80;
            dgridBCBan.Columns[6].Width = 60;
            dgridBCBan.Columns[7].Width = 80;
            dgridBCBan.Columns[8].Width = 100;
            dgridBCBan.AllowUserToAddRows = false;
            dgridBCBan.EditMode = DataGridViewEditMode.EditProgrammatically;
           
        }
        DataTable tblTongSPBan;
        private void Load_dgridTongSPBan()
        {
            string sql1;
            sql1 = @"SELECT tblChitiethdx.Masach, Tensach, SUM(Soluongxuat) AS TongSoLuongBan 
                    FROM tblHoadonxuat 
                    JOIN tblChitiethdx ON tblHoadonxuat.Sohdx = tblChitiethdx.Sohdx 
                    JOIN tblSach ON tblChitiethdx.Masach = tblSach.Masach 
                    GROUP BY tblChitiethdx.Masach, Tensach";
            tblTongSPBan = Class.Functions.GetDataToTables(sql1);
            dgridTongSPBan.DataSource = tblTongSPBan;
            dgridTongSPBan.Columns[0].HeaderText = "Mã sách";
            dgridTongSPBan.Columns[1].HeaderText = "Tên sách";
            dgridTongSPBan.Columns[2].HeaderText = "Tổng số lượng bán";
            dgridTongSPBan.Columns[0].Width = 80;
            dgridTongSPBan.Columns[1].Width = 80;
            dgridTongSPBan.Columns[2].Width = 80;
            dgridTongSPBan.AllowUserToAddRows = false;
            dgridTongSPBan.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
 

        DataTable tblBCban;
        private void btnTim_Click(object sender, EventArgs e)
        {
            string sql, sql1;
            //if ((cboSohdx.Text == "") && (cboTenSP.Text == "") && (cboTenKH.Text =="") && (cboTenNV.Text ==""))
            //{
            //    MessageBox.Show("Hãy chọn ít nhất một tiêu chí tìm kiếm", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            if ((rdTheoKhoang.Checked == false) && (rdTheoNgay.Checked == false)) 
            {
                MessageBox.Show("Hãy chọn xem báo cáo theo ngày hoặc theo khoảng", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = @"SELECT tblHoadonxuat.Sohdx, tblChitiethdx.Masach, Tensach, Soluongxuat, Giaban, Ngayban, Thanhtien, Tenkhach, Tennv  FROM tblHoadonxuat 
                join tblChitiethdx on tblHoadonxuat.Sohdx = tblChitiethdx.Sohdx 
                join tblSach on tblChitiethdx.Masach = tblSach.Masach 
                join tblKhach on tblHoadonxuat.Makh = tblKhach.Makh 
                join tblNhanvien on tblHoadonxuat.Manv = tblNhanvien.Manv where 1=1";
            sql1 = @"SELECT tblChitiethdx.Masach, Tensach, SUM(Soluongxuat) AS TongSoLuongBan 
                    FROM tblHoadonxuat 
                    JOIN tblChitiethdx ON tblHoadonxuat.Sohdx = tblChitiethdx.Sohdx 
                    JOIN tblSach ON tblChitiethdx.Masach = tblSach.Masach 
                    GROUP BY tblChitiethdx.Masach, Tensach where 1=1";
            if (cboSohdx.Text != "")
            {
                sql = sql + " and tblHoadonxuat.Sohdx like N'%" + cboSohdx.Text +"%'";
                sql1 = sql1 + " and tblHoadonxuat.Sohdx like N'%" + cboSohdx.Text + "%'";
            }    
            if (cboTenSP.Text != "")
            {
                sql = sql + " and Tensach like N'%"+cboTenSP.Text+"%'";
                sql1 = sql1 + " and Tensach like N'%" + cboTenSP.Text + "%'";
            }
            if (cboTenKH.Text != "")
            {
                sql = sql + " and Tenkhach like N'%" + cboTenKH.Text + "%'";
                sql1 = sql1 + " and Tenkhach like N'%" + cboTenKH.Text + "%'";
            }
            if (cboTenNV.Text != "")
            {
                sql = sql + " and Tennv like N'%"+cboTenNV.Text+"%'";
                sql1 = sql1 + " and Tennv like N'%" + cboTenNV.Text + "%'";
            }
            if (rdTheoNgay.Checked)
            {
                sql = sql + " AND Ngayban = '" + dtChonNgay.Value.ToString("yyyy-MM-dd") + "'";
                sql1 = sql1 + " AND Ngayban = '" + dtChonNgay.Value.ToString("yyyy-MM-dd") + "'";
            }
            else if (rdTheoKhoang.Checked)
            {
                sql = sql + " AND Ngayban between '" + dtTuNgay.Value.ToString("yyyy-MM-dd") + "' AND '" + dtDenNgay.Value.ToString("yyyy-MM-dd") + "'";
                sql1 = sql1 + " AND Ngayban between '" + dtTuNgay.Value.ToString("yyyy-MM-dd") + "' AND '" + dtDenNgay.Value.ToString("yyyy-MM-dd") + "'";
            }
            sql1 += " GROUP BY tblChitiethdx.Masach, Tensach"; // Di chuyển GROUP BY ra ngoài điều kiện WHERE

            tblBCban = Class.Functions.GetDataToTables(sql);
            tblTongSPBan = Class.Functions.GetDataToTables(sql1);

            if (tblBCban.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
            }
            else
            {
                MessageBox.Show("Có " + tblBCban.Rows.Count + " bản ghi thỏa mãn điều kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgridBCBan.DataSource = tblBCban;
                ResetValues(); // Gọi hàm ResetValues sau khi hiển thị kết quả tìm kiếm
            }

            if (tblTongSPBan.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dgridTongSPBan.DataSource = tblTongSPBan;
            }
        }
        private void ResetValues()
        {
            // Xóa hết dữ liệu đã chọn trong các ComboBox
            cboSohdx.SelectedIndex = -1;
            cboTenSP.SelectedIndex = -1;
            cboTenKH.SelectedIndex = -1;
            cboTenNV.SelectedIndex = -1;
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblTTBC;
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
            exRange.Range["A1:B1"].Value = "DH BOOKSTORE";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Đống Đa - Hà Nội";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: 039 318 9119";
            exRange.Range["E2:G2"].Font.Size = 16;
            exRange.Range["E2:G2"].Font.Name = "Times new roman";
            exRange.Range["E2:G2"].Font.Bold = true;
            exRange.Range["E2:G2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["E2:G2"].MergeCells = true;
            exRange.Range["E2:G2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["E2:G2"].Value = "BÁO CÁO BÁN HÀNG";
            sql = @"SELECT tblHoadonxuat.Sohdx, tblChitiethdx.Masach, Tensach, Soluongxuat, Giaban, Ngayban, Thanhtien, Tenkhach, Tennv  FROM tblHoadonxuat 
                join tblChitiethdx on tblHoadonxuat.Sohdx = tblChitiethdx.Sohdx 
                join tblSach on tblChitiethdx.Masach = tblSach.Masach 
                join tblKhach on tblHoadonxuat.Makh = tblKhach.Makh 
                join tblNhanvien on tblHoadonxuat.Manv = tblNhanvien.Manv";
            tblTTBC = Class.Functions.GetDataToTables(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A5:J5"].Font.Bold = true;
            exRange.Range["A5:J5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A5:J5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A5:A5"].Value = "STT";
            exRange.Range["A5:A5"].ColumnWidth = 5;
            exRange.Range["B5:B5"].Value = "Số hóa đơn xuất";
            exRange.Range["B5:B5"].ColumnWidth = 15;
            exRange.Range["C5:C5"].Value = "Mã sách";
            exRange.Range["C5:C5"].ColumnWidth = 12;
            exRange.Range["D5:D5"].Value = "Tên sách";
            exRange.Range["D5:D5"].ColumnWidth = 12;
            exRange.Range["E5:E5"].Value = "Số lượng xuất";
            exRange.Range["E5:E5"].ColumnWidth = 15;
            exRange.Range["F5:F5"].Value = "Giá bán";
            exRange.Range["F5:F5"].ColumnWidth = 8;
            exRange.Range["G5:G5"].Value = "Ngày bán";
            exRange.Range["G5:G5"].ColumnWidth = 15;
            exRange.Range["H5:H5"].Value = "Thành tiền";
            exRange.Range["H5:H5"].ColumnWidth = 10;
            exRange.Range["I5:I5"].Value = "Tên khách";
            exRange.Range["I5:I5"].ColumnWidth = 17;
            exRange.Range["J5:J5"].Value = "Tên nhân viên";
            exRange.Range["J5:J5"].ColumnWidth = 17;
            for (hang = 0; hang <= tblTTBC.Rows.Count - 1; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 6
                exSheet.Cells[1][hang + 6] = hang + 1;
                for (cot = 0; cot <= tblTTBC.Columns.Count - 1; cot++)
                    //Điền thông tin hàng từ cột thứ 2, dòng 6
                    exSheet.Cells[cot + 2][hang + 6] = tblTTBC.Rows[hang][cot].ToString();
            }
            exApp.Visible = true;

        }

       
    }
}
