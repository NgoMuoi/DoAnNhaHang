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
    public partial class CongThuc : Form
    {
        public CongThuc()
        {
            InitializeComponent();
        }
        BLThongBao bltb = new BLThongBao();
        BLCongThuc blct = new BLCongThuc();
        public string KT { get; set; }
        bool Them = false;
        public void Loaddata()
        {
            blct.LoadCBBTenMon(cbbTenMon);
            blct.LoadCBBTenNguyenLieu(cbbTenNL);
            blct.LayCongThuc(dtgvTT);
            grcrlTT.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;

            cbbTenMon.ResetText();
            cbbTenNL.ResetText();
            txtHamLuong.ResetText();

            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }
        private void CongThuc_Load(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            grcrlTT.Enabled = true;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;

            cbbTenMon.Enabled = true;
            cbbTenNL.Enabled = true;

            cbbTenMon.ResetText();
            cbbTenNL.ResetText();
            txtHamLuong.ResetText();

            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            MessageBoxYesNo msgyn = new MessageBoxYesNo();
            msgyn.ThongBao = "Bạn Có Muốn Xóa Không?";
            msgyn.ShowDialog();
            msgyn.Hide();
            KT = msgyn.Check;
            if (KT == "Có")
            {
                try
                {
                    string MaMon = blct.LayMaMon(cbbTenMon.Text);
                    string Manl = blct.LayMaNguyenLieu(cbbTenNL.Text);
                    blct.XoaCT(MaMon, Manl);
                    Loaddata();
                    blct.LayCongThuc(dtgvTT);
                    bltb.Show("Đã Xóa Xong");
                }
                catch
                {
                    bltb.Show("Lỗi");
                }
            }
                
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;
            grcrlTT.Enabled = true;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;

            txtHamLuong.ResetText();

            cbbTenMon.Enabled = false;
            cbbTenNL.Enabled = false;

            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string MaMon = blct.LayMaMon(cbbTenMon.Text);
            string Manl = blct.LayMaNguyenLieu(cbbTenNL.Text);
            if (Them)
            {
                try
                {
                    blct.ThemCT(MaMon, Manl, txtHamLuong.Text.Trim());
                    Loaddata();
                    blct.LayCongThuc(dtgvTT);
                    bltb.Show("Thêm Xong");
                }
                catch
                {
                    bltb.Show("Lỗi");
                }

            }
            else
            {
                try
                {
                    blct.SuaCT(MaMon, Manl, txtHamLuong.Text.Trim());
                    Loaddata();
                    blct.LayCongThuc(dtgvTT);
                    bltb.Show("Sửa Xong");
                }
                catch
                {
                    bltb.Show("Lỗi");
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void dtgvTT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dtgvTT.CurrentCell.RowIndex;
                cbbTenMon.Text = dtgvTT.Rows[r].Cells[0].Value.ToString();
                cbbTenNL.Text = dtgvTT.Rows[r].Cells[1].Value.ToString();
                txtHamLuong.Text = dtgvTT.Rows[r].Cells[2].Value.ToString();

            }
            catch
            {

            }
        }
    }
}
