using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_TrangChu : Form
    {
        Form fm;
        string id_nv;
        public frm_TrangChu(string manv)
        {
            InitializeComponent();
            grbMove.Visible = false;
            id_nv = manv;
        }
        private void container(object _form)
        {
            if (fm != null)
            {
                fm.Close();
            }
            fm = _form as Form;
            fm.TopLevel = false;
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.Dock = DockStyle.Fill;
            panelCenter.Controls.Add(fm);
            panelCenter.Tag = fm;
            fm.BringToFront();
            fm.Show();
        }
        private void btnTK_Click(object sender, EventArgs e)
        {
            grbMove.Visible = true;
            grbMove.Height = btnTK.Height;
            grbMove.Top = btnTK.Top;
            btnTK.FillColor = Color.FromArgb(231, 229, 255);
            btnNV.FillColor = Color.FromArgb(254, 254, 254);
            btnSP.FillColor = Color.FromArgb(254, 254, 254);
            btnThongKe.FillColor = Color.FromArgb(254, 254, 254);
            btnCaiDat.FillColor = Color.FromArgb(254, 254, 254);
            btnCT.FillColor = Color.FromArgb(254, 254, 254);
            btnHD.FillColor = Color.FromArgb(254, 254, 254);
            btnKH.FillColor = Color.FromArgb(254, 254, 254);
            container(new frm_KhoHang());           
        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            grbMove.Visible = true;
            grbMove.Height = btnSP.Height;
            grbMove.Top = btnSP.Top;
            btnSP.FillColor = Color.FromArgb(231, 229, 255);
            btnNV.FillColor = Color.FromArgb(254, 254, 254);
            btnTK.FillColor = Color.FromArgb(254, 254, 254);
            btnThongKe.FillColor = Color.FromArgb(254, 254, 254);
            btnCaiDat.FillColor = Color.FromArgb(254, 254, 254);
            btnCT.FillColor = Color.FromArgb(254, 254, 254);
            btnHD.FillColor = Color.FromArgb(254, 254, 254);
            btnKH.FillColor = Color.FromArgb(254, 254, 254);
            container(new frm_SanPham());
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }

        private void btnKH_Click(object sender, EventArgs e)
        {
            grbMove.Visible = true;
            grbMove.Height = btnKH.Height;
            grbMove.Top = btnKH.Top;
            btnKH.FillColor = Color.FromArgb(231, 229, 255);
            btnNV.FillColor = Color.FromArgb(254, 254, 254);
            btnSP.FillColor = Color.FromArgb(254, 254, 254);
            btnThongKe.FillColor = Color.FromArgb(254, 254, 254);
            btnCaiDat.FillColor = Color.FromArgb(254, 254, 254);
            btnCT.FillColor = Color.FromArgb(254, 254, 254);
            btnHD.FillColor = Color.FromArgb(254, 254, 254);
            btnTK.FillColor = Color.FromArgb(254, 254, 254);
            container(new frm_KhachHang());
        }

        private void btnHD_Click(object sender, EventArgs e)
        {
            grbMove.Visible = true;
            grbMove.Height = btnHD.Height;
            grbMove.Top = btnHD.Top;
            btnHD.FillColor = Color.FromArgb(231, 229, 255);
            btnNV.FillColor = Color.FromArgb(254, 254, 254);
            btnSP.FillColor = Color.FromArgb(254, 254, 254);
            btnThongKe.FillColor = Color.FromArgb(254, 254, 254);
            btnCaiDat.FillColor = Color.FromArgb(254, 254, 254);
            btnCT.FillColor = Color.FromArgb(254, 254, 254);
            btnTK.FillColor = Color.FromArgb(254, 254, 254);
            btnKH.FillColor = Color.FromArgb(254, 254, 254);
            container(new frm_HoaDon(id_nv));
        }

        private void btnCT_Click(object sender, EventArgs e)
        {
            grbMove.Visible = true;
            grbMove.Height = btnCT.Height;
            grbMove.Top = btnCT.Top;
            btnCT.FillColor = Color.FromArgb(231, 229, 255);
            btnNV.FillColor = Color.FromArgb(254, 254, 254);
            btnSP.FillColor = Color.FromArgb(254, 254, 254);
            btnThongKe.FillColor = Color.FromArgb(254, 254, 254);
            btnCaiDat.FillColor = Color.FromArgb(254, 254, 254);
            btnTK.FillColor = Color.FromArgb(254, 254, 254);
            btnHD.FillColor = Color.FromArgb(254, 254, 254);
            btnKH.FillColor = Color.FromArgb(254, 254, 254);
            container(new frm_ChungTu());
        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            grbMove.Visible = true;
            grbMove.Height = btnNV.Height;
            grbMove.Top = btnNV.Top;
            btnNV.FillColor = Color.FromArgb(231, 229, 255);
            btnTK.FillColor = Color.FromArgb(254, 254, 254);
            btnSP.FillColor = Color.FromArgb(254, 254, 254);
            btnThongKe.FillColor = Color.FromArgb(254, 254, 254);
            btnCaiDat.FillColor = Color.FromArgb(254, 254, 254);
            btnCT.FillColor = Color.FromArgb(254, 254, 254);
            btnHD.FillColor = Color.FromArgb(254, 254, 254);
            btnKH.FillColor = Color.FromArgb(254, 254, 254);
            container(new frm_NhanVien());
        }

        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            grbMove.Visible = true;
            grbMove.Height = btnCaiDat.Height;
            grbMove.Top = btnCaiDat.Top;
            btnCaiDat.FillColor = Color.FromArgb(231, 229, 255);
            btnNV.FillColor = Color.FromArgb(254, 254, 254);
            btnSP.FillColor = Color.FromArgb(254, 254, 254);
            btnThongKe.FillColor = Color.FromArgb(254, 254, 254);
            btnTK.FillColor = Color.FromArgb(254, 254, 254);
            btnCT.FillColor = Color.FromArgb(254, 254, 254);
            btnHD.FillColor = Color.FromArgb(254, 254, 254);
            btnKH.FillColor = Color.FromArgb(254, 254, 254);
            container(new frm_TaiKhoan(id_nv));
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            grbMove.Visible = true;
            grbMove.Height = btnThongKe.Height;
            grbMove.Top = btnThongKe.Top;
            btnThongKe.FillColor = Color.FromArgb(231, 229, 255);
            btnNV.FillColor = Color.FromArgb(254, 254, 254);
            btnSP.FillColor = Color.FromArgb(254, 254, 254);
            btnTK.FillColor = Color.FromArgb(254, 254, 254);
            btnCaiDat.FillColor = Color.FromArgb(254, 254, 254);
            btnCT.FillColor = Color.FromArgb(254, 254, 254);
            btnHD.FillColor = Color.FromArgb(254, 254, 254);
            btnKH.FillColor = Color.FromArgb(254, 254, 254);
            container(new frm_ThongKe());
        }

        private void frm_TrangChu_Load(object sender, EventArgs e)
        {          
            lblTenNV.Text += NhanVien_BUS.TimNhanVienTheoID_BUS(id_nv).HoTen+"!";
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                frm_DangNhap f = new frm_DangNhap();
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
        }
    }
}
