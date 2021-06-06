using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.Drawing;

namespace DoAnNhaHang.BSLayer
{
    class BLThucDon
    {
        public void LayThucDon(DataGridView dtgvTD)
        {
            NhaHangEntities QLTDETT = new NhaHangEntities();
            var nv = (from p in QLTDETT.THUCDONs
                      join q in QLTDETT.LOAIMONs on p.MALOAIMON equals q.MALOAIMON
                      select new
                      {
                          p.MAMON,
                          p.TENMON,
                          p.DVT,
                          p.DONGIA,
                          q.TENLOAIMON
                      }).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Món");
            dt.Columns.Add("Tên Món");
            dt.Columns.Add("ĐVT");
            dt.Columns.Add("Đơn Giá");
            dt.Columns.Add("Tên Loại Món");
            foreach (var TD in nv)
            {
                dt.Rows.Add(TD.MAMON.Trim(), TD.TENMON.Trim(), TD.DVT.Trim(), TD.DONGIA.ToString(), TD.TENLOAIMON.Trim());
            }
            dtgvTD.DataSource = dt;
        }

        public void ThemTD(string MM, string TM, string DVT, int DG, string MLM, string HA)
        {
            NhaHangEntities tnv = new NhaHangEntities();
            THUCDON td = new THUCDON();
            td.MAMON = MM;
            td.TENMON = TM;
            td.DVT = DVT;
            td.DONGIA = DG;
            td.MALOAIMON = MLM;
            td.HINHANH = HA;
            tnv.THUCDONs.Add(td);
            tnv.SaveChanges();
        }

        public void XoaTD(string MaMon)
        {
            NhaHangEntities xnv = new NhaHangEntities();
            THUCDON td = new THUCDON();
            td.MAMON = MaMon;
            xnv.THUCDONs.Attach(td);
            xnv.THUCDONs.Remove(td);
            xnv.SaveChanges();
        }

        public void SuaTD(string MM, string TM, string DVT, int DG, string MLM, string HA)
        {
            NhaHangEntities std = new NhaHangEntities();
            var td = (from a in std.THUCDONs where a.MAMON == MM select a).SingleOrDefault();
            if (td != null)
            {
                td.TENMON = TM;
                td.DVT = DVT;
                td.DONGIA = DG;
                td.MALOAIMON = MLM;
                td.HINHANH = HA;
                std.SaveChanges();
            }
        }

        public void LoadTenLoaiMon(ComboBoxEdit cbbTLM)
        {
            NhaHangEntities nh = new NhaHangEntities();
            var tlm = (from p in nh.LOAIMONs
                       select new
                       {
                           tenloai = p.TENLOAIMON
                       }).ToList();
            for (int i = cbbTLM.Properties.Items.Count - 1; i >= 0; i--)
            {
                cbbTLM.Properties.Items.RemoveAt(i);
            }
            foreach (var i in tlm)
            {
                cbbTLM.Properties.Items.Add(i.tenloai.Trim());
            }
        }

        public string LayMaLoaiMon(string TenLM)
        {
            string b = "";
            NhaHangEntities nh = new NhaHangEntities();
            var maloaimon = (from p in nh.LOAIMONs
                             where p.TENLOAIMON.Trim() == TenLM
                             select new
                             {
                                 p.MALOAIMON
                             }).ToList();
            if (maloaimon.Count() != 0)
            {
                foreach (var a in maloaimon)
                    b = a.MALOAIMON;
            }
            return b;
        }

        public void TimCT(DataGridView dtgvTD, DataGridView dtgvCT)
        {
            string MM = "";
            int r = dtgvTD.CurrentCell.RowIndex;
            MM = dtgvTD.Rows[r].Cells[0].Value.ToString().Trim();
            NhaHangEntities nh = new NhaHangEntities();
            var ct = from p in nh.THUCDONs
                     join q in nh.CONGTHUCs on p.MAMON equals q.MAMON
                     where p.MAMON == MM
                     select new { q.MANGUYENLIEU, q.HAMLUONG };

            var a = from p in ct
                    join c in nh.NGUYENLIEUx on p.MANGUYENLIEU equals c.MANGUYENLIEU
                    select new { p.MANGUYENLIEU, c.TENNGUYENLIEU, p.HAMLUONG };
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Nguyên Liệu");
            dt.Columns.Add("Tên Nguyên Liệu");
            dt.Columns.Add("Hàm Lượng");
            foreach (var c in a)
            {
                dt.Rows.Add(c.MANGUYENLIEU.Trim(), c.TENNGUYENLIEU.Trim(), c.HAMLUONG.Trim());
            }
            dtgvCT.DataSource = dt;
        }

        public void LayHinhAnh(string MaMon, PictureEdit PicThucAn)
        {
            NhaHangEntities ql = new NhaHangEntities();
            var hinhAnh = from h in ql.THUCDONs
                          where h.MAMON == MaMon
                          select h;
            foreach (var item in hinhAnh)
            {
                try
                {
                    if (item.HINHANH.Trim() != "No Image")
                        PicThucAn.Image = Image.FromFile(item.HINHANH);
                    else
                        PicThucAn.Image = Image.FromFile("C:\\Users\\win 10pro\\Desktop\\QL_QUANCAFE\\Hinh Anh\\background.jpg");
                }
                catch
                {
                    PicThucAn.Image = Image.FromFile("C:\\Users\\win 10pro\\Desktop\\QL_QUANCAFE\\Hinh Anh\\background.jpg");
                }
            }
        }

        public string LayHinhAnh2(string MaMon)
        {
            NhaHangEntities ql = new NhaHangEntities();
            var HA = from h in ql.THUCDONs
                     where h.MAMON.Trim() == MaMon.Trim()
                     select h;
            foreach (var item in HA)
            {
                if (item.HINHANH == null)
                    return "No Image";
                return item.HINHANH.ToString().Trim();
            }
            return "";
        }
        public void LayHinhAnh3(string link, PictureEdit PicThucAn)
        {

            try
            {
                PicThucAn.Image = Image.FromFile(link);
            }
            catch
            {
                PicThucAn.Image = Image.FromFile(@"C:\Users\win 10pro\Desktop\QL_QUANCAFE\Hinh Anh\background.jpg");
            }

        }
    }
}
