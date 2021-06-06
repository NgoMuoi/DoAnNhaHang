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
using DevExpress.XtraEditors;

namespace DoAnNhaHang
{
    public partial class DatMon : Form
    {
        public DatMon()
        {
            InitializeComponent();
        }
        public string MaBanDangChon { get; set; }
        public string MaPhieuTuDong { get; set; }
        public string MaMonTrongChiTiet { get; set; }
        public string MaMonTrongThucDon { get; set; }
        public string MaNVTrongThucDon { get; set; }
        public string MaPhieuDangChon { get; set; }
        public string KT { get; set; }

        DateTime NgayTao = DateTime.Now;
        string trangThai = "";
        string TenMon = "";
        BLThongBao bltb = new BLThongBao();
        BLDatMon bldm = new BLDatMon();
        public void Loaddata()
        {
            bldm.LayThucDon(dtgvTT);
            bldm.LoadCBBLoaiMon(cbbLoaiMon);
            bldm.ThongTinBan(MaBanDangChon, dtgvTTDat);
            trangThai = bldm.LayTrangThai(MaBanDangChon);
            if(trangThai == "Đã Đặt")
            {
                xtraTabDS.Enabled = true;
                nmrSL.Enabled = true;
                grctrlXuLy.Enabled = true;
                btnThemMonAn.Enabled = false;
                btnTaoPhieu.Enabled = false;
            }
            else
            {
                xtraTabDS.Enabled = false;
                nmrSL.Enabled = false;
                grctrlXuLy.Enabled = false;
                btnThemMonAn.Enabled = false;
                btnTaoPhieu.Enabled = true;
            }
        }

        private void DatMon_Load(object sender, EventArgs e)
        {
            Loaddata();
            nmrSL.Enabled = false;
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            MaPhieuTuDong = bldm.LayMaPhieu();
            bldm.ThemPhieu(MaPhieuTuDong, NgayTao, MaBanDangChon, MaNVTrongThucDon);
            bldm.CapNhatTrangThaiBan(MaBanDangChon,"Đã Đặt");

            xtraTabDS.Enabled = true;
            grctrlXuLy.Enabled = true;
            btnTaoPhieu.Enabled = false;
        }

        private void dtgvTT_CellClick(object sender, DataGridViewCellEventArgs e)
        {     
            try
            {
                btnThemMonAn.Enabled = true;
                int r = dtgvTT.CurrentCell.RowIndex;
                lblTenMon.Text = dtgvTT.Rows[r].Cells[1].Value.ToString().Trim();
                MaMonTrongThucDon = dtgvTT.Rows[r].Cells[0].Value.ToString().Trim();
                bldm.LayHinhAnh(MaMonTrongThucDon, pbHA);
            }
            catch
            {

            }
        }
        private void btnThemMonAn_Click(object sender, EventArgs e)
        {
            MaPhieuDangChon = bldm.LayMaPhieu1(MaBanDangChon);          
            try
            {
                bldm.ThemCTPhieu(MaPhieuDangChon, MaMonTrongThucDon, int.Parse(nmrSL.Value.ToString()));
                bldm.ThongTinBan(MaBanDangChon, dtgvTTDat);
                bltb.Show("Thêm món ăn vào thành công!");
                btnXacNhan.Enabled = true;
            }
            catch
            {
                bltb.Show("Lỗi. Không Thêm Món Trùng Nhau!");
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                bltb.Show("Đã đặt món thành công!");
                this.Hide();
            }
            catch
            {
                bltb.Show("Lỗi rồi!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int r = dtgvTTDat.CurrentCell.RowIndex;
            MessageBoxYesNo msgyn = new MessageBoxYesNo();
            msgyn.ThongBao = "Bạn Có Muốn Xóa " + dtgvTTDat.Rows[r].Cells[1].Value.ToString().Trim() + " Không?";
            msgyn.ShowDialog();
            msgyn.Hide();
            KT = msgyn.Check;
            if (KT == "Có")
            {
                try
                {
                    bldm.XoaChiTietPhieu(bldm.LayMaPhieu1(MaBanDangChon), MaMonTrongChiTiet);
                    bltb.Show("Xóa khỏi danh sách thành công!");
                    bldm.ThongTinBan(MaBanDangChon, dtgvTTDat);
                    Loaddata();
                    btnXoa.Enabled = false;
                    btnCapNhat.Enabled = false;
                }
                catch
                {
                    bltb.Show("Lỗi Rồi");
                }
            }      
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            MessageBoxYesNo msgyn = new MessageBoxYesNo();
            msgyn.ThongBao = "Bạn Có Muốn Hủy Bàn " + MaBanDangChon + " Không?";
            msgyn.ShowDialog();
            msgyn.Hide();
            KT = msgyn.Check;
            if(KT=="Có")
            {
                try
                {
                    bldm.XoaPhieu(bldm.LayMaPhieu1(MaBanDangChon));
                    bldm.CapNhatTrangThaiBan(MaBanDangChon, "Trống");
                    bltb.Show("Xóa Bàn Thành công");
                    this.Hide();
                }
                catch
                {

                }
            }       
        }
        private void txtTimKiem_EditValueChanged(object sender, EventArgs e)
        {
            bldm.TimKiemMenu(dtgvTT, txtTimKiem, cbbLoaiMon);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                bldm.CapNhatChiTietPhieu(bldm.LayMaPhieu1(MaBanDangChon), MaMonTrongChiTiet, int.Parse(nmrSLCN.Value.ToString()));
                bltb.Show("Cập Nhật Bàn Thành công");
                Loaddata();
                bldm.ThongTinBan(MaBanDangChon, dtgvTTDat);
            }
            catch
            {

            }         
        }

        private void cbbLoaiMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            bldm.TimKiemMenu(dtgvTT, txtTimKiem, cbbLoaiMon);
        }

        private void dtgvTTDat_CellClick(object sender, DataGridViewCellEventArgs e)
        {          
            int r = dtgvTTDat.CurrentCell.RowIndex;
            MaMonTrongChiTiet = dtgvTTDat.Rows[r].Cells[0].Value.ToString().Trim();
            TenMon = dtgvTTDat.Rows[r].Cells[1].Value.ToString().Trim();
            nmrSLCN.Value = int.Parse(dtgvTTDat.Rows[r].Cells[3].Value.ToString().Trim());
            lblTenMonCN.Text = TenMon;           
        }

        private void lblTenMon_TextChanged(object sender, EventArgs e)
        {
            nmrSL.Enabled = true;
        }

        private void lblTenMonCN_TextChanged(object sender, EventArgs e)
        {
            btnXoa.Enabled = true;
            btnCapNhat.Enabled = true;
        }
    }
}
