using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;
using DoAnNhaHang.BSLayer;

namespace DoAnNhaHang
{
    public partial class DoanhThu : Form
    {
        public DoanhThu()
        {
            InitializeComponent();
        }
        BLChamCong blcc = new BLChamCong();
        private void DoanhThu_Load(object sender, EventArgs e)
        {
            blcc.ThemThang(cbbThang);
            blcc.ThemNam(cbbNam);
            DateTime day = System.DateTime.Now;
            cbbThang.Text = (day.Month - 1).ToString();
            cbbNam.Text = day.Year.ToString();
        }

        private void btnInThongKe_Click(object sender, EventArgs e)
        {
            string st = "Data Source=DESKTOP-DSC536G; Initial Catalog=QuanLyNhaHang; Integrated Security=True";
            SqlConnection sql = new SqlConnection(st);
            sql.Open();
            SqlCommand cmd = new SqlCommand("select * from DOANHTHU where Thang ='" + cbbThang.Text + "' and Nam ='" + cbbNam.Text + "'", sql);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            sql.Close();
            RPDoanhThu rp = new RPDoanhThu();
            rp.DataSource = dt;
            rp.DataMember = "DOANHTHU";
            rp.ShowPreview();
            this.Hide();
        }
    }
}
