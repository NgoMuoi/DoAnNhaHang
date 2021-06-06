namespace DoAnNhaHang
{
    partial class QLThucDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QLThucDon));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.dtgvThucDon = new System.Windows.Forms.DataGridView();
            this.grctrolXuLy = new DevExpress.XtraEditors.GroupControl();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.btnReLoad = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.grctrlTTThucDon = new DevExpress.XtraEditors.GroupControl();
            this.cbbTenLoai = new DevExpress.XtraEditors.ComboBoxEdit();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pbHA = new DevExpress.XtraEditors.PictureEdit();
            this.btnMacDinh = new DevExpress.XtraEditors.SimpleButton();
            this.btnDuyetHA = new DevExpress.XtraEditors.SimpleButton();
            this.txtLinkHA = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtDonGia = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtDVT = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtTenMon = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtMaMon = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThucDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grctrolXuLy)).BeginInit();
            this.grctrolXuLy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grctrlTTThucDon)).BeginInit();
            this.grctrlTTThucDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbTenLoai.Properties)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinkHA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonGia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDVT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenMon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaMon.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.DarkCyan;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(-5, -5);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(1684, 92);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "QUẢN LÝ ĐỒ UỐNG";
            // 
            // groupControl3
            // 
            this.groupControl3.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl3.CaptionImageOptions.Image")));
            this.groupControl3.Controls.Add(this.dtgvThucDon);
            this.groupControl3.Location = new System.Drawing.Point(627, 92);
            this.groupControl3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(960, 676);
            this.groupControl3.TabIndex = 4;
            this.groupControl3.Text = "Danh Sách Đồ Uống";
            // 
            // dtgvThucDon
            // 
            this.dtgvThucDon.AllowUserToAddRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            this.dtgvThucDon.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgvThucDon.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgvThucDon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgvThucDon.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dtgvThucDon.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Bisque;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvThucDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgvThucDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvThucDon.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtgvThucDon.EnableHeadersVisualStyles = false;
            this.dtgvThucDon.Location = new System.Drawing.Point(8, 53);
            this.dtgvThucDon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtgvThucDon.Name = "dtgvThucDon";
            this.dtgvThucDon.RowHeadersWidth = 51;
            this.dtgvThucDon.RowTemplate.Height = 30;
            this.dtgvThucDon.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvThucDon.Size = new System.Drawing.Size(913, 614);
            this.dtgvThucDon.TabIndex = 0;
            this.dtgvThucDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvThucDon_CellClick);
            // 
            // grctrolXuLy
            // 
            this.grctrolXuLy.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grctrolXuLy.AppearanceCaption.Options.UseFont = true;
            this.grctrolXuLy.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("grctrolXuLy.CaptionImageOptions.Image")));
            this.grctrolXuLy.Controls.Add(this.btnHuy);
            this.grctrolXuLy.Controls.Add(this.btnReLoad);
            this.grctrolXuLy.Controls.Add(this.btnLuu);
            this.grctrolXuLy.Controls.Add(this.btnSua);
            this.grctrolXuLy.Controls.Add(this.btnXoa);
            this.grctrolXuLy.Controls.Add(this.btnThem);
            this.grctrolXuLy.Location = new System.Drawing.Point(444, 95);
            this.grctrolXuLy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grctrolXuLy.Name = "grctrolXuLy";
            this.grctrolXuLy.Size = new System.Drawing.Size(175, 676);
            this.grctrolXuLy.TabIndex = 4;
            this.grctrolXuLy.Text = "Xử Lý";
            // 
            // btnHuy
            // 
            this.btnHuy.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Appearance.Options.UseFont = true;
            this.btnHuy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.ImageOptions.Image")));
            this.btnHuy.Location = new System.Drawing.Point(16, 576);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(141, 52);
            this.btnHuy.TabIndex = 15;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnReLoad
            // 
            this.btnReLoad.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReLoad.Appearance.Options.UseFont = true;
            this.btnReLoad.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnReLoad.ImageOptions.Image")));
            this.btnReLoad.Location = new System.Drawing.Point(16, 476);
            this.btnReLoad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReLoad.Name = "btnReLoad";
            this.btnReLoad.Size = new System.Drawing.Size(141, 52);
            this.btnReLoad.TabIndex = 14;
            this.btnReLoad.Text = "Reload";
            this.btnReLoad.Click += new System.EventHandler(this.btnReLoad_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.ImageOptions.Image")));
            this.btnLuu.Location = new System.Drawing.Point(16, 374);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(141, 52);
            this.btnLuu.TabIndex = 13;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnSua
            // 
            this.btnSua.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Appearance.Options.UseFont = true;
            this.btnSua.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.ImageOptions.Image")));
            this.btnSua.Location = new System.Drawing.Point(16, 271);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(141, 52);
            this.btnSua.TabIndex = 12;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Appearance.Options.UseFont = true;
            this.btnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.Image")));
            this.btnXoa.Location = new System.Drawing.Point(16, 171);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(141, 52);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Appearance.Options.UseFont = true;
            this.btnThem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.ImageOptions.Image")));
            this.btnThem.Location = new System.Drawing.Point(16, 73);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(141, 52);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // grctrlTTThucDon
            // 
            this.grctrlTTThucDon.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grctrlTTThucDon.AppearanceCaption.Options.UseFont = true;
            this.grctrlTTThucDon.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("grctrlTTThucDon.CaptionImageOptions.Image")));
            this.grctrlTTThucDon.Controls.Add(this.cbbTenLoai);
            this.grctrlTTThucDon.Controls.Add(this.tabControl1);
            this.grctrlTTThucDon.Controls.Add(this.labelControl6);
            this.grctrlTTThucDon.Controls.Add(this.txtDonGia);
            this.grctrlTTThucDon.Controls.Add(this.labelControl5);
            this.grctrlTTThucDon.Controls.Add(this.txtDVT);
            this.grctrlTTThucDon.Controls.Add(this.labelControl4);
            this.grctrlTTThucDon.Controls.Add(this.txtTenMon);
            this.grctrlTTThucDon.Controls.Add(this.labelControl3);
            this.grctrlTTThucDon.Controls.Add(this.txtMaMon);
            this.grctrlTTThucDon.Controls.Add(this.labelControl2);
            this.grctrlTTThucDon.Location = new System.Drawing.Point(16, 95);
            this.grctrlTTThucDon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grctrlTTThucDon.Name = "grctrlTTThucDon";
            this.grctrlTTThucDon.Size = new System.Drawing.Size(420, 676);
            this.grctrlTTThucDon.TabIndex = 3;
            this.grctrlTTThucDon.Text = "Thông Tin Đồ Uống";
            // 
            // cbbTenLoai
            // 
            this.cbbTenLoai.Location = new System.Drawing.Point(137, 233);
            this.cbbTenLoai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbTenLoai.Name = "cbbTenLoai";
            this.cbbTenLoai.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTenLoai.Properties.Appearance.Options.UseFont = true;
            this.cbbTenLoai.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbTenLoai.Size = new System.Drawing.Size(247, 26);
            this.cbbTenLoai.TabIndex = 11;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(7, 287);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(395, 383);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Bisque;
            this.tabPage2.Controls.Add(this.pbHA);
            this.tabPage2.Controls.Add(this.btnMacDinh);
            this.tabPage2.Controls.Add(this.btnDuyetHA);
            this.tabPage2.Controls.Add(this.txtLinkHA);
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(387, 347);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Hình Ảnh";
            // 
            // pbHA
            // 
            this.pbHA.EditValue = global::DoAnNhaHang.Properties.Resources.Menu;
            this.pbHA.Location = new System.Drawing.Point(20, 65);
            this.pbHA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbHA.Name = "pbHA";
            this.pbHA.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pbHA.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pbHA.Size = new System.Drawing.Size(345, 219);
            this.pbHA.TabIndex = 18;
            this.pbHA.EditValueChanged += new System.EventHandler(this.pbHA_EditValueChanged);
            // 
            // btnMacDinh
            // 
            this.btnMacDinh.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMacDinh.Appearance.Options.UseFont = true;
            this.btnMacDinh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnMacDinh.ImageOptions.SvgImage")));
            this.btnMacDinh.Location = new System.Drawing.Point(8, 292);
            this.btnMacDinh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMacDinh.Name = "btnMacDinh";
            this.btnMacDinh.Size = new System.Drawing.Size(364, 43);
            this.btnMacDinh.TabIndex = 17;
            this.btnMacDinh.Text = "Mặc Định";
            this.btnMacDinh.Click += new System.EventHandler(this.btnMacDinh_Click);
            // 
            // btnDuyetHA
            // 
            this.btnDuyetHA.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDuyetHA.Appearance.Options.UseFont = true;
            this.btnDuyetHA.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDuyetHA.ImageOptions.Image")));
            this.btnDuyetHA.Location = new System.Drawing.Point(301, 7);
            this.btnDuyetHA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDuyetHA.Name = "btnDuyetHA";
            this.btnDuyetHA.Size = new System.Drawing.Size(64, 52);
            this.btnDuyetHA.TabIndex = 16;
            this.btnDuyetHA.Click += new System.EventHandler(this.btnDuyetHA_Click);
            // 
            // txtLinkHA
            // 
            this.txtLinkHA.Location = new System.Drawing.Point(8, 20);
            this.txtLinkHA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLinkHA.Name = "txtLinkHA";
            this.txtLinkHA.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLinkHA.Properties.Appearance.Options.UseFont = true;
            this.txtLinkHA.Size = new System.Drawing.Size(285, 26);
            this.txtLinkHA.TabIndex = 12;
            this.txtLinkHA.TextChanged += new System.EventHandler(this.txtLinkHA_TextChanged);
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(7, 239);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(75, 23);
            this.labelControl6.TabIndex = 8;
            this.labelControl6.Text = "Tên Loại";
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(137, 186);
            this.txtDonGia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDonGia.Properties.Appearance.Options.UseFont = true;
            this.txtDonGia.Size = new System.Drawing.Size(247, 26);
            this.txtDonGia.TabIndex = 7;
            this.txtDonGia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDonGia_KeyPress);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(7, 190);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(71, 23);
            this.labelControl5.TabIndex = 6;
            this.labelControl5.Text = "Đơn Giá";
            // 
            // txtDVT
            // 
            this.txtDVT.Location = new System.Drawing.Point(137, 143);
            this.txtDVT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDVT.Name = "txtDVT";
            this.txtDVT.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDVT.Properties.Appearance.Options.UseFont = true;
            this.txtDVT.Size = new System.Drawing.Size(247, 26);
            this.txtDVT.TabIndex = 5;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(7, 146);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(103, 23);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Đơn Vị Tính";
            // 
            // txtTenMon
            // 
            this.txtTenMon.Location = new System.Drawing.Point(137, 97);
            this.txtTenMon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenMon.Properties.Appearance.Options.UseFont = true;
            this.txtTenMon.Size = new System.Drawing.Size(247, 26);
            this.txtTenMon.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(7, 101);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(110, 23);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Tên Đồ Uống";
            // 
            // txtMaMon
            // 
            this.txtMaMon.Location = new System.Drawing.Point(137, 57);
            this.txtMaMon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMaMon.Name = "txtMaMon";
            this.txtMaMon.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaMon.Properties.Appearance.Options.UseFont = true;
            this.txtMaMon.Size = new System.Drawing.Size(247, 26);
            this.txtMaMon.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(7, 60);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(106, 23);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Mã Đồ Uống";
            // 
            // QLThucDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1675, 785);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.grctrolXuLy);
            this.Controls.Add(this.grctrlTTThucDon);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "QLThucDon";
            this.Text = "Quản Lý Đồ Uống";
            this.Load += new System.EventHandler(this.QLThucDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThucDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grctrolXuLy)).EndInit();
            this.grctrolXuLy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grctrlTTThucDon)).EndInit();
            this.grctrlTTThucDon.ResumeLayout(false);
            this.grctrlTTThucDon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbTenLoai.Properties)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbHA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinkHA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonGia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDVT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenMon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaMon.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grctrlTTThucDon;
        private DevExpress.XtraEditors.GroupControl grctrolXuLy;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnReLoad;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtDonGia;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtDVT;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtTenMon;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtMaMon;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cbbTenLoai;
        private DevExpress.XtraEditors.PictureEdit pbHA;
        private DevExpress.XtraEditors.SimpleButton btnMacDinh;
        private DevExpress.XtraEditors.SimpleButton btnDuyetHA;
        private DevExpress.XtraEditors.TextEdit txtLinkHA;
        private System.Windows.Forms.DataGridView dtgvThucDon;
    }
}