using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace DoAnNhaHang.BSLayer
{
    class BLTaiKhoan
    {
        public void LayThongTin(DataGridView dtgvTT)
        {
            NhaHangEntities nh = new NhaHangEntities();
            var nv = (from p in nh.TAIKHOANs
                      join q in nh.NHANVIENs on p.MANHANVIEN equals q.MANHANVIEN
                      select new
                      {
                          p.MANHANVIEN,
                          q.HOTEN,
                          p.TENDANGNHAP,
                          p.CAPQUYEN,
                          p.TRANGTHAI
                      }).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Nhân Viên");
            dt.Columns.Add("Họ Tên");
            dt.Columns.Add("Tên Đăng Nhập");
            dt.Columns.Add("Cấp Quyền");
            dt.Columns.Add("Trạng Thái");
            foreach (var TD in nv)
            {
                dt.Rows.Add(TD.MANHANVIEN.Trim(), TD.HOTEN.Trim(), TD.TENDANGNHAP.Trim(), TD.CAPQUYEN.Trim(), TD.TRANGTHAI.Trim());
            }
            dtgvTT.DataSource = dt;
        }

        public void ThemTK(string MNV, string TDN, string MK, string CQ, string TT)
        {
            NhaHangEntities tnv = new NhaHangEntities();
            TAIKHOAN td = new TAIKHOAN();
            td.MANHANVIEN = MNV;
            td.TENDANGNHAP = TDN;
            td.MATKHAU = MK;
            td.CAPQUYEN = CQ;
            td.TRANGTHAI = TT;
            tnv.TAIKHOANs.Add(td);
            tnv.SaveChanges();
        }

        public void XoaTK(string TDN)
        {
            NhaHangEntities xnv = new NhaHangEntities();
            TAIKHOAN td = new TAIKHOAN();
            td.TENDANGNHAP = TDN;
            xnv.TAIKHOANs.Attach(td);
            xnv.TAIKHOANs.Remove(td);
            xnv.SaveChanges();
        }

        public void SuaTK(string MNV, string TDN, string MK, string CQ, string TT)
        {
            NhaHangEntities std = new NhaHangEntities();
            var td = (from a in std.TAIKHOANs where a.TENDANGNHAP == TDN select a).SingleOrDefault();
            if (td != null)
            {
                td.MATKHAU = MK;
                td.CAPQUYEN = CQ;
                td.TRANGTHAI = TT;
                std.SaveChanges();
            }
        }

        public void SuaTK2(string MNV, string TDN, string CQ, string TT)
        {
            NhaHangEntities std = new NhaHangEntities();
            var td = (from a in std.TAIKHOANs where a.TENDANGNHAP == TDN select a).SingleOrDefault();
            if (td != null)
            {
                td.CAPQUYEN = CQ;
                td.TRANGTHAI = TT;
                std.SaveChanges();
            }
        }

        public string LayMaNV(string Ten)
        {
            string b = "";
            NhaHangEntities nh = new NhaHangEntities();
            var Ma = (from p in nh.NHANVIENs
                      where p.HOTEN.Trim() == Ten
                      select new
                      {
                          p.MANHANVIEN
                      }).ToList();
            if (Ma.Count() != 0)
            {
                foreach (var a in Ma)
                    b = a.MANHANVIEN;
            }
            return b;
        }

        public string LayMK(string tdn)
        {
            string b = "";
            NhaHangEntities nh = new NhaHangEntities();
            var Ma = (from p in nh.TAIKHOANs
                      where p.TENDANGNHAP.Trim() == tdn
                      select new
                      {
                          p.MATKHAU
                      }).ToList();
            if (Ma.Count() != 0)
            {
                foreach (var a in Ma)
                    b = a.MATKHAU;
            }
            return b;
        }

        public void LoadcbbTenNV(ComboBoxEdit cbb)
        {
            for (int i = cbb.Properties.Items.Count - 1; i >= 0; i--)
            {
                cbb.Properties.Items.RemoveAt(i);
            }
            NhaHangEntities nh = new NhaHangEntities();
            var HT = from a in nh.NHANVIENs
                     select new
                     {
                         a.HOTEN
                     };
            foreach (var x in HT)
            {
                cbb.Properties.Items.Add(x.HOTEN.Trim());
            }
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
