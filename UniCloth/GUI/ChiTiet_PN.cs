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

namespace GUI
{
    public partial class ChiTiet_PN : Form
    {
        int id_pn;
        string masp;
        public ChiTiet_PN(int sophieu)
        {
            InitializeComponent();
            id_pn = sophieu;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa phiếu nhập này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(result==DialogResult.Yes)
            {
                try
                {
                    PhieuNhap_BUS.DeleteKho_BUS(id_pn);
                    MessageBox.Show("Đã xóa 1 phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch(Exception ex)
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
        private void ChiTiet_PN_Load(object sender, EventArgs e)
        {
            PhieuNhap_DTO pn = PhieuNhap_BUS.HienThi_SP_BUS(id_pn);
            lblSP.Text = pn.TenSP + " " + pn.SizeSP;
            lblNCC.Text = pn.TenNCC;
            masp = pn.MaSP;
            SanPham_DTO sp = SanPham_BUS.TimSP_ID_BUS(masp);
            lblGiaNhap.Text = pn.GiaNhap.ToString();
            lblNgayNhap.Text = pn.NgayNhap;
            lblSoLuong.Text = pn.SoLuong.ToString();
            picSP.Image = ByteToImg(sp.AnhSP.ToString());
        }
    }
}
