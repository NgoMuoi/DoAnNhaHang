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
    class BLBan
    {

        //public void DesignDgv(DataGridView dgv)
        //{
        //    dgv.BorderStyle = BorderStyle.Fixed3D;
        //    dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
        //    dgv.CellBorderStyle = DataGridViewCellBorderStyle.SunkenVertical;

        //    dgv.DefaultCellStyle.ForeColor = Color.DarkSlateBlue;
        //    dgv.DefaultCellStyle.SelectionBackColor = Color.LightGreen;
        //    dgv.DefaultCellStyle.SelectionForeColor = Color.SaddleBrown;
        //    dgv.DefaultCellStyle.Font = new Font("Time New RoMan", 9f);

        //    dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10f, FontStyle.Bold);
        //    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Bisque;
        //    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkSlateGray;

        //    dgv.BackgroundColor = Color.WhiteSmoke;
        //    dgv.EnableHeadersVisualStyles = false;
        //    dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

        //    dgv.RowTemplate.Resizable = DataGridViewTriState.True;
        //    dgv.RowTemplate.Height = 30;
        //}
        public void ThemBan(string MB, string TB, int SCN, string MKV, string TT)
        {
            NhaHangEntities nh = new NhaHangEntities();
            BAN ban = new BAN();
            ban.MABAN = MB;
            ban.TENBAN = TB;
            ban.SOCHONGOI = SCN;
            ban.MAKHUVUC = MKV;
            ban.TRANGTHAI = TT;
            nh.BANs.Add(ban);
            nh.SaveChanges();
        }

        public void XoaBan(string MB)
        {
            NhaHangEntities nh = new NhaHangEntities();
            BAN ban = new BAN();
            ban.MABAN = MB;
            nh.BANs.Attach(ban);
            nh.BANs.Remove(ban);
            nh.SaveChanges();
        }

        public void SuaBan(string MB, string TB, int SCN, string MKV, string TT)
        {
            NhaHangEntities std = new NhaHangEntities();
            var td = (from a in std.BANs where a.MABAN == MB select a).SingleOrDefault();
            if (td != null)
            {
                td.TENBAN = TB;
                td.SOCHONGOI = SCN;
                td.MAKHUVUC = MKV;
                td.TRANGTHAI = TT;
                std.SaveChanges();
            }
        }
        public void LoadCBBTenKhuVuc(ComboBoxEdit cbb)
        {
            for (int i = cbb.Properties.Items.Count - 1; i >= 0; i--)
            {
                cbb.Properties.Items.RemoveAt(i);
            }
            NhaHangEntities nh = new NhaHangEntities();
            var tkv = (from p in nh.KHUVUCs
                       select new
                       {
                           tenkv = p.TENKHUVUC
                       }).ToList();
            foreach (var i in tkv)
            {
                cbb.Properties.Items.Add(i.tenkv.Trim());
            }
        }

        public string LayMaKV(string TenKV)
        {
            string b = "";
            NhaHangEntities nh = new NhaHangEntities();
            var makv = (from p in nh.KHUVUCs
                        where p.TENKHUVUC.Trim() == TenKV
                        select new
                        {
                            p.MAKHUVUC
                        }).ToList();
            if (makv.Count() != 0)
            {
                foreach (var a in makv)
                    b = a.MAKHUVUC;
            }
            return b;
        }

        public string LayTenKV(string MaKV)
        {
            string b = "";
            NhaHangEntities nh = new NhaHangEntities();
            var tenkv = (from p in nh.KHUVUCs
                        where p.MAKHUVUC.Trim() == MaKV
                        select new
                        {
                            p.TENKHUVUC
                        }).ToList();
            if (tenkv.Count() != 0)
            {
                foreach (var a in tenkv)
                    b = a.TENKHUVUC;
            }
            return b;
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
    }
}
