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
    class BLCongThuc
    {
        public void LayCongThuc(DataGridView dtgvCT)
        {
            NhaHangEntities nh = new NhaHangEntities();
            var CT1 = (from p in nh.THUCDONs
                       join q in nh.CONGTHUCs on p.MAMON equals q.MAMON
                       select new
                       {
                           p.TENMON,
                           q.MANGUYENLIEU,
                           q.HAMLUONG
                       }).ToList();

            var CT2 = (from x in CT1
                       join y in nh.NGUYENLIEUx on x.MANGUYENLIEU equals y.MANGUYENLIEU
                       select new
                       {
                           x.TENMON,
                           y.TENNGUYENLIEU,
                           x.HAMLUONG
                       }).ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("Tên Món Ăn");
            dt.Columns.Add("Tên Nguyên Liệu");
            dt.Columns.Add("Hàm Lượng");
            foreach (var TD in CT2)
            {
                dt.Rows.Add(TD.TENMON.Trim(), TD.TENNGUYENLIEU.Trim(), TD.HAMLUONG.Trim());
            }
            dtgvCT.DataSource = dt;
        }

        public void ThemCT(string MM, string MNL, string HL)
        {
            NhaHangEntities nh = new NhaHangEntities();
            CONGTHUC ct = new CONGTHUC();
            ct.MAMON = MM;
            ct.MANGUYENLIEU = MNL;
            ct.HAMLUONG = HL;
            nh.CONGTHUCs.Add(ct);
            nh.SaveChanges();
        }

        public void XoaCT(string MM, string MNL)
        {
            NhaHangEntities nh = new NhaHangEntities();
            CONGTHUC ct = new CONGTHUC();
            ct.MAMON = MM;
            ct.MANGUYENLIEU = MNL;
            nh.CONGTHUCs.Attach(ct);
            nh.CONGTHUCs.Remove(ct);
            nh.SaveChanges();
        }

        public void SuaCT(string MM, string MNL, string HL)
        {
            NhaHangEntities std = new NhaHangEntities();
            var td = (from a in std.CONGTHUCs where a.MAMON == MM && a.MANGUYENLIEU == MNL select a).SingleOrDefault();
            if (td != null)
            {
                td.HAMLUONG = HL;
                std.SaveChanges();
            }
        }

        public string LayMaMon(string TenM)
        {
            string b = "";
            NhaHangEntities nh = new NhaHangEntities();
            var mamon = (from p in nh.THUCDONs
                         where p.TENMON.Trim() == TenM
                         select new
                         {
                             p.MAMON
                         }).ToList();
            if (mamon.Count() != 0)
            {
                foreach (var a in mamon)
                    b = a.MAMON;
            }
            return b;
        }

        public string LayMaNguyenLieu(string TenNguyenLieu)
        {
            string b = "";
            NhaHangEntities nh = new NhaHangEntities();
            var manl = (from p in nh.NGUYENLIEUx
                        where p.TENNGUYENLIEU.Trim() == TenNguyenLieu
                        select new
                        {
                            p.MANGUYENLIEU
                        }).ToList();
            if (manl.Count() != 0)
            {
                foreach (var a in manl)
                    b = a.MANGUYENLIEU;
            }
            return b;
        }

        public void LoadCBBTenMon(ComboBoxEdit cbbTM)
        {
            for (int i = cbbTM.Properties.Items.Count - 1; i >= 0; i--)
            {
                cbbTM.Properties.Items.RemoveAt(i);
            }
            NhaHangEntities nh = new NhaHangEntities();
            var tm = (from p in nh.THUCDONs
                      select new
                      {
                          tenmon = p.TENMON
                      }).ToList();
            foreach (var i in tm)
            {
                cbbTM.Properties.Items.Add(i.tenmon.Trim());
            }
        }

        public void LoadCBBTenNguyenLieu(ComboBoxEdit cbbTNL)
        {
            for (int i = cbbTNL.Properties.Items.Count - 1; i >= 0; i--)
            {
                cbbTNL.Properties.Items.RemoveAt(i);
            }
            NhaHangEntities nh = new NhaHangEntities();
            var tnl = (from p in nh.NGUYENLIEUx
                       select new
                       {
                           TenNguyenLieu = p.TENNGUYENLIEU
                       }).ToList();
            foreach (var i in tnl)
            {
                cbbTNL.Properties.Items.Add(i.TenNguyenLieu.Trim());
            }
        }
    }
}
