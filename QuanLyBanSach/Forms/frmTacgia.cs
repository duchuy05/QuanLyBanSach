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

        private void txtMatacgia_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
