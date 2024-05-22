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
    public partial class ThemKH : Form
    {
        KhachHang_DTO kh;
        public ThemKH()
        {
            InitializeComponent();
        }
        public void LayDL()
        {
            kh = new KhachHang_DTO();
            kh.MaKH = txtMaKH.Text;
            kh.HoTen = txtHoTen.Text;
            kh.PhaiKH = radNam.Checked ? "Nam" : "Nữ";
            kh.NgaySinh = dtpNgaySinh.Value.ToString();
            kh.SoDT = txtDT.Text;
            kh.DiaChi = txtDiaChi.Text;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public int kt_KiTuSo(string s)
        {
            int dem = 0;
            char[] chars = s.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] < 48 || chars[i] > 57)
                {
                    dem++;
                    break;
                }
            }
            return dem;
        }
        public bool check_Nhap()
        {
            // 48 - 57            

            if (txtMaKH.Text.Equals(""))
            {
                MessageBox.Show("Mã khách hàng không được trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaKH.Focus();
                return false;
            }
            else
            {
                if (txtMaKH.Text.Length > 4)
                {
                    MessageBox.Show("Mã khách hàng chỉ chứa 4 kí tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    if ((KhachHang_BUS.TimKH_ID_BUS(txtMaKH.Text) != null))
                    {
                        MessageBox.Show("Mã khách hàng đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMaKH.Text = "";
                        txtMaKH.Focus();
                        return false;
                    }
                }
            }
            if (txtHoTen.Text.Equals(""))
            {
                MessageBox.Show("Họ tên không được trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoTen.Focus();
                return false;
            }
            if (txtDT.Text.Equals(""))
            {
                MessageBox.Show("Điện thoại không được trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDT.Focus();
                return false;
            }
            else
            {
                if (kt_KiTuSo(txtDT.Text) == 1)
                {
                    MessageBox.Show("Số điện thoại phải là kí tự chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDT.Text = "";
                    txtDT.Focus();
                    return false;
                }
                else
                {
                    if (txtDT.Text.Length > 11)
                    {
                        MessageBox.Show("Số điện thoại chỉ chứa tối đa 11 số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            if (radNam.Checked == false && radNu.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dtpNgaySinh.Value >= DateTime.Now)
            {
                MessageBox.Show("Ngày sinh phải nhỏ hơn hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (check_Nhap())
            {
                try
                {
                    LayDL();
                    KhachHang_BUS.InsertKH_BUS(kh);
                    MessageBox.Show("Thêm 1 khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo");
                }
            }
        }

        private void btnResetText_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = string.Empty;
            txtHoTen.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtDT.Text = string.Empty;
            radNam.Checked = false;
            radNu.Checked = false;
            dtpNgaySinh.Value = DateTime.Now;
        }
    }
}
