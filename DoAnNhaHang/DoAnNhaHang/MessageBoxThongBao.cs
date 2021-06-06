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
    public partial class MessageBoxThongBao : Form
    {
        public MessageBoxThongBao()
        {
            InitializeComponent();
        }

        public string ThongBao { get; set; }

        private void btnOke_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MessageBoxThongBao_Load(object sender, EventArgs e)
        {
            lblThongBao.Text = ThongBao;
        }
    }
}
