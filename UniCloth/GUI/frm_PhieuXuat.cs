using BUS;
using DTO;
using GUI.QuanLyShopQuanAoDataSetTableAdapters;
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
    public partial class frm_PhieuXuat : Form
    {
        PhieuXuat_DTO px;
        String[] am_pm = { "AM", "PM" };
        string[] lstTim = { "Mã SP", "Tên SP" };
        string dateTime = "";
        string gio = "";
        string phut = "";
        string id_nv;
        public frm_PhieuXuat(string manv)
        {
            InitializeComponent();
            id_nv = manv;
        }
        public void load_All()
        {
            int slsp = KhoHang_BUS.LaySoLuong_SP_KhoHang_BUS();
            string[] lstSP = new string[slsp];
            List<KhoHang_DTO> sp = KhoHang_BUS.LaySanPham_ComboBox_KhoHang_BUS();
            for (int i = 0; i < lstSP.Length; i++)
            {
                lstSP[i] = sp[i].MaSP + " | " + sp[i].TenSP + " | " + sp[i].SizeSP;
            }
            cboSP.DataSource = lstSP;
            cboSC.DataSource = am_pm;
            cboTim.DataSource = lstTim;

            int slkh = KhachHang_BUS.LaySoLuong_KH_BUS();
            string[] lstKH = new string[slkh];
            List<KhachHang_DTO> kh = KhachHang_BUS.LayKhachHang_DataGridView_BUS();
            for (int i = 0; i < lstKH.Length; i++)
            {
                lstKH[i] = kh[i].MaKH + " | " + kh[i].HoTen;
            }
            cboKH.DataSource = lstKH;

        }
        public void load_DGV()
        {
            List<PhieuXuat_DTO> lstPX = PhieuXuat_BUS.LayPX_DataGridView_BUS();
            if (lstPX != null)
            {
                dgvPhieuXuat.DataSource = lstPX;
                dgvPhieuXuat.Columns["MaSP"].Visible = false;
                dgvPhieuXuat.Columns["MaNV"].Visible = false;
                dgvPhieuXuat.Columns["MaKH"].Visible = false;
                dgvPhieuXuat.Columns["SoPhieu"].HeaderText = "ID";
                dgvPhieuXuat.Columns["SoPhieu"].Width = 30;
                dgvPhieuXuat.Columns["TenNV"].HeaderText = "Nhân viên lập";
                dgvPhieuXuat.Columns["TenKH"].HeaderText = "Khách hàng";            
                dgvPhieuXuat.Columns["SoLuong"].HeaderText = "Số lượng";
                dgvPhieuXuat.Columns["SoLuong"].Width = 50;
                dgvPhieuXuat.Columns["NgayXuat"].HeaderText = "Ngày xuất";
                dgvPhieuXuat.Columns["NgayXuat"].Width = 120;                
                dgvPhieuXuat.Columns["TenSP"].HeaderText = "Sản phẩm";
                dgvPhieuXuat.Columns["TenSP"].Width = 150;
                dgvPhieuXuat.Columns["SizeSP"].HeaderText = "Size";
                dgvPhieuXuat.Columns["SizeSP"].Width = 70;
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
        public bool check_DL()
        {
            if(kt_KiTuSo(txtGio.Text) == 1)
            {
                MessageBox.Show("Giờ phải là kí tự số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGio.Text = "";
                txtGio.Focus();
                return false;
            }    
            else
            {
                if (int.Parse(txtGio.Text) < 0 || int.Parse(txtGio.Text) > 12)
                {
                    MessageBox.Show("Giờ phải từ 0 -> 12!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtGio.Text = "";
                    txtGio.Focus();
                    return false;
                }
                else
                {
                    if (int.Parse(txtGio.Text) >= 0 && int.Parse(txtGio.Text) <= 9)
                    {
                        gio = "0" + txtGio.Text;
                    }
                    else
                    {
                        gio = txtGio.Text;
                    }
                }
            }
            if(kt_KiTuSo(txtPhut.Text) == 1)
            {
                MessageBox.Show("Phút phải là kí tự số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhut.Text = "";
                txtPhut.Focus();
                return false;
            }
            else
            {
                if (int.Parse(txtPhut.Text) < 0 || int.Parse(txtPhut.Text) > 60)
                {
                    MessageBox.Show("Phút phải từ 0 -> 60", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPhut.Text = "";
                    txtPhut.Focus();
                    return false;
                }
                else
                {
                    if (int.Parse(txtPhut.Text) >= 0 && int.Parse(txtPhut.Text) <= 9)
                    {
                        phut = "0" + txtPhut.Text;
                    }
                    else
                    {
                        phut = txtPhut.Text;
                    }
                }
            }
            if (kt_KiTuSo(txtSoLuong.Text) == 1)
            {
                MessageBox.Show("Số lượng xuất là kí tự số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoLuong.Text = "";
                txtSoLuong.Focus();
                return false;
            }
            else
            {
                if (int.Parse(txtSoLuong.Text) < 0)
                {
                    MessageBox.Show("Số lượng xuất phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSoLuong.Text = "";
                    txtSoLuong.Focus();
                    return false;
                }
            }
            if (dtpNgayXuat.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày nhập hàng phải không được lớn hơn hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(int.Parse(txtSoLuong.Text)>KhoHang_BUS.lay_SL_Kho_BUS(Lay_5_characters(cboSP.Text)))
            {
                MessageBox.Show("Số lượng xuất phải nhỏ hơn số lượng sản phẩm trong kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }    
            return true;
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
        private string Lay_4_characters(string text)
        {
            char[] chars = text.ToCharArray();
            string s = "";
            for (int i = 0; i < 4; i++)
            {
                s += chars[i];
            }
            return s;
        }
        public void layDL()
        {
            px = new PhieuXuat_DTO();
            dateTime = dtpNgayXuat.Text + " " + gio + ":" + phut + ":00" + " " + cboSC.Text;
            px.MaSP = Lay_5_characters(cboSP.Text);
            px.NgayXuat = dateTime;
            px.MaNV = id_nv;
            px.SoLuong = int.Parse(txtSoLuong.Text);            
            px.MaKH = Lay_4_characters(cboKH.Text);
        }
        private void frm_PhieuXuat_Load(object sender, EventArgs e)
        {
            load_All();
            load_DGV();
        }

        private void dgvPhieuNhap_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgvPhieuXuat.SelectedRows[0];
            int sp = int.Parse(dr.Cells["SoPhieu"].Value.ToString());
            ChiTiet_PX ct = new ChiTiet_PX(sp);
            ct.ShowDialog();
        }

        private void btnXuatHang_Click(object sender, EventArgs e)
        {
            if (check_DL())
            {
                try
                {
                    layDL();
                    PhieuXuat_BUS.Insert_PhieuXuat_BUS(px);
                    int sl = KhoHang_BUS.lay_SL_Kho_BUS(px.MaSP)-int.Parse(txtSoLuong.Text);
                    KhoHang_BUS.Update_SoLuong_Kho_BUS(sl, px.MaSP);
                    MessageBox.Show("Lập phiếu xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load_DGV();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            load_All();
            txtSoLuong.Text = string.Empty;
            txtGio.Text = string.Empty;
            txtPhut.Text = string.Empty;
        }
        private Image ByteToImg(string byteString)
        {
            byte[] imgBytes = Convert.FromBase64String(byteString);
            MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
            ms.Write(imgBytes, 0, imgBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
        private void cboSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string masp = Lay_5_characters(cboSP.Text);
            SanPham_DTO sp = SanPham_BUS.TimSP_ID_BUS(masp);
            picSP.Image = ByteToImg(sp.AnhSP.ToString());

            int sl = KhoHang_BUS.TimSP_ID_KhoHang_BUS(masp).SoLuong;
            lblSoLuongTon.Text = "Số lượng trong kho: "+sl.ToString();
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            ThemKH f = new ThemKH();
            f.ShowDialog();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            load_All();
            load_DGV();
        }
        public void HienThi_MaSP()
        {
            List<PhieuXuat_DTO> lstPX = PhieuXuat_BUS.TimSP_MaSP_PhieuXuat_BUS(txtTim.Text);
            if (lstPX != null)
            {
                dgvPhieuXuat.DataSource = lstPX;
                dgvPhieuXuat.Columns["MaSP"].Visible = false;
                dgvPhieuXuat.Columns["MaNV"].Visible = false;
                dgvPhieuXuat.Columns["MaKH"].Visible = false;
                dgvPhieuXuat.Columns["SoPhieu"].HeaderText = "ID";
                dgvPhieuXuat.Columns["SoPhieu"].Width = 30;
                dgvPhieuXuat.Columns["TenNV"].HeaderText = "Nhân viên lập";
                dgvPhieuXuat.Columns["TenKH"].HeaderText = "Khách hàng";
                dgvPhieuXuat.Columns["SoLuong"].HeaderText = "Số lượng";
                dgvPhieuXuat.Columns["SoLuong"].Width = 50;
                dgvPhieuXuat.Columns["NgayXuat"].HeaderText = "Ngày xuất";
                dgvPhieuXuat.Columns["NgayXuat"].Width = 120;
                dgvPhieuXuat.Columns["TenSP"].HeaderText = "Sản phẩm";
                dgvPhieuXuat.Columns["TenSP"].Width = 150;
                dgvPhieuXuat.Columns["SizeSP"].HeaderText = "Size";
                dgvPhieuXuat.Columns["SizeSP"].Width = 70;
            }
        }
        public void HienThi_TenSP()
        {
            List<PhieuXuat_DTO> lstPX = PhieuXuat_BUS.TimSP_Ten_PhieuXuat_BUS(txtTim.Text);
            if (lstPX != null)
            {
                dgvPhieuXuat.DataSource = lstPX;
                dgvPhieuXuat.Columns["MaSP"].Visible = false;
                dgvPhieuXuat.Columns["MaNV"].Visible = false;
                dgvPhieuXuat.Columns["MaKH"].Visible = false;
                dgvPhieuXuat.Columns["SoPhieu"].HeaderText = "ID";
                dgvPhieuXuat.Columns["SoPhieu"].Width = 30;
                dgvPhieuXuat.Columns["TenNV"].HeaderText = "Nhân viên lập";
                dgvPhieuXuat.Columns["TenKH"].HeaderText = "Khách hàng";
                dgvPhieuXuat.Columns["SoLuong"].HeaderText = "Số lượng";
                dgvPhieuXuat.Columns["SoLuong"].Width = 50;
                dgvPhieuXuat.Columns["NgayXuat"].HeaderText = "Ngày xuất";
                dgvPhieuXuat.Columns["NgayXuat"].Width = 120;
                dgvPhieuXuat.Columns["TenSP"].HeaderText = "Sản phẩm";
                dgvPhieuXuat.Columns["TenSP"].Width = 150;
                dgvPhieuXuat.Columns["SizeSP"].HeaderText = "Size";
                dgvPhieuXuat.Columns["SizeSP"].Width = 70;
            }
        }
        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            if(cboTim.Text.Equals("Mã SP"))
            {
                HienThi_MaSP();
            }
            if (cboTim.Text.Equals("Tên SP"))
            {
                HienThi_TenSP();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {

        }
    }
}
