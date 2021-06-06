using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnNhaHang.BSLayer
{
    class BLChamCong
    {
        public void ThemChamCong(string MaNV, DateTime NgayLam, string Ca)
        {
            NhaHangEntities qlcfEntities = new NhaHangEntities();
            CHAMCONG cc = new CHAMCONG();

            cc.MANHANVIEN = MaNV;
            cc.NGAYLAM = NgayLam;
            cc.CA = Ca;
            qlcfEntities.CHAMCONGs.Add(cc);
            qlcfEntities.SaveChanges();
        }

        public void XoaChamCong(string MaNV, string NgayLam, string Ca)
        {
            NhaHangEntities qlcfEntities = new NhaHangEntities();
            CHAMCONG cc = new CHAMCONG();
            cc.MANHANVIEN = MaNV;
            cc.NGAYLAM = DateTime.Parse(NgayLam);
            cc.CA = Ca;
            qlcfEntities.CHAMCONGs.Attach(cc);
            qlcfEntities.CHAMCONGs.Remove(cc);
            qlcfEntities.SaveChanges();
        }
        public void LayNhanVien(DataGridView dgvNhanVien)
        {
            NhaHangEntities qlcfEntities = new NhaHangEntities();
            var nvs =
            from p in qlcfEntities.NHANVIENs
            select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã");
            dt.Columns.Add("Họ Tên");
            dt.Columns.Add("Ngày Sinh");
            foreach (var p in nvs)
            {
                dt.Rows.Add(p.MANHANVIEN.Trim(), p.HOTEN.Trim(), DateTime.Parse(p.NGAYSINH.ToString()).Date.ToShortDateString());
            }
            dgvNhanVien.DataSource = dt;
        }

        public void LayThongTinNgayLam(DataGridView dgvChamCong)
        {
            NhaHangEntities nh = new NhaHangEntities();
            var nvs = (from p in nh.CHAMCONGs
                       join q in nh.NHANVIENs on p.MANHANVIEN equals q.MANHANVIEN
                       select new
                       {
                           q.MANHANVIEN,
                           q.HOTEN,
                           p.NGAYLAM,
                           p.CA
                       }).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã");
            dt.Columns.Add("Họ Tên");
            dt.Columns.Add("Ngày Làm");
            dt.Columns.Add("Ca");
            foreach (var p in nvs)
            {
                dt.Rows.Add(p.MANHANVIEN.Trim(), p.HOTEN.Trim(), DateTime.Parse(p.NGAYLAM.ToString()).Date.ToShortDateString(), p.CA);
            }
            dgvChamCong.DataSource = dt;
        }
        public void ThemNam(ComboBoxEdit cmbNam)
        {
            for (int i = 2017; i <= 2030; i++)
            {
                cmbNam.Properties.Items.Add(i);
            }
        }

        public void ThemThang(ComboBoxEdit cbbthang)
        {
            for (int i = 1; i <= 12; i++)
            {
                cbbthang.Properties.Items.Add(i);
            }
        }
        public void TimKiemNV(DataGridView dtgvtTT, TextEdit txtTimKiem)
        {
            NhaHangEntities nh = new NhaHangEntities();
            var tim = (from p in nh.NHANVIENs
                       where p.HOTEN.Contains(txtTimKiem.Text)
                       select new
                       {
                           p.MANHANVIEN,
                           p.HOTEN,
                           p.NGAYSINH                     
                       }).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã");
            dt.Columns.Add("Họ Tên");
            dt.Columns.Add("Ngày Sinh");
            foreach (var i in tim)
            {
                dt.Rows.Add(i.MANHANVIEN.Trim(), i.HOTEN.Trim(), i.NGAYSINH.ToString().Substring(0, 10));
            }
            dtgvtTT.DataSource = dt;
        }

        public void TimKiemCC(DataGridView dtgvCC, ComboBoxEdit cbbThang, ComboBoxEdit cbbNam, ComboBoxEdit cbbCa)
        {
            //Tìm Kiếm Theo Tháng
            if(cbbNam.Text=="Tất Cả" && cbbCa.Text=="Tất Cả")
            {
                NhaHangEntities nh = new NhaHangEntities();
                var tim = (from p in nh.NHANVIENs join q in nh.CHAMCONGs on p.MANHANVIEN equals q.MANHANVIEN
                           where q.NGAYLAM.Month.ToString()==cbbThang.Text
                           select new
                           {
                               p.MANHANVIEN,
                               p.HOTEN,
                               q.NGAYLAM,
                               q.CA
                           }).ToList();
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã");
                dt.Columns.Add("Họ Tên");
                dt.Columns.Add("Ngày Làm");
                dt.Columns.Add("Ca");
                foreach (var i in tim)
                {
                    dt.Rows.Add(i.MANHANVIEN.Trim(), i.HOTEN.Trim(), i.NGAYLAM.ToString().Substring(0, 10), i.CA);
                }
                dtgvCC.DataSource = dt;
            }
            //Tìm Kiếm Theo Năm
            else if (cbbThang.Text == "Tất Cả" && cbbCa.Text == "Tất Cả")
            {
                NhaHangEntities nh = new NhaHangEntities();
                var tim = (from p in nh.NHANVIENs
                           join q in nh.CHAMCONGs on p.MANHANVIEN equals q.MANHANVIEN
                           where q.NGAYLAM.Year.ToString() == cbbNam.Text
                           select new
                           {
                               p.MANHANVIEN,
                               p.HOTEN,
                               q.NGAYLAM,
                               q.CA
                           }).ToList();
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã");
                dt.Columns.Add("Họ Tên");
                dt.Columns.Add("Ngày Làm");
                dt.Columns.Add("Ca");
                foreach (var i in tim)
                {
                    dt.Rows.Add(i.MANHANVIEN.Trim(), i.HOTEN.Trim(), i.NGAYLAM.ToString().Substring(0, 10), i.CA);
                }
                dtgvCC.DataSource = dt;
            }
            //Tìm Kiếm Theo Ca
            else if (cbbThang.Text == "Tất Cả" && cbbNam.Text == "Tất Cả")
            {
                NhaHangEntities nh = new NhaHangEntities();
                var tim = (from p in nh.NHANVIENs
                           join q in nh.CHAMCONGs on p.MANHANVIEN equals q.MANHANVIEN
                           where q.CA == cbbCa.Text
                           select new
                           {
                               p.MANHANVIEN,
                               p.HOTEN,
                               q.NGAYLAM,
                               q.CA
                           }).ToList();
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã");
                dt.Columns.Add("Họ Tên");
                dt.Columns.Add("Ngày Làm");
                dt.Columns.Add("Ca");
                foreach (var i in tim)
                {
                    dt.Rows.Add(i.MANHANVIEN.Trim(), i.HOTEN.Trim(), i.NGAYLAM.ToString().Substring(0, 10), i.CA);
                }
                dtgvCC.DataSource = dt;
            }
            //Tìm Kiếm Theo Tháng, Năm
            else if (cbbNam.Text != "Tất Cả" && cbbThang.Text!="Tất Cả" && cbbCa.Text == "Tất Cả")
            {
                NhaHangEntities nh = new NhaHangEntities();
                var tim = (from p in nh.NHANVIENs
                           join q in nh.CHAMCONGs on p.MANHANVIEN equals q.MANHANVIEN
                           where q.NGAYLAM.Month.ToString()==cbbThang.Text && q.NGAYLAM.Year.ToString() == cbbNam.Text
                           select new
                           {
                               p.MANHANVIEN,
                               p.HOTEN,
                               q.NGAYLAM,
                               q.CA
                           }).ToList();
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã");
                dt.Columns.Add("Họ Tên");
                dt.Columns.Add("Ngày Làm");
                dt.Columns.Add("Ca");
                foreach (var i in tim)
                {
                    dt.Rows.Add(i.MANHANVIEN.Trim(), i.HOTEN.Trim(), i.NGAYLAM.ToString().Substring(0, 10), i.CA);
                }
                dtgvCC.DataSource = dt;
            }
            //Tìm Kiếm Theo Tháng, Ca
            else if (cbbThang.Text!="Tất Cả" && cbbNam.Text == "Tất Cả" && cbbCa.Text != "Tất Cả")
            {
                NhaHangEntities nh = new NhaHangEntities();
                var tim = (from p in nh.NHANVIENs
                           join q in nh.CHAMCONGs on p.MANHANVIEN equals q.MANHANVIEN
                           where q.NGAYLAM.Month.ToString()==cbbThang.Text && q.CA == cbbCa.Text
                           select new
                           {
                               p.MANHANVIEN,
                               p.HOTEN,
                               q.NGAYLAM,
                               q.CA
                           }).ToList();
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã");
                dt.Columns.Add("Họ Tên");
                dt.Columns.Add("Ngày Làm");
                dt.Columns.Add("Ca");
                foreach (var i in tim)
                {
                    dt.Rows.Add(i.MANHANVIEN.Trim(), i.HOTEN.Trim(), i.NGAYLAM.ToString().Substring(0, 10), i.CA);
                }
                dtgvCC.DataSource = dt;
            }
            //Tìm Kiếm Theo Năm, Ca
            else if (cbbThang.Text == "Tất Cả" && cbbNam.Text != "Tất Cả" && cbbCa.Text != "Tất Cả")
            {
                NhaHangEntities nh = new NhaHangEntities();
                var tim = (from p in nh.NHANVIENs
                           join q in nh.CHAMCONGs on p.MANHANVIEN equals q.MANHANVIEN
                           where q.NGAYLAM.Year.ToString() == cbbNam.Text && q.CA == cbbCa.Text
                           select new
                           {
                               p.MANHANVIEN,
                               p.HOTEN,
                               q.NGAYLAM,
                               q.CA
                           }).ToList();
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã");
                dt.Columns.Add("Họ Tên");
                dt.Columns.Add("Ngày Làm");
                dt.Columns.Add("Ca");
                foreach (var i in tim)
                {
                    dt.Rows.Add(i.MANHANVIEN.Trim(), i.HOTEN.Trim(), i.NGAYLAM.ToString().Substring(0, 10), i.CA);
                }
                dtgvCC.DataSource = dt;
            }
            //Tìm Kiếm Theo Tháng, Năm, Ca
            else
            {
                NhaHangEntities nh = new NhaHangEntities();
                var tim = (from p in nh.NHANVIENs
                           join q in nh.CHAMCONGs on p.MANHANVIEN equals q.MANHANVIEN
                           where q.NGAYLAM.Month.ToString()==cbbThang.Text && q.NGAYLAM.Year.ToString() == cbbNam.Text && q.CA == cbbCa.Text
                           select new
                           {
                               p.MANHANVIEN,
                               p.HOTEN,
                               q.NGAYLAM,
                               q.CA
                           }).ToList();
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã");
                dt.Columns.Add("Họ Tên");
                dt.Columns.Add("Ngày Làm");
                dt.Columns.Add("Ca");
                foreach (var i in tim)
                {
                    dt.Rows.Add(i.MANHANVIEN.Trim(), i.HOTEN.Trim(), i.NGAYLAM.ToString().Substring(0, 10), i.CA);
                }
                dtgvCC.DataSource = dt;
            }
        }
    }
}
