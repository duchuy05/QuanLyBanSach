namespace QuanLyBanSach.Forms
{
    partial class frmDangnhap
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
            this.btnDangnhap = new Guna.UI2.WinForms.Guna2Button();
            this.txtTaikhoan = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMatkhau = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTaikhoan = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblMatkhau = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SuspendLayout();
            // 
            // btnDangnhap
            // 
            this.btnDangnhap.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDangnhap.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDangnhap.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDangnhap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDangnhap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDangnhap.ForeColor = System.Drawing.Color.White;
            this.btnDangnhap.Location = new System.Drawing.Point(154, 254);
            this.btnDangnhap.Name = "btnDangnhap";
            this.btnDangnhap.Size = new System.Drawing.Size(108, 45);
            this.btnDangnhap.TabIndex = 0;
            this.btnDangnhap.Text = "Đăng nhập";
            this.btnDangnhap.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // txtTaikhoan
            // 
            this.txtTaikhoan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTaikhoan.DefaultText = "";
            this.txtTaikhoan.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTaikhoan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTaikhoan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTaikhoan.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTaikhoan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTaikhoan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTaikhoan.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTaikhoan.Location = new System.Drawing.Point(154, 118);
            this.txtTaikhoan.Name = "txtTaikhoan";
            this.txtTaikhoan.PasswordChar = '\0';
            this.txtTaikhoan.PlaceholderText = "";
            this.txtTaikhoan.SelectedText = "";
            this.txtTaikhoan.Size = new System.Drawing.Size(253, 36);
            this.txtTaikhoan.TabIndex = 1;
            // 
            // txtMatkhau
            // 
            this.txtMatkhau.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMatkhau.DefaultText = "";
            this.txtMatkhau.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMatkhau.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMatkhau.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMatkhau.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMatkhau.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMatkhau.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMatkhau.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMatkhau.Location = new System.Drawing.Point(154, 189);
            this.txtMatkhau.Name = "txtMatkhau";
            this.txtMatkhau.PasswordChar = '\0';
            this.txtMatkhau.PlaceholderText = "";
            this.txtMatkhau.SelectedText = "";
            this.txtMatkhau.Size = new System.Drawing.Size(253, 36);
            this.txtMatkhau.TabIndex = 2;
            // 
            // lblTaikhoan
            // 
            this.lblTaikhoan.BackColor = System.Drawing.Color.Transparent;
            this.lblTaikhoan.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTaikhoan.Location = new System.Drawing.Point(56, 118);
            this.lblTaikhoan.Name = "lblTaikhoan";
            this.lblTaikhoan.Size = new System.Drawing.Size(78, 21);
            this.lblTaikhoan.TabIndex = 3;
            this.lblTaikhoan.Text = "Tài khoản";
            // 
            // lblMatkhau
            // 
            this.lblMatkhau.BackColor = System.Drawing.Color.Transparent;
            this.lblMatkhau.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblMatkhau.Location = new System.Drawing.Point(56, 189);
            this.lblMatkhau.Name = "lblMatkhau";
            this.lblMatkhau.Size = new System.Drawing.Size(74, 21);
            this.lblMatkhau.TabIndex = 4;
            this.lblMatkhau.Text = "Mật khẩu";
            // 
            // frmDangnhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 450);
            this.Controls.Add(this.lblMatkhau);
            this.Controls.Add(this.lblTaikhoan);
            this.Controls.Add(this.txtMatkhau);
            this.Controls.Add(this.txtTaikhoan);
            this.Controls.Add(this.btnDangnhap);
            this.Name = "frmDangnhap";
            this.Text = "frmDangnhap";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnDangnhap;
        private Guna.UI2.WinForms.Guna2TextBox txtTaikhoan;
        private Guna.UI2.WinForms.Guna2TextBox txtMatkhau;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTaikhoan;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMatkhau;
    }
}