using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;
using System.Globalization;

namespace DoAnNhaHang.BSLayer
{
    class BLXemTTBan
    {
        public void XemTTBan(string Maban, DataGridView dvgTT)
        {
            NhaHangEntities nh = new NhaHangEntities();
            var Thucan1 = from p in nh.PHIEUx
                          join q in nh.CHITIETPHIEUx on p.MAPHIEU equals q.MAPHIEU
                          where p.MABAN == Maban && p.THANHTIEN==0
                          select new
                          {
                              q.MAMON,
                              q.SOLUONG
                          };

            var Thucan2 = from p in Thucan1
                          join q in nh.THUCDONs on p.MAMON equals q.MAMON
                          select new
                          {
                              p.SOLUONG,
                              q.TENMON,
                              q.DONGIA,
                              TONG = p.SOLUONG * q.DONGIA
                          };

            DataTable dt = new DataTable();
            dt.Columns.Add("Tên Món");
            dt.Columns.Add("Số Lượng");
            dt.Columns.Add("Thành Tiền");

            foreach (var tt in Thucan2)
            {
                dt.Rows.Add(tt.TENMON, tt.SOLUONG, tt.TONG);
            }
            dvgTT.DataSource = dt;
        }

        public int TongTien(DataGridView dgvi)
        {
            int T = 0;
            for (int i = 0; i <= dgvi.Rows.Count - 1; i++)
            {
                T += int.Parse(dgvi.Rows[i].Cells[2].Value.ToString());
            }
            return T;
        }
        public int TimSoTang()
        {
            NhaHangEntities nh = new NhaHangEntities();
            var tim = from p in nh.KHUVUCs
                      select p;
            return tim.Count();
        }
        public void XoaHet(TabControl TabPDSBan)
        {
            try
            {
                for (int i = TimSoTang() - 1; i >= 0; i--)
                    TabPDSBan.Controls.RemoveAt(i);
            }
            catch
            {

            }
        }

