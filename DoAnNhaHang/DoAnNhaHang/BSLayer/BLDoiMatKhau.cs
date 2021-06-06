using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace DoAnNhaHang.BSLayer
{
    class BLDoiMatKhau
    {
        BLThongBao BLTB = new BLThongBao();
        public void DoiMK(string TenDN, string txtMatKhauCu, string txtMatKhauMoi, string txtXacNhan, Form DoiMK)
        {

            NhaHangEntities qlcfEntity = new NhaHangEntities();
            var tk = (from a in qlcfEntity.TAIKHOANs
                      where a.TENDANGNHAP == TenDN
                      select a).SingleOrDefault();

            if (tk != null)
            {
                if (tk.MATKHAU.Trim() == MaHoa(txtMatKhauCu) && txtMatKhauMoi == txtXacNhan)
                {
                    tk.MATKHAU = MaHoa(txtMatKhauMoi);
                    qlcfEntity.SaveChanges();
                    BLTB.Show("Đổi mật khẩu thành công");
                    DoiMK.Hide();
                }
                else
                {
                    BLTB.Show("Sai mật khẩu cũ hoặc mật khẩu mới không khớp!");
                }
            }
        }
        public string MaHoa(string MK)
        {
            string str = "";
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(MK);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hasPass = "";
            foreach (byte item in hasData)
            {
                hasPass += item;
            }
            str = hasPass.Substring(0, 15);
            return str;
        }
    }
}
