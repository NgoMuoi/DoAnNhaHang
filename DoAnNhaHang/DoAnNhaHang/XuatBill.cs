using DevExpress.XtraReports.UI;
using DoAnNhaHang.BSLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DoAnNhaHang
{
    public partial class XuatBill : Form
    {
        public XuatBill()
        {
            InitializeComponent();
        }
        public string Tien { get; set; }
        public string TenBan { get; set; }
        public string TenBan2 { get; set; }
        public string BangSo { get; set; }
        public string BangChu { get; set; }
        public string TongTien { get; set; }
        public string MaPhieu { get; set; }

        BLThongBao bltb = new BLThongBao();
        private void jTextBox1_TextChangeEvent(object sender, EventArgs e)
        {
            this.txtTien.ForeColor = Color.Black;
            if (txtTien.TextValue == "" || TienThoi(txtTien.TextValue) < 0)
            {
                btnXuat.Enabled = false;
            }
            else
                btnXuat.Enabled = true;
        }
        public int TienThoi(string SoTienKhachGui)
        {
            try
            {

                int t = int.Parse(SoTienKhachGui) - TongTienHD();
                return t;
            }
            catch
            {

            }
            return 0;
        }

        public int VAT(string TongTien)
        {
            try
            {

                int t = int.Parse(Tien) * 10/100;
                return t;
            }
            catch
            {

            }
            return 0;
        }

        public int TongTienHD()
        {
            try
            {

                int t = int.Parse(Tien) + VAT(Tien);
                return t;
            }
            catch
            {

            }
            return 0;
        }
        private void XuatBill_Load(object sender, EventArgs e)
        {
            btnXuat.Enabled = false;
            lblBan.Text = "Bàn " + TenBan;
            lblTien.Text = "Tiền: " + BangSo;
            lblTongTien.Text = "Tổng Tiền: " + string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", TongTienHD());
            lblVAT.Text = "VAT: " + string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", VAT(Tien));
            if (TienThoi(txtTien.TextValue) > 0)
            {
                btnXuat.Enabled = true;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            

            try
            {
                //In Hoa Don
                string st = "Data Source=DESKTOP-DSC536G; Initial Catalog=QuanLyNhaHang; Integrated Security=True";
                SqlConnection sql = new SqlConnection(st);
                sql.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM HOADON WHERE MAPHIEU ='" + MaPhieu + "'", sql);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                sql.Close();
                RPHoaDon rp = new RPHoaDon();
                rp.DataSource = dt;
                rp.DataMember = "HOADON";
                rp.GTBangChu = TongTienHD().ToString();
                rp.TongTien = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", TongTienHD());
                rp.TienThoi = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", TienThoi(txtTien.TextValue));
                rp.VAT = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", VAT(Tien));
                rp.TienKhachGui = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", int.Parse(txtTien.TextValue));
                rp.ShowPreview();  
                BLXemTTBan blxttb = new BLXemTTBan();
                blxttb.CapNhatBan(TenBan, "Trống");
                blxttb.CapNhatPhieu(MaPhieu,TongTienHD());               
                this.Hide();
            }
            catch
            {

            }
        }
    }
}
