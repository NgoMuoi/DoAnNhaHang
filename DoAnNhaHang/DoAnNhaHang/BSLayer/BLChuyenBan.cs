using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace DoAnNhaHang.BSLayer
{
    class BLChuyenBan
    {
        public void LayBanCu(string MB, TextEdit txtMB, TextEdit txtTB, TextEdit txtTKV)
        {
            NhaHangEntities nh = new NhaHangEntities();
            var ban = (from p in nh.BANs
                       join q in nh.KHUVUCs on p.MAKHUVUC equals q.MAKHUVUC
                       select new
                       {
                           p.MABAN,
                           p.TENBAN,
                           q.TENKHUVUC
                       }).ToList();
            foreach (var p in ban)
            {
                if (p.MABAN.Trim() == MB.Trim())
                {
                    txtMB.Text = p.MABAN.Trim();
                    txtTB.Text = p.TENBAN.Trim();
                    txtTKV.Text = p.TENKHUVUC.Trim();
                }
            }
        }

        public void LayBan(string MaBanHienTai, TextEdit txtMaBan, TextEdit txtTenBan, TextEdit SoChoNgoi, TextEdit txtMaKV, ComboBoxEdit txtTenKV, TextEdit txtTrangThai)
        {
            NhaHangEntities nh = new NhaHangEntities();
            var ban = (from p in nh.BANs
                       join q in nh.KHUVUCs on p.MAKHUVUC equals q.MAKHUVUC
                       select new
                       {
                           p.MABAN,
                           p.TENBAN,
                           p.SOCHONGOI,
                           p.MAKHUVUC,
                           q.TENKHUVUC,
                           p.TRANGTHAI
                       }).ToList();
            foreach (var p in ban)
            {
                if (p.MABAN.Trim() == MaBanHienTai.Trim())
                {
                    txtMaBan.Text = p.MABAN.Trim();
                    txtTenBan.Text = p.TENBAN.Trim();
                    SoChoNgoi.Text = p.SOCHONGOI.ToString().Trim();
                    txtMaKV.Text = p.MAKHUVUC.Trim();
                    txtTenKV.Text = p.TENKHUVUC.Trim();
                    if (p.TRANGTHAI.Trim() == "Trống")
                    {
                        txtTrangThai.Text = "Không Có Khách";
                    }
                    else
                    {
                        txtTrangThai.Text = "Đã Có Khách";
                    }
                }
            }
        }

        public void CapNhatBan(string MaBan, string trangThai)
        {
            NhaHangEntities qlcfEntity = new NhaHangEntities();
            var Ban = (from a in qlcfEntity.BANs
                       where a.MABAN == MaBan
                       select a).SingleOrDefault();
            if (Ban != null)
            {
                Ban.TRANGTHAI = trangThai;
                qlcfEntity.SaveChanges();
            }
        }

        public void ThemChiTietPhieu(string MaPhieu, string MaMon, int SL)
        {
            NhaHangEntities qlcfEntity = new NhaHangEntities();
            CHITIETPHIEU a = new CHITIETPHIEU();
            a.MAPHIEU = MaPhieu;
            a.MAMON = MaMon;
            a.SOLUONG = SL;
            qlcfEntity.CHITIETPHIEUx.Add(a);
            qlcfEntity.SaveChanges();
        }
        public void ChuyenBan(string MBCanChuyen, string MBDich)
        {
            NhaHangEntities ql = new NhaHangEntities();
            var Item1 = (from p in ql.PHIEUx
                         where p.MABAN == MBDich && p.THANHTIEN==0
                         select new
                         {
                             p.MAPHIEU
                         }).ToList();

            if (Item1.Count() == 0)
            {
                var Item2 = (from p in ql.PHIEUx
                             where p.MABAN == MBCanChuyen && p.THANHTIEN ==0
                             select p).SingleOrDefault();
                try
                {
                    if (Item2 != null)
                    {
                        Item2.MABAN = MBDich;
                        ql.SaveChanges();
                        CapNhatBan(MBCanChuyen, "Trống");
                        CapNhatBan(MBDich, "Đã Đặt");
                    }
                }
                catch
                {

                }
            }
            else
            {
                var dsTADich = from p in ql.PHIEUx
                               join q in ql.CHITIETPHIEUx on p.MAPHIEU equals q.MAPHIEU
                               where p.MABAN == MBDich && p.THANHTIEN==0//xuly
                               select new
                               {
                                   q.MAPHIEU,
                                   q.MAMON,
                                   q.SOLUONG
                               };
                var dsTAChuyen = from p in ql.PHIEUx
                                 join q in ql.CHITIETPHIEUx on p.MAPHIEU equals q.MAPHIEU
                                 where p.MABAN == MBCanChuyen && p.THANHTIEN==0//xuly
                                 select new
                                 {
                                     q.MAPHIEU,
                                     q.MAMON,
                                     q.SOLUONG
                                 };

                foreach (var x in dsTAChuyen)
                {
                    int check = 0;
                    string maPhieu = "";
                    string maMon = "";
                    int soLuong = 0;
                    int temp = 0;
                    foreach (var y in dsTADich)
                    {
                        if (y.MAMON == x.MAMON)
                        {
                            check = 1;
                            temp = int.Parse(y.SOLUONG.ToString());
                        }
                        maPhieu = y.MAPHIEU; // ma phieu ban dich
                    }
                    maMon = x.MAMON;
                    soLuong = int.Parse(x.SOLUONG.ToString());
                    try
                    {
                        if (check == 0)
                        {
                            BLDatMon bldm = new BLDatMon();
                            ThemChiTietPhieu(maPhieu, maMon, soLuong);
                            bldm.XoaPhieu(x.MAPHIEU);
                        }
                        else
                        {
                            int tongSL = temp + soLuong;
                            BLDatMon BLDM = new BLDatMon();
                            BLDM.CapNhatChiTietPhieu(maPhieu, maMon, tongSL);
                            BLDM.XoaPhieu(x.MAPHIEU);
                        }
                    }
                    catch
                    {

                    }
                }
                CapNhatBan(MBCanChuyen, "Trống");
                CapNhatBan(MBDich, "Đã Đặt");
            }
        }
    }
}
