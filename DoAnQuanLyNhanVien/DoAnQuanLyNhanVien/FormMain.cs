using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnQuanLyNhanVien
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            PhanQuyen();
        }
        void PhanQuyen()
        {
            if (frmLogin.quyen == "0")
            {
                chứcNăngToolStripMenuItem.Visible = false;
                quảnLýToolStripMenuItem.Visible = false;
                tsmQuanLyTaiKhoan.Enabled = false;
            }
            else
            {
                
            }    
        }
        private void tsmNhanVien_Click(object sender, EventArgs e)
        {
            frmDSNhanVien fnv = new frmDSNhanVien();
            panelShow.Show();
            panelShow.Controls.Clear();
            fnv.TopLevel = false;
            fnv.Dock = DockStyle.Fill;
            panelShow.Controls.Add(fnv);
            fnv.Show();
        }

        private void tsmChucVu_Click(object sender, EventArgs e)
        {
            frmDSChucVu fcv = new frmDSChucVu();
            panelShow.Show();
            panelShow.Controls.Clear();
            fcv.TopLevel = false;
            fcv.Dock = DockStyle.Fill;
            panelShow.Controls.Add(fcv);
            fcv.Show();
        }

        private void tsmDuAn_Click(object sender, EventArgs e)
        {
            frmDSDuAn fda = new frmDSDuAn();
            panelShow.Show();
            panelShow.Controls.Clear();
            fda.TopLevel = false;
            fda.Dock = DockStyle.Fill;
            panelShow.Controls.Add(fda);
            fda.Show();
        }

        private void tsmTinhLuongNhanVien_Click(object sender, EventArgs e)
        {
            frmBangLuongNhanVien bangluong = new frmBangLuongNhanVien();
            panelShow.Show();
            panelShow.Controls.Clear();
            bangluong.TopLevel = false;
            bangluong.Dock = DockStyle.Fill;
            panelShow.Controls.Add(bangluong);
            bangluong.Show();
        }


        private void tsmPhongBan_Click(object sender, EventArgs e)
        {
            frmDSPhongBan fpb = new frmDSPhongBan();
            panelShow.Show();
            panelShow.Controls.Clear();
            fpb.TopLevel = false;
            fpb.Dock = DockStyle.Fill;
            panelShow.Controls.Add(fpb);
            fpb.Show();
        }

        private void tsmChamCong_Click(object sender, EventArgs e)
        {
            frmDSChamCong fcc = new frmDSChamCong();
            panelShow.Show();
            panelShow.Controls.Clear();
            fcc.TopLevel = false;
            fcc.Dock = DockStyle.Fill;
            panelShow.Controls.Add(fcc);
            fcc.Show();
        }

        private void tsmTraCuu_Click(object sender, EventArgs e)
        {
            frmSearch fs = new frmSearch();
            panelShow.Show();
            panelShow.Controls.Clear();
            fs.TopLevel = false;
            fs.Dock = DockStyle.Fill;
            panelShow.Controls.Add(fs);
            fs.Show();
        }

        private void tsmPhanCongDuAn_Click(object sender, EventArgs e)
        {
            frmPhanCongDuAn fpcda = new frmPhanCongDuAn();
            panelShow.Show();
            panelShow.Controls.Clear();
            fpcda.TopLevel = false;
            fpcda.Dock = DockStyle.Fill;
            panelShow.Controls.Add(fpcda);
            fpcda.Show();
        }

        private void tsmThongTinCaNhan_Click(object sender, EventArgs e)
        {
            frmThongTinCaNhan fttcn = new frmThongTinCaNhan();
            panelShow.Show();
            panelShow.Controls.Clear();
            fttcn.TopLevel = false;
            fttcn.Dock = DockStyle.Fill;
            panelShow.Controls.Add(fttcn);
            fttcn.Show();
        }
        private void tsmHopDong_Click(object sender, EventArgs e)
        {
            frmHopDongLD fhd = new frmHopDongLD();
            panelShow.Show();
            panelShow.Controls.Clear();
            fhd.TopLevel = false;
            fhd.Dock = DockStyle.Fill;
            panelShow.Controls.Add(fhd);
            fhd.Show();
        }
        private void tsmDangXuat_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void tsmPasswordChange_Click(object sender, EventArgs e)
        {
            panelShow.Controls.Clear();
            frmPasswordChange fpc = new frmPasswordChange();
            fpc.Show();
        }

        private void tsmQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            frmQuanLyTaiKhoan fqltk = new frmQuanLyTaiKhoan();
            panelShow.Show();
            panelShow.Controls.Clear();
            fqltk.TopLevel = false;
            fqltk.Dock = DockStyle.Fill;
            panelShow.Controls.Add(fqltk);
            fqltk.Show();
        }
    }
}
