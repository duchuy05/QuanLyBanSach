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
    public partial class frmHoadonnhap : Form
    {
        DataTable tblHDNhap;
        public frmHoadonnhap()
        {
            InitializeComponent();
        }

        private void frmHoadonnhap_Load(object sender, EventArgs e)
        {
            Class.Functions.ketnoi();
            txtSohoadonnhap.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Functions.FillCombo("SELECT Mancc, Tenncc FROM tblNcc", cboMancc, "Mancc", "Tenncc");
            cboMancc.SelectedIndex = -1;
            Functions.FillCombo("SELECT Masach, Tensach FROM tblSach", cboMasach, "Masach", "Tensach");
            cboMasach.SelectedIndex = -1;
            Functions.FillCombo("SELECT Manv, Tennv FROM tblNhanvien", cboManhanvien, "Manv", "Tennv");
            cboMasach.SelectedIndex = -1;
            load_datagrid();
        }
        private void load_datagrid()
        {
            string sql;
            sql = "SELECT tblHoadonnhap.Sohdn, Manv, Ngaynhap, Mancc, Tongtien, Masach, Soluongnhap, Gianhap, Khuyenmai, Thanhtien  FROM tblHoadonnhap join tblChitiethdn on tblHoadonnhap.Sohdn = tblChitiethdn.Sohdn";
            tblHDNhap = Class.Functions.GetDataToTables(sql);
            datagridviewBan.DataSource = tblHDNhap;
            datagridviewBan.Columns[0].HeaderText = "Số hóa đơn nhập";
            datagridviewBan.Columns[1].HeaderText = "Mã nhân viên";
            datagridviewBan.Columns[2].HeaderText = "Ngày nhập";
            datagridviewBan.Columns[3].HeaderText = "Mã nhà cung cấp";
            datagridviewBan.Columns[4].HeaderText = "Tổng tiền";
            datagridviewBan.Columns[5].HeaderText = "Mã sách";
            datagridviewBan.Columns[6].HeaderText = "Số lượng nhập";
            datagridviewBan.Columns[7].HeaderText = "Giá nhập";
            datagridviewBan.Columns[8].HeaderText = "Khuyến mãi";
            datagridviewBan.Columns[9].HeaderText = "Thành tiền";
            datagridviewBan.Columns[0].Width = 80;
            datagridviewBan.Columns[1].Width = 140;
            datagridviewBan.Columns[2].Width = 80;
            datagridviewBan.Columns[3].Width = 80;
            datagridviewBan.Columns[4].Width = 80;
            datagridviewBan.Columns[5].Width = 80;
            datagridviewBan.Columns[6].Width = 80;
            datagridviewBan.Columns[7].Width = 100;
            datagridviewBan.Columns[8].Width = 80;
            datagridviewBan.Columns[9].Width = 80;
            datagridviewBan.AllowUserToAddRows = false;
            datagridviewBan.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void cboMancc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboManhanvien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
