namespace HTTTDN_Code
{
    partial class Nhanvien
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnLay = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.txtSoKiTu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.GridLayMa = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TKCN_Ten = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.TKCN_lbID = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.TKCN_TrangThai = new System.Windows.Forms.Label();
            this.TKCN_ChucVu = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.TKCN_MatKhau = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btnSuaTKQL = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.btnIn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridLayMa)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(-4, -4);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(757, 611);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.tabPage1.Controls.Add(this.btnIn);
            this.tabPage1.Controls.Add(this.btnLay);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtSL);
            this.tabPage1.Controls.Add(this.txtSoKiTu);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.GridLayMa);
            this.tabPage1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(749, 581);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lấy mã";
            // 
            // btnLay
            // 
            this.btnLay.BackColor = System.Drawing.SystemColors.Control;
            this.btnLay.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLay.Image = global::HTTTDN_Code.Properties.Resources.add1;
            this.btnLay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLay.Location = new System.Drawing.Point(572, 47);
            this.btnLay.Margin = new System.Windows.Forms.Padding(4);
            this.btnLay.Name = "btnLay";
            this.btnLay.Size = new System.Drawing.Size(89, 42);
            this.btnLay.TabIndex = 14;
            this.btnLay.Text = "Lấy mã";
            this.btnLay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLay.UseVisualStyleBackColor = false;
            this.btnLay.Click += new System.EventHandler(this.btnLay_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Số lượng mã cần";
            // 
            // txtSL
            // 
            this.txtSL.Location = new System.Drawing.Point(237, 64);
            this.txtSL.Margin = new System.Windows.Forms.Padding(4);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(260, 25);
            this.txtSL.TabIndex = 11;
            // 
            // txtSoKiTu
            // 
            this.txtSoKiTu.Location = new System.Drawing.Point(237, 23);
            this.txtSoKiTu.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoKiTu.Name = "txtSoKiTu";
            this.txtSoKiTu.Size = new System.Drawing.Size(260, 25);
            this.txtSoKiTu.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 27);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Số kí tự của mã";
            // 
            // GridLayMa
            // 
            this.GridLayMa.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.GridLayMa.AllowUserToAddRows = false;
            this.GridLayMa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridLayMa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Column3});
            this.GridLayMa.Location = new System.Drawing.Point(76, 130);
            this.GridLayMa.Margin = new System.Windows.Forms.Padding(4);
            this.GridLayMa.Name = "GridLayMa";
            this.GridLayMa.Size = new System.Drawing.Size(585, 252);
            this.GridLayMa.TabIndex = 5;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "STT";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 70;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Mã code";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Thời Gian Hết Hạn";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.PaleTurquoise;
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(749, 581);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Chỉnh sửa TK Cá nhân";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TKCN_Ten);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.TKCN_lbID);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.TKCN_TrangThai);
            this.groupBox2.Controls.Add(this.TKCN_ChucVu);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.TKCN_MatKhau);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.btnSuaTKQL);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Location = new System.Drawing.Point(362, 33);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(359, 364);
            this.groupBox2.TabIndex = 55;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin cá nhân";
            // 
            // TKCN_Ten
            // 
            this.TKCN_Ten.AutoSize = true;
            this.TKCN_Ten.Location = new System.Drawing.Point(133, 90);
            this.TKCN_Ten.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TKCN_Ten.Name = "TKCN_Ten";
            this.TKCN_Ten.Size = new System.Drawing.Size(31, 17);
            this.TKCN_Ten.TabIndex = 54;
            this.TKCN_Ten.Text = "Tên";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(47, 215);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 17);
            this.label13.TabIndex = 53;
            this.label13.Text = "Chức Vụ";
            // 
            // TKCN_lbID
            // 
            this.TKCN_lbID.AutoSize = true;
            this.TKCN_lbID.Location = new System.Drawing.Point(134, 53);
            this.TKCN_lbID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TKCN_lbID.Name = "TKCN_lbID";
            this.TKCN_lbID.Size = new System.Drawing.Size(42, 17);
            this.TKCN_lbID.TabIndex = 39;
            this.TKCN_lbID.Text = "label5";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(42, 180);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 17);
            this.label15.TabIndex = 52;
            this.label15.Text = "Tình Trạng";
            // 
            // TKCN_TrangThai
            // 
            this.TKCN_TrangThai.AutoSize = true;
            this.TKCN_TrangThai.Location = new System.Drawing.Point(134, 180);
            this.TKCN_TrangThai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TKCN_TrangThai.Name = "TKCN_TrangThai";
            this.TKCN_TrangThai.Size = new System.Drawing.Size(68, 17);
            this.TKCN_TrangThai.TabIndex = 38;
            this.TKCN_TrangThai.Text = "Tình trạng";
            // 
            // TKCN_ChucVu
            // 
            this.TKCN_ChucVu.AutoSize = true;
            this.TKCN_ChucVu.Location = new System.Drawing.Point(135, 215);
            this.TKCN_ChucVu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TKCN_ChucVu.Name = "TKCN_ChucVu";
            this.TKCN_ChucVu.Size = new System.Drawing.Size(62, 17);
            this.TKCN_ChucVu.TabIndex = 37;
            this.TKCN_ChucVu.Text = "Chức Vụ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(42, 135);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(68, 17);
            this.label17.TabIndex = 48;
            this.label17.Text = "Mật Khẩu";
            // 
            // TKCN_MatKhau
            // 
            this.TKCN_MatKhau.Location = new System.Drawing.Point(138, 131);
            this.TKCN_MatKhau.Margin = new System.Windows.Forms.Padding(4);
            this.TKCN_MatKhau.Name = "TKCN_MatKhau";
            this.TKCN_MatKhau.PasswordChar = '*';
            this.TKCN_MatKhau.Size = new System.Drawing.Size(192, 25);
            this.TKCN_MatKhau.TabIndex = 50;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(40, 90);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 17);
            this.label18.TabIndex = 47;
            this.label18.Text = "Họ và tên";
            // 
            // btnSuaTKQL
            // 
            this.btnSuaTKQL.Location = new System.Drawing.Point(231, 291);
            this.btnSuaTKQL.Margin = new System.Windows.Forms.Padding(4);
            this.btnSuaTKQL.Name = "btnSuaTKQL";
            this.btnSuaTKQL.Size = new System.Drawing.Size(99, 44);
            this.btnSuaTKQL.TabIndex = 29;
            this.btnSuaTKQL.Text = "Sửa";
            this.btnSuaTKQL.UseVisualStyleBackColor = true;
            this.btnSuaTKQL.Click += new System.EventHandler(this.btnSuaTKQL_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(35, 53);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(91, 17);
            this.label21.TabIndex = 26;
            this.label21.Text = "ID Nhân Viên";
            // 
            // btnIn
            // 
            this.btnIn.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Image = global::HTTTDN_Code.Properties.Resources.luu1;
            this.btnIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIn.Location = new System.Drawing.Point(572, 408);
            this.btnIn.Margin = new System.Windows.Forms.Padding(4);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(89, 44);
            this.btnIn.TabIndex = 15;
            this.btnIn.Text = "In mã";
            this.btnIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // button1
            // 
            this.button1.Image = global::HTTTDN_Code.Properties.Resources.admin;
            this.button1.Location = new System.Drawing.Point(41, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(243, 287);
            this.button1.TabIndex = 56;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Nhanvien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 492);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Nhanvien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhân viên";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Nhanvien_FormClosed);
            this.Load += new System.EventHandler(this.Nhanvien_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridLayMa)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnLay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.TextBox txtSoKiTu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView GridLayMa;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label TKCN_lbID;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label TKCN_TrangThai;
        private System.Windows.Forms.Label TKCN_ChucVu;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox TKCN_MatKhau;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnSuaTKQL;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label TKCN_Ten;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}

