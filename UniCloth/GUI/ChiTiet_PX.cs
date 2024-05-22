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
    public partial class ChiTiet_PX : Form
    {
        int id_px;
        string masp;
        public ChiTiet_PX(int sophieu)
        {
            InitializeComponent();
            id_px = sophieu;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private Image ByteToImg(string byteString)
        {
            byte[] imgBytes = Convert.FromBase64String(byteString);
            MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
            ms.Write(imgBytes, 0, imgBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
        private void ChiTiet_PX_Load(object sender, EventArgs e)
        {
            PhieuXuat_DTO pn = PhieuXuat_BUS.HienThi_SP_PhieuXuat_BUS(id_px);
            lblSP.Text = pn.TenSP + " " + pn.SizeSP;
            lblKH.Text = pn.MaKH + " " + pn.TenKH;
            masp = pn.MaSP;
            SanPham_DTO sp = SanPham_BUS.TimSP_ID_BUS(masp);
            lblThanhTien.Text = (pn.SoLuong * pn.GiaBan)+" VND";
            lblNgayNhap.Text = pn.NgayXuat;
            lblSoLuong.Text = pn.SoLuong.ToString();
            picSP.Image = ByteToImg(sp.AnhSP.ToString());
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa phiếu xuất này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    PhieuXuat_BUS.Delete_PhieuXuat_BUS(id_px);
                    MessageBox.Show("Đã xóa 1 phiếu xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
