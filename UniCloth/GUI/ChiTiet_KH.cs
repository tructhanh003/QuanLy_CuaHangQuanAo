using BUS;
using DTO;
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
    public partial class ChiTiet_KH : Form
    {
        string id_kh;
        KhachHang_DTO kh;
        public ChiTiet_KH(string makh)
        {
            InitializeComponent();
            id_kh = makh;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void LayDL()
        {
            kh = new KhachHang_DTO();
            kh.MaKH = txtMaKH.Text;
            kh.HoTen = txtHoTen.Text;
            kh.SoDT = txtDT.Text;
            kh.DiaChi = txtDiaChi.Text;
            kh.PhaiKH = radNam.Checked ? "Nam" : "Nữ";
            kh.NgaySinh = dtpNgaySinh.Value.ToString();
        }
        private void ChiTiet_KH_Load(object sender, EventArgs e)
        {
            try
            {
                KhachHang_DTO kh = KhachHang_BUS.TimKH_ID_BUS(id_kh);
                if (kh != null)
                {
                    txtMaKH.Text = kh.MaKH;
                    txtHoTen.Text = kh.HoTen;
                    txtDT.Text = kh.SoDT;
                    txtDiaChi.Text = kh.DiaChi;
                    if (kh.PhaiKH.Equals("Nam"))
                    {
                        radNam.Checked = true;
                    }
                    else
                        radNu.Checked = true;
                    dtpNgaySinh.Text = kh.NgaySinh;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                LayDL();
                KhachHang_BUS.UpdateKH_BUS(kh);
                MessageBox.Show("Đã sửa thông tin khách hàng thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(result == DialogResult.Yes)
            {
                try
                {
                    KhachHang_BUS.DeleteKH_BUS(txtMaKH.Text);
                    MessageBox.Show("Đã xóa thông tin khách hàng thành công!", "Thông báo");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo");
                }
            }
        }
    }
}
