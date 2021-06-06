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
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
        }
        public string MaBanDangChon { get; set; }
        public string TT { get; set; }
        BLThongBao bltb = new BLThongBao();
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDat_Click(object sender, EventArgs e)
        {
            BLOrder blod = new BLOrder();
            TT ="Tên: "+ txtTen.TextValue + ", SĐT: " + txtSDT.TextValue + ", Giờ: " + txtGio.TextValue;
            blod.CapNhatBan(MaBanDangChon, TT);
            bltb.Show("Đặt Thành Công: " + TT);
            this.Hide();
        }

        private void Order_Load(object sender, EventArgs e)
        {
            txtGio.ForeColor = Color.Black;
            txtSDT.ForeColor = Color.Black;
            txtTen.ForeColor = Color.Black;
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
