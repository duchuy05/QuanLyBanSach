namespace QuanLyBanSach
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
            this.btnDangnhap = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.txtTaikhoan = new System.Windows.Forms.TextBox();
            this.txtMatkhau = new System.Windows.Forms.TextBox();
            this.lblTaikhoan = new System.Windows.Forms.Label();
            this.lblMatkhau = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDangnhap
            // 
            this.btnDangnhap.Location = new System.Drawing.Point(351, 353);
            this.btnDangnhap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDangnhap.Name = "btnDangnhap";
            this.btnDangnhap.Size = new System.Drawing.Size(100, 28);
            this.btnDangnhap.TabIndex = 0;
            this.btnDangnhap.Text = "Đăng nhập";
            this.btnDangnhap.UseVisualStyleBackColor = true;
            this.btnDangnhap.Click += new System.EventHandler(this.btnDangnhap_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(523, 353);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(100, 28);
            this.btnThoat.TabIndex = 1;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // txtTaikhoan
            // 
            this.txtTaikhoan.Location = new System.Drawing.Point(351, 235);
            this.txtTaikhoan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTaikhoan.Name = "txtTaikhoan";
            this.txtTaikhoan.Size = new System.Drawing.Size(304, 22);
            this.txtTaikhoan.TabIndex = 2;
            this.txtTaikhoan.TextChanged += new System.EventHandler(this.txtTaikhoan_TextChanged);
            // 
            // txtMatkhau
            // 
            this.txtMatkhau.Location = new System.Drawing.Point(351, 298);
            this.txtMatkhau.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMatkhau.Name = "txtMatkhau";
            this.txtMatkhau.Size = new System.Drawing.Size(304, 22);
            this.txtMatkhau.TabIndex = 3;
            // 
            // lblTaikhoan
            // 
            this.lblTaikhoan.AutoSize = true;
            this.lblTaikhoan.Location = new System.Drawing.Point(275, 244);
            this.lblTaikhoan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTaikhoan.Name = "lblTaikhoan";
            this.lblTaikhoan.Size = new System.Drawing.Size(67, 16);
            this.lblTaikhoan.TabIndex = 4;
            this.lblTaikhoan.Text = "Tài khoản";
            // 
            // lblMatkhau
            // 
            this.lblMatkhau.AutoSize = true;
            this.lblMatkhau.Location = new System.Drawing.Point(275, 306);
            this.lblMatkhau.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMatkhau.Name = "lblMatkhau";
            this.lblMatkhau.Size = new System.Drawing.Size(61, 16);
            this.lblMatkhau.TabIndex = 5;
            this.lblMatkhau.Text = "Mật khẩu";
            // 
            // frmDangnhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.lblMatkhau);
            this.Controls.Add(this.lblTaikhoan);
            this.Controls.Add(this.txtMatkhau);
            this.Controls.Add(this.txtTaikhoan);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDangnhap);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmDangnhap";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDangnhap;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TextBox txtTaikhoan;
        private System.Windows.Forms.TextBox txtMatkhau;
        private System.Windows.Forms.Label lblTaikhoan;
        private System.Windows.Forms.Label lblMatkhau;
    }
}

