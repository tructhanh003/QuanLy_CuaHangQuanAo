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
    public partial class frm_PhieuNhap : Form
    {
        PhieuNhap_DTO pn;
        String[] am_pm = { "AM", "PM" };       
        string dateTime = "";
        string gio = "";
        string phut = "";
        string id_nv;
        public frm_PhieuNhap(string manv)
        {
            InitializeComponent();
            id_nv = manv;
        }
        public void Load_All()
        {
            int slsp = SanPham_BUS.LaySoLuong_SP_BUS();
            string[] lstSP = new string[slsp];
            List<SanPham_DTO> sp = SanPham_BUS.LaySanPham_DataGridView_BUS();
            for (int i = 0; i < lstSP.Length; i++)
            {
                lstSP[i] = sp[i].MaSP + " | " + sp[i].TenSP + " | " + sp[i].SizeSP;
            }
            cboSP.DataSource = lstSP;
            cboSC.DataSource = am_pm;          
           
            load_DGV();
        }
        public void load_DGV()
        {
            List<PhieuNhap_DTO> lstKhoHang = PhieuNhap_BUS.LayPN_DataGridView();
            if (lstKhoHang != null)
            {
                dgvPhieuNhap.DataSource = lstKhoHang;
                dgvPhieuNhap.Columns["MaSP"].Visible = false;
                dgvPhieuNhap.Columns["MaNV"].Visible = false;
                dgvPhieuNhap.Columns["MaNCC"].Visible = false;
                dgvPhieuNhap.Columns["SoPhieu"].HeaderText = "ID";
                dgvPhieuNhap.Columns["SoPhieu"].Width = 30;
                dgvPhieuNhap.Columns["TenNV"].HeaderText = "Nhân viên lập";
                dgvPhieuNhap.Columns["TenNCC"].HeaderText = "NCC";
                dgvPhieuNhap.Columns["TenNCC"].Width = 50;
                dgvPhieuNhap.Columns["SoLuong"].HeaderText = "Số lượng";
                dgvPhieuNhap.Columns["SoLuong"].Width = 50;
                dgvPhieuNhap.Columns["NgayNhap"].HeaderText = "Ngày nhập";
                dgvPhieuNhap.Columns["NgayNhap"].Width = 120;
                dgvPhieuNhap.Columns["GiaNhap"].HeaderText = "Giá nhập";
                dgvPhieuNhap.Columns["GiaNhap"].Width = 50;
                dgvPhieuNhap.Columns["TenSP"].HeaderText = "Sản phẩm";
                dgvPhieuNhap.Columns["TenSP"].Width = 150;
                dgvPhieuNhap.Columns["SizeSP"].HeaderText = "Size";
                dgvPhieuNhap.Columns["SizeSP"].Width = 70;
            }
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
                if (chars[i].Equals(" "))
                {
                    break;
                }
                s += chars[i];
            }
            return s;
        }
        public bool check_DL()
        {
            if (int.Parse(txtGio.Text) < 0 || int.Parse(txtGio.Text) > 12)
            {
                MessageBox.Show("Giờ phải từ 0 -> 12", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (int.Parse(txtSoLuong.Text) < 0)
            {
                MessageBox.Show("Số lượng nhập phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoLuong.Text = "";
                txtSoLuong.Focus();
                return false;
            }
            if (int.Parse(txtGiaNhap.Text) < 0)
            {
                MessageBox.Show("Giá nhập phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGiaNhap.Text = "";
                txtGiaNhap.Focus();
                return false;
            }         
            if (dtpNgayNhap.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày nhập hàng phải không được lớn hơn hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public void layDL()
        {
            pn = new PhieuNhap_DTO();
            dateTime = dtpNgayNhap.Text + " " + gio + ":" + phut + ":00" + " " + cboSC.Text;
            pn.MaSP = Lay_5_characters(cboSP.Text);
            pn.NgayNhap = dateTime;
            pn.MaNV = id_nv;
            pn.SoLuong = int.Parse(txtSoLuong.Text);
            pn.GiaNhap = int.Parse(txtGiaNhap.Text);
            pn.MaNCC = NhaCungCap_BUS.chuyenMaNCC_BUS(lblNCC.Text);
        }

        private void btnThemHang_Click(object sender, EventArgs e)
        {
            if (check_DL())
            {
                try
                {
                    if (KhoHang_BUS.TimSP_ID_KhoHang_BUS(Lay_5_characters(cboSP.Text)) == null)
                    {
                        layDL();
                        PhieuNhap_BUS.Insert_Kho(pn);
                        KhoHang_DTO kho = new KhoHang_DTO();
                        kho.MaSP = Lay_5_characters(cboSP.Text);
                        kho.SoLuong = int.Parse(txtSoLuong.Text);
                        kho.GiaBan = 0;
                        KhoHang_BUS.Insert_KhoHang_BUS(kho);
                        MessageBox.Show("Lập phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load_DGV();
                    }
                    else
                    {
                        layDL();
                        PhieuNhap_BUS.Insert_Kho(pn);
                        int sl = pn.SoLuong + KhoHang_BUS.lay_SL_Kho_BUS(pn.MaSP);
                        KhoHang_BUS.Update_SoLuong_Kho_BUS(sl, pn.MaSP);
                        MessageBox.Show("Lập phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load_DGV();                     
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frm_PhieuNhap_Load(object sender, EventArgs e)
        {
            Load_All();
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
            lblNCC.Text = NhaCungCap_BUS.chuyenMa_TenNCC(sp.MaNCC);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtSoLuong.Text = string.Empty;
            txtGiaNhap.Text = string.Empty;
            txtGio.Text = string.Empty;
            txtPhut.Text = string.Empty;
            txtGiaNhap.Focus();
        }

        private void dgvPhieuNhap_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgvPhieuNhap.SelectedRows[0];
            int sp = int.Parse(dr.Cells["SoPhieu"].Value.ToString());
            ChiTiet_PN ct = new ChiTiet_PN(sp);
            ct.ShowDialog();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            load_DGV();
        }
    }
}
