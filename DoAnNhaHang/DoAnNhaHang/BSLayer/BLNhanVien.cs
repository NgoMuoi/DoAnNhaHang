using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.Globalization;

namespace DoAnNhaHang.BSLayer
{
    class BLNhanVien
    {
        public void LayNhanVien(DataGridView dtgvNV)
        {
            NhaHangEntities QLNVETT = new NhaHangEntities();
            var nv = from p in QLNVETT.NHANVIENs
                     select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã NV");
            dt.Columns.Add("Họ Tên");
            dt.Columns.Add("Phái");
            dt.Columns.Add("Ngày Sinh");
            dt.Columns.Add("Địa Chỉ");
            dt.Columns.Add("SĐT");
            dt.Columns.Add("Ngày Vào");
            dt.Columns.Add("Lương CB");
            DateTime.Now.Date.ToShortDateString();
            foreach (var nv1 in nv)
            {
                dt.Rows.Add(nv1.MANHANVIEN.Trim(), nv1.HOTEN.Trim(), nv1.PHAI.Trim(), DateTime.Parse(nv1.NGAYSINH.ToString()).Date.ToShortDateString(), nv1.DIACHI.Trim(), nv1.SDT.Trim(), DateTime.Parse(nv1.NGAYVAOLAM.ToString()).Date.ToShortDateString(), nv1.LUONGCOBAN.ToString());
            }
            dtgvNV.DataSource = dt;
        }

        public void ThemNV(string MNV, string HT, string PH, string NS, string DC, string SDT, string NVL, string LCB)
        {
            NhaHangEntities env = new NhaHangEntities();
            NHANVIEN nv = new NHANVIEN();
            nv.MANHANVIEN = MNV;
            nv.HOTEN = HT;
            nv.PHAI = PH;
            nv.NGAYSINH = DateTime.Parse(NS);
            nv.DIACHI = DC;
            nv.SDT = SDT;
            nv.NGAYVAOLAM = DateTime.Parse(NVL);
            nv.LUONGCOBAN = int.Parse(LCB);
            env.NHANVIENs.Add(nv);
            env.SaveChanges();
        }

        public void SuaNV(string MaNV, string HT, string PH, string NS, string DC, string SDT, string NVL, string LCB)
        {
            NhaHangEntities snv = new NhaHangEntities();
            var nv = (from a in snv.NHANVIENs where a.MANHANVIEN == MaNV select a).SingleOrDefault();
            if (nv != null)
            {
                nv.HOTEN = HT;
                nv.PHAI = PH;
                nv.NGAYSINH = DateTime.Parse(NS);
                nv.DIACHI = DC;
                nv.SDT = SDT;
                nv.NGAYVAOLAM = DateTime.Parse(NVL);
                nv.LUONGCOBAN = int.Parse(LCB);
                snv.SaveChanges();
            }
        }

        public void XoaNV(string Manv)
        {
            NhaHangEntities nh = new NhaHangEntities();
            NHANVIEN nv = new NHANVIEN();
            nv.MANHANVIEN = Manv;
            nh.NHANVIENs.Attach(nv);
            nh.NHANVIENs.Remove(nv);
            nh.SaveChanges();
        }

        public void LoadDiaChi(ComboBoxEdit cbbDC)
        {
            for (int i = cbbDC.Properties.Items.Count - 1; i >= 0; i--)
            {
                cbbDC.Properties.Items.RemoveAt(i);
            }
            cbbDC.Properties.Items.Add("Tất Cả");
            NhaHangEntities nh = new NhaHangEntities();
            var dc = from p in nh.NHANVIENs group p by p.DIACHI into g select new { dc = g.Key };
            foreach (var i in dc)
            {            
                cbbDC.Properties.Items.Add(i.dc.Trim());              
            }         
        }

