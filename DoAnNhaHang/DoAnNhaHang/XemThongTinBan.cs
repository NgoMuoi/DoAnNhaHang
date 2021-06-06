using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnNhaHang.BSLayer;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;
using System.Globalization;

namespace DoAnNhaHang
{
    public partial class XemThongTinBan : Form
    {
        public XemThongTinBan()
        {
            InitializeComponent();
        }

        BLThongBao bltb = new BLThongBao();
        BLXemTTBan blxttb = new BLXemTTBan();
        public string MaBanDangChon { get; set; }
        public string TenBanDangChon { get; set; }
        public string Manvdangchon { get; set; }
        public string Tienxttb { get; set; }
        public string KT { get; set; }
        public double gt = 0;
        public class Ban
        {
            public SimpleButton btn;
            public Label lblTenBan;
            public ToolTip tTip;
        }

        public class Tang
        {
            public List<Ban> LBan;
        }

        public List<Ban> ListBan = new List<Ban>();
        public List<TabPage> ListTapPage = new List<TabPage>();
        public int index = 0;

        int temp = 0;
        public void loadBan()
        {
            NhaHangEntities nh = new NhaHangEntities();
            var LayKV = (from kv in nh.KHUVUCs select new { kv.MAKHUVUC, kv.TENKHUVUC }).ToList();

            foreach (var item in LayKV)
            {
                string tentang = item.MAKHUVUC.Trim();
                TabPage tb = new TabPage(tentang);
                ListTapPage.Add(tb);
                tb.Width = grctrlDSBan.Width - 10;
                tb.Text = item.TENKHUVUC.Trim();
                tb.BackColor = Color.WhiteSmoke;

                var table = from x in nh.BANs
                            join i in nh.KHUVUCs on x.MAKHUVUC equals i.MAKHUVUC
                            where i.TENKHUVUC == tb.Text
                            select new
                            {
                                x.MABAN,
                                x.TENBAN,
                                x.TRANGTHAI
                            };
                foreach (var a in table)
                {
                    Ban b = new Ban();
                    ListBan.Add(b);
                    ListBan[index].btn = new SimpleButton();
                    ListBan[index].btn.Size = new Size(50, 50);
                    ListBan[index].btn.BackColor = Color.Blue;
                    ListBan[index].btn.Name = a.MABAN.ToString();
                    ListBan[index].btn.ImageOptions.Location = ImageLocation.MiddleCenter;
                    ListBan[index].btn.AppearanceHovered.BackColor = Color.Gold;
                    ListBan[index].btn.AppearancePressed.BackColor = Color.Yellow;

                    if (a.TRANGTHAI.Trim() == "Trống")
                        this.ListBan[index].btn.ImageOptions.Image = global::DoAnNhaHang.Properties.Resources.table;
                    else if (a.TRANGTHAI.Trim() == "Đã Đặt")
                        this.ListBan[index].btn.ImageOptions.Image = global::DoAnNhaHang.Properties.Resources.Banan2_32x32_230;
                    else
                        this.ListBan[index].btn.ImageOptions.Image = global::DoAnNhaHang.Properties.Resources.BanDaDat;

                    ListBan[index].lblTenBan = new Label();
                    ListBan[index].lblTenBan.Name = a.MABAN.ToString();
                    ListBan[index].lblTenBan.Size = new Size(50, 25);
                    ListBan[index].lblTenBan.Text = a.TENBAN.Trim();
                    ListBan[index].lblTenBan.BackColor = Color.WhiteSmoke;
                    ListBan[index].lblTenBan.Font = new Font(ListBan[index].lblTenBan.Font, FontStyle.Bold);
                    ListBan[index].btn.Click += btn_Click;
                    tb.Controls.Add(ListBan[index].lblTenBan);
                    tb.Controls.Add(ListBan[index].btn);

                    if (index == temp)
                    {
                        ListBan[index].btn.Location = new Point(30, 5);
                    }
                    else
                    {
                        if (ListBan[index - 1].btn.Location.X + 150 > tb.Width)
                        {
                            ListBan[index].btn.Location = new Point(30, ListBan[index - 1].btn.Location.Y + 80);
                        }
                        else
                        {
                            ListBan[index].btn.Location = new Point(ListBan[index - 1].btn.Location.X + 70, ListBan[index - 1].btn.Location.Y);
                        }
                    }

                    ListBan[index].lblTenBan.Location = new Point(ListBan[index].btn.Location.X, ListBan[index].btn.Location.Y + 50);
                    ListBan[index].lblTenBan.TextAlign = ContentAlignment.MiddleCenter;
                    index++;
                }
                temp += table.Count();
                tb.Refresh();
                tabctrlDSBan.Controls.Add(tb);
            }
        }

