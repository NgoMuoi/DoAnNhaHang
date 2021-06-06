using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnNhaHang
{
    public partial class MessageBoxYesNo : Form
    {
        public MessageBoxYesNo()
        {
            InitializeComponent();
        }
        public string Check { get; set; }
        public string ThongBao { get; set; }

        private void btnCo_Click(object sender, EventArgs e)
        {
            Check = "Có";
            this.Hide();
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            Check = "Không";
            this.Hide();
        }

        private void MessageBoxYesNo_Load(object sender, EventArgs e)
        {
            lblThongBao.Text = ThongBao;
        }
    }
}
