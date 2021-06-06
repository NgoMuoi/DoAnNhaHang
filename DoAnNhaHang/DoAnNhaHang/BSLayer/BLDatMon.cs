using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnNhaHang.BSLayer;
using System.Data;
using System.Drawing;
using DevExpress.XtraEditors;

namespace DoAnNhaHang.BSLayer
{
    class BLDatMon
    {
        public void LayThucDon(DataGridView dgvThucDon)
        {
            Image img = null;
            NhaHangEntities ql = new NhaHangEntities();
            var p = from i in ql.THUCDONs
                    select new
                    {
                        i.MAMON,
                        i.TENMON,
                        i.DONGIA,
                        i.HINHANH
                    };
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Món");
            dt.Columns.Add("Tên Món");
            dt.Columns.Add("Đơn Giá");
            dt.Columns.Add("Hình Ảnh");
            foreach (var i in p)
            {
                dgvThucDon.RowTemplate.Height = 110;             
                try
                {
                    if (i.HINHANH.Trim() != "No Image" || i.HINHANH.Trim() == "NULL")
                        img = Image.FromFile(i.HINHANH);
                    else
                        //img = Image.FromFile(@"C:\Users\win 10pro\Desktop\QL_QUANCAFE\Hinh Anh\background.jpg");
                    dgvThucDon.Rows.Add(i.MAMON.Trim(), i.TENMON.Trim(), i.DONGIA.ToString().Trim(), img);
                }
                catch
                {
                    //img = Image.FromFile(@"C:\Users\win 10pro\Desktop\QL_QUANCAFE\Hinh Anh\background.jpg");
                    dgvThucDon.Rows.Add(i.MAMON.Trim(), i.TENMON.Trim(), i.DONGIA.ToString().Trim(), img);
                }
            }

        }
        public void LoadCBBLoaiMon(ComboBoxEdit cbb)
        {
            for (int i = cbb.Properties.Items.Count - 1; i >= 0; i--)
            {
                cbb.Properties.Items.RemoveAt(i);
            }
            NhaHangEntities nh = new NhaHangEntities();
            var TenLoai = (from p in nh.LOAIMONs
                       select new
                       {
                           tenloai = p.TENLOAIMON
                       }).ToList();
            foreach (var i in TenLoai)
            {
                cbb.Properties.Items.Add(i.tenloai.Trim());
            }
        }
        public string LayTrangThai(string MaBanDangChon)
        {
            string b = "";
            NhaHangEntities nh = new NhaHangEntities();
            var tt = (from p in nh.BANs
                      where p.MABAN.Trim() == MaBanDangChon
                      select new
                      {
                          p.TRANGTHAI
                      }).ToList();
            if (tt.Count() != 0)
            {
                foreach (var a in tt)
                    b = a.TRANGTHAI;
            }
            return b;
        }
        public void ThongTinBan(string MaBan, DataGridView dgvChiTietBan)
        {
            NhaHangEntities ql = new NhaHangEntities();
            var Thucan1 = from p in ql.PHIEUx
                          join q in ql.CHITIETPHIEUx on p.MAPHIEU equals q.MAPHIEU
                          where p.MABAN == MaBan && p.THANHTIEN==0
                          select new
                          {
                              q.MAMON,
                              q.SOLUONG
                          };
            var Thucan2 = from p in Thucan1
                          join q in ql.THUCDONs on p.MAMON equals q.MAMON
                          select new { p.SOLUONG, q.TENMON, q.DONGIA, p.MAMON };
            DataTable data = new DataTable();
            data.Columns.Add("Mã Món");
            data.Columns.Add("Tên Món");
            data.Columns.Add("Đơn Giá");
            data.Columns.Add("Số Lượng");
            foreach (var q in Thucan2)
            {
                data.Rows.Add(q.MAMON.Trim(), q.TENMON.Trim(), q.DONGIA.ToString().Trim(), q.SOLUONG.ToString().Trim());
            }
            dgvChiTietBan.DataSource = data;
        }
        public string LayMaPhieu()
        {
            int max1 = 0;
            int max2 = 0;
            NhaHangEntities ql = new NhaHangEntities();
            var ma1 = from p in ql.PHIEUx
                      select new
                      {
                          p.MAPHIEU
                      };

            foreach (var i in ma1)
            {
                if (max2 < int.Parse(i.MAPHIEU.Trim()))
                {
                    max2 = int.Parse(i.MAPHIEU.Trim());                 
                }
            }
            if (max1 == max2 || max1 > max2)
                return (max1 + 1).ToString();
            return (max2 + 1).ToString();
        }

        public void ThemPhieu(string MaPhieu, DateTime NgayTao, string MaBan, string MaNV)
        {
            NhaHangEntities nh = new NhaHangEntities();
            PHIEU p = new PHIEU();
            p.MAPHIEU = MaPhieu;
            p.NGAYTAO = NgayTao;
            p.MABAN = MaBan;
            p.MANHANVIEN = MaNV;
            p.THANHTIEN = 0;
            nh.PHIEUx.Add(p);
            nh.SaveChanges();
        }

