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
    public partial class ChamCong : Form
    {
        public ChamCong()
        {
            InitializeComponent();
        }
        BLChamCong blcc = new BLChamCong();
        BLThongBao bltb = new BLThongBao();
        public string KT { get; set; }
        //string a = DateTime.Now.ToString().Substring(0,10);
        private void ChamCong_Load(object sender, EventArgs e)
        {
            try
            {
                blcc.LayNhanVien(dtgvTTNV);
                blcc.LayThongTinNgayLam(dtgvTTCC);
                blcc.ThemNam(cbbNam);
                blcc.ThemThang(cbbThang);
                if (cbbCa.Text == "Tất Cả")
                {
                    btnThem.Enabled = false;
                }
                btnXoa.Enabled = false;
            }
            catch
            {

            }     
        }

        public void loaddata()
        {
            if (txtMaNV.Text == "")
                btnThem.Enabled = false; 
            else
                btnThem.Enabled = true;
        }
        private void cbbThang_TextChanged(object sender, EventArgs e)
        {
            try
            {
                blcc.TimKiemCC(dtgvTTCC, cbbThang, cbbNam, cbbCa);
                if (cbbCa.Text == "Tất Cả" && cbbThang.Text == "Tất Cả" && cbbNam.Text == "Tất Cả")
                {
                    blcc.LayThongTinNgayLam(dtgvTTCC);
                }
            }
            catch
            {

            }         
        }

        private void cbbNam_TextChanged(object sender, EventArgs e)
        {
            try
            {
                blcc.TimKiemCC(dtgvTTCC, cbbThang, cbbNam, cbbCa);
                if (cbbCa.Text == "Tất Cả" && cbbThang.Text == "Tất Cả" && cbbNam.Text == "Tất Cả")
                {
                    blcc.LayThongTinNgayLam(dtgvTTCC);
                }
            }
            catch
            {

            }           
        }

        private void cbbCa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                loaddata();
                blcc.TimKiemCC(dtgvTTCC, cbbThang, cbbNam, cbbCa);
                if (cbbCa.Text == "Tất Cả" && cbbThang.Text == "Tất Cả" && cbbNam.Text == "Tất Cả")
                {
                    blcc.LayThongTinNgayLam(dtgvTTCC);
                }
            }
            catch
            {

            }           
        }

        private void dtgvTTNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dtgvTTNV.CurrentCell.RowIndex;
                txtMaNV.Text = dtgvTTNV.Rows[r].Cells[0].Value.ToString();
                txtTenNV.Text = dtgvTTNV.Rows[r].Cells[1].Value.ToString();
                btnXoa.Enabled = false;
                cbbCaTCC.Enabled = true;
            }
            catch
            {

            }        
        }

        private void btnThem_Click(object sender, EventArgs e)
        {        
            try
            {
                blcc.ThemChamCong(txtMaNV.Text, DateTime.Now, cbbCaTCC.Text);
                bltb.Show("Đã thêm thành công " + txtTenNV.Text + ".Vào ngày " + DateTime.Now + " Ca " + cbbCaTCC.Text);
                blcc.LayThongTinNgayLam(dtgvTTCC);
                blcc.TimKiemCC(dtgvTTCC, cbbThang, cbbNam, cbbCa);
                if (cbbCa.Text == "Tất Cả" && cbbThang.Text == "Tất Cả" && cbbNam.Text == "Tất Cả")
                {
                    blcc.LayThongTinNgayLam(dtgvTTCC);
                }
                btnThem.Enabled = false;
                cbbCaTCC.Enabled = false;
            }
            catch
            {
                bltb.Show("Không Thể Thêm Trùng");
            }        
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
                    int r = dtgvTTCC.CurrentCell.RowIndex;
                    string manv = dtgvTTCC.Rows[r].Cells[0].Value.ToString();
                    string Ngaylam = dtgvTTCC.Rows[r].Cells[2].Value.ToString();
                    string ca = dtgvTTCC.Rows[r].Cells[3].Value.ToString();
                    blcc.XoaChamCong(manv, Ngaylam, ca);
                    bltb.Show("Xóa Thành Công");
                    blcc.TimKiemCC(dtgvTTCC, cbbThang, cbbNam, cbbCa);
                    if (cbbCa.Text == "Tất Cả" && cbbThang.Text == "Tất Cả" && cbbNam.Text == "Tất Cả")
                    {
                        blcc.LayThongTinNgayLam(dtgvTTCC);
                    }
                    btnXoa.Enabled = false;
                }
                catch
                {

                }
            }                  
        }

        private void txtMaNV_EditValueChanged(object sender, EventArgs e)
        {
            loaddata();
        }

        private void txtTimKiem_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                blcc.TimKiemNV(dtgvTTNV, txtTimKiem);
            }
            catch
            {

            }            
        }

        private void dtgvTTCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
            cbbCaTCC.Enabled = false;
        }
    }
}
