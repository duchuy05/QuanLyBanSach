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
    public partial class frmBaocaonhaphang : Form
    {
        DataTable tblBcn;
        DataTable tblTongSPNhap;
        private bool isFirstLoad = true;
        public frmBaocaonhaphang()
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
            if (rdoTheokhoang.Checked && dtTuNgay.Value != dtDenNgay.Value)
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
            if (rdoTheokhoang.Checked && dtTuNgay.Value != dtDenNgay.Value)
            {
                dtChonNgay.Enabled = false;
            }
            else
            {
                dtChonNgay.Enabled = true;
            }
        }

        private void rdoTheokhoang_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTheokhoang.Checked)
            {
                dtChonNgay.Enabled = false;
            }
            else
            {
                dtChonNgay.Enabled = true;
            }
        }

        private void rdoTheongay_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTheongay.Checked)
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

        private void frmBaocaonhaphang_Load(object sender, EventArgs e)
        {
            Class.Functions.ketnoi();
            dtTuNgay.Value = DateTime.Now;
            dtDenNgay.Value = DateTime.Now;
            dtChonNgay.Value = DateTime.Now;
            isFirstLoad = false; // Đánh dấu là form đã được load lần đầu tiên
            Class.Functions.FillCombo("select Mancc,Tenncc from tblNcc", cboTenNcc, "Mancc", "Tenncc");
            Class.Functions.FillCombo("select Manv,Tennv from tblNhanvien", cboTenNv, "Manv", "Tennv");
            txtSohdn.Text = "";
            txtTensach.Text = "";
            cboTenNcc.SelectedIndex = -1;
            cboTenNv.SelectedIndex = -1;

            string sql = @"SELECT tblHoadonnhap.Sohdn, tblChitiethdn.Masach, Tensach, Soluongnhap, tblChitiethdn.Gianhap, Ngaynhap, Thanhtien, Tenncc, Tennv FROM tblHoadonnhap
                join tblChitiethdn on tblHoadonnhap.Sohdn = tblChitiethdn.Sohdn
                join tblSach on tblChitiethdn.Masach = tblSach.Masach
                join tblNcc on tblHoadonnhap.Mancc = tblNcc.Mancc
                join tblNhanvien on tblHoadonnhap.Manv = tblNhanvien.Manv";

            Load_DataGridViewBCNhap(sql);


            string sql1 = @"SELECT tblChitiethdn.Masach,tblSach.Tensach,SUM(tblChitiethdn.Soluongnhap) AS TongSoLuongNhap FROM tblHoadonnhap
                JOIN tblChitiethdn ON tblHoadonnhap.Sohdn = tblChitiethdn.Sohdn
                JOIN tblSach ON tblChitiethdn.Masach = tblSach.Masach
                GROUP BY tblChitiethdn.Masach, tblSach.Tensach";

            Load_DataGridViewTongSPNhap(sql1);
        }
        private void Load_DataGridViewBCNhap(string sql)
        {
            tblBcn = Class.Functions.GetDataToTables(sql);
            dgridBaocaonhap.DataSource = tblBcn;
            dgridBaocaonhap.Columns[0].HeaderText = "Số hóa đơn nhập";
            dgridBaocaonhap.Columns[1].HeaderText = "Mã sách";
            dgridBaocaonhap.Columns[2].HeaderText = "Tên sách";
            dgridBaocaonhap.Columns[3].HeaderText = "Số lượng nhập";
            dgridBaocaonhap.Columns[4].HeaderText = "Giá nhập";
            dgridBaocaonhap.Columns[5].HeaderText = "Ngày nhập";
            dgridBaocaonhap.Columns[6].HeaderText = "Thành tiền";
            dgridBaocaonhap.Columns[7].HeaderText = "Tên nhà cung cấp";
            dgridBaocaonhap.Columns[8].HeaderText = "Tên nhân viên";
            dgridBaocaonhap.Columns[0].Width = 80;
            dgridBaocaonhap.Columns[1].Width = 80;
            dgridBaocaonhap.Columns[2].Width = 80;
            dgridBaocaonhap.Columns[3].Width = 80;
            dgridBaocaonhap.Columns[4].Width = 80;
            dgridBaocaonhap.Columns[5].Width = 80;
            dgridBaocaonhap.Columns[6].Width = 60;
            dgridBaocaonhap.Columns[7].Width = 80;
            dgridBaocaonhap.Columns[8].Width = 100;
            dgridBaocaonhap.AllowUserToAddRows = false;
            dgridBaocaonhap.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void Load_DataGridViewTongSPNhap(string sql)
        {
            tblTongSPNhap = Class.Functions.GetDataToTables(sql);
            dgridTongslnhap.DataSource = tblTongSPNhap;
            dgridTongslnhap.Columns[0].HeaderText = "Mã sách";
            dgridTongslnhap.Columns[1].HeaderText = "Tên sách";
            dgridTongslnhap.Columns[2].HeaderText = "Tổng số lượng nhập";
            dgridTongslnhap.Columns[0].Width = 80;
            dgridTongslnhap.Columns[1].Width = 80;
            dgridTongslnhap.Columns[2].Width = 100;
            dgridTongslnhap.AllowUserToAddRows = false;
            dgridTongslnhap.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        DataTable tblBCN;
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql, sql1;
            //if ((cboSohdx.Text == "") && (cboTenSP.Text == "") && (cboTenKH.Text =="") && (cboTenNV.Text ==""))
            //{
            //    MessageBox.Show("Hãy chọn ít nhất một tiêu chí tìm kiếm", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            if ((rdoTheokhoang.Checked == false) && (rdoTheongay.Checked == false))
            {
                MessageBox.Show("Hãy chọn xem báo cáo theo ngày hoặc theo khoảng", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = @"SELECT tblHoadonnhap.Sohdn, tblChitiethdn.Masach, Tensach, Soluongnhap, tblChitiethdn.Gianhap, Ngaynhap, Thanhtien, Tenncc, Tennv FROM tblHoadonnhap
                join tblChitiethdn on tblHoadonnhap.Sohdn = tblChitiethdn.Sohdn
                join tblSach on tblChitiethdn.Masach = tblSach.Masach
                join tblNcc on tblHoadonnhap.Mancc = tblNcc.Mancc
                join tblNhanvien on tblHoadonnhap.Manv = tblNhanvien.Manv where 1=1";
            if (txtSohdn.Text != "")
            {
                sql = sql + " and tblHoadonnhap.Sohdn like N'%" + txtSohdn.Text + "%'";
            }
            if (txtTensach.Text != "")
            {
                sql = sql + " and Tensach like N'%" + txtTensach.Text + "%'";
            }
            if (cboTenNcc.Text != "")
            {
                sql = sql + " and TenNcc like N'%" + cboTenNcc.Text + "%'";
            }
            if (cboTenNv.Text != "")
            {
                sql = sql + " and TenNv like N'%" + cboTenNv.Text + "%'";
            }
            if (rdoTheongay.Checked)
            {
                sql = sql + " AND Ngaynhap = '" + dtChonNgay.Value.ToString("yyyy-MM-dd") + "'";
            }
            else if (rdoTheokhoang.Checked)
            {
                sql = sql + " AND Ngaynhap between '" + dtTuNgay.Value.ToString("yyyy-MM-dd") + "' AND '" + dtDenNgay.Value.ToString("yyyy-MM-dd") + "'";
            }
            sql1 = @"SELECT tblChitiethdn.Masach, tblSach.Tensach, SUM(tblChitiethdn.Soluongnhap) AS TongSoLuongNhap
                    FROM tblHoadonnhap
                    JOIN tblChitiethdn ON tblHoadonnhap.Sohdn = tblChitiethdn.Sohdn
                    JOIN tblSach ON tblChitiethdn.Masach = tblSach.Masach
                    JOIN tblNcc ON tblHoadonnhap.Mancc = tblNcc.Mancc
                    JOIN tblNhanvien ON tblHoadonnhap.Manv = tblNhanvien.Manv
                    WHERE 1 = 1";
            if (txtSohdn.Text != "")
            {
                sql1 = sql1 + " and tblHoadonnhap.Sohdn like N'%" + txtSohdn.Text + "%'";
            }
            if (txtTensach.Text != "")
            {
                sql1 = sql1 + " and Tensach like N'%" + txtTensach.Text + "%'";
            }
            if (cboTenNcc.Text != "")
            {
                sql1 = sql1 + " and Tenncc like N'%" + cboTenNcc.Text + "%'";
            }
            if (cboTenNv.Text != "")
            {
                sql1 = sql1 + " and Tennv like N'%" + cboTenNv.Text + "%'";
            }
            if (rdoTheongay.Checked)
            {
                sql1 = sql1 + " AND Ngaynhap = '" + dtChonNgay.Value.ToString("yyyy-MM-dd") + "'";
            }
            else if (rdoTheokhoang.Checked)
            {
                sql1 = sql1 + " AND Ngaynhap between '" + dtTuNgay.Value.ToString("yyyy-MM-dd") + "' AND '" + dtDenNgay.Value.ToString("yyyy-MM-dd") + "'";
            }
            string mainQuery = sql1 + "GROUP BY tblChitiethdn.Masach, tblSach.Tensach order by SUM(tblChitiethdn.Soluongnhap) desc";
            Load_DataGridViewTongSPNhap(mainQuery);
            Load_DataGridViewBCNhap(sql);
            tblBCN = Class.Functions.GetDataToTables(sql);
            tblTongSPNhap = Class.Functions.GetDataToTables(mainQuery);
            if (rdoTheongay.Checked || rdoTheokhoang.Checked)
            {
                if (tblBCN.Rows.Count == 0 || tblTongSPNhap.Rows.Count == 0)
                {
                    MessageBox.Show("Không có bản ghi thỏa mãn điều kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ResetValues();
                }
                else
                {
                    MessageBox.Show("Có " + tblBCN.Rows.Count + " bản ghi thỏa mãn điều kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgridBaocaonhap.DataSource = tblBCN;
                    ResetValues(); // Gọi hàm ResetValues sau khi hiển thị kết quả tìm kiếm
                }
            }
        }
        private void ResetValues()
        {
            // Xóa hết dữ liệu đã chọn trong các ComboBox
            txtSohdn.Text = "";
            txtTensach.Text = "";
            cboTenNcc.SelectedIndex = -1;
            cboTenNv.SelectedIndex = -1;
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;

            int hang = 0, cot = 0;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung cho báo cáo bán hàng
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
            exRange.Range["E2:G2"].Value = "BÁO CÁO NHẬP HÀNG";

            //Tạo dòng tiêu đề bảng
            exRange.Range["A5:J5"].Font.Bold = true;
            exRange.Range["A5:J5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A5:J5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A5:A5"].Value = "STT";
            exRange.Range["A5:A5"].ColumnWidth = 5;
            exRange.Range["B5:B5"].Value = "Số hóa đơn nhập";
            exRange.Range["B5:B5"].ColumnWidth = 15;
            exRange.Range["C5:C5"].Value = "Mã sách";
            exRange.Range["C5:C5"].ColumnWidth = 12;
            exRange.Range["D5:D5"].Value = "Tên sách";
            exRange.Range["D5:D5"].ColumnWidth = 12;
            exRange.Range["E5:E5"].Value = "Số lượng nhập";
            exRange.Range["E5:E5"].ColumnWidth = 15;
            exRange.Range["F5:F5"].Value = "Giá nhập";
            exRange.Range["F5:F5"].ColumnWidth = 8;
            exRange.Range["G5:G5"].Value = "Ngày nhập";
            exRange.Range["G5:G5"].ColumnWidth = 15;
            exRange.Range["H5:H5"].Value = "Thành tiền";
            exRange.Range["H5:H5"].ColumnWidth = 10;
            exRange.Range["I5:I5"].Value = "Tên nhà cung cấp";
            exRange.Range["I5:I5"].ColumnWidth = 17;
            exRange.Range["J5:J5"].Value = "Tên nhân viên";
            exRange.Range["J5:J5"].ColumnWidth = 17;
            for (hang = 0; hang <= tblBcn.Rows.Count - 1; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 6
                exSheet.Cells[1][hang + 6] = hang + 1;
                for (cot = 0; cot <= tblBcn.Columns.Count - 1; cot++)
                    //Điền thông tin hàng từ cột thứ 2, dòng 6
                    exSheet.Cells[cot + 2][hang + 6] = tblBcn.Rows[hang][cot].ToString();
            }

            // Định dạng chung cho tổng số lượng bán được của mỗi sản phẩm
            exRange.Range["L2:P2"].Font.Size = 13;
            exRange.Range["L2:P2"].Font.Name = "Times new roman";
            exRange.Range["L2:P2"].Font.Bold = true;
            exRange.Range["L2:P2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["L2:P2"].MergeCells = true;
            exRange.Range["L2:P2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["L2:P2"].Value = "TỐNG SỐ LƯỢNG NHẬP VÀO THEO MỖI MÃ SÁCH";
            //Tạo dòng tiêu đề bảng
            exRange.Range["M5:O5"].Font.Bold = true;
            exRange.Range["M5:O5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["M5:O5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["M5:M5"].Value = "Mã sách";
            exRange.Range["M5:M5"].ColumnWidth = 10;
            exRange.Range["N5:N5"].Value = "Tên sách";
            exRange.Range["N5:N5"].ColumnWidth = 15;
            exRange.Range["O5:O5"].Value = "Tổng số lượng nhập";
            exRange.Range["O5:O5"].ColumnWidth = 17;
            for (hang = 0; hang <= tblTongSPNhap.Rows.Count - 1; hang++)
            {
                for (cot = 0; cot <= tblTongSPNhap.Columns.Count - 1; cot++)
                    //Điền thông tin hàng từ cột thứ 13, dòng 6
                    exSheet.Cells[cot + 13][hang + 6] = tblTongSPNhap.Rows[hang][cot].ToString();
            }
            exApp.Visible = true;
        }
    }
}
