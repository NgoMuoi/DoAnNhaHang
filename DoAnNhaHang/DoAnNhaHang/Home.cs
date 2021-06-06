using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DoAnNhaHang.BSLayer;

namespace DoAnNhaHang
{
    public partial class Home : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Home()
        {
            InitializeComponent();
        }
        public string TenNV { get; set; }
        public string Quyen { get; set; }
        public string TK { get; set; }
        public string TTin { get; set; }
        public string TenDN { get; set; }
        public string KT { get; set; }
        private void Home_Load(object sender, EventArgs e)
        {
            loaddata();
            ItemTenNV.Caption = TenNV;
            ItemQuyenNV.Caption = Quyen;
            ItemTaiKhoan.Caption = TenDN;
            if(ItemQuyenNV.Caption=="Nhân Viên")
            {
                btnTK.Enabled = false;
                ribbonPage2.Visible = false;
                ribbonPage3.Visible = false;
            }
        }
        public void DongTatCaCacTab()
        {
            for (int i = xtraTabbedMdiManager1.Pages.Count - 1; i >= 0; i--)
            {
                xtraTabbedMdiManager1.Pages[i].MdiChild.Close();
            }
        }
        public void loaddata()
        {
            DongTatCaCacTab();
            baraa.Caption = TTin;
            int dai = 0;
            int rong = 0;
            XemThongTinBan xttb = new XemThongTinBan();
            //xttb.ThongTinDat = TTin;
            xttb.Manvdangchon = TK;
            rong = xttb.Size.Width;
            dai = xttb.Size.Height;

            xttb.MdiParent = this;
            xttb.Show();
            this.ClientSize = new Size(rong, dai+190);
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
        }

        private void btnDoiMK_ItemClick(object sender, ItemClickEventArgs e)
        {
            DoiMatKhau dmk = new DoiMatKhau();
            dmk.TenDN = TenDN;
            dmk.Show();
        }

        private void btnTK_ItemClick(object sender, ItemClickEventArgs e)
        {
            DongTatCaCacTab();
            int dai = 0;
            int rong = 0;
            QLTaiKhoan qltk = new QLTaiKhoan();
            rong = qltk.Size.Width;
            dai = qltk.Size.Height;
            qltk.MdiParent = this;
            qltk.Show();
            this.ClientSize = new Size(rong, dai + 190);
        }

        private void btnQLNV_ItemClick(object sender, ItemClickEventArgs e)
        {
            DongTatCaCacTab();
            int dai = 0;
            int rong = 0;
            QLNhanVien qlnv = new QLNhanVien();
            rong = qlnv.Size.Width;
            dai = qlnv.Size.Height;
            qlnv.MdiParent = this;
            qlnv.Show();
            this.ClientSize = new Size(rong, dai + 190);
        }

        private void btnQLThucDon_ItemClick(object sender, ItemClickEventArgs e)
        {
            DongTatCaCacTab();
            int dai = 0;
            int rong = 0;
            QLThucDon qltd = new QLThucDon();
            rong = qltd.Size.Width;
            dai = qltd.Size.Height;
            qltd.MdiParent = this;
            qltd.Show();
            this.ClientSize = new Size(rong, dai + 190);
        }

        private void btnQLConThuc_ItemClick(object sender, ItemClickEventArgs e)
        {
            DongTatCaCacTab();
            int dai = 0;
            int rong = 0;
            QLLoaiMon qllm = new QLLoaiMon();
            rong = qllm.Size.Width;
            dai = qllm.Size.Height;
            qllm.MdiParent = this;
            qllm.Show();
            this.ClientSize = new Size(rong, dai + 190);
        }

        private void btnQLBan_ItemClick(object sender, ItemClickEventArgs e)
        {
            DongTatCaCacTab();
            int dai = 0;
            int rong = 0;
            QLBan ban = new QLBan();
            rong = ban.Size.Width;
            dai = ban.Size.Height;
            ban.MdiParent = this;
            ban.Show();
            this.ClientSize = new Size(rong, dai + 190);
        }

        private void btnChamCong_ItemClick(object sender, ItemClickEventArgs e)
        {
            DongTatCaCacTab();
            int dai = 0;
            int rong = 0;
            ChamCong cc = new ChamCong();
            rong = cc.Size.Width;
            dai = cc.Size.Height;
            cc.MdiParent = this;
            cc.Show();
            this.ClientSize = new Size(rong, dai + 190);
        }

        private void btnDoanhThu_ItemClick(object sender, ItemClickEventArgs e)
        {
            DoanhThu dt = new DoanhThu();
            dt.Show();
        }

        private void btnLuong_ItemClick(object sender, ItemClickEventArgs e)
        {
            TinhLuong tl = new TinhLuong();
            tl.Show();
        }

        private void btnTrangChu_ItemClick(object sender, ItemClickEventArgs e)
        {
            loaddata();
        }

        private void btnThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBoxYesNo msgyn = new MessageBoxYesNo();
            msgyn.ThongBao = "Bạn Có Muốn Thoát Không?";
            msgyn.ShowDialog();
            msgyn.Hide();
            KT = msgyn.Check;
            if (KT == "Có")
            {
                Application.Exit();
            }              
        }

        private void btnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBoxYesNo msgyn = new MessageBoxYesNo();
            msgyn.ThongBao = "Bạn Có Muốn Đăng Xuất Không?";
            msgyn.ShowDialog();
            msgyn.Hide();
            KT = msgyn.Check;
            if (KT == "Có")
            {
                this.Close();
            }               
        }
    }
}