        public string Tach(string tach3)
        {
            string Ktach = "";
            if (tach3.Equals("000"))
                return "";
            if (tach3.Length == 3)
            {
                string tr = tach3.Trim().Substring(0, 1).ToString().Trim();
                string ch = tach3.Trim().Substring(1, 1).ToString().Trim();
                string dv = tach3.Trim().Substring(2, 1).ToString().Trim();
                if (tr.Equals("0") && ch.Equals("0"))
                    Ktach = " không trăm lẻ " + Chu(dv.ToString().Trim()) + " ";
                if (!tr.Equals("0") && ch.Equals("0") && dv.Equals("0"))
                    Ktach = Chu(tr.ToString().Trim()).Trim() + " trăm ";
                if (!tr.Equals("0") && ch.Equals("0") && !dv.Equals("0"))
                    Ktach = Chu(tr.ToString().Trim()).Trim() + " trăm lẻ " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && dv.Equals("0"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && dv.Equals("5"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi lăm ";
                if (tr.Equals("0") && ch.Equals("1") && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = " không trăm mười " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && ch.Equals("1") && dv.Equals("0"))
                    Ktach = " không trăm mười ";
                if (tr.Equals("0") && ch.Equals("1") && dv.Equals("5"))
                    Ktach = " không trăm mười lăm ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi " + Chu(dv.Trim()).Trim() + " ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && dv.Equals("0"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi lăm ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười " + Chu(dv.Trim()).Trim() + " ";

                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && dv.Equals("0"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười lăm ";

            }
            return Ktach;
        }

        public string Donvi(string so)
        {
            string Kdonvi = "";

            if (so.Equals("1"))
                Kdonvi = "";
            if (so.Equals("2"))
                Kdonvi = "nghìn";
            if (so.Equals("3"))
                Kdonvi = "triệu";
            if (so.Equals("4"))
                Kdonvi = "tỷ";
            if (so.Equals("5"))
                Kdonvi = "nghìn tỷ";
            if (so.Equals("6"))
                Kdonvi = "triệu tỷ";
            if (so.Equals("7"))
                Kdonvi = "tỷ tỷ";

            return Kdonvi;
        }

        public string Chu(string gNumber)
        {
            string result = "";
            switch (gNumber)
            {
                case "0":
                    result = "không";
                    break;
                case "1":
                    result = "một";
                    break;
                case "2":
                    result = "hai";
                    break;
                case "3":
                    result = "ba";
                    break;
                case "4":
                    result = "bốn";
                    break;
                case "5":
                    result = "năm";
                    break;
                case "6":
                    result = "sáu";
                    break;
                case "7":
                    result = "bảy";
                    break;
                case "8":
                    result = "tám";
                    break;
                case "9":
                    result = "chín";
                    break;
            }
            return result;
        }

        public string So_chu(double gNum)
        {
            if (gNum == 0)
                return "Không đồng";

            string lso_chu = "";
            string tach_mod = "";
            string tach_conlai = "";
            double Num = Math.Round(gNum, 0);
            string gN = Convert.ToString(Num);
            int m = Convert.ToInt32(gN.Length / 3);
            int mod = gN.Length - m * 3;
            string dau = "[+]";

            if (gNum < 0)
                dau = "[-]";
            dau = "";

            // Tach hang lon nhat
            if (mod.Equals(1))
                tach_mod = "00" + Convert.ToString(Num.ToString().Trim().Substring(0, 1)).Trim();
            if (mod.Equals(2))
                tach_mod = "0" + Convert.ToString(Num.ToString().Trim().Substring(0, 2)).Trim();
            if (mod.Equals(0))
                tach_mod = "000";
            // Tach hang con lai sau mod :
            if (Num.ToString().Length > 2)
                tach_conlai = Convert.ToString(Num.ToString().Trim().Substring(mod, Num.ToString().Length - mod)).Trim();

            ///don vi hang mod
            int im = m + 1;
            if (mod > 0)
                lso_chu = Tach(tach_mod).ToString().Trim() + " " + Donvi(im.ToString().Trim());
            /// Tach 3 trong tach_conlai

            int i = m;
            int _m = m;
            int j = 1;
            string tach3 = "";
            string tach3_ = "";

            while (i > 0)
            {
                tach3 = tach_conlai.Trim().Substring(0, 3).Trim();
                tach3_ = tach3;
                lso_chu = lso_chu.Trim() + " " + Tach(tach3.Trim()).Trim();
                m = _m + 1 - j;
                if (!tach3_.Equals("000"))
                    lso_chu = lso_chu.Trim() + " " + Donvi(m.ToString().Trim()).Trim();
                tach_conlai = tach_conlai.Trim().Substring(3, tach_conlai.Trim().Length - 3);

                i = i - 1;
                j = j + 1;
            }
            if (lso_chu.Trim().Substring(0, 1).Equals("k"))
                lso_chu = lso_chu.Trim().Substring(10, lso_chu.Trim().Length - 10).Trim();
            if (lso_chu.Trim().Substring(0, 1).Equals("l"))
                lso_chu = lso_chu.Trim().Substring(2, lso_chu.Trim().Length - 2).Trim();
            if (lso_chu.Trim().Length > 0)
                lso_chu = dau.Trim() + " " + lso_chu.Trim().Substring(0, 1).Trim().ToUpper() + lso_chu.Trim().Substring(1, lso_chu.Trim().Length - 1).Trim() + " đồng chẵn.";
            return lso_chu.ToString().Trim();
        }

        //check riêng
        public string LayTrangThai(string MaBanDangChon)
        {
            NhaHangEntities ql = new NhaHangEntities();
            var ban = from p in ql.BANs
                      where p.MABAN == MaBanDangChon
                      select p;
            foreach (var item in ban)
            {
                return item.TRANGTHAI.Trim();
            }
            return "";
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

        public void CapNhatPhieu(string maphieu, int gt)
        {
            NhaHangEntities qlcfEntity = new NhaHangEntities();
            var phieu = (from a in qlcfEntity.PHIEUx
                       where a.MAPHIEU == maphieu
                       select a).SingleOrDefault();
            if (phieu != null)
            {
                phieu.THANHTIEN = gt;
                qlcfEntity.SaveChanges();
            }
        }

        public void XoaChiTietPhieuKhiHuy(string MaPhieu)
        {

            NhaHangEntities qlcfEntity = new NhaHangEntities();
            var x = (from y in qlcfEntity.CHITIETPHIEUx
                     where y.MAPHIEU.Trim() == MaPhieu
                     select y).ToList();
            foreach (var a in x)
            {
                CHITIETPHIEU c = new CHITIETPHIEU();
                c.MAPHIEU = a.MAPHIEU.Trim();
                c.MAMON = a.MAMON.Trim();
                qlcfEntity.CHITIETPHIEUx.Attach(c);
                qlcfEntity.CHITIETPHIEUx.Remove(c);
                qlcfEntity.SaveChanges();
            }
        }

        public string LayMaPhieu(string MBDangChon)
        {
            NhaHangEntities ql = new NhaHangEntities();
            var mp = (from p in ql.PHIEUx
                      where p.MABAN == MBDangChon && p.THANHTIEN==0
                      select p);
            foreach (var item in mp)
            {
                return item.MAPHIEU.Trim();
            }
            return "";
        }

        public void XoaPhieu(string MaPhieu)
        {
            NhaHangEntities qlcfEntity = new NhaHangEntities();
            PHIEU p = new PHIEU();
            p.MAPHIEU = MaPhieu;
            qlcfEntity.PHIEUx.Attach(p);
            qlcfEntity.PHIEUx.Remove(p);
            qlcfEntity.SaveChanges();
        }

        public string ThongTin()
        {
            string b = "";
            Order msg = new Order();
            b = msg.TT;
            return b;
        }
    }
}
