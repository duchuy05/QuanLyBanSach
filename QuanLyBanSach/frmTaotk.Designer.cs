namespace QuanLyBanSach
{
    partial class frmTaotk
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
            this.btnDongy = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblTentk = new System.Windows.Forms.Label();
            this.lblMatkhau = new System.Windows.Forms.Label();
            this.txtTentk = new System.Windows.Forms.TextBox();
            this.txtMatkhau = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnDongy
            // 
            this.btnDongy.Location = new System.Drawing.Point(257, 441);
            this.btnDongy.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnDongy.Name = "btnDongy";
            this.btnDongy.Size = new System.Drawing.Size(150, 44);
            this.btnDongy.TabIndex = 0;
            this.btnDongy.Text = "Đồng ý";
            this.btnDongy.UseVisualStyleBackColor = true;
            this.btnDongy.Click += new System.EventHandler(this.btnDongy_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(525, 441);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(150, 44);
            this.btnThoat.TabIndex = 1;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // lblTentk
            // 
            this.lblTentk.AutoSize = true;
            this.lblTentk.Location = new System.Drawing.Point(177, 138);
            this.lblTentk.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTentk.Name = "lblTentk";
            this.lblTentk.Size = new System.Drawing.Size(143, 25);
            this.lblTentk.TabIndex = 2;
            this.lblTentk.Text = "Tên tài khoản";
            // 
            // lblMatkhau
            // 
            this.lblMatkhau.AutoSize = true;
            this.lblMatkhau.Location = new System.Drawing.Point(177, 226);
            this.lblMatkhau.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMatkhau.Name = "lblMatkhau";
            this.lblMatkhau.Size = new System.Drawing.Size(101, 25);
            this.lblMatkhau.TabIndex = 3;
            this.lblMatkhau.Text = "Mật khẩu";
            // 
            // txtTentk
            // 
            this.txtTentk.Location = new System.Drawing.Point(365, 132);
            this.txtTentk.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtTentk.Name = "txtTentk";
            this.txtTentk.Size = new System.Drawing.Size(448, 31);
            this.txtTentk.TabIndex = 4;
            // 
            // txtMatkhau
            // 
            this.txtMatkhau.Location = new System.Drawing.Point(365, 226);
            this.txtMatkhau.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtMatkhau.Name = "txtMatkhau";
            this.txtMatkhau.Size = new System.Drawing.Size(448, 31);
            this.txtMatkhau.TabIndex = 5;
            // 
            // frmTaotk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 590);
            this.Controls.Add(this.txtMatkhau);
            this.Controls.Add(this.txtTentk);
            this.Controls.Add(this.lblMatkhau);
            this.Controls.Add(this.lblTentk);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDongy);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "frmTaotk";
            this.Text = "frmTaotk";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDongy;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label lblTentk;
        private System.Windows.Forms.Label lblMatkhau;
        private System.Windows.Forms.TextBox txtTentk;
        private System.Windows.Forms.TextBox txtMatkhau;
    }
}