        public void CapNhatTrangThaiBan(string MaBan, string trangThai)
        {
            NhaHangEntities nh = new NhaHangEntities();
            var Ban = (from a in nh.BANs
                       where a.MABAN == MaBan
                       select a).SingleOrDefault();
            if (Ban != null)
            {
                Ban.TRANGTHAI = trangThai;
                nh.SaveChanges();
            }
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
                        PicThucAn.Image = Image.FromFile("@C:\\Users\\win 10pro\\Desktop\\QL_QUANCAFE\\Hinh Anh\\background.jpg");
                }
                catch
                {
                    PicThucAn.Image = Image.FromFile("@C:\\Users\\win 10pro\\Desktop\\QL_QUANCAFE\\Hinh Anh\\background.jpg");
                }
            }
        }
        public void ThemCTPhieu(string MaPhieu, string Mamon, int SL)
        {
            NhaHangEntities env = new NhaHangEntities();
            CHITIETPHIEU nv = new CHITIETPHIEU();
            nv.MAPHIEU = MaPhieu;
            nv.MAMON = Mamon;
            nv.SOLUONG = SL;
            env.CHITIETPHIEUx.Add(nv);
            env.SaveChanges();
        }
        public string LayMaPhieu1(string MBDangChon)
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

        public void XoaChiTietPhieu(string MaPhieu, string MaMon)
        {
            NhaHangEntities qlcfEntity = new NhaHangEntities();
            CHITIETPHIEU c = new CHITIETPHIEU();
            c.MAPHIEU = MaPhieu;
            c.MAMON = MaMon;
            qlcfEntity.CHITIETPHIEUx.Attach(c);
            qlcfEntity.CHITIETPHIEUx.Remove(c);
            qlcfEntity.SaveChanges();
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


        public void CapNhatChiTietPhieu(string MaPhieu, string MaMon, int Soluong)
        {
            NhaHangEntities snv = new NhaHangEntities();
            var phieu = (from a in snv.CHITIETPHIEUx
                         where a.MAPHIEU == MaPhieu && a.MAMON ==MaMon
                         select a).SingleOrDefault();
            if (phieu != null)
            {
                phieu.SOLUONG = Soluong;
                snv.SaveChanges();
            }
        }

        public void TimKiemMenu(DataGridView dgvThucDon, TextEdit txtTimKiem, ComboBoxEdit cmbLoaiMon)
        {
            Image img = null;
            if (cmbLoaiMon.Text == "Tất Cả")
            {
                NhaHangEntities ql = new NhaHangEntities();
                var p = from i in ql.THUCDONs
                        where i.TENMON.Contains(txtTimKiem.Text)
                        select new
                        {
                            i.MAMON,
                            i.TENMON,
                            i.HINHANH,
                            i.DONGIA
                        };
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã Món");
                dt.Columns.Add("Tên Món");
                dt.Columns.Add("Đơn Giá");
                dt.Columns.Add("Hình Ảnh");
                dgvThucDon.Rows.Clear();
                foreach (var i in p)
                {

                    dgvThucDon.RowTemplate.Height = 110;
                    try
                    {
                        if (i.HINHANH.Trim() != "No Image")
                            img = Image.FromFile(i.HINHANH);
                        else
                            img = Image.FromFile("@C:\\Users\\win 10pro\\Desktop\\QL_QUANCAFE\\Hinh Anh\\background.jpg");
                        dgvThucDon.Rows.Add(i.MAMON.Trim(), i.TENMON.Trim(), i.DONGIA.ToString().Trim(), img);
                    }
                    catch
                    {
                        img = Image.FromFile("@C:\\Users\\win 10pro\\Desktop\\QL_QUANCAFE\\Hinh Anh\\background.jpg");
                        dgvThucDon.Rows.Add(i.MAMON.Trim(), i.TENMON.Trim(), i.DONGIA.ToString().Trim(), img);
                    }

                }

            }
            else
            {
                NhaHangEntities ql = new NhaHangEntities();
                var p = from i in ql.THUCDONs
                        join x in ql.LOAIMONs on i.MALOAIMON equals x.MALOAIMON
                        where i.TENMON.Contains(txtTimKiem.Text) && x.TENLOAIMON.Trim() == cmbLoaiMon.Text
                        select new
                        {
                            i.MAMON,
                            i.TENMON,
                            i.DONGIA,
                            i.HINHANH
                        };
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã Món");
                dt.Columns.Add("Tên Món");
                dt.Columns.Add("Đơn Giá");
                dt.Columns.Add("Hình Ảnh");
                dgvThucDon.Rows.Clear();
                foreach (var i in p)
                {

                    dgvThucDon.RowTemplate.Resizable = DataGridViewTriState.True;
                    dgvThucDon.RowTemplate.Height = 110;
                    try
                    {
                        if (i.HINHANH.Trim() != "No Image")
                            img = Image.FromFile(i.HINHANH);
                        else
                            img = Image.FromFile("@C:\\Users\\win 10pro\\Desktop\\QL_QUANCAFE\\Hinh Anh\\background.jpg");
                        dgvThucDon.Rows.Add(i.MAMON.Trim(), i.TENMON.Trim(), i.DONGIA.ToString().Trim(), img);
                    }
                    catch
                    {
                        img = Image.FromFile("@C:\\Users\\win 10pro\\Desktop\\QL_QUANCAFE\\Hinh Anh\\background.jpg");
                        dgvThucDon.Rows.Add(i.MAMON.Trim(), i.TENMON.Trim(), i.DONGIA.ToString().Trim(), img);
                    }

                }
            }           
        }
    }
}