        public void Loc(ComboBoxEdit cbbDC, ComboBoxEdit cbbGT, ButtonEdit txtTKiem, DataGridView dtgvtt)
        {
            try
            {
                if (cbbDC.Text == "Tất Cả" && cbbGT.Text == "Tất Cả")
                {
                    try
                    {
                        NhaHangEntities nh = new NhaHangEntities();
                        var tim = (from p in nh.NHANVIENs
                                   where p.HOTEN.Contains(txtTKiem.Text)
                                   select new
                                   {
                                       p.MANHANVIEN,
                                       p.HOTEN,
                                       p.PHAI,
                                       p.NGAYSINH,
                                       p.DIACHI,
                                       p.SDT,
                                       p.NGAYVAOLAM,
                                       p.LUONGCOBAN
                                   }).ToList();
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Mã NV");
                        dt.Columns.Add("Họ Tên");
                        dt.Columns.Add("Phái");
                        dt.Columns.Add("Ngày Sinh");
                        dt.Columns.Add("Địa Chỉ");
                        dt.Columns.Add("SĐT");
                        dt.Columns.Add("Ngày Vào");
                        dt.Columns.Add("Lương CB");

                        foreach (var i in tim)
                        {
                            dt.Rows.Add(i.MANHANVIEN.Trim(), i.HOTEN.Trim(), i.PHAI.Trim(), i.NGAYSINH.ToString().Substring(0, 10), i.DIACHI.Trim(), i.SDT.Trim(), i.NGAYVAOLAM.ToString().Substring(0, 10), i.LUONGCOBAN.ToString());
                        }
                        dtgvtt.DataSource = dt;
                    }
                    catch
                    {

                    }

                }
                else if (cbbDC.Text == "Tất Cả" && cbbGT.Text != "Tất Cả")
                {
                    try
                    {
                        NhaHangEntities nh = new NhaHangEntities();
                        var tim = (from p in nh.NHANVIENs
                                   where p.HOTEN.Contains(txtTKiem.Text) && p.PHAI.Trim() == cbbGT.Text
                                   select new
                                   {
                                       p.MANHANVIEN,
                                       p.HOTEN,
                                       p.PHAI,
                                       p.NGAYSINH,
                                       p.DIACHI,
                                       p.SDT,
                                       p.NGAYVAOLAM,
                                       p.LUONGCOBAN
                                   }).ToList();
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Mã NV");
                        dt.Columns.Add("Họ Tên");
                        dt.Columns.Add("Phái");
                        dt.Columns.Add("Ngày Sinh");
                        dt.Columns.Add("Địa Chỉ");
                        dt.Columns.Add("SĐT");
                        dt.Columns.Add("Ngày Vào");
                        dt.Columns.Add("Lương CB");

                        foreach (var i in tim)
                        {
                            dt.Rows.Add(i.MANHANVIEN.Trim(), i.HOTEN.Trim(), i.PHAI.Trim(), i.NGAYSINH.ToString().Substring(0, 10), i.DIACHI.Trim(), i.SDT.Trim(), i.NGAYVAOLAM.ToString().Substring(0, 10), i.LUONGCOBAN.ToString());
                        }
                        dtgvtt.DataSource = dt;
                    }
                    catch
                    {

                    }
                }
                else if (cbbDC.Text != "Tất Cả" && cbbGT.Text == "Tất Cả")
                {
                    try
                    {
                        NhaHangEntities nh = new NhaHangEntities();
                        var tim = (from p in nh.NHANVIENs
                                   where p.HOTEN.Contains(txtTKiem.Text) && p.DIACHI == cbbDC.Text
                                   select new
                                   {
                                       p.MANHANVIEN,
                                       p.HOTEN,
                                       p.PHAI,
                                       p.NGAYSINH,
                                       p.DIACHI,
                                       p.SDT,
                                       p.NGAYVAOLAM,
                                       p.LUONGCOBAN
                                   }).ToList();
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Mã NV");
                        dt.Columns.Add("Họ Tên");
                        dt.Columns.Add("Phái");
                        dt.Columns.Add("Ngày Sinh");
                        dt.Columns.Add("Địa Chỉ");
                        dt.Columns.Add("SĐT");
                        dt.Columns.Add("Ngày Vào");
                        dt.Columns.Add("Lương CB");

                        foreach (var i in tim)
                        {
                            dt.Rows.Add(i.MANHANVIEN.Trim(), i.HOTEN.Trim(), i.PHAI.Trim(), i.NGAYSINH.ToString().Substring(0, 10), i.DIACHI.Trim(), i.SDT.Trim(), i.NGAYVAOLAM.ToString().Substring(0, 10), i.LUONGCOBAN.ToString());
                        }
                        dtgvtt.DataSource = dt;
                    }
                    catch
                    {

                    }
                }

                else
                {
                    try
                    {
                        NhaHangEntities nh = new NhaHangEntities();
                        var tim = (from p in nh.NHANVIENs
                                   where p.HOTEN.Contains(txtTKiem.Text) && p.DIACHI == cbbDC.Text && p.PHAI == cbbGT.Text
                                   select new
                                   {
                                       p.MANHANVIEN,
                                       p.HOTEN,
                                       p.PHAI,
                                       p.NGAYSINH,
                                       p.DIACHI,
                                       p.SDT,
                                       p.NGAYVAOLAM,
                                       p.LUONGCOBAN
                                   }).ToList();
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Mã NV");
                        dt.Columns.Add("Họ Tên");
                        dt.Columns.Add("Phái");
                        dt.Columns.Add("Ngày Sinh");
                        dt.Columns.Add("Địa Chỉ");
                        dt.Columns.Add("SĐT");
                        dt.Columns.Add("Ngày Vào");
                        dt.Columns.Add("Lương CB");

                        foreach (var i in tim)
                        {
                            dt.Rows.Add(i.MANHANVIEN.Trim(), i.HOTEN.Trim(), i.PHAI.Trim(), i.NGAYSINH.ToString().Substring(0, 10), i.DIACHI.Trim(), i.SDT.Trim(), i.NGAYVAOLAM.ToString().Substring(0, 10), i.LUONGCOBAN.ToString());
                        }
                        dtgvtt.DataSource = dt;
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }
        }

        public void LayLuong(LabelControl lbCa, LabelControl lbLuong, string manv, int Luongcb)
        {
            DateTime day = System.DateTime.Now;
            int tien = 0;
            NhaHangEntities nh = new NhaHangEntities();
            var ds = (from p in nh.NHANVIENs
                      join q in nh.CHAMCONGs on p.MANHANVIEN equals q.MANHANVIEN
                      where p.MANHANVIEN == manv && q.NGAYLAM.Month == day.Month && q.NGAYLAM.Year == day.Year
                      select new
                      {
                          p.MANHANVIEN
                      }).ToList();
            lbCa.Text = "Tổng Ca Tháng " + day.Month + ": " + ds.Count().ToString() + " Ca";
            tien = ds.Count() * Luongcb;
            lbLuong.Text = "Tổng Lương: " + string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", tien);
        }
    }
}

