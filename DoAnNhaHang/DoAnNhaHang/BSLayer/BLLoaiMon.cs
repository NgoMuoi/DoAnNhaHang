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
    class BLLoaiMon
    {
        public void LayLoaiMon(DataGridView dtgvLM)
        {
            NhaHangEntities nh = new NhaHangEntities();
            var LM = (from p in nh.LOAIMONs
                      select new
                      {
                          p.MALOAIMON,
                          p.TENLOAIMON
                      }).ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Loại Món");
            dt.Columns.Add("Tên Loại Món");
            foreach (var m in LM)
            {
                dt.Rows.Add(m.MALOAIMON.Trim(), m.TENLOAIMON.Trim());
            }
            dtgvLM.DataSource = dt;
        }

        public void ThemLM(string MLM, string TLM)
        {
            NhaHangEntities nh = new NhaHangEntities();
            LOAIMON lm = new LOAIMON();
            lm.MALOAIMON = MLM;
            lm.TENLOAIMON = TLM;
            nh.LOAIMONs.Add(lm);
            nh.SaveChanges();
        }

        public void XoaLM(string MLM)
        {
            NhaHangEntities nh = new NhaHangEntities();
            LOAIMON lm = new LOAIMON();
            lm.MALOAIMON = MLM;
            nh.LOAIMONs.Attach(lm);
            nh.LOAIMONs.Remove(lm);
            nh.SaveChanges();
        }

        public void SuaLM(string MLM, string TLM)
        {
            NhaHangEntities nh = new NhaHangEntities();
            var lm = (from a in nh.LOAIMONs where a.MALOAIMON == MLM select a).SingleOrDefault();
            if (lm != null)
            {
                lm.TENLOAIMON = TLM;
                nh.SaveChanges();
            }
        }

        public void TaoTenMon(ComboBoxEdit cbb)
        {
            for (int i = cbb.Properties.Items.Count - 1; i >= 0; i--)
            {
                cbb.Properties.Items.RemoveAt(i);
            }
            NhaHangEntities nh = new NhaHangEntities();
            var tenmon = from a in nh.LOAIMONs
                         group a by a.TENLOAIMON into g
                         select new
                         {
                             tenloai = g.Key
                         };
            foreach (var x in tenmon)
            {
                cbb.Properties.Items.Add(x.tenloai.Trim());
            }
        }

        public void Timkiem(DataGridView dtgv, ComboBoxEdit cbb)
        {
            NhaHangEntities nh = new NhaHangEntities();
            var timkiem = (from p in nh.LOAIMONs
                           join q in nh.THUCDONs on p.MALOAIMON equals q.MALOAIMON
                           where p.TENLOAIMON == cbb.Text
                           select new
                           {
                               q.MAMON,
                               q.TENMON,
                               q.DVT,
                               q.DONGIA
                           }).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Món");
            dt.Columns.Add("Tên Món");
            dt.Columns.Add("Đơn vị Tính");
            dt.Columns.Add("Đơn Giá");

            foreach (var a in timkiem)
            {
                dt.Rows.Add(a.MAMON.Trim(), a.TENMON.Trim(), a.DVT.Trim(), a.DONGIA);
            }
            dtgv.DataSource = dt;
        }
    }
}
