using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DoAnNhaHang.BSLayer;

namespace DoAnNhaHang
{
    public partial class RPHoaDon : DevExpress.XtraReports.UI.XtraReport
    {
        public RPHoaDon()
        {
            InitializeComponent();
        }
        public string GTBangChu { get; set; }
        public string TienThoi { get; set; }
        public string TienKhachGui { get; set; }
        public string VAT { get; set; }
        public string TongTien { get; set; }
        public double GT = 0;
        BLXemTTBan blxttb = new BLXemTTBan();
        private void ReportFooter_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            GT = double.Parse(GTBangChu);
            lblVAT.Text = VAT;
            lblTienTraLai.Text = TienThoi;
            lblTienNhan.Text = TienKhachGui;
            lblTongTienHD.Text = TongTien;
            lblBangChu.Text = blxttb.So_chu(GT);
        }
    }
}
