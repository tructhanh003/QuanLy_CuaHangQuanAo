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
    public partial class frm_TrangChu_ThuKho : Form
    {
        Form fm;
        string id_nv;
        public frm_TrangChu_ThuKho(string manv)
        {
            InitializeComponent();
            grbMove.Visible = false;
            id_nv = manv;
            lblTenNV.Text += NhanVien_BUS.TimNhanVienTheoID_BUS(id_nv).HoTen + "!";
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
        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            grbMove.Visible = true;
            grbMove.Height = btnNhapHang.Height;
            grbMove.Top = btnNhapHang.Top;
            btnNhapHang.FillColor = Color.FromArgb(231, 229, 255);
            btnKhoHang.FillColor = Color.FromArgb(254, 254, 254);
            btnXuatHang.FillColor = Color.FromArgb(254, 254, 254);
            btnTaiKhoan.FillColor = Color.FromArgb(254, 254, 254);
            container(new frm_PhieuNhap(id_nv));
        }

        private void btnKhoHang_Click(object sender, EventArgs e)
        {
            grbMove.Visible = true;
            grbMove.Height = btnKhoHang.Height;
            grbMove.Top = btnKhoHang.Top;
            btnKhoHang.FillColor = Color.FromArgb(231, 229, 255);
            btnNhapHang.FillColor = Color.FromArgb(254, 254, 254);
            btnXuatHang.FillColor = Color.FromArgb(254, 254, 254);
            btnTaiKhoan.FillColor = Color.FromArgb(254, 254, 254);
            container(new frm_KhoHang());
        }

        private void btnXuatHang_Click(object sender, EventArgs e)
        {
            grbMove.Visible = true;
            grbMove.Height = btnXuatHang.Height;
            grbMove.Top = btnXuatHang.Top;
            btnXuatHang.FillColor = Color.FromArgb(231, 229, 255);
            btnKhoHang.FillColor = Color.FromArgb(254, 254, 254);
            btnNhapHang.FillColor = Color.FromArgb(254, 254, 254);
            btnTaiKhoan.FillColor = Color.FromArgb(254, 254, 254);
            container(new frm_PhieuXuat(id_nv));
        }

        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            grbMove.Visible = true;
            grbMove.Height = btnTaiKhoan.Height;
            grbMove.Top = btnTaiKhoan.Top;
            btnTaiKhoan.FillColor = Color.FromArgb(231, 229, 255);
            btnKhoHang.FillColor = Color.FromArgb(254, 254, 254);
            btnXuatHang.FillColor = Color.FromArgb(254, 254, 254);
            btnNhapHang.FillColor = Color.FromArgb(254, 254, 254);
            container(new frm_TaiKhoan(id_nv));
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