        public void loadlaikhixong()
        {
            blxttb.XemTTBan(MaBanDangChon, dtgvTT);
            txtThanhTien.TextName = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", Double.Parse(blxttb.TongTien(dtgvTT).ToString()));
            Tienxttb = blxttb.TongTien(dtgvTT).ToString();
            lblBangChu.Text = "Bằng Chữ: " + blxttb.So_chu(Double.Parse(blxttb.TongTien(dtgvTT).ToString()));
            btnXuatHD.Enabled = false;
        }
        private void btn_Click(object sender, EventArgs e)
        {

            SimpleButton sb = sender as SimpleButton;
            MaBanDangChon = sb.Name.Trim();
            blxttb.XemTTBan(sb.Name, dtgvTT);
            DoiMauBan(sb, ListBan);
            Tienxttb = blxttb.TongTien(dtgvTT).ToString();
            txtThanhTien.TextName = blxttb.TongTien(dtgvTT).ToString();
            Label lb = new Label();
            TenBanDangChon = lb.Text;
            btnChonMon.Enabled = true;
            //string tt = blxttb.LayTrangThai(MaBanDangChon);
            //if (tt.Trim() == "Đã Đặt")
            //{
            //    btnChuyenBan.Enabled = true;
            //    btnGopBan.Enabled = true;
            //    btnHuy.Enabled = false;
            //}
            //else
            //{
            //    btnChuyenBan.Enabled = false;
            //    btnGopBan.Enabled = false;
            //}

            btnDatBan.Enabled = true;
            gt = Double.Parse(txtThanhTien.TextName.ToString());
            txtThanhTien.TextName = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", gt);

            if (blxttb.LayTrangThai(MaBanDangChon) == "Đã Đặt" || blxttb.LayTrangThai(MaBanDangChon) == "Trống")
            {
                lblTTKhachDT.Text = "KHÔNG CÓ THÔNG TIN";
                btnHuy.Enabled = false;
                if (blxttb.LayTrangThai(MaBanDangChon) == "Đã Đặt")
                {
                    btnDatBan.Enabled = false;
                    btnHuy.Enabled = false;
                    btnXuatHD.Enabled = true;
                    btnChuyenBan.Enabled = true;
                    btnGopBan.Enabled = true;
                }
                else if (blxttb.LayTrangThai(MaBanDangChon) == "Trống")
                {
                    btnDatBan.Enabled = true;
                    btnHuy.Enabled = false;
                    btnXuatHD.Enabled = false;
                    btnChuyenBan.Enabled = false;
                    btnGopBan.Enabled = false;
                }
            }
            else
            {
                lblTTKhachDT.Text = blxttb.LayTrangThai(MaBanDangChon);
                btnHuy.Enabled = true;
                btnDatBan.Enabled = false;
                btnXuatHD.Enabled = false;
                btnChuyenBan.Enabled = false;
                btnGopBan.Enabled = false;
            }

            lblBangChu.Text = "Bằng Chữ: " + blxttb.So_chu(gt);
        }

        public void DoiMauBan(SimpleButton btnBan, List<Ban> Bann)
        {
            for (int i = 0; i <= Bann.Count - 1; i++)
            {
                if (btnBan.Name == Bann[i].btn.Name)
                {
                    Bann[i].lblTenBan.BackColor = Color.Yellow;
                    lblHienThi.Text = Bann[i].lblTenBan.Text;
                }
                else
                {
                    Bann[i].lblTenBan.BackColor = Color.WhiteSmoke;
                }
            }
        }

