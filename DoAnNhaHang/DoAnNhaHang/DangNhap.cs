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

namespace DoAnNhaHang
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
            this.AcceptButton = btnDangNhap;
        }
        public string MaNVDangChon { get; set; }
        public string TenNVDangChon { get; set; }
        public string QuyenNVDangChon { get; set; }
        public string TenTK { get; set; }
        public string KT { get; set; }
        DateTime NgayLam = System.DateTime.Now;
        BLThongBao bltb = new BLThongBao();
        BLDangNhap bldn = new BLDangNhap();

        //public string layCa(DateTime NgayLam)
        //{
        //    int hour = NgayLam.TimeOfDay.Hours;
        //    if (hour >= 6 && hour <= 12)
        //        return "Sáng";
        //    if (hour > 12 && hour <= 18)
        //        return "Chiều";
        //    else
        //        return "Đêm";
        //}
        private void btnDong_Click(object sender, EventArgs e)
        {
            MessageBoxYesNo msgyn = new MessageBoxYesNo();
            msgyn.ThongBao = "Bạn Có Muốn Thoát Không?";
            msgyn.ShowDialog();
            msgyn.Hide();
            KT = msgyn.Check;
            if(KT=="Có")
            {
                this.Close();
                Application.Exit();
            }       
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (bldn.LayTaiKhoan(txtTenDangNhap.TextName, txtMatKhau.TextName) == 1 && bldn.LayTrangThai(txtTenDangNhap.TextName, txtMatKhau.TextName) == "Hoạt Động")
                {
                    TenNVDangChon = bldn.LayTenNV(txtTenDangNhap.TextName, txtMatKhau.TextName);
                    QuyenNVDangChon = bldn.LayQuyenNV(txtTenDangNhap.TextName, txtMatKhau.TextName);
                    MaNVDangChon = bldn.LayMaNV(txtTenDangNhap.TextName, txtMatKhau.TextName);
                    TenTK = txtTenDangNhap.TextName;
                    bltb.Show("Thành Công!");
                    Home h = new Home();
                    h.TenNV = TenNVDangChon;
                    h.Quyen = QuyenNVDangChon;
                    h.TK = MaNVDangChon;
                    h.TenDN = TenTK;
                    h.ShowDialog();
                    this.Hide();
                }
                else if(bldn.LayTaiKhoan(txtTenDangNhap.TextName, txtMatKhau.TextName) == 1 && bldn.LayTrangThai(txtTenDangNhap.TextName, txtMatKhau.TextName) == "Khóa")
                {
                    bltb.Show("Tài Khoản Đã Bị Khóa!");
                }
                else
                    bltb.Show("Sai Tên Đăng Nhập Hoặc Mật Khẩu!");
            }
            catch
            {

            }                   
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
