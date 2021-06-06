using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnNhaHang.BSLayer
{
    class BLDangNhap
    {
        public int LayTaiKhoan(string user, string password)
        {
            password = MaHoa(password);
            NhaHangEntities nhahang = new NhaHangEntities();
            var tk = (from x in nhahang.TAIKHOANs
                      where x.TENDANGNHAP.Trim() == user && x.MATKHAU.Trim() == password
                      select x).ToList();      
            int a = tk.Count();
            return a;
        }

        public string LayTenNV(string user, string password)
        {
            password = MaHoa(password);
            string b = "";
            NhaHangEntities nh = new NhaHangEntities();
            var Tennv = (from p in nh.NHANVIENs join q in nh.TAIKHOANs on p.MANHANVIEN equals q.MANHANVIEN
                             where q.TENDANGNHAP.Trim() == user && q.MATKHAU.Trim() ==password
                             select new
                             {
                                 p.HOTEN
                             }).ToList();
            if (Tennv.Count() != 0)
            {
                foreach (var a in Tennv)
                    b = a.HOTEN;
            }
            return b;
        }

        public string LayQuyenNV(string user, string password)
        {
            string b = "";
            password = MaHoa(password);
            NhaHangEntities nh = new NhaHangEntities();
            var Tennv = (from p in nh.TAIKHOANs
                         where p.TENDANGNHAP.Trim() == user && p.MATKHAU.Trim() == password
                         select new
                         {
                             p.CAPQUYEN
                         }).ToList();
            if (Tennv.Count() != 0)
            {
                foreach (var a in Tennv)
                    b = a.CAPQUYEN;
            }
            return b;
        }

        public string LayMaNV(string user, string password)
        {
            password = MaHoa(password);
            string b = "";
            NhaHangEntities nh = new NhaHangEntities();
            var Tennv = (from p in nh.TAIKHOANs
                         where p.TENDANGNHAP.Trim() == user && p.MATKHAU.Trim() == password
                         select new
                         {
                             p.MANHANVIEN
                         }).ToList();
            if (Tennv.Count() != 0)
            {
                foreach (var a in Tennv)
                    b = a.MANHANVIEN;
            }
            return b;
        }

        public string LayTrangThai(string user, string password)
        {
            string b = "";
            password = MaHoa(password);
            NhaHangEntities nh = new NhaHangEntities();
            var Tennv = (from p in nh.TAIKHOANs
                         where p.TENDANGNHAP.Trim() == user && p.MATKHAU.Trim() == password
                         select new
                         {
                             p.TRANGTHAI
                         }).ToList();
            if (Tennv.Count() != 0)
            {
                foreach (var a in Tennv)
                    b = a.TRANGTHAI;
            }
            return b;
        }
        public string MaHoa(string MK)
        {
            string str = "";
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(MK);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hasPass = "";
            foreach (byte item in hasData)
            {
                hasPass += item;
            }
            str = hasPass.Substring(0, 15);
            return str;
        }
    }
}
