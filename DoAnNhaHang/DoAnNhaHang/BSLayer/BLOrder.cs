using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnNhaHang.BSLayer;

namespace DoAnNhaHang.BSLayer
{
    class BLOrder
    {
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
    }
}
