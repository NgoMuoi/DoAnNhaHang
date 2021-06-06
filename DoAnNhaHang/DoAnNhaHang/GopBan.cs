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
    public partial class GopBan : Form
    {
        public GopBan()
        {
            InitializeComponent();
        }
        BLBan blb = new BLBan();
        BLGopBan blgb = new BLGopBan();
        BLThongBao bltb = new BLThongBao();
        public string MaBanCanGop { get; set; }
        public string MaBanCu { get; set; }

        int temp = 0;
        public class Ban
        {
            public SimpleButton btn;
            public Label lbl;
        }

        public class Tang
        {
            public List<Ban> LBan;
        }

        public List<Ban> Lban = new List<Ban>();
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
                          where z.TENKHUVUC == tp.Text && y.MABAN != MaBanCu && y.TRANGTHAI.Trim() == "Đã Đặt"
                          select new
                          {
                              y.MABAN,
                              y.TENBAN,
                              y.TRANGTHAI,
                              y.SOCHONGOI,
                              z.MAKHUVUC,
                              z.TENKHUVUC
                          };
                foreach (var b in ban)
                {
                    Ban bann = new Ban();
                    Lban.Add(bann);
                    Lban[i].btn = new SimpleButton();
                    Lban[i].btn.Size = new Size(50, 50);
                    Lban[i].btn.BackColor = Color.Blue;
                    Lban[i].btn.Name = b.MABAN.ToString().Trim();
                    Lban[i].btn.ImageOptions.Location = ImageLocation.MiddleCenter;
                    Lban[i].btn.AppearanceHovered.BackColor = Color.Khaki;
                    Lban[i].btn.AppearancePressed.BackColor = Color.IndianRed;
                    this.Lban[i].btn.ImageOptions.Image = global::DoAnNhaHang.Properties.Resources.Banan2_32x32_230;

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

        public void DoiMauBan(SimpleButton btnBan, List<Ban> Bann)
        {
            for (int i = 0; i <= Bann.Count - 1; i++)
            {
                if (btnBan.Name == Bann[i].btn.Name)
                {
                    Bann[i].lbl.BackColor = Color.Yellow;
                }
                else
                {
                    Bann[i].lbl.BackColor = Color.WhiteSmoke;
                }
            }
        }
        private void btn_Click(object sender, EventArgs e)
        {
            try
            {
                SimpleButton sb = sender as SimpleButton;
                DoiMauBan(sb, Lban);
                MaBanCanGop = sb.Name.Trim();
                btnXoa.Enabled = false;
            }
            catch
            {

            }
        }
        private void GopBan_Load(object sender, EventArgs e)
        {
            loadBan();
            blgb.LayBanCu(MaBanCu, txtMaBan, txtTenBan, txtTenKV);
        }
        public void AnBan(string MaBan, List<Ban> B)
        {
            for (int i = 0; i < B.Count; i++)
            {
                if (MaBan.Trim() == B[i].btn.Name.Trim())
                {
                    B[i].btn.Visible = false;
                    B[i].lbl.Visible = false;
                }
            }
        }
        public void HienBan(string MaBan, List<Ban> B)
        {
            for (int i = 0; i < B.Count; i++)
            {
                if (MaBan.Trim() == B[i].btn.Name.Trim())
                {
                    B[i].btn.Visible = true;
                    B[i].lbl.Visible = true;
                }
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string str = ListBanCanGop.SelectedItem.ToString();
                ListBanCanGop.Items.RemoveAt(ListBanCanGop.SelectedIndices[0]);
                HienBan(str.Trim(), Lban);
                btnThem.Enabled = true;
                TestDS();
            }
            catch
            {

            }
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                ListBanCanGop.Items.Add(MaBanCanGop);
                AnBan(MaBanCanGop, Lban);
                btnXoa.Enabled = true;
                TestDS();
            }
            catch
            {

            }
            
        }

        public void TestDS()
        {
            if (ListBanCanGop.Items.Count != 0)
                btnGop.Enabled = true;
            else
                btnGop.Enabled = false;
        }
        private void btnGop_Click(object sender, EventArgs e)
        {
            string str = "";
            try
            {
                BLChuyenBan BLCB = new BLChuyenBan();
                foreach (var i in ListBanCanGop.Items)
                {
                    str += i.ToString().Trim() + ",";
                    BLCB.ChuyenBan(i.ToString().Trim(), txtMaBan.Text.Trim());
                }
                bltb.Show("Gộp thành công bàn " + str + " sang bàn " + txtMaBan.Text.ToString());
                this.Close();
            }
            catch
            {

            }
        }

        private void ListBanCanGop_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
        }
    }
}
