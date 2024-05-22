using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
using System.IO;
namespace GUI
{
    public partial class frm_ThemSP : Form
    {
        string[] lstSize = { "S", "M", "L", "XL", "FreeSize" };
        string f = "";
        public frm_ThemSP()
        {
            InitializeComponent();
            cboSize.DataSource = lstSize;

            List<LoaiSP_DTO> lstLoaiSP = LoaiSP_BUS.LayLoaiSP_ComboBox_BUS();
            cboLoai.DataSource = lstLoaiSP;
            cboLoai.DisplayMember = "tenloai";

            List<NhaCungCap_DTO> lstNCC = NhaCungCap_BUS.LayNCC_ComboBox_BUS();
            cboNCC.DataSource = lstNCC;
            cboNCC.DisplayMember = "tenncc";

            List<ChatLieu_DTO> lstCL = ChatLieu_BUS.LayChatLieu_ComboBox_BUS();
            cboCL.DisplayMember = "TenCL";
            cboCL.DataSource = lstCL;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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
        public bool check_Nhap()
        {
            if (txtMaSP.Text.Equals(""))
            {
                MessageBox.Show("Mã sản phẩm không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaSP.Focus();
                return false;
            }
            else 
            {
                if(txtMaSP.Text.Length > 5)
                {
                    MessageBox.Show("Mã sản phẩm chỉ chứa 5 kí tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaSP.Text = "";
                    txtMaSP.Focus();
                    return false;
                }
                else
                {
                    if(SanPham_BUS.TimSP_ID_BUS(txtMaSP.Text)!=null)
                    {
                        MessageBox.Show("Mã sản phẩm đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMaSP.Text = "";
                        txtMaSP.Focus();
                        return false;
                    }    
                }
            }
            return true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(check_Nhap())
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
                    SanPham_BUS.InsertSP_BUS(sp);
                    MessageBox.Show("Thêm 1 sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }    
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
    }
}
