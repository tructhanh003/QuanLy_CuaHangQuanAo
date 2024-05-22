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
using static System.Net.Mime.MediaTypeNames;

namespace GUI
{
    public partial class frm_KhachHang : Form
    {
        string[] lstLoc = { "Mã KH", "Họ tên", "Điện thoại" };
        KhachHang_DTO kh;
        public frm_KhachHang()
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
        public void LoadKH()
        {
            List<KhachHang_DTO> lstKH = KhachHang_BUS.LayKhachHang_DataGridView_BUS();
            dgvKH.DataSource = lstKH;
            dgvKH.Columns["MaKH"].HeaderText = "Mã KH";
            dgvKH.Columns["MaKH"].Width = 50;
            dgvKH.Columns["HoTen"].HeaderText = "Họ tên";
            dgvKH.Columns["HoTen"].Width = 120;
            dgvKH.Columns["PhaiKH"].HeaderText = "Phái";
            dgvKH.Columns["PhaiKH"].Width = 50;
            dgvKH.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgvKH.Columns["NgaySinh"].Width = 70;
            dgvKH.Columns["SoDT"].HeaderText = "Điện thoại";
            dgvKH.Columns["SoDT"].Width = 70;
            dgvKH.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvKH.Columns["DiaChi"].Width = 210;
            cboTim.DataSource = lstLoc;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(check_Nhap())
            {
                try
                {
                    LayDL();
                    KhachHang_BUS.InsertKH_BUS(kh);
                    MessageBox.Show("Thêm 1 khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadKH();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo");
                }
            }    
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
                if (txtMaKH.Text.Length>4)
                {
                    MessageBox.Show("Mã khách hàng chỉ chứa 4 kí tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else 
                {
                    if((KhachHang_BUS.TimKH_ID_BUS(txtMaKH.Text) != null))
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
                if (kt_KiTuSo(txtDT.Text)==1)
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
            if (radNam.Checked==false && radNu.Checked==false)
            {
                MessageBox.Show("Bạn chưa chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                return false;
            }
            if (dtpNgaySinh.Value>=DateTime.Now)
            {
                MessageBox.Show("Ngày sinh phải nhỏ hơn hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void frm_KhachHang_Load(object sender, EventArgs e)
        {
            LoadKH();
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

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadKH();
        }

        private void dgvKH_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgvKH.SelectedRows[0];
            string s = dr.Cells["MaKH"].Value.ToString();
            ChiTiet_KH f = new ChiTiet_KH(s);
            f.ShowDialog();
        }
        public void HienThi_MaKH_TimKiem()
        {
            List<KhachHang_DTO> lstSP = KhachHang_BUS.TimKH_TheoMa_BUS(txtTim.Text);
            if (lstSP != null)
            {
                dgvKH.DataSource = lstSP;
                dgvKH.Columns["MaKH"].HeaderText = "Mã KH";
                dgvKH.Columns["MaKH"].Width = 50;
                dgvKH.Columns["HoTen"].HeaderText = "Họ tên";
                dgvKH.Columns["HoTen"].Width = 120;
                dgvKH.Columns["PhaiKH"].HeaderText = "Phái";
                dgvKH.Columns["PhaiKH"].Width = 50;
                dgvKH.Columns["NgaySinh"].HeaderText = "Ngày sinh";
                dgvKH.Columns["NgaySinh"].Width = 70;
                dgvKH.Columns["SoDT"].HeaderText = "Điện thoại";
                dgvKH.Columns["SoDT"].Width = 70;
                dgvKH.Columns["DiaChi"].HeaderText = "Địa chỉ";
                dgvKH.Columns["DiaChi"].Width = 210;
            }
        }
        public void HienThi_HoTen_TimKiem()
        {
            List<KhachHang_DTO> lstSP = KhachHang_BUS.TimKH_TheoTen_BUS(txtTim.Text);
            if (lstSP != null)
            {
                dgvKH.DataSource = lstSP;
                dgvKH.Columns["MaKH"].HeaderText = "Mã KH";
                dgvKH.Columns["MaKH"].Width = 50;
                dgvKH.Columns["HoTen"].HeaderText = "Họ tên";
                dgvKH.Columns["HoTen"].Width = 120;
                dgvKH.Columns["PhaiKH"].HeaderText = "Phái";
                dgvKH.Columns["PhaiKH"].Width = 50;
                dgvKH.Columns["NgaySinh"].HeaderText = "Ngày sinh";
                dgvKH.Columns["NgaySinh"].Width = 70;
                dgvKH.Columns["SoDT"].HeaderText = "Điện thoại";
                dgvKH.Columns["SoDT"].Width = 70;
                dgvKH.Columns["DiaChi"].HeaderText = "Địa chỉ";
                dgvKH.Columns["DiaChi"].Width = 210;
            }
        }
        public void HienThi_SoDT_TimKiem()
        {
            List<KhachHang_DTO> lstSP = KhachHang_BUS.TimKH_TheoDT_BUS(txtTim.Text);
            if (lstSP != null)
            {
                dgvKH.DataSource = lstSP;
                dgvKH.Columns["MaKH"].HeaderText = "Mã KH";
                dgvKH.Columns["MaKH"].Width = 50;
                dgvKH.Columns["HoTen"].HeaderText = "Họ tên";
                dgvKH.Columns["HoTen"].Width = 120;
                dgvKH.Columns["PhaiKH"].HeaderText = "Phái";
                dgvKH.Columns["PhaiKH"].Width = 50;
                dgvKH.Columns["NgaySinh"].HeaderText = "Ngày sinh";
                dgvKH.Columns["NgaySinh"].Width = 70;
                dgvKH.Columns["SoDT"].HeaderText = "Điện thoại";
                dgvKH.Columns["SoDT"].Width = 70;
                dgvKH.Columns["DiaChi"].HeaderText = "Địa chỉ";
                dgvKH.Columns["DiaChi"].Width = 210;
            }
        }
        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            if(cboTim.Text.Equals("Mã KH"))
            {
                HienThi_MaKH_TimKiem();
            }   
            if(cboTim.Text.Equals("Họ tên"))
            {
                HienThi_HoTen_TimKiem();
            }
            if (cboTim.Text.Equals("Điện thoại"))
            {
                HienThi_SoDT_TimKiem();
            }
        }
    }
}
