using QuanLyBanSach.Class;
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
    public partial class frmBaocaodoanhthu : Form
    {
        public frmBaocaodoanhthu()
        {
            InitializeComponent();
        }
        private bool isFirstLoad = true;
        private void frmBaocaodoanhthu_Load(object sender, EventArgs e)
        {
            string sql1 = "SELECT SUM(ctdx.Soluongxuat * s.Giaban) AS TongDoanhthu " +
                   "FROM tblChitiethdx ctdx " +
                   "JOIN tblSach s ON ctdx.Masach = s.Masach " +
                   "JOIN tblHoadonxuat hd ON ctdx.Sohdx = hd.Sohdx " +
                   "WHERE 1=1";
            Class.Functions.ketnoi();
            LoadDataGridView();
            dtpTungay.Value = DateTime.Now;
            dtpDenngay.Value = DateTime.Now;
            dtpNgay.Value = DateTime.Now;
            isFirstLoad = false; // Đánh dấu là form đã được load lần đầu tiên
            Class.Functions.FillCombo("select Tensach from tblSach", cboTensach, "Tensach", "Tensach");
            cboTensach.SelectedIndex = -1;
            txtTongtien.ReadOnly = true;
            txtTongtien.Text = Functions.GetFieldValues(sql1);
            lblBangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(txtTongtien.Text);
        }
        private void ResetValues()
        {
            cboTensach.Text = "";
            txtSoluong.Text = "";
            txtGiaban.Text = "";
            txtDoanhthu.Text = "";
            dtpNgay.Value = DateTime.Now;
            dtpTungay.Value = DateTime.Now;
            dtpDenngay.Value = DateTime.Now;
        }
        DataTable tblBCDT;
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT hd.Ngayban, s.Tensach, ctdx.Soluongxuat, s.Giaban, (ctdx.Soluongxuat * s.Giaban) AS Doanhthu FROM tblChitiethdx ctdx JOIN tblSach s ON ctdx.Masach = s.Masach JOIN tblHoadonxuat hd ON ctdx.Sohdx = hd.Sohdx;";
            tblBCDT = Functions.GetDataToTable(sql); //Lấy dữ liệu từ bảng
            datagridviewDT.DataSource = tblBCDT; //Hiển thị vào dataGridView
            datagridviewDT.Columns[0].HeaderText = "Ngày bán";
            datagridviewDT.Columns[1].HeaderText = "Tên sản phẩm";
            datagridviewDT.Columns[2].HeaderText = "Số lượng bán";
            datagridviewDT.Columns[3].HeaderText = "Đơn giá bán";
            datagridviewDT.Columns[4].HeaderText = "Doanh thu";
            datagridviewDT.Columns[0].Width = 30;
            datagridviewDT.Columns[1].Width = 60;
            datagridviewDT.Columns[2].Width = 30;
            datagridviewDT.Columns[3].Width = 50;
            datagridviewDT.Columns[4].Width = 100;
            datagridviewDT.AllowUserToAddRows = false;
            datagridviewDT.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql, sql1;

            sql = "SELECT hd.Ngayban, s.Tensach, ctdx.Soluongxuat, s.Giaban, (ctdx.Soluongxuat * s.Giaban) AS Doanhthu " +
                  "FROM tblChitiethdx ctdx " +
                  "JOIN tblSach s ON ctdx.Masach = s.Masach " +
                  "JOIN tblHoadonxuat hd ON ctdx.Sohdx = hd.Sohdx " +
                  "WHERE 1=1";
            if((rdbTheokhoang.Checked==false)&&(rdbTheongay.Checked==false))
            {
                MessageBox.Show("Hãy chọn xem báo cáo theo ngày hoặc theo khoảng","Yêu cầu",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }    

            if (cboTensach.SelectedValue != null && cboTensach.SelectedValue.ToString() != "")
            {
                sql += " AND s.Tensach LIKE N'%" + cboTensach.Text + "%'";
            }

            if (txtGiaban.Text != "")
            {
                sql += " AND s.Giaban = " + txtGiaban.Text;
            }

            if (rdbTheongay.Checked)
            {
                sql += " AND hd.Ngayban = '" + dtpNgay.Value.ToString("yyyy-MM-dd") + "'";
            }
            else if (rdbTheokhoang.Checked)
            {
                sql += " AND hd.Ngayban BETWEEN '" + dtpTungay.Value.ToString("yyyy-MM-dd") + "' AND '" + dtpDenngay.Value.ToString("yyyy-MM-dd") + "'";
            }

            if (txtSoluong.Text != "")
            {
                sql += " AND ctdx.Soluongxuat >= " + txtSoluong.Text;
            }

            if (txtDoanhthu.Text != "")
            {
                sql += " AND (ctdx.Soluongxuat * s.Giaban) >= " + txtDoanhthu.Text;
            }

            tblBCDT = Class.Functions.GetDataToTables(sql);

            if (tblBCDT.Rows.Count == 0)
            {
                MessageBox.Show("Không có kết quả phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            datagridviewDT.DataSource = tblBCDT;

            sql1 = "SELECT SUM(ctdx.Soluongxuat * s.Giaban) AS TongDoanhthu " +
                   "FROM tblChitiethdx ctdx " +
                   "JOIN tblSach s ON ctdx.Masach = s.Masach " +
                   "JOIN tblHoadonxuat hd ON ctdx.Sohdx = hd.Sohdx " +
                   "WHERE 1=1";

            if (cboTensach.SelectedValue != null && cboTensach.SelectedValue.ToString() != "")
            {
                sql1 += " AND s.Tensach = N'" + cboTensach.Text + "'";
            }

            if (txtGiaban.Text != "")
            {
                sql1 += " AND s.Giaban = " + txtGiaban.Text;
            }

            if (dtpTungay.Value != DateTimePicker.MinimumDateTime && dtpDenngay.Value != DateTimePicker.MinimumDateTime)
            {
                if (dtpTungay.Value > dtpDenngay.Value)
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                sql1 += " AND hd.Ngayban BETWEEN '" + dtpTungay.Value.ToString("yyyy-MM-dd") + "' AND '" + dtpDenngay.Value.ToString("yyyy-MM-dd") + "'";
            }

            if (txtDoanhthu.Text != "")
            {
                sql1 += " AND (ctdx.Soluongxuat * s.Giaban) >= " + txtDoanhthu.Text;
            }

            txtTongtien.Text = Functions.GetFieldValues(sql1);
            lblBangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(txtTongtien.Text);
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook;
            COMExcel.Worksheet exSheet;
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;

            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            exRange = exSheet.Cells[1, 1];

            exRange.Range["E10:F10:G10"].Font.Size = 14;
            exRange.Range["E10:F10:G10"].Font.Name = "Times new roman";
            exRange.Range["E10:F10:G10"].Font.Bold = true;
            exRange.Range["E10:F10:G10"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["E10:F10:G10"].MergeCells = true;
            exRange.Range["E10:F10:G10"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["E10:F10:G10"].Value = "Báo cáo doanh thu ";

            exRange.Range["H12:H12"].Value = "Tổng tiền:";
            exRange.Range["I12:I12"].Value = txtTongtien.Text;

            exRange.Range["A12:F12"].Font.Bold = true;
            exRange.Range["A12:F12"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A12:A12"].Value = "STT";
            exRange.Range["B12:B12"].Value = "Ngày bán";
            exRange.Range["C12:C12"].Value = "Tên sách";
            exRange.Range["D12:D12"].Value = "Số lượng bán";
            exRange.Range["E12:E12"].Value = "Giá bán";
            exRange.Range["F12:F12"].Value = "Doanh thu sách ";

            for (hang = 0; hang < tblBCDT.Rows.Count; hang++)
            {
                exSheet.Cells[1][hang + 13] = hang + 1;
                for (cot = 0; cot < tblBCDT.Columns.Count; cot++)
                {
                    exSheet.Cells[cot + 2][hang + 13] = tblBCDT.Rows[hang][cot].ToString();
                }
            }
            exApp.Visible = true;
        }

        private void dtpTungay_ValueChanged(object sender, EventArgs e)
        {
            if (!isFirstLoad && dtpTungay.Value > dtpDenngay.Value)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpTungay.Value = dtpDenngay.Value;
                dtpTungay.Focus();
            }
            if (rdbTheokhoang.Checked && dtpTungay.Value != dtpDenngay.Value)
            {
                dtpNgay.Enabled = false;
            }
            else
            {
                dtpNgay.Enabled = true;
            }
        }

        private void dtpDenngay_ValueChanged(object sender, EventArgs e)
        {
            if (!isFirstLoad && dtpDenngay.Value < dtpTungay.Value)
            {
                MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpDenngay.Value = dtpTungay.Value;
                dtpDenngay.Focus();
            }
            if (rdbTheokhoang.Checked && dtpTungay.Value != dtpDenngay.Value)
            {
                dtpNgay.Enabled = false;
            }
            else
            {
                dtpNgay.Enabled = true;
            }
        }

        private void rdbTheokhoang_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTheokhoang.Checked)
            {
                dtpNgay.Enabled = false;
            }
            else
            {
                dtpNgay.Enabled = true;
            }
        }

        private void rdbTheongay_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTheongay.Checked)
            {
                dtpTungay.Enabled = false;
                dtpDenngay.Enabled = false;
            }
            else
            {
                dtpTungay.Enabled = true;
                dtpDenngay.Enabled = true;
            }
        }
    }
}
