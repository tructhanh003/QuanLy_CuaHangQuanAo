using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace GUI
{
    public partial class frm_KhoHang : Form
    {
        KhoHang_DTO khoHang;
        String[] am_pm = {"AM", "PM" };
        string[] lstTim = { "Sắp xếp tăng dần", "Sắp xếp giảm dần"};
        string dateTime="";
        string gio = "";
        string phut = "";
        public frm_KhoHang()
        {
            InitializeComponent();
        }
        public void Load_All()
        {
            cboTim.DataSource = lstTim;
            
            load_DGV();
        }
        public void load_DGV()
        {
            List<KhoHang_DTO> lstKho = KhoHang_BUS.LayKhoHang_DataGridView();
            if(lstKho!=null)
            {
                dgvKhoHang.DataSource = lstKho;
                dgvKhoHang.Columns["MaSP"].HeaderText = "ID SP";
                dgvKhoHang.Columns["MaSP"].Width = 50;
                dgvKhoHang.Columns["NgayNhap"].HeaderText = "Ngày nhập";
                dgvKhoHang.Columns["NgayNhap"].Width = 100;
                dgvKhoHang.Columns["TenSP"].HeaderText = "Sản phẩm";
                dgvKhoHang.Columns["SoLuong"].Width = 250;
                dgvKhoHang.Columns["SizeSP"].HeaderText = "Size";
                dgvKhoHang.Columns["SizeSP"].Width = 40;
                dgvKhoHang.Columns["GiaNhap"].HeaderText = "Giá nhập";
                dgvKhoHang.Columns["GiaNhap"].Width = 60;
                dgvKhoHang.Columns["GiaBan"].HeaderText = "Giá bán";
                dgvKhoHang.Columns["GiaBan"].Width = 60;
                dgvKhoHang.Columns["SoLuong"].HeaderText = "Số lượng";
                dgvKhoHang.Columns["SoLuong"].Width = 50;
            }    
        }
        private void frm_KhoHang_Load(object sender, EventArgs e)
        {
            Load_All();
        }
        private string Lay_5_characters(string text)
        {
            char[] chars = text.ToCharArray();
            string s = "";
            for (int i = 0; i < 5; i++)
            {
                s += chars[i];
            }
            return s;
        }
        private string Lay_NgayNhap(string text)
        {
            char[] chars = text.ToCharArray();
            string s = "";
            for (int i = 0; i < chars.Length; i++)
            {
                if(chars[i].Equals(" "))
                {
                    break;
                }    
                s += chars[i];
            }
            return s;
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
        public bool check_DL()
        {
            if(kt_KiTuSo(txtSoLuong.Text) == 1)
            {
                MessageBox.Show("Số lượng nhập là kí tự số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoLuong.Text = "";
                txtSoLuong.Focus();
                return false;
            }    
            else
            {
                if (int.Parse(txtSoLuong.Text) < 0)
                {
                    MessageBox.Show("Số lượng nhập phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSoLuong.Text = "";
                    txtSoLuong.Focus();
                    return false;
                }
            }
            if(kt_KiTuSo(txtGiaBan.Text) == 1)
            {
                MessageBox.Show("Giá bán phải là kí tự số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGiaBan.Text = "";
                txtGiaBan.Focus();
                return false;
            }
            else
            {
                if (int.Parse(txtGiaBan.Text) < 0)
                {
                    MessageBox.Show("Giá bán phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtGiaBan.Text = "";
                    txtGiaBan.Focus();
                    return false;
                }
                else
                {
                    if (int.Parse(txtGiaBan.Text) < int.Parse(txtGiaNhap.Text))
                    {
                        MessageBox.Show("Giá bán phải lớn hơn giá nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }             
            return true;
        }
        public void layDL()
        {            
             khoHang = new KhoHang_DTO();      
             khoHang.MaSP = Lay_5_characters(txtSP.Text);            
             khoHang.GiaBan = int.Parse(txtGiaBan.Text);
                  
        }
        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            
        }

        private void btnInDS_Click(object sender, EventArgs e)
        {
            frm_ReportSP f = new frm_ReportSP();
            f.ShowDialog();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            load_DGV();
        }

        private void btnThemHang_Click(object sender, EventArgs e)
        {
            if(check_DL())
            {
                try
                {
                    layDL();
                    KhoHang_BUS.Update_GiaBan_Kho(khoHang.GiaBan, khoHang.MaSP);
                    MessageBox.Show("Cập nhật giá bán thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load_DGV();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }    
        }
        private Image ByteToImg(string byteString)
        {
            byte[] imgBytes = Convert.FromBase64String(byteString);
            MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
            ms.Write(imgBytes, 0, imgBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
        
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                layDL();
                //PhieuNhap_BUS.UpdateKho_BUS(khoHang);
                MessageBox.Show("Sửa thông tin sản phẩm trong kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_DGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này trong kho?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(result==DialogResult.Yes)
            {
                try
                {
                    string masp = Lay_5_characters(txtSP.Text);
                    KhoHang_BUS.Delete_KhoHang_BUS(masp);
                    MessageBox.Show("Xóa 1 sản phẩm trong kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load_DGV();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }    
        }

        private void dgvKhoHang_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgvKhoHang.SelectedRows[0];
            txtSP.Text = dr.Cells["MaSP"].Value.ToString() + " | " + dr.Cells["TenSP"].Value.ToString() + " | " + dr.Cells["SizeSP"].Value.ToString();
            txtSoLuong.Text = dr.Cells["SoLuong"].Value.ToString();
            txtGiaNhap.Text = dr.Cells["GiaNhap"].Value.ToString();
            txtGiaBan.Text = dr.Cells["GiaBan"].Value.ToString();
            txtNgayNhap.Text = dr.Cells["NgayNhap"].Value.ToString();
            SanPham_DTO sp = SanPham_BUS.TimSP_ID_BUS(dr.Cells["MaSP"].Value.ToString());
            picSP.Image = ByteToImg(sp.AnhSP.ToString());            
        }
        public void loadDGV_TangDan()
        {
            List<KhoHang_DTO> lstKhoHang = KhoHang_BUS.SapXep_TangDan_SoLuong_BUS();
            if (lstKhoHang != null)
            {
                dgvKhoHang.DataSource = lstKhoHang;
                dgvKhoHang.Columns["MaSP"].HeaderText = "ID";
                dgvKhoHang.Columns["MaSP"].Width = 50;
                dgvKhoHang.Columns["TenSP"].HeaderText = "Sản phẩm";
                dgvKhoHang.Columns["TenSP"].Width = 180;
                dgvKhoHang.Columns["SizeSP"].HeaderText = "Size";
                dgvKhoHang.Columns["SizeSP"].Width = 60;
                dgvKhoHang.Columns["SoLuong"].HeaderText = "Số lượng";
                dgvKhoHang.Columns["SoLuong"].Width = 90;
                dgvKhoHang.Columns["NgayNhap"].HeaderText = "Ngày nhập";
                dgvKhoHang.Columns["NgayNhap"].Width = 120;
                dgvKhoHang.Columns["GiaNhap"].HeaderText = "Giá nhập";
                dgvKhoHang.Columns["GiaBan"].HeaderText = "Giá bán";
            }
        }
        public void loadDGV_GiamDan()
        {
            List<KhoHang_DTO> lstKhoHang = KhoHang_BUS.SapXep_GiamDan_SoLuong_BUS();
            if (lstKhoHang != null)
            {
                dgvKhoHang.DataSource = lstKhoHang;
                dgvKhoHang.Columns["MaSP"].HeaderText = "ID";
                dgvKhoHang.Columns["MaSP"].Width = 50;
                dgvKhoHang.Columns["TenSP"].HeaderText = "Sản phẩm";
                dgvKhoHang.Columns["TenSP"].Width = 180;
                dgvKhoHang.Columns["SizeSP"].HeaderText = "Size";
                dgvKhoHang.Columns["SizeSP"].Width = 60;
                dgvKhoHang.Columns["SoLuong"].HeaderText = "Số lượng";
                dgvKhoHang.Columns["SoLuong"].Width = 90;
                dgvKhoHang.Columns["NgayNhap"].HeaderText = "Ngày nhập";
                dgvKhoHang.Columns["NgayNhap"].Width = 120;
                dgvKhoHang.Columns["GiaNhap"].HeaderText = "Giá nhập";
                dgvKhoHang.Columns["GiaBan"].HeaderText = "Giá bán";
            }
        }
        private void cboTim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboTim.Text.Equals("Sắp xếp tăng dần"))
            {
                loadDGV_TangDan();
            }
            if (cboTim.Text.Equals("Sắp xếp giảm dần"))
            {
                loadDGV_GiamDan();
            }
        }
        public void HienThi_SP_TimKiem()
        {
            List<PhieuNhap_DTO> lstKhoHang = PhieuNhap_BUS.TimSP_TheoTen_BUS(txtTim.Text);
            if (lstKhoHang != null)
            {           
                dgvKhoHang.DataSource = lstKhoHang;
                dgvKhoHang.Columns["MaSP"].HeaderText = "ID";
                dgvKhoHang.Columns["MaSP"].Width = 50;
                dgvKhoHang.Columns["TenSP"].HeaderText = "Sản phẩm";
                dgvKhoHang.Columns["TenSP"].Width = 180;
                dgvKhoHang.Columns["SizeSP"].HeaderText = "Size";
                dgvKhoHang.Columns["SizeSP"].Width = 60;
                dgvKhoHang.Columns["SoLuong"].HeaderText = "Số lượng";
                dgvKhoHang.Columns["SoLuong"].Width = 90;
                dgvKhoHang.Columns["NgayNhap"].HeaderText = "Ngày nhập";
                dgvKhoHang.Columns["NgayNhap"].Width = 120;
                dgvKhoHang.Columns["GiaNhap"].HeaderText = "Giá nhập";
                dgvKhoHang.Columns["GiaBan"].HeaderText = "Giá bán";
            }
        }
        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            HienThi_SP_TimKiem();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            HienThi_SP_TimKiem();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frm_ReportSP f = new frm_ReportSP();
            f.ShowDialog();
        }
    }
}