        private void XemThongTinBan_Load(object sender, EventArgs e)
        {
            loadBan();
            btnChonMon.Enabled = false;
            btnDatBan.Enabled = false;
            btnGopBan.Enabled = false;
            btnChuyenBan.Enabled = false;
            btnXuatHD.Enabled = false;
            btnHuy.Enabled = false;
        }

        public void ReloadBan()
        {
            try
            {
                blxttb.XoaHet(tabctrlDSBan);
                loadBan();
            }
            catch
            {

            }
        }

        private void btnChonMon_Click(object sender, EventArgs e)
        {
            DatMon dat = new DatMon();
            dat.MaBanDangChon = MaBanDangChon;
            dat.MaNVTrongThucDon = Manvdangchon;
            dat.ShowDialog();
            dat.Hide();
            ReloadBan();
            loadlaikhixong();
        }

        private void btnTraLai_Click(object sender, EventArgs e)
        {
            ReloadBan();
            blxttb.XemTTBan(MaBanDangChon, dtgvTT);
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            ChuyenBan cb = new ChuyenBan();
            cb.MaBanCu = MaBanDangChon;
            cb.ShowDialog();
            cb.Hide();
            ReloadBan();
            loadlaikhixong();
            lblHienThi.Text = "Chưa Chọn Bàn";
        }

        private void btnGopBan_Click(object sender, EventArgs e)
        {
            GopBan gb = new GopBan();
            gb.MaBanCu = MaBanDangChon;
            gb.ShowDialog();
            gb.Hide();
            ReloadBan();
            loadlaikhixong();
        }

        private void btnDatBan_Click(object sender, EventArgs e)
        {
            Order od = new Order();
            od.MaBanDangChon = MaBanDangChon;
            od.ShowDialog();
            od.Hide();
            ReloadBan();
            loadlaikhixong();
            lblTTKhachDT.Text = blxttb.LayTrangThai(MaBanDangChon);
            btnHuy.Enabled = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            string trangThai = blxttb.LayTrangThai(MaBanDangChon);
            MessageBoxYesNo msgyn = new MessageBoxYesNo();
            msgyn.ThongBao = "Bạn Có Muốn Hủy Bàn "+MaBanDangChon+" Không?";
            msgyn.ShowDialog();
            msgyn.Hide();
            KT = msgyn.Check;
            if(KT == "Có")
            {
                try
                {
                    if (trangThai.Trim() != "Đã Đặt" && trangThai.Trim() != "Trống")
                    {

                        blxttb.CapNhatBan(MaBanDangChon, "Trống");
                        bltb.Show("Bạn đã hủy bàn thành công!");
                        ReloadBan();
                    }
                    else if (trangThai.Trim() == "Đã Đặt")
                    {
                        blxttb.XoaPhieu(blxttb.LayMaPhieu(MaBanDangChon));
                        blxttb.CapNhatBan(MaBanDangChon, "Trống");
                        bltb.Show("Bạn đã hủy bàn thành công!");
                        ReloadBan();
                        loadlaikhixong();
                    }
                    else
                        lblTTKhachDT.Text = "Thông Tin Khách Đặt Trước: ";
                }
                catch
                {

                }
            }
            
        }

        private void btnXuatHD_Click(object sender, EventArgs e)
        {
            XuatBill xb = new XuatBill();
            xb.TenBan = MaBanDangChon;
            xb.TenBan2 = TenBanDangChon;
            xb.BangSo = txtThanhTien.TextName.ToString();
            xb.BangChu = lblBangChu.Text;
            xb.TongTien = gt.ToString();
            xb.MaPhieu = blxttb.LayMaPhieu(MaBanDangChon);
            xb.Tien = Tienxttb;
            xb.ShowDialog();
            xb.Hide();
            ReloadBan();
            loadlaikhixong();
            lblHienThi.Text = "Chưa Chọn Bàn";
        }
    }
}
