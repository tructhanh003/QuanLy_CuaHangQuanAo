using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using Excel = Microsoft.Office.Interop.Excel;
namespace GUI
{
    public partial class ChiTiet_HD : Form
    {
        string id_hd;
        public ChiTiet_HD(string mahd)
        {
            InitializeComponent();
            id_hd = mahd;
        }
        public void HienThi()
        {
            HoaDon_DTO hd = HoaDon_BUS.TimHD_ID_BUS(id_hd);
            if (hd != null)
            {
                lblMaHD.Text = hd.MaHD.ToString();
                NhanVien_DTO nv = NhanVien_BUS.TimNhanVienTheoID_BUS(hd.MaNV);
                lblNV.Text = nv.MaNV + " | " + nv.HoTen;

                KhachHang_DTO kh = KhachHang_BUS.TimKH_ID_BUS(hd.MaKH);
                lblKH.Text = kh.MaKH + " | " + kh.HoTen;

                lblNgayLap.Text = hd.NgayLap.ToString();

                List<CTHD_DTO> lstCTHD = CTHD_BUS.Lay_CTHD_DGV(id_hd);
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
                int tien = CTHD_BUS.TinhTongTien_BUS(id_hd);
                if(tien > 0)
                {
                    lblTongTien.Text = CTHD_BUS.TinhTongTien_BUS(id_hd).ToString() + " VND";
                }                
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChiTiet_HD_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa hóa đơn này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {

                    HoaDon_BUS.DeleteHD_BUS(lblMaHD.Text);
                    MessageBox.Show("Đã xóa hóa đơn thành công!", "Thông báo");                    
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo");
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn in hóa đơn ra file excel?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Excel.Application exApp = new Excel.Application();
                Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
                Excel.Range exRange = (Excel.Range)exSheet.Cells[1, 1];
                exRange.Font.Size = 15;
                exRange.Font.Bold = true;
                exRange.Font.Color = Color.Blue;
                exRange.Value = "UniCloth Store";

                Excel.Range dc = (Excel.Range)exSheet.Cells[2, 1];
                dc.Font.Size = 13;
                dc.Font.Bold = true;
                dc.Font.Color = Color.Blue;
                dc.Value = "315/2B Hai Bà Trưng, tp Long Xuyên";

                exSheet.Range["C4"].Font.Size = 20;
                exSheet.Range["C4"].Font.Bold = true;
                exSheet.Range["C4"].Font.Color = Color.Black;
                exSheet.Range["C4"].Value = "HÓA ĐƠN";

                exSheet.Range["A5:A8"].Font.Size = 12;
                exSheet.Range["A5"].Value = "Mã hóa đơn: "+lblMaHD.Text;
                exSheet.Range["A6"].Value = "Nhân viên lập: " + lblNV.Text;
                exSheet.Range["A7"].Value = "Khách hàng: " + lblKH.Text;

                exSheet.Range["A9:D9"].Font.Size = 12;
                exSheet.Range["A9:D9"].Font.Bold = true;

                exSheet.Range["A9"].Value = "STT";
                exSheet.Range["B9"].Value = "Sản phẩm";
                exSheet.Range["B9"].ColumnWidth = 34;
                exSheet.Range["C9"].Value = "Số lượng";
                exSheet.Range["C9"].ColumnWidth = 10;
                exSheet.Range["D9"].Value = "Giá tiền";
                exSheet.Range["D9"].ColumnWidth = 17;

                int sodong = CTHD_BUS.LaySoLuong_CTHD_BUS(lblMaHD.Text);
                List<CTHD_DTO> lstCTHD = CTHD_BUS.Lay_CTHD_DGV(id_hd);
                int dong = 10;
                for(int i = 0; i< sodong; i++)
                {
                    exSheet.Range["A" + (dong + i).ToString()].Value = (i+1).ToString();
                    exSheet.Range["B" + (dong + i).ToString()].Value = lstCTHD[i].TenSP;
                    exSheet.Range["C" + (dong + i).ToString()].Value = lstCTHD[i].SoLuong;
                    exSheet.Range["D" + (dong + i).ToString()].Value = lstCTHD[i].GiaTien;
                }    
                dong = dong+sodong;
                exSheet.Range["C"+dong.ToString()].Value = "Tổng tiền: "+lblTongTien.Text+" VND";
                exSheet.Range["C" + (dong+2).ToString()].Value = "Ngày lập: " + lblNgayLap.Text;
                exSheet.Name = lblMaHD.Text;
                exBook.Activate();

                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Excel 97 - 2002 Workbook|*.xls|Excel Workbook|*.xlsx|All files|*.*";
                save.FilterIndex = 2;
                if(save.ShowDialog() == DialogResult.OK)
                {
                    exBook.SaveAs(save.FileName.ToLower());
                }   
                exApp.Quit();
                MessageBox.Show("Thanh toán hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thanh toán hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
