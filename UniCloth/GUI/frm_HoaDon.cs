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
    public partial class frm_HoaDon : Form
    {
        string id_nv;
        HoaDon_DTO hd;
        CTHD_DTO cthd;
        string dateTime = "";
        string gio = "";
        string phut = "";
        String[] am_pm = { "AM", "PM" };
        public frm_HoaDon(string manv)
        {
            InitializeComponent();
            id_nv = manv;
        }
        public void Load_All_DL()
        {
            NhanVien_DTO nv = NhanVien_BUS.TimNhanVienTheoID_BUS(id_nv);
            txtNV.Text = nv.MaNV + " | " + nv.HoTen;

            int slkh = KhachHang_BUS.LaySoLuong_KH_BUS();
            string[] lstKH = new string[slkh];
            List<KhachHang_DTO> kh = KhachHang_BUS.LayKhachHang_DataGridView_BUS();
            for (int i = 0; i < lstKH.Length; i++)
            {
                lstKH[i] = kh[i].MaKH + " | " + kh[i].HoTen;
            }
            cboKH.DataSource = lstKH;

            int slsp = KhoHang_BUS.LaySoLuong_SP_KhoHang_BUS();
            string[] lstSP = new string[slsp];
            List<KhoHang_DTO> sp = KhoHang_BUS.LaySanPham_ComboBox_KhoHang_BUS();
            for (int i = 0; i < lstSP.Length; i++)
            {
                lstSP[i] = sp[i].MaSP + " | " + sp[i].TenSP + " | " + sp[i].SizeSP;
            }
            cboSP.DataSource = lstSP;
            cboSC.DataSource = am_pm;

            List<HoaDon_DTO> lstHD = HoaDon_BUS.LayHD_DataGridView_BUS();
            cboTim.DataSource = lstHD;
            cboTim.DisplayMember = "MaHD";
            load_DataGridView();
        }
        public void load_DataGridView()
        {
            List<HoaDon_DTO> lstHD = HoaDon_BUS.LayHD_DataGridView_BUS();
            if (lstHD != null)
            {
                dgvHD.DataSource = lstHD;
                dgvHD.Columns["MaHD"].HeaderText = "ID";
                dgvHD.Columns["MaHD"].Width = 50;
                dgvHD.Columns["TenNV"].HeaderText = "Nhân viên lập";
                dgvHD.Columns["TenNV"].Width = 150;
                dgvHD.Columns["TenKH"].HeaderText = "Khách hàng";
                dgvHD.Columns["TenKH"].Width = 150;
                dgvHD.Columns["MaNV"].Visible = false;
                dgvHD.Columns["MaKH"].Visible = false;
                dgvHD.Columns["NgayLap"].HeaderText = "Ngày lập";
            }
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
            if(txtMaHD.Text.Equals(""))
            {
                MessageBox.Show("Mã hóa đơn không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaHD.Text = "";
                txtMaHD.Focus();
                return false;
            }
            else
            {
                if (HoaDon_BUS.TimHD_ID_BUS(txtMaHD.Text) != null)
                {
                    MessageBox.Show("Mã hóa đơn đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    if(txtMaHD.Text.Length > 5)
                    {
                        MessageBox.Show("Mã hóa đơn chỉ chứa 5 kí tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }    
                }
            }
            if (kt_KiTuSo(txtGio.Text) == 1)
            {
                MessageBox.Show("Giờ phải nhập là kí tự số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGio.Text = "";
                txtGio.Focus();
                return false;
            }
            else
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
            }
            if(kt_KiTuSo(txtPhut.Text) == 1)
            {
                MessageBox.Show("Phút phải nhập là kí tự số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if(kt_KiTuSo(txtSoLuong.Text) ==1)
            {
                MessageBox.Show("Số lượng nhập phải là kí tự số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                else
                {
                    if (PhieuNhap_BUS.lay_SL_Kho_BUS(Lay_5_characters(cboSP.Text)) < int.Parse(txtSoLuong.Text))
                    {
                        MessageBox.Show("Số lượng sản phẩm trong kho không đủ! \n Số lượng tồn: " + PhieuNhap_BUS.lay_SL_Kho_BUS(Lay_5_characters(cboSP.Text)), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSoLuong.Text = "";
                        txtSoLuong.Focus();
                        return false;
                    }
                }
            }
            if (dtpNgayLap.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày lập đơn không được lớn hơn hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public bool checkDL_CTHD()
        {
            if (txtMaHD.Text.Equals(""))
            {
                MessageBox.Show("Mã hóa đơn không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaHD.Text = "";
                txtMaHD.Focus();
                return false;
            }
            else
            {
                if (txtMaHD.Text.Length > 5)
                {
                    MessageBox.Show("Mã hóa đơn chỉ chứa 5 kí tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }                 
            }
            if (kt_KiTuSo(txtSoLuong.Text) == 1)
            {
                MessageBox.Show("Số lượng nhập phải là kí tự số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                else
                {
                    if (KhoHang_BUS.lay_SL_Kho_BUS(Lay_5_characters(cboSP.Text)) < int.Parse(txtSoLuong.Text))
                    {
                        MessageBox.Show("Số lượng sản phẩm trong kho không đủ! \n Số lượng tồn: " + KhoHang_BUS.lay_SL_Kho_BUS(Lay_5_characters(cboSP.Text)), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSoLuong.Text = "";
                        txtSoLuong.Focus();
                        return false;
                    }
                }
            }
            return true;
        }
        private void LayDL_HD()
        {
            hd = new HoaDon_DTO();
            hd.MaHD = txtMaHD.Text;
            dateTime = dtpNgayLap.Text + " " + gio + ":" + phut + ":00" + " " + cboSC.Text;
            hd.MaNV = Lay_4_characters(txtNV.Text);
            hd.MaKH = Lay_4_characters(cboKH.Text);
            hd.NgayLap = dateTime;
        }
        private void LayDL_CTHD()
        {
            cthd = new CTHD_DTO();
            cthd.MaHD = txtMaHD.Text;
            cthd.MaSP = Lay_5_characters(cboSP.Text);
            cthd.SoLuong = int.Parse(txtSoLuong.Text);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
             if (CTHD_BUS.kt_MaHD_CTHD(txtMaHD.Text) != null)
             {
                if(checkDL_CTHD())
                {
                    // thêm cthđ, ko them hd
                    LayDL_CTHD();
                    try
                    {
                        CTHD_BUS.InsertCTHD(cthd);
                        int soluongKho = KhoHang_BUS.lay_SL_Kho_BUS(cthd.MaSP) - cthd.SoLuong;
                        KhoHang_BUS.Update_SoLuong_Kho_BUS(soluongKho, cthd.MaSP);
                        MessageBox.Show("Thêm hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("CTHD: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }    
             }
             else
             {
                // thêm cả hđ và cthđ
                if (check_DL())
                {
                    LayDL_HD();
                    LayDL_CTHD();
                    try
                    {
                        HoaDon_BUS.InsertHD(hd);
                        CTHD_BUS.InsertCTHD(cthd);
                        int soluongKho = KhoHang_BUS.lay_SL_Kho_BUS(cthd.MaSP) - cthd.SoLuong;
                        KhoHang_BUS.Update_SoLuong_Kho_BUS(soluongKho, cthd.MaSP);
                        MessageBox.Show("Thêm hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load_DataGridView();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("HD: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
               
        }

        private void frm_HoaDon_Load(object sender, EventArgs e)
        {
            Load_All_DL();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtMaHD.Text = "";
            txtSoLuong.Text = "";
            txtGio.Text = "";
            txtPhut.Text = "";
            txtMaHD.Focus();
        }

        private void dgvHD_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgvHD.SelectedRows[0];
            string s = dr.Cells["MaHD"].Value.ToString();
            ChiTiet_HD f = new ChiTiet_HD(s);
            f.ShowDialog();
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            ThemKH f = new ThemKH();
            f.ShowDialog();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            Load_All_DL();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            List<HoaDon_DTO> hd = HoaDon_BUS.TimKiem_HD_TheoMa_DGV_BUS(cboTim.Text);
            if (hd != null)
            {
                dgvHD.DataSource = hd;
                
            }
        }

        private void cboSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string masp = Lay_5_characters(cboSP.Text);
            SanPham_DTO sp = SanPham_BUS.TimSP_ID_BUS(masp);            

            int sl = KhoHang_BUS.TimSP_ID_KhoHang_BUS(masp).SoLuong;
            lblSoLuongTon.Text = "Tồn kho: " + sl.ToString();
        }
    }
}
