
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DoAnNhaHang.BSLayer;

namespace DoAnNhaHang
{
    public partial class QLBan : Form
    {
        public QLBan()
        {
            InitializeComponent();
        }
        int temp = 0;
        bool them = false;

        BLBan blb = new BLBan();
        BLThongBao bltb = new BLThongBao();
        public string KT { get; set; }
        public class ban
        {
            public SimpleButton btn;
            public Label lbl;
            public Label lblSCN;
            public Label lblTT;
        }

        public class Tang
        {
            public List<ban> Listban;
        }

        public List<ban> Lban = new List<ban>();
        public List<TabPage> Ltabpage = new List<TabPage>();
        public int i = 0;

        public void loadBan()
        {
            blb.XoaHet(tabcrlBan);
            NhaHangEntities nh = new NhaHangEntities();
            var kv = from x in nh.KHUVUCs select x;
            foreach (var x in kv)
            {
                string mkv = x.MAKHUVUC.Trim();
                TabPage tp = new TabPage(mkv);
                Ltabpage.Add(tp);
                tp.Width = this.Width / 2;
                tp.Text = x.TENKHUVUC.Trim();
                tp.BackColor = Color.LightSalmon;

                var ban = from y in nh.BANs
                          join z in nh.KHUVUCs
                          on y.MAKHUVUC equals z.MAKHUVUC
                          where z.TENKHUVUC == tp.Text
                          select new
                          {
                              y.MABAN,
                              y.TENBAN,
                              y.TRANGTHAI,
                              y.SOCHONGOI,
                              z.MAKHUVUC
                          };
                foreach (var b in ban)
                {
                    ban bann = new ban();
                    Lban.Add(bann);
                    Lban[i].btn = new SimpleButton();
                    Lban[i].btn.Size = new Size(50, 50);
                    Lban[i].btn.BackColor = Color.Blue;
                    Lban[i].btn.Name = b.MABAN.ToString().Trim();
                    Lban[i].btn.ImageOptions.Location = ImageLocation.MiddleCenter;
                    Lban[i].btn.AppearanceHovered.BackColor = Color.Khaki;
                    Lban[i].btn.AppearancePressed.BackColor = Color.IndianRed;
                    if (b.TRANGTHAI.Trim() == "Trống")
                        this.Lban[i].btn.ImageOptions.Image = global::DoAnNhaHang.Properties.Resources.table;
                    else if (b.TRANGTHAI.Trim() == "Đã Đặt")
                        this.Lban[i].btn.ImageOptions.Image = global::DoAnNhaHang.Properties.Resources.Banan2_32x32_230;
                    else
                        this.Lban[i].btn.ImageOptions.Image = global::DoAnNhaHang.Properties.Resources.BanDaDat;

                    Lban[i].lblSCN = new Label();
                    Lban[i].lblSCN.Text = b.SOCHONGOI.ToString().Trim();
                    Lban[i].lblSCN.Visible = false;

                    Lban[i].lblTT = new Label();
                    Lban[i].lblTT.Text = b.TRANGTHAI.Trim();
                    Lban[i].lblTT.Visible = false;

                    Lban[i].lbl = new Label();
                    Lban[i].lbl.Name = b.MAKHUVUC.ToString();
                    Lban[i].lbl.Size = new Size(50, 25);
                    Lban[i].lbl.Text = b.TENBAN.Trim();
                    Lban[i].lbl.BackColor = Color.WhiteSmoke;
                    Lban[i].lbl.Font = new Font(Lban[i].lbl.Font, FontStyle.Bold);
                    Lban[i].btn.Click += btn_Click;
                    tp.Controls.Add(Lban[i].lbl);
                    tp.Controls.Add(Lban[i].btn);

                    if (i == temp)
                    {
                        Lban[i].btn.Location = new Point(30, 5);
                    }
                    else
                    {
                        if (Lban[i - 1].btn.Location.X + 150 > tp.Width)
                        {
                            Lban[i].btn.Location = new Point(30, Lban[i - 1].btn.Location.Y + 80);
                        }
                        else
                        {
                            Lban[i].btn.Location = new Point(Lban[i - 1].btn.Location.X + 80, Lban[i - 1].btn.Location.Y);
                        }
                    }
                    Lban[i].lbl.Location = new Point(Lban[i].btn.Location.X, Lban[i].btn.Location.Y + 50);
                    Lban[i].lbl.TextAlign = ContentAlignment.MiddleCenter;
                    i++;
                }
                temp += ban.Count();
                tp.Refresh();
                tabcrlBan.Controls.Add(tp);
            }
        }

        public void DoiMauBan(SimpleButton btnBan, List<ban> Bann)
        {
            for (int i = 0; i <= Bann.Count - 1; i++)
            {
                if (btnBan.Name == Bann[i].btn.Name)
                {
                    Bann[i].lbl.BackColor = Color.Yellow;
                    txtTenBan.Text = Bann[i].lbl.Text;
                    cbbKhuVuc.Text = blb.LayTenKV(Bann[i].lbl.Name);
                    txtSoChoNgoi.Text = Bann[i].lblSCN.Text;
                    cbbTrangThai.Text = Bann[i].lblTT.Text;
                    txtMaBan.Text = Bann[i].btn.Name;
                }
                else
                {
                    Bann[i].lbl.BackColor = Color.WhiteSmoke;
                }
            }
        }

        public void Loaddata()
        {
            loadBan();
            blb.LoadCBBTenKhuVuc(cbbKhuVuc);
            this.grcrlTT.Enabled = false;
            this.btnHuy.Enabled = false;
            this.btnLuu.Enabled = false;

            this.txtMaBan.ResetText();
            this.txtTenBan.ResetText();
            this.txtSoChoNgoi.ResetText();
            this.cbbKhuVuc.ResetText();
            this.cbbTrangThai.ResetText();

            this.btnThem.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnSua.Enabled = true;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            SimpleButton sb = sender as SimpleButton;
            DoiMauBan(sb, Lban);
        }

        private void QLBan_Load(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;

            this.grcrlTT.Enabled = true;
            this.btnHuy.Enabled = true;
            this.btnLuu.Enabled = true;

            this.txtMaBan.ResetText();
            this.txtTenBan.ResetText();
            this.txtSoChoNgoi.ResetText();
            this.cbbKhuVuc.ResetText();
            this.cbbTrangThai.ResetText();

            txtMaBan.Enabled = true;

            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnSua.Enabled = false;
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
                    string ma = txtMaBan.Text;
                    blb.XoaBan(ma);
                    Loaddata();
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

            this.grcrlTT.Enabled = true;
            this.btnHuy.Enabled = true;
            this.btnLuu.Enabled = true;

            this.txtMaBan.ResetText();
            this.txtTenBan.ResetText();
            this.txtSoChoNgoi.ResetText();
            this.cbbKhuVuc.ResetText();
            this.cbbTrangThai.ResetText();

            txtMaBan.Enabled = false;
            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnSua.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string MaKV = blb.LayMaKV(cbbKhuVuc.Text);
            if (them)
            {
                try
                {
                    blb.ThemBan(txtMaBan.Text, txtTenBan.Text, int.Parse(txtSoChoNgoi.Text), MaKV, cbbTrangThai.Text);
                    Loaddata();
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
                    blb.SuaBan(txtMaBan.Text, txtTenBan.Text, int.Parse(txtSoChoNgoi.Text), MaKV, cbbTrangThai.Text);
                    Loaddata();
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

        private void txtSoChoNgoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
