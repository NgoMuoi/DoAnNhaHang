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
    public partial class QLThucDon : Form
    {
        public QLThucDon()
        {
            InitializeComponent();
        }
        bool Them = false;
        BLThongBao bltb = new BLThongBao();
        BLThucDon bltd = new BLThucDon();
        public string MaMonDangChon { get; set; }
        public string TenMonDangChon { get; set; }
        public string KiemTra { get; set; }
        public void loaddata()
        {
            bltd.LayThucDon(dtgvThucDon);
            bltd.LoadTenLoaiMon(cbbTenLoai);
            grctrlTTThucDon.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;

            this.txtMaMon.ResetText();
            this.txtTenMon.ResetText();
            this.txtDVT.ResetText();
            this.txtDonGia.ResetText();
            this.cbbTenLoai.ResetText();
            this.txtLinkHA.ResetText();
        }

        private void QLThucDon_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            this.txtMaMon.ResetText();
            this.txtTenMon.ResetText();
            this.txtDVT.ResetText();
            this.txtDonGia.ResetText();
            this.cbbTenLoai.ResetText();
            this.txtLinkHA.ResetText();
            this.txtMaMon.Focus();

            this.grctrlTTThucDon.Enabled = true;
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.txtMaMon.Enabled = true;

            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnSua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = txtMaMon.Text;
                MessageBoxYesNo msgyn = new MessageBoxYesNo();
                msgyn.ThongBao = "Bạn Có Muốn Xóa Món "+txtTenMon.Text+" Không?";
                msgyn.ShowDialog();
                msgyn.Hide();
                KiemTra = msgyn.Check;
                if (KiemTra == "Có")
                {
                    bltd.XoaTD(ma);
                    loaddata();
                    bltd.LayThucDon(dtgvThucDon);
                    bltb.Show("Đã Xóa Xong");
                }
                else
                {
                    bltb.Show("Không Xóa Được");
                }
            }
            catch
            {
                bltb.Show("Lỗi");
            }
        }

        private void dtgvThucDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dtgvThucDon.CurrentCell.RowIndex;
                txtMaMon.Text = dtgvThucDon.Rows[r].Cells[0].Value.ToString();
                txtTenMon.Text = dtgvThucDon.Rows[r].Cells[1].Value.ToString();
                txtDVT.Text = dtgvThucDon.Rows[r].Cells[2].Value.ToString();
                txtDonGia.Text = dtgvThucDon.Rows[r].Cells[3].Value.ToString();
                cbbTenLoai.Text = dtgvThucDon.Rows[r].Cells[4].Value.ToString();

                //bltd.TimCT(dtgvThucDon, dtgvCongThuc);

                bltd.LayHinhAnh(MaMonDangChon, pbHA);

                txtLinkHA.Text = bltd.LayHinhAnh2(txtMaMon.Text.Trim());

            }
            catch
            {

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;
            this.txtMaMon.ResetText();
            this.txtTenMon.ResetText();
            this.txtDVT.ResetText();
            this.txtDonGia.ResetText();
            this.cbbTenLoai.ResetText();
            this.txtLinkHA.ResetText();
            this.txtTenMon.Focus();
            this.txtMaMon.Enabled = false;

            this.grctrlTTThucDon.Enabled = true;
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;

            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnSua.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string MaLM = bltd.LayMaLoaiMon(cbbTenLoai.Text);
            if (Them)
            {
                try
                {
                    bltd.ThemTD(txtMaMon.Text, txtTenMon.Text, txtDVT.Text, int.Parse(txtDonGia.Text), MaLM, txtLinkHA.Text);
                    loaddata();
                    bltd.LayThucDon(dtgvThucDon);
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
                    bltd.SuaTD(txtMaMon.Text, txtTenMon.Text, txtDVT.Text, int.Parse(txtDonGia.Text), MaLM, txtLinkHA.Text);
                    loaddata();
                    bltd.LayThucDon(dtgvThucDon);
                    bltb.Show("Sửa Xong");
                }
                catch
                {
                    bltb.Show("Lỗi");
                }
            }
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            txtLinkHA.Text = "Không Có Ảnh";
            pbHA.Image = Image.FromFile("C:\\Users\\DELL\\Desktop\\DA_TUAN4\\DoAnNhaHang\\DoAnNhaHang\\Resources\\Menu.jpg");
        }

        private void btnDuyetHA_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtLinkHA.Text = openFileDialog1.FileName;
                pbHA.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btnSuaCT_Click(object sender, EventArgs e)
        {
            CongThuc ct = new CongThuc();
            ct.ShowDialog();
        }

        private void txtLinkHA_TextChanged(object sender, EventArgs e)
        {
            bltd.LayHinhAnh3(txtLinkHA.Text, pbHA);
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            loaddata();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            loaddata();
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void pbHA_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
