namespace QuanLyBanSach.Forms
{
    partial class frmBaocaonhaphang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnXuat = new Guna.UI2.WinForms.Guna2Button();
            this.btnTimkiem = new Guna.UI2.WinForms.Guna2Button();
            this.grbBaocaonhaphang = new Guna.UI2.WinForms.Guna2GroupBox();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtChonNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtDenNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtTuNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.rdoTheongay = new System.Windows.Forms.RadioButton();
            this.rdoTheokhoang = new System.Windows.Forms.RadioButton();
            this.cboTenNv = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboTenNcc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dgridBaocaonhap = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dgridTongslnhap = new Guna.UI2.WinForms.Guna2DataGridView();
            this.txtSohdn = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTensach = new Guna.UI2.WinForms.Guna2TextBox();
            this.grbBaocaonhaphang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridBaocaonhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgridTongslnhap)).BeginInit();
            this.SuspendLayout();
            // 
            // btnXuat
            // 
            this.btnXuat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXuat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXuat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXuat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXuat.FillColor = System.Drawing.Color.Navy;
            this.btnXuat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXuat.ForeColor = System.Drawing.Color.White;
            this.btnXuat.Location = new System.Drawing.Point(1937, 392);
            this.btnXuat.Margin = new System.Windows.Forms.Padding(6);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(250, 73);
            this.btnXuat.TabIndex = 7;
            this.btnXuat.Text = "Xuất Excel";
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTimkiem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTimkiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTimkiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTimkiem.FillColor = System.Drawing.Color.Navy;
            this.btnTimkiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTimkiem.ForeColor = System.Drawing.Color.White;
            this.btnTimkiem.Location = new System.Drawing.Point(1937, 273);
            this.btnTimkiem.Margin = new System.Windows.Forms.Padding(6);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(250, 80);
            this.btnTimkiem.TabIndex = 6;
            this.btnTimkiem.Text = "Tìm kiếm";
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // grbBaocaonhaphang
            // 
            this.grbBaocaonhaphang.Controls.Add(this.txtTensach);
            this.grbBaocaonhaphang.Controls.Add(this.txtSohdn);
            this.grbBaocaonhaphang.Controls.Add(this.guna2HtmlLabel6);
            this.grbBaocaonhaphang.Controls.Add(this.guna2HtmlLabel5);
            this.grbBaocaonhaphang.Controls.Add(this.dtChonNgay);
            this.grbBaocaonhaphang.Controls.Add(this.dtDenNgay);
            this.grbBaocaonhaphang.Controls.Add(this.dtTuNgay);
            this.grbBaocaonhaphang.Controls.Add(this.rdoTheongay);
            this.grbBaocaonhaphang.Controls.Add(this.rdoTheokhoang);
            this.grbBaocaonhaphang.Controls.Add(this.cboTenNv);
            this.grbBaocaonhaphang.Controls.Add(this.cboTenNcc);
            this.grbBaocaonhaphang.Controls.Add(this.guna2HtmlLabel4);
            this.grbBaocaonhaphang.Controls.Add(this.guna2HtmlLabel3);
            this.grbBaocaonhaphang.Controls.Add(this.guna2HtmlLabel2);
            this.grbBaocaonhaphang.Controls.Add(this.guna2HtmlLabel1);
            this.grbBaocaonhaphang.CustomBorderColor = System.Drawing.Color.Navy;
            this.grbBaocaonhaphang.CustomBorderThickness = new System.Windows.Forms.Padding(0, 50, 0, 0);
            this.grbBaocaonhaphang.FillColor = System.Drawing.Color.LightSteelBlue;
            this.grbBaocaonhaphang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grbBaocaonhaphang.ForeColor = System.Drawing.Color.White;
            this.grbBaocaonhaphang.Location = new System.Drawing.Point(81, 187);
            this.grbBaocaonhaphang.Margin = new System.Windows.Forms.Padding(6);
            this.grbBaocaonhaphang.Name = "grbBaocaonhaphang";
            this.grbBaocaonhaphang.Size = new System.Drawing.Size(1825, 516);
            this.grbBaocaonhaphang.TabIndex = 5;
            this.grbBaocaonhaphang.Text = "Báo cáo nhập hàng";
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(1307, 144);
            this.guna2HtmlLabel6.Margin = new System.Windows.Forms.Padding(6);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(48, 27);
            this.guna2HtmlLabel6.TabIndex = 14;
            this.guna2HtmlLabel6.Text = "Đến:";
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(780, 144);
            this.guna2HtmlLabel5.Margin = new System.Windows.Forms.Padding(6);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(34, 27);
            this.guna2HtmlLabel5.TabIndex = 13;
            this.guna2HtmlLabel5.Text = "Từ:";
            // 
            // dtChonNgay
            // 
            this.dtChonNgay.Checked = true;
            this.dtChonNgay.FillColor = System.Drawing.Color.Navy;
            this.dtChonNgay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtChonNgay.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtChonNgay.Location = new System.Drawing.Point(874, 232);
            this.dtChonNgay.Margin = new System.Windows.Forms.Padding(6);
            this.dtChonNgay.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtChonNgay.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtChonNgay.Name = "dtChonNgay";
            this.dtChonNgay.Size = new System.Drawing.Size(335, 63);
            this.dtChonNgay.TabIndex = 12;
            this.dtChonNgay.Value = new System.DateTime(2024, 5, 21, 10, 20, 11, 758);
            // 
            // dtDenNgay
            // 
            this.dtDenNgay.Checked = true;
            this.dtDenNgay.FillColor = System.Drawing.Color.Navy;
            this.dtDenNgay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtDenNgay.Location = new System.Drawing.Point(1415, 118);
            this.dtDenNgay.Margin = new System.Windows.Forms.Padding(6);
            this.dtDenNgay.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtDenNgay.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtDenNgay.Name = "dtDenNgay";
            this.dtDenNgay.Size = new System.Drawing.Size(335, 70);
            this.dtDenNgay.TabIndex = 11;
            this.dtDenNgay.Value = new System.DateTime(2024, 5, 21, 10, 20, 11, 758);
            this.dtDenNgay.ValueChanged += new System.EventHandler(this.dtDenNgay_ValueChanged);
            // 
            // dtTuNgay
            // 
            this.dtTuNgay.Checked = true;
            this.dtTuNgay.FillColor = System.Drawing.Color.Navy;
            this.dtTuNgay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtTuNgay.Location = new System.Drawing.Point(874, 120);
            this.dtTuNgay.Margin = new System.Windows.Forms.Padding(6);
            this.dtTuNgay.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtTuNgay.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtTuNgay.Name = "dtTuNgay";
            this.dtTuNgay.Size = new System.Drawing.Size(335, 68);
            this.dtTuNgay.TabIndex = 10;
            this.dtTuNgay.Value = new System.DateTime(2024, 5, 21, 10, 20, 11, 758);
            this.dtTuNgay.ValueChanged += new System.EventHandler(this.dtTuNgay_ValueChanged);
            // 
            // rdoTheongay
            // 
            this.rdoTheongay.AutoSize = true;
            this.rdoTheongay.BackColor = System.Drawing.Color.LightSteelBlue;
            this.rdoTheongay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoTheongay.ForeColor = System.Drawing.Color.Black;
            this.rdoTheongay.Location = new System.Drawing.Point(571, 259);
            this.rdoTheongay.Margin = new System.Windows.Forms.Padding(6);
            this.rdoTheongay.Name = "rdoTheongay";
            this.rdoTheongay.Size = new System.Drawing.Size(132, 29);
            this.rdoTheongay.TabIndex = 9;
            this.rdoTheongay.TabStop = true;
            this.rdoTheongay.Text = "Theo ngày:";
            this.rdoTheongay.UseVisualStyleBackColor = false;
            this.rdoTheongay.CheckedChanged += new System.EventHandler(this.rdoTheongay_CheckedChanged);
            // 
            // rdoTheokhoang
            // 
            this.rdoTheokhoang.AutoSize = true;
            this.rdoTheokhoang.BackColor = System.Drawing.Color.LightSteelBlue;
            this.rdoTheokhoang.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoTheokhoang.ForeColor = System.Drawing.Color.Black;
            this.rdoTheokhoang.Location = new System.Drawing.Point(571, 144);
            this.rdoTheokhoang.Margin = new System.Windows.Forms.Padding(6);
            this.rdoTheokhoang.Name = "rdoTheokhoang";
            this.rdoTheokhoang.Size = new System.Drawing.Size(154, 29);
            this.rdoTheokhoang.TabIndex = 8;
            this.rdoTheokhoang.TabStop = true;
            this.rdoTheokhoang.Text = "Theo khoảng:";
            this.rdoTheokhoang.UseVisualStyleBackColor = false;
            this.rdoTheokhoang.CheckedChanged += new System.EventHandler(this.rdoTheokhoang_CheckedChanged);
            // 
            // cboTenNv
            // 
            this.cboTenNv.BackColor = System.Drawing.Color.Transparent;
            this.cboTenNv.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTenNv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTenNv.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTenNv.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTenNv.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTenNv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboTenNv.ItemHeight = 30;
            this.cboTenNv.Location = new System.Drawing.Point(227, 338);
            this.cboTenNv.Margin = new System.Windows.Forms.Padding(6);
            this.cboTenNv.Name = "cboTenNv";
            this.cboTenNv.Size = new System.Drawing.Size(276, 36);
            this.cboTenNv.TabIndex = 7;
            // 
            // cboTenNcc
            // 
            this.cboTenNcc.BackColor = System.Drawing.Color.Transparent;
            this.cboTenNcc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTenNcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTenNcc.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTenNcc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTenNcc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTenNcc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboTenNcc.ItemHeight = 30;
            this.cboTenNcc.Location = new System.Drawing.Point(227, 266);
            this.cboTenNcc.Margin = new System.Windows.Forms.Padding(6);
            this.cboTenNcc.Name = "cboTenNcc";
            this.cboTenNcc.Size = new System.Drawing.Size(276, 36);
            this.cboTenNcc.TabIndex = 6;
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(63, 340);
            this.guna2HtmlLabel4.Margin = new System.Windows.Forms.Padding(6);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(129, 27);
            this.guna2HtmlLabel4.TabIndex = 3;
            this.guna2HtmlLabel4.Text = "Tên nhân viên:";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(63, 268);
            this.guna2HtmlLabel3.Margin = new System.Windows.Forms.Padding(6);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(81, 27);
            this.guna2HtmlLabel3.TabIndex = 2;
            this.guna2HtmlLabel3.Text = "Tên NCC:";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(63, 197);
            this.guna2HtmlLabel2.Margin = new System.Windows.Forms.Padding(6);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(83, 27);
            this.guna2HtmlLabel2.TabIndex = 1;
            this.guna2HtmlLabel2.Text = "Tên sách:";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(63, 127);
            this.guna2HtmlLabel1.Margin = new System.Windows.Forms.Padding(6);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(152, 27);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "Số hóa đơn nhập:";
            // 
            // dgridBaocaonhap
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgridBaocaonhap.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgridBaocaonhap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgridBaocaonhap.ColumnHeadersHeight = 4;
            this.dgridBaocaonhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgridBaocaonhap.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgridBaocaonhap.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgridBaocaonhap.Location = new System.Drawing.Point(3, 729);
            this.dgridBaocaonhap.Margin = new System.Windows.Forms.Padding(6);
            this.dgridBaocaonhap.Name = "dgridBaocaonhap";
            this.dgridBaocaonhap.RowHeadersVisible = false;
            this.dgridBaocaonhap.RowHeadersWidth = 82;
            this.dgridBaocaonhap.Size = new System.Drawing.Size(1456, 468);
            this.dgridBaocaonhap.TabIndex = 9;
            this.dgridBaocaonhap.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgridBaocaonhap.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgridBaocaonhap.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgridBaocaonhap.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgridBaocaonhap.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgridBaocaonhap.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgridBaocaonhap.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgridBaocaonhap.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgridBaocaonhap.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgridBaocaonhap.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgridBaocaonhap.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgridBaocaonhap.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgridBaocaonhap.ThemeStyle.HeaderStyle.Height = 4;
            this.dgridBaocaonhap.ThemeStyle.ReadOnly = false;
            this.dgridBaocaonhap.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgridBaocaonhap.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgridBaocaonhap.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgridBaocaonhap.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgridBaocaonhap.ThemeStyle.RowsStyle.Height = 22;
            this.dgridBaocaonhap.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgridBaocaonhap.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // dgridTongslnhap
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgridTongslnhap.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgridTongslnhap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgridTongslnhap.ColumnHeadersHeight = 4;
            this.dgridTongslnhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgridTongslnhap.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgridTongslnhap.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgridTongslnhap.Location = new System.Drawing.Point(1471, 729);
            this.dgridTongslnhap.Margin = new System.Windows.Forms.Padding(6);
            this.dgridTongslnhap.Name = "dgridTongslnhap";
            this.dgridTongslnhap.RowHeadersVisible = false;
            this.dgridTongslnhap.RowHeadersWidth = 82;
            this.dgridTongslnhap.Size = new System.Drawing.Size(702, 468);
            this.dgridTongslnhap.TabIndex = 10;
            this.dgridTongslnhap.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgridTongslnhap.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgridTongslnhap.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgridTongslnhap.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgridTongslnhap.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgridTongslnhap.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgridTongslnhap.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgridTongslnhap.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgridTongslnhap.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgridTongslnhap.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgridTongslnhap.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgridTongslnhap.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgridTongslnhap.ThemeStyle.HeaderStyle.Height = 4;
            this.dgridTongslnhap.ThemeStyle.ReadOnly = false;
            this.dgridTongslnhap.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgridTongslnhap.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgridTongslnhap.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgridTongslnhap.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgridTongslnhap.ThemeStyle.RowsStyle.Height = 22;
            this.dgridTongslnhap.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgridTongslnhap.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // txtSohdn
            // 
            this.txtSohdn.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSohdn.DefaultText = "";
            this.txtSohdn.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSohdn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSohdn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSohdn.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSohdn.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSohdn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSohdn.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSohdn.Location = new System.Drawing.Point(225, 115);
            this.txtSohdn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSohdn.Name = "txtSohdn";
            this.txtSohdn.PasswordChar = '\0';
            this.txtSohdn.PlaceholderText = "";
            this.txtSohdn.SelectedText = "";
            this.txtSohdn.Size = new System.Drawing.Size(278, 51);
            this.txtSohdn.TabIndex = 15;
            // 
            // txtTensach
            // 
            this.txtTensach.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTensach.DefaultText = "";
            this.txtTensach.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTensach.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTensach.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTensach.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTensach.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTensach.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTensach.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTensach.Location = new System.Drawing.Point(227, 187);
            this.txtTensach.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTensach.Name = "txtTensach";
            this.txtTensach.PasswordChar = '\0';
            this.txtTensach.PlaceholderText = "";
            this.txtTensach.SelectedText = "";
            this.txtTensach.Size = new System.Drawing.Size(276, 51);
            this.txtTensach.TabIndex = 16;
            // 
            // frmBaocaonhaphang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2188, 1224);
            this.Controls.Add(this.dgridTongslnhap);
            this.Controls.Add(this.dgridBaocaonhap);
            this.Controls.Add(this.btnXuat);
            this.Controls.Add(this.btnTimkiem);
            this.Controls.Add(this.grbBaocaonhaphang);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBaocaonhaphang";
            this.Text = "frmBaocaonhaphang";
            this.Load += new System.EventHandler(this.frmBaocaonhaphang_Load);
            this.grbBaocaonhaphang.ResumeLayout(false);
            this.grbBaocaonhaphang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridBaocaonhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgridTongslnhap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnXuat;
        private Guna.UI2.WinForms.Guna2Button btnTimkiem;
        private Guna.UI2.WinForms.Guna2GroupBox grbBaocaonhaphang;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtChonNgay;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtDenNgay;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtTuNgay;
        private System.Windows.Forms.RadioButton rdoTheongay;
        private System.Windows.Forms.RadioButton rdoTheokhoang;
        private Guna.UI2.WinForms.Guna2ComboBox cboTenNv;
        private Guna.UI2.WinForms.Guna2ComboBox cboTenNcc;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgridBaocaonhap;
        private Guna.UI2.WinForms.Guna2DataGridView dgridTongslnhap;
        private Guna.UI2.WinForms.Guna2TextBox txtTensach;
        private Guna.UI2.WinForms.Guna2TextBox txtSohdn;
    }
}