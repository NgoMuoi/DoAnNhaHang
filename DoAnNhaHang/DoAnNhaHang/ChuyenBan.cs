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
    public partial class ChuyenBan : Form
    {
        public ChuyenBan()
        {
            InitializeComponent();
        }
        public string MaBanCu { get; set; }
        public string MaBanMoi { get; set; }
        int temp = 0;
        BLChuyenBan blcb = new BLChuyenBan();
        BLThongBao bltb = new BLThongBao();
        BLBan blb = new BLBan();
        public class ban
        {
            public SimpleButton btn;
            public Label lbl;
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
            blb.XoaHet(tabctrlDSBT);
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
                          where z.TENKHUVUC == tp.Text && y.MABAN != MaBanCu && y.TRANGTHAI == "Trống" && y.SOCHONGOI >= nmrSoKhach.Value
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
                tabctrlDSBT.Controls.Add(tp);
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            SimpleButton bt = sender as SimpleButton;
            MaBanMoi = bt.Name.Trim();
            blcb.LayBan(MaBanMoi, txtMaBanMoi, txtTenBanMoi, txtSoChoNgoi, txtMaKhuVuc, cbbTenKhuVuc, txtTrangThai);
        }

        public void loadData()
        {
            loadBan();
        }

        private void ChuyenBan_Load(object sender, EventArgs e)
        {
            loadData();
            blcb.LayBanCu(MaBanCu, txtMaBanCu, txtTenBanCu, txtTenKhuVucCu);
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            try
            {
                blcb.ChuyenBan(txtMaBanCu.Text.Trim(), txtMaBanMoi.Text.Trim());
                bltb.Show("Đã chuyển bàn " + txtMaBanCu.Text.Trim() + " sang bàn " + txtMaBanMoi.Text.Trim() + " thành công!");
                this.Hide();
            }
            catch
            {
                this.Hide();
            }
        }

        private void nmrSoKhach_ValueChanged(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
