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
    public partial class QLLoaiMon : Form
    {
        public QLLoaiMon()
        {
            InitializeComponent();
        }
        BLLoaiMon bllm = new BLLoaiMon();
        BLThongBao bltb = new BLThongBao();
        public string KT { get; set; }
        bool them = false;
        public void Loaddata()
        {
            bllm.LayLoaiMon(dtgvDSLM);
            bllm.TaoTenMon(cbbTenLoaiMon);
            grctlTT.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txtMaLoaiMon.ResetText();
            txtTenLoaiMon.ResetText();

            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        private void QLLoaiMon_Load(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            this.grctlTT.Enabled = true;
            this.btnHuy.Enabled = true;
            this.btnLuu.Enabled = true;

            this.txtMaLoaiMon.ResetText();
            this.txtTenLoaiMon.ResetText();

            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnSua.Enabled = false;

            this.txtMaLoaiMon.Enabled = true;
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
                    int r = dtgvDSLM.CurrentCell.RowIndex;
                    string ma = dtgvDSLM.Rows[r].Cells[0].Value.ToString();
                    bllm.XoaLM(ma);
                    Loaddata();
                    bllm.LayLoaiMon(dtgvDSLM);
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
            them = false;
            this.grctlTT.Enabled = true;
            this.btnHuy.Enabled = true;
            this.btnLuu.Enabled = true;

            txtMaLoaiMon.ResetText();
            txtTenLoaiMon.ResetText();

            this.txtMaLoaiMon.Enabled = false;
            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnSua.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (them)
            {
                try
                {
                    bllm.ThemLM(txtMaLoaiMon.Text, txtTenLoaiMon.Text);
                    Loaddata();
                    bllm.LayLoaiMon(dtgvDSLM);
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
                    bllm.SuaLM(txtMaLoaiMon.Text, txtTenLoaiMon.Text);
                    Loaddata();
                    bllm.LayLoaiMon(dtgvDSLM);
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

        private void dtgvDSLM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dtgvDSLM.CurrentCell.RowIndex;
                txtMaLoaiMon.Text = dtgvDSLM.Rows[r].Cells[0].Value.ToString();
                txtTenLoaiMon.Text = dtgvDSLM.Rows[r].Cells[1].Value.ToString();
            }
            catch
            {

            }
        }

        private void cbbTenLoaiMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            bllm.Timkiem(dtgvDSTK, cbbTenLoaiMon);
        }
    }
}
