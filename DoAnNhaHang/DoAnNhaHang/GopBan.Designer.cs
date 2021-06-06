namespace DoAnNhaHang
{
    partial class GopBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GopBan));
            this.btnGop = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.ListBanCanGop = new System.Windows.Forms.ListBox();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.txtTenKV = new DevExpress.XtraEditors.TextEdit();
            this.txtTenBan = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtMaBan = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.tabcrlBan = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenKV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenBan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaBan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGop
            // 
            this.btnGop.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGop.Appearance.Options.UseFont = true;
            this.btnGop.ImageOptions.Image = global::DoAnNhaHang.Properties.Resources.merge;
            this.btnGop.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnGop.Location = new System.Drawing.Point(848, 428);
            this.btnGop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGop.Name = "btnGop";
            this.btnGop.Size = new System.Drawing.Size(100, 52);
            this.btnGop.TabIndex = 28;
            this.btnGop.Click += new System.EventHandler(this.btnGop_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Appearance.Options.UseFont = true;
            this.btnXoa.ImageOptions.Image = global::DoAnNhaHang.Properties.Resources.media_step_back_arrow;
            this.btnXoa.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnXoa.Location = new System.Drawing.Point(848, 313);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 52);
            this.btnXoa.TabIndex = 27;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Appearance.Options.UseFont = true;
            this.btnThem.ImageOptions.Image = global::DoAnNhaHang.Properties.Resources.forward_media_step;
            this.btnThem.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnThem.Location = new System.Drawing.Point(848, 204);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 52);
            this.btnThem.TabIndex = 26;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImageOptions.Image")));
            this.groupControl1.Controls.Add(this.ListBanCanGop);
            this.groupControl1.Location = new System.Drawing.Point(979, 21);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(251, 585);
            this.groupControl1.TabIndex = 25;
            this.groupControl1.Text = "Danh Sách Sẽ Gộp";
            // 
            // ListBanCanGop
            // 
            this.ListBanCanGop.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBanCanGop.FormattingEnabled = true;
            this.ListBanCanGop.ItemHeight = 26;
            this.ListBanCanGop.Location = new System.Drawing.Point(8, 53);
            this.ListBanCanGop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ListBanCanGop.Name = "ListBanCanGop";
            this.ListBanCanGop.Size = new System.Drawing.Size(227, 472);
            this.ListBanCanGop.TabIndex = 0;
            this.ListBanCanGop.SelectedIndexChanged += new System.EventHandler(this.ListBanCanGop_SelectedIndexChanged);
            // 
            // groupControl4
            // 
            this.groupControl4.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl4.AppearanceCaption.Options.UseFont = true;
            this.groupControl4.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl4.CaptionImageOptions.Image")));
            this.groupControl4.Controls.Add(this.txtTenKV);
            this.groupControl4.Controls.Add(this.txtTenBan);
            this.groupControl4.Controls.Add(this.labelControl1);
            this.groupControl4.Controls.Add(this.txtMaBan);
            this.groupControl4.Controls.Add(this.labelControl3);
            this.groupControl4.Controls.Add(this.labelControl13);
            this.groupControl4.Location = new System.Drawing.Point(23, 15);
            this.groupControl4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(796, 130);
            this.groupControl4.TabIndex = 11;
            this.groupControl4.Text = "Thông Tin Bàn";
            // 
            // txtTenKV
            // 
            this.txtTenKV.Location = new System.Drawing.Point(624, 68);
            this.txtTenKV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTenKV.Name = "txtTenKV";
            this.txtTenKV.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKV.Properties.Appearance.Options.UseFont = true;
            this.txtTenKV.Size = new System.Drawing.Size(152, 26);
            this.txtTenKV.TabIndex = 25;
            // 
            // txtTenBan
            // 
            this.txtTenBan.Location = new System.Drawing.Point(347, 64);
            this.txtTenBan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTenBan.Name = "txtTenBan";
            this.txtTenBan.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenBan.Properties.Appearance.Options.UseFont = true;
            this.txtTenBan.Size = new System.Drawing.Size(141, 26);
            this.txtTenBan.TabIndex = 24;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(496, 68);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(111, 23);
            this.labelControl1.TabIndex = 23;
            this.labelControl1.Text = "Tên Khu Vực";
            // 
            // txtMaBan
            // 
            this.txtMaBan.Location = new System.Drawing.Point(109, 64);
            this.txtMaBan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMaBan.Name = "txtMaBan";
            this.txtMaBan.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaBan.Properties.Appearance.Options.UseFont = true;
            this.txtMaBan.Size = new System.Drawing.Size(131, 26);
            this.txtMaBan.TabIndex = 22;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(263, 68);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(70, 23);
            this.labelControl3.TabIndex = 21;
            this.labelControl3.Text = "Tên Bàn";
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Location = new System.Drawing.Point(17, 68);
            this.labelControl13.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(66, 23);
            this.labelControl13.TabIndex = 20;
            this.labelControl13.Text = "Mã Bàn";
            // 
            // groupControl3
            // 
            this.groupControl3.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl3.CaptionImageOptions.Image")));
            this.groupControl3.Controls.Add(this.tabcrlBan);
            this.groupControl3.Location = new System.Drawing.Point(23, 153);
            this.groupControl3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(796, 453);
            this.groupControl3.TabIndex = 24;
            this.groupControl3.Text = "Danh Sách Bàn Có Thể Gộp";
            // 
            // tabcrlBan
            // 
            this.tabcrlBan.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabcrlBan.Location = new System.Drawing.Point(7, 53);
            this.tabcrlBan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabcrlBan.Name = "tabcrlBan";
            this.tabcrlBan.SelectedIndex = 0;
            this.tabcrlBan.Size = new System.Drawing.Size(783, 394);
            this.tabcrlBan.TabIndex = 1;
            // 
            // GopBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 617);
            this.Controls.Add(this.btnGop);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.groupControl3);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "GopBan";
            this.Text = "Gộp Bàn";
            this.Load += new System.EventHandler(this.GopBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.groupControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenKV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenBan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaBan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.TextEdit txtTenKV;
        private DevExpress.XtraEditors.TextEdit txtTenBan;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtMaBan;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.ListBox ListBanCanGop;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnGop;
        private System.Windows.Forms.TabControl tabcrlBan;
    }
}