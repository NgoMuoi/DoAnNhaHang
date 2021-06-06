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
    class BLGopBan
    {
        public void LayBanCu(string MaBanHienTai, TextEdit txtMaBan, TextEdit txtTenBan, TextEdit txtTenKV)
        {
            NhaHangEntities qlcfEntity = new NhaHangEntities();
            var ban = (from p in qlcfEntity.BANs
                       join q in qlcfEntity.KHUVUCs on p.MAKHUVUC equals q.MAKHUVUC
                       select new
                       {
                           p.MABAN,
                           p.TENBAN,
                           q.TENKHUVUC
                       }).ToList();
            foreach (var p in ban)
            {
                if (p.MABAN.Trim() == MaBanHienTai.Trim())
                {
                    txtMaBan.Text = p.MABAN.Trim();
                    txtTenBan.Text = p.TENBAN.Trim();
                    txtTenKV.Text = p.TENKHUVUC.Trim();
                }
            }
        }
        public void CapNhatPhieu(string MaBanMoi, string MaNV, string MaBanCu)
        {

            string MaPhieu = "";
            string NgayTao = "";
            NhaHangEntities qlcfEntity = new NhaHangEntities();
            var Phieu = from a in qlcfEntity.PHIEUx
                        where a.MABAN == MaBanCu
                        select a;
                        
            var Phieu2 = (from a in qlcfEntity.PHIEUx
                          where a.MABAN == MaBanCu
                          select a).ToList();
            foreach (var x in Phieu)
            {
                foreach (var y in Phieu2)
                {
                    if (x.MAPHIEU == y.MAPHIEU && x.MABAN == y.MABAN)
                    {
                        MaPhieu = x.MAPHIEU;
                        NgayTao = x.NGAYTAO.ToString();
                        MaBanCu = x.MABAN;
                        MaNV = x.MANHANVIEN;

                        y.MAPHIEU = MaPhieu;
                        y.NGAYTAO = DateTime.Parse(NgayTao);
                        y.MABAN = MaBanMoi;
                        y.MANHANVIEN = MaNV;
                        qlcfEntity.SaveChanges();
                    }
                }
            }
            MessageBox.Show("Đã gộp bàn " + MaBanCu.Trim() + " sang bàn " + MaBanMoi.Trim() + " thành công!");
        }
        public void DoiTrangThai(string MaBanDangChon)
        {
            string maBan = "";
            string tenBan = "";
            string soNguoi = "";
            string maKV = "";
            string trangThai = "";
            NhaHangEntities ql = new NhaHangEntities();
            var ban = from p in ql.BANs
                      where p.MABAN == MaBanDangChon
                      select p;
            foreach (var p in ban)
            {
                maBan = p.MABAN;
                tenBan = p.TENBAN;
                trangThai = "Đã Đặt";
                maKV = p.MAKHUVUC;
                soNguoi = p.SOCHONGOI.ToString();
                CapNhatBan(maBan, tenBan, int.Parse(soNguoi), maKV, trangThai);
            }

        }
        public void CapNhatBan(string MaBan, string TenBan, int songuoi, string MaKV, string trangThai)
        {
            NhaHangEntities qlcfEntity = new NhaHangEntities();
            var Ban = (from a in qlcfEntity.BANs
                       where a.MABAN == MaBan
                       select a).SingleOrDefault();
            if (Ban != null)
            {
                Ban.TENBAN = TenBan;
                Ban.SOCHONGOI = songuoi;
                Ban.MAKHUVUC = MaKV;
                Ban.TRANGTHAI = trangThai;
                qlcfEntity.SaveChanges();
            }
        }
    }
}
