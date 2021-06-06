using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnNhaHang.BSLayer;

namespace DoAnNhaHang
{
    public partial class DoiMatKhau : Form
    {
        public DoiMatKhau()
        {
            InitializeComponent();
            this.AcceptButton = btnDoiMK;
        }
        public string TenDN { get; set; }
        BLDoiMatKhau bldmk = new BLDoiMatKhau();

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            bldmk.DoiMK(TenDN, txtMKCu.TextValue, txtMKMoi.TextValue, txtXacNhanMK.TextValue, this);
        }

        private void txtMKCu_Load(object sender, EventArgs e)
        {
            txtMKCu.ForeColor = Color.Black;
        }

        private void txtMKMoi_Load(object sender, EventArgs e)
        {
            txtMKMoi.ForeColor = Color.Black;
        }

        private void txtXacNhanMK_Load(object sender, EventArgs e)
        {
            txtXacNhanMK.ForeColor = Color.Black;
        }
    }
}
