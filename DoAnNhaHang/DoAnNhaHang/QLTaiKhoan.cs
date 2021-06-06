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
    public partial class QLTaiKhoan : Form
    {
        public QLTaiKhoan()
        {
            InitializeComponent();
        }
        BLThongBao bltb = new BLThongBao();
        BLTaiKhoan bltk = new BLTaiKhoan();
        public string KT { get; set; }
        bool Them = false;
        private void QLTaiKhoan_Load(object sender, EventArgs e)
        {
            loaddata();
        }
        public void loaddata()
        {
            bltk.LoadcbbTenNV(cbbTenNV);
            bltk.LayThongTin(dtgvTT);
            grctlCapQuyen.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;

            this.txtMaNV.Enabled = false;
            this.txtMatKhau.Enabled = false;
            this.txtTenDN.Enabled = false;
            this.cbbTenNV.Enabled = true;
            this.cbbTrangThai.Enabled = false;

            this.txtMatKhau.ResetText();
            this.txtMaNV.ResetText();
            this.cbbTrangThai.ResetText();
            this.txtTenDN.ResetText();
            this.cbbTenNV.ResetText();
            this.rdobtnNhanVien.Checked = false;
            this.rdobtnQuanLy.Checked = false;
            this.txtMaNV.Enabled = false;
            this.cbbTenNV.Enabled = false;
        }

        private void dtgvTT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dtgvTT.CurrentCell.RowIndex;
                txtMaNV.Text = dtgvTT.Rows[r].Cells[0].Value.ToString();
                cbbTenNV.Text = dtgvTT.Rows[r].Cells[1].Value.ToString();
                txtTenDN.Text = dtgvTT.Rows[r].Cells[2].Value.ToString();
                string a = dtgvTT.Rows[r].Cells[3].Value.ToString();
                txtMatKhau.Text = bltk.LayMK(txtTenDN.Text);
                if (a == "Quản Lý")
                    rdobtnQuanLy.Checked = true;
                else
                    rdobtnNhanVien.Checked = true;
                cbbTrangThai.Text = dtgvTT.Rows[r].Cells[4].Value.ToString();
            }
            catch
            {

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            grctlCapQuyen.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;

            this.txtMaNV.Enabled = false;
            this.txtMatKhau.Enabled = true;
            this.txtTenDN.Enabled = true;
            this.cbbTrangThai.Enabled = true;

            this.txtMatKhau.ResetText();
            this.txtMaNV.ResetText();
            this.cbbTrangThai.ResetText();
            this.txtTenDN.ResetText();
            this.cbbTenNV.ResetText();
            this.rdobtnNhanVien.Checked = true;
            this.rdobtnQuanLy.Checked = true;
            this.cbbTenNV.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string tdn = txtTenDN.Text;
            MessageBoxYesNo msgyn = new MessageBoxYesNo();
            msgyn.ThongBao = "Bạn Có Muốn Xóa Không?";
            msgyn.ShowDialog();
            msgyn.Hide();
            KT = msgyn.Check;
            if (KT == "Có")
            {
                try
                {
                    bltk.XoaTK(tdn);
                    loaddata();
                    bltk.LayThongTin(dtgvTT);
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
            grctlCapQuyen.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;

            this.txtTenDN.Enabled = false;
            this.txtMaNV.Enabled = false;

            this.txtMatKhau.Enabled = true;
            this.cbbTrangThai.Enabled = true;

            this.txtMatKhau.ResetText();
            this.txtMaNV.ResetText();
            this.cbbTrangThai.ResetText();
            this.txtTenDN.ResetText();
            this.cbbTenNV.ResetText();
            this.rdobtnNhanVien.Checked = true;
            this.rdobtnQuanLy.Checked = true;
            this.cbbTenNV.Enabled = false;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loaddata();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string a;
            if (rdobtnNhanVien.Checked == true)
            {
                a = "Nhân Viên";
            }
            else
            {
                a = "Quản Lý";
            }

            if (Them)
            {
                try
                {
                    bltk.ThemTK(txtMaNV.Text, txtTenDN.Text, bltk.MaHoa(txtMatKhau.Text), a, cbbTrangThai.Text);
                    loaddata();
                    bltk.LayThongTin(dtgvTT);
                    bltb.Show("Thêm Xong");
                }
                catch
                {
                    bltb.Show("Lỗi");
                }

            }
            else
            {
                if (txtMatKhau.Text == bltk.LayMK(txtTenDN.Text))
                {
                    try
                    {
                        bltk.SuaTK2(txtMaNV.Text, txtTenDN.Text, a, cbbTrangThai.Text);
                        loaddata();
                        bltk.LayThongTin(dtgvTT);
                        bltb.Show("Sửa Xong");
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
                        bltk.SuaTK(txtMaNV.Text, txtTenDN.Text, bltk.MaHoa(txtMatKhau.Text), a, cbbTrangThai.Text);
                        loaddata();
                        bltk.LayThongTin(dtgvTT);
                        bltb.Show("Sửa Xong");
                    }
                    catch
                    {
                        bltb.Show("Lỗi");
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            loaddata();
        }

        private void txtMatKhau_EditValueChanged(object sender, EventArgs e)
        {
            this.txtMatKhau.Properties.PasswordChar = '•';
        }

        private void cbbTenNV_TextChanged(object sender, EventArgs e)
        {
            txtMaNV.Text = bltk.LayMaNV(cbbTenNV.Text);
        }
    }
}
