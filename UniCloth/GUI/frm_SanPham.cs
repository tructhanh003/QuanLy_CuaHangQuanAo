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
using BUS;
using DTO;
namespace GUI
{
    public partial class frm_SanPham : Form
    {
        string[] lstTim = { "Mã SP", "Tên SP", "Màu" };
        string[] lstSize = { "S", "M", "L", "XL", "FreeSize" };
        string f = "";
        public frm_SanPham()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {           
            DialogResult result = MessageBox.Show("Bạn có chắc muốn cập nhật thông tin của sản phẩm này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    SanPham_DTO sp = new SanPham_DTO();
                    sp.MaSP = txtMaSP.Text;
                    sp.TenSP = txtTenSP.Text;
                    sp.MauSP = txtMauSP.Text;
                    sp.SizeSP = cboSize.Text;
                    sp.NoteSP = txtNote.Text;
                    sp.AnhSP = Convert.ToBase64String(converImgToByte());
                    sp.MaLoai = LoaiSP_BUS.chuyenMaLoai_BUS(cboLoai.Text);
                    sp.MaCL = ChatLieu_BUS.chuyenMaCL_BUS(cboCL.Text);
                    sp.MaNCC = NhaCungCap_BUS.chuyenMaNCC_BUS(cboNCC.Text);
                    SanPham_BUS.UpdateSP_BUS(sp);
                    MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThi_DGV();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void HienThi_DGV()
        {
            List<SanPham_DTO> lstSP = SanPham_BUS.LaySanPham_DataGridView_BUS();
            dgvSP.DataSource = lstSP;
            dgvSP.Columns["MaSP"].HeaderText = "Mã SP";
            dgvSP.Columns["MaSP"].Width = 50;
            dgvSP.Columns["TenSP"].HeaderText = "Tên SP";
            dgvSP.Columns["TenSP"].Width = 120;           
            dgvSP.Columns["MauSP"].HeaderText = "Màu sắc";
            dgvSP.Columns["MauSP"].Width = 70;
            dgvSP.Columns["SizeSP"].HeaderText = "Size";
            dgvSP.Columns["SizeSP"].Width = 50;
            dgvSP.Columns["AnhSP"].Visible = false;
            dgvSP.Columns["MaLoai"].Visible = false;
            dgvSP.Columns["MaNCC"].Visible = false;
            dgvSP.Columns["MaCL"].Visible = false;
            dgvSP.Columns["NoteSP"].Visible = false;
            dgvSP.Columns["TenLoai"].HeaderText = "Loại";
            dgvSP.Columns["TenLoai"].Width = 70;
            dgvSP.Columns["TenNCC"].HeaderText = "Nhà cung cấp";
            dgvSP.Columns["TenNCC"].Width = 100;
            dgvSP.Columns["TenCL"].HeaderText = "Chất liệu";
            dgvSP.Columns["TenCL"].Width = 90;
        }
        private byte[] converImgToByte()
        {
            FileStream fs;
            fs = new FileStream(f, FileMode.Open, FileAccess.Read);
            byte[] picbyte = new byte[fs.Length];
            fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            return picbyte;
        }
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh";
            openFileDialog.Filter = "Image Files(*.gif; *.jpg; *.jpeg; *.bmp; *.wmf; *.png)|*.gif; *.jpg; *.jpeg; *.bmp; *.wmf; *.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                f = openFileDialog.FileName;
                Image img = Image.FromFile(f);
                picSP.Image = img;
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            HienThi_DGV();
            txtTim.Text = "";
        }
        private Image ByteToImg(string byteString)
        {
            byte[] imgBytes = Convert.FromBase64String(byteString);
            MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
            ms.Write(imgBytes, 0, imgBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
        private void dgvSP_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgvSP.SelectedRows[0];
            txtMaSP.Text = dr.Cells["MaSP"].Value.ToString();
            txtTenSP.Text = dr.Cells["TenSP"].Value.ToString();
            txtMauSP.Text = dr.Cells["MauSP"].Value.ToString();
            txtNote.Text = dr.Cells["NoteSP"].Value.ToString();
            cboSize.Text = dr.Cells["SizeSP"].Value.ToString();
            cboCL.Text = ChatLieu_BUS.chuyenMa_TenCL(int.Parse(dr.Cells["MaCL"].Value.ToString()));
            cboLoai.Text = LoaiSP_BUS.chuyenMa_TenLoai(int.Parse(dr.Cells["MaLoai"].Value.ToString()));          
            cboNCC.Text = NhaCungCap_BUS.chuyenMa_TenNCC(int.Parse(dr.Cells["MaNCC"].Value.ToString()));            
            picSP.Image = ByteToImg(dr.Cells["AnhSP"].Value.ToString());
        }

        private void frm_SanPham_Load(object sender, EventArgs e)
        {
            cboSize.DataSource = lstSize;
            cboTim.DataSource = lstTim;
            
            List<LoaiSP_DTO> lstLoaiSP = LoaiSP_BUS.LayLoaiSP_ComboBox_BUS();
            cboLoai.DataSource = lstLoaiSP;
            cboLoai.DisplayMember = "tenloai";

            List<NhaCungCap_DTO> lstNCC = NhaCungCap_BUS.LayNCC_ComboBox_BUS();
            cboNCC.DataSource = lstNCC;
            cboNCC.DisplayMember = "tenncc";

            List<ChatLieu_DTO> lstCL = ChatLieu_BUS.LayChatLieu_ComboBox_BUS();
            cboCL.DisplayMember = "TenCL";
            cboCL.DataSource = lstCL;

            HienThi_DGV();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    SanPham_BUS.DeleteSP_BUS(txtMaSP.Text);
                    MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThi_DGV();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReload_Click_1(object sender, EventArgs e)
        {
            HienThi_DGV();
            txtTim.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frm_ThemSP f = new frm_ThemSP();
            f.ShowDialog();
        }
        public void HienThi_MaSP_TimKiem()
        {
            List<SanPham_DTO> lstSP = SanPham_BUS.TimSP_MaSP(txtTim.Text);
            if(lstSP!=null)
            {
                dgvSP.DataSource = lstSP;
                dgvSP.Columns["MaSP"].HeaderText = "Mã SP";
                dgvSP.Columns["MaSP"].Width = 50;
                dgvSP.Columns["TenSP"].HeaderText = "Tên SP";
                dgvSP.Columns["TenSP"].Width = 120;
                dgvSP.Columns["MauSP"].HeaderText = "Màu sắc";
                dgvSP.Columns["MauSP"].Width = 70;
                dgvSP.Columns["SizeSP"].HeaderText = "Size";
                dgvSP.Columns["SizeSP"].Width = 50;
                dgvSP.Columns["AnhSP"].Visible = false;
                dgvSP.Columns["MaLoai"].Visible = false;
                dgvSP.Columns["MaNCC"].Visible = false;
                dgvSP.Columns["MaCL"].Visible = false;
                dgvSP.Columns["NoteSP"].Visible = false;
                dgvSP.Columns["TenLoai"].HeaderText = "Loại";
                dgvSP.Columns["TenLoai"].Width = 70;
                dgvSP.Columns["TenNCC"].HeaderText = "Nhà cung cấp";
                dgvSP.Columns["TenNCC"].Width = 100;
                dgvSP.Columns["TenCL"].HeaderText = "Chất liệu";
                dgvSP.Columns["TenCL"].Width = 90;
            }    
        }
        public void HienThi_TenSP_TimKiem()
        {
            List<SanPham_DTO> lstSP = SanPham_BUS.TimSP_Ten(txtTim.Text);
            if (lstSP != null)
            {
                dgvSP.DataSource = lstSP;
                dgvSP.Columns["MaSP"].HeaderText = "Mã SP";
                dgvSP.Columns["MaSP"].Width = 50;
                dgvSP.Columns["TenSP"].HeaderText = "Tên SP";
                dgvSP.Columns["TenSP"].Width = 120;
                dgvSP.Columns["MauSP"].HeaderText = "Màu sắc";
                dgvSP.Columns["MauSP"].Width = 70;
                dgvSP.Columns["SizeSP"].HeaderText = "Size";
                dgvSP.Columns["SizeSP"].Width = 50;
                dgvSP.Columns["AnhSP"].Visible = false;
                dgvSP.Columns["MaLoai"].Visible = false;
                dgvSP.Columns["MaNCC"].Visible = false;
                dgvSP.Columns["MaCL"].Visible = false;
                dgvSP.Columns["NoteSP"].Visible = false;
                dgvSP.Columns["TenLoai"].HeaderText = "Loại";
                dgvSP.Columns["TenLoai"].Width = 70;
                dgvSP.Columns["TenNCC"].HeaderText = "Nhà cung cấp";
                dgvSP.Columns["TenNCC"].Width = 100;
                dgvSP.Columns["TenCL"].HeaderText = "Chất liệu";
                dgvSP.Columns["TenCL"].Width = 90;
            }
        }
        public void HienThi_Mau_TimKiem()
        {
            List<SanPham_DTO> lstSP = SanPham_BUS.TimSP_MauSP(txtTim.Text);
            if (lstSP != null)
            {
                dgvSP.DataSource = lstSP;
                dgvSP.Columns["MaSP"].HeaderText = "Mã SP";
                dgvSP.Columns["MaSP"].Width = 50;
                dgvSP.Columns["TenSP"].HeaderText = "Tên SP";
                dgvSP.Columns["TenSP"].Width = 120;
                dgvSP.Columns["MauSP"].HeaderText = "Màu sắc";
                dgvSP.Columns["MauSP"].Width = 70;
                dgvSP.Columns["SizeSP"].HeaderText = "Size";
                dgvSP.Columns["SizeSP"].Width = 50;
                dgvSP.Columns["AnhSP"].Visible = false;
                dgvSP.Columns["MaLoai"].Visible = false;
                dgvSP.Columns["MaNCC"].Visible = false;
                dgvSP.Columns["MaCL"].Visible = false;
                dgvSP.Columns["NoteSP"].Visible = false;
                dgvSP.Columns["TenLoai"].HeaderText = "Loại";
                dgvSP.Columns["TenLoai"].Width = 70;
                dgvSP.Columns["TenNCC"].HeaderText = "Nhà cung cấp";
                dgvSP.Columns["TenNCC"].Width = 100;
                dgvSP.Columns["TenCL"].HeaderText = "Chất liệu";
                dgvSP.Columns["TenCL"].Width = 90;
            }
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            if(cboTim.Text.Equals("Mã SP"))
            {
                HienThi_MaSP_TimKiem();
            }
            if (cboTim.Text.Equals("Tên SP"))
            {
                HienThi_TenSP_TimKiem();
            }
            if (cboTim.Text.Equals("Màu"))
            {
                HienThi_Mau_TimKiem();
            }
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            if (cboTim.Text.Equals("Mã SP"))
            {
                HienThi_MaSP_TimKiem();
            }
            if (cboTim.Text.Equals("Tên SP"))
            {
                HienThi_TenSP_TimKiem();
            }
            if (cboTim.Text.Equals("Màu"))
            {
                HienThi_Mau_TimKiem();
            }
        }
    }
}
