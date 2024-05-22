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
    public partial class frm_ChungTu : Form
    {
        public frm_ChungTu()
        {
            InitializeComponent();
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
        private void frm_ChungTu_Load(object sender, EventArgs e)
        {
            load_DataGridView();
        }

        private void dgvHD_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgvHD.SelectedRows[0];
            string s = dr.Cells["MaHD"].Value.ToString();
            List<CTHD_DTO> lstCTHD = CTHD_BUS.Lay_CTHD_DGV(s);
            if (lstCTHD != null)
            {
                dgvCTHD.DataSource = lstCTHD;
                dgvCTHD.Columns["MaHD"].HeaderText = "ID";
                dgvCTHD.Columns["MaHD"].Width = 50;
                dgvCTHD.Columns["SoLuong"].HeaderText = "Số lượng";
                dgvCTHD.Columns["SoLuong"].Width = 75;
                dgvCTHD.Columns["MaSP"].Visible = false;
                dgvCTHD.Columns["TongTien"].Visible = false;
                dgvCTHD.Columns["TenSP"].HeaderText = "Sản phẩm";
                dgvCTHD.Columns["TenSP"].Width = 200;
                dgvCTHD.Columns["GiaTien"].HeaderText = "Giá tiền";
                dgvCTHD.Columns["GiaTien"].Width = 88;
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if(dtpThuNhat.Value > dtpThuHai.Value)
            {
                MessageBox.Show("Giá trị ngày tháng năm đầu tiên phải trước giá trị ngày tháng năm thứ hai!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    List<HoaDon_DTO> list = HoaDon_BUS.LayHD_ChungTu_BUS(dtpThuNhat.Text, dtpThuHai.Text);
                    if (list != null)
                    {
                        MessageBox.Show("Đã tìm thấy hóa đơn trong khoảng thời gian này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvHD.DataSource = list;
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
                    else
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn trong khoảng thời gian này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } catch(Exception ex) {
                    MessageBox.Show("Lỗi: "+ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            load_DataGridView();
            dtpThuNhat.Value = DateTime.Now;
            dtpThuHai.Value = DateTime.Now;
            dgvCTHD.DataSource = null;
        }
    }
}
