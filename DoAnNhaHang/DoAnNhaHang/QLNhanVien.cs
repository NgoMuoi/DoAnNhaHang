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
    public partial class QLNhanVien : Form
    {
        public QLNhanVien()
        {
            InitializeComponent();
        }
        BLNhanVien blnv = new BLNhanVien();
        BLThongBao bltb = new BLThongBao();
        public string KT { get; set; }
        bool them;

        public void Loaddata()
        {
            blnv.LoadDiaChi(cbbDiaChi);
            blnv.LayNhanVien(dtgvTT);
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            this.grctrlTT.Enabled = false;

            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;

            this.txtDiaChi.ResetText();
            this.txtHoTen.ResetText();
            this.txtLuongCB.ResetText();
            this.txtMaNV.ResetText();
            this.txtNgaySinh.ResetText();
            this.txtNgayVaoLam.ResetText();
            this.cbbPhai.ResetText();
            this.txtSDT.ResetText();
        }

        private void QLNhanVien_Load(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void dtgvTT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dtgvTT.CurrentCell.RowIndex;
                txtMaNV.Text = dtgvTT.Rows[r].Cells[0].Value.ToString();
                txtHoTen.Text = dtgvTT.Rows[r].Cells[1].Value.ToString();
                cbbPhai.Text = dtgvTT.Rows[r].Cells[2].Value.ToString();
                txtNgaySinh.Text = dtgvTT.Rows[r].Cells[3].Value.ToString();
                txtDiaChi.Text = dtgvTT.Rows[r].Cells[4].Value.ToString();
                txtSDT.Text = dtgvTT.Rows[r].Cells[5].Value.ToString();
                txtNgayVaoLam.Text = dtgvTT.Rows[r].Cells[6].Value.ToString();
                txtLuongCB.Text = dtgvTT.Rows[r].Cells[7].Value.ToString();
                blnv.LayLuong(lblTongCa, lblTongTien, txtMaNV.Text, int.Parse(txtLuongCB.Text));
            }
            catch
            {

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            this.txtDiaChi.ResetText();
            this.txtHoTen.ResetText();
            this.txtLuongCB.ResetText();
            this.txtMaNV.ResetText();
            this.txtNgaySinh.ResetText();
            this.txtNgayVaoLam.ResetText();
            this.cbbPhai.ResetText();
            this.txtSDT.ResetText();

            this.txtMaNV.Enabled = true;

            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.grctrlTT.Enabled = true;

            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;

            this.txtNgayVaoLam.Text = DateTime.Now.Date.ToShortDateString();
            
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
                    int r = dtgvTT.CurrentCell.RowIndex;
                    string ma = dtgvTT.Rows[r].Cells[0].Value.ToString();
                    blnv.XoaNV(ma);
                    Loaddata();
                    blnv.LayNhanVien(dtgvTT);
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
            this.txtDiaChi.ResetText();
            this.txtHoTen.ResetText();
            this.txtLuongCB.ResetText();
            this.txtMaNV.ResetText();
            this.txtNgaySinh.ResetText();
            this.txtNgayVaoLam.ResetText();
            this.cbbPhai.ResetText();
            this.txtSDT.ResetText();

            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.grctrlTT.Enabled = true;

            this.txtMaNV.Enabled = false;
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (them)
            {
                try
                {
                    blnv.ThemNV(txtMaNV.Text, txtHoTen.Text, cbbPhai.Text, txtNgaySinh.Text, txtDiaChi.Text, txtSDT.Text, txtNgayVaoLam.Text, txtLuongCB.Text);
                    Loaddata();
                    blnv.LayNhanVien(dtgvTT);
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
                    blnv.SuaNV(txtMaNV.Text, txtHoTen.Text, cbbPhai.Text, txtNgaySinh.Text, txtDiaChi.Text, txtSDT.Text, txtNgayVaoLam.Text, txtLuongCB.Text);
                    Loaddata();
                    blnv.LayNhanVien(dtgvTT);
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

        private void cbbDiaChi_TextChanged(object sender, EventArgs e)
        {
            try
            {
                blnv.Loc(cbbDiaChi, cbbGioiTinh, txtTimKiem, dtgvTT);
                if (txtTimKiem.Text == "" && cbbDiaChi.Text == "Tất Cả" && cbbGioiTinh.Text == "Tất Cả")
                {
                    Loaddata();
                }
            }
            catch
            {

            }
        }

        private void cbbGioiTinh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                blnv.Loc(cbbDiaChi, cbbGioiTinh, txtTimKiem, dtgvTT);
                if (txtTimKiem.Text == "" && cbbDiaChi.Text == "Tất Cả" && cbbGioiTinh.Text == "Tất Cả")
                {
                    Loaddata();
                }
            }
            catch
            {

            }
        }

        private void txtTimKiem_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                blnv.Loc(cbbDiaChi, cbbGioiTinh, txtTimKiem, dtgvTT);
                if (txtTimKiem.Text == "" && cbbDiaChi.Text == "Tất Cả" && cbbGioiTinh.Text == "Tất Cả")
                {
                    Loaddata();
                }
            }
            catch
            {

            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLuongCB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
