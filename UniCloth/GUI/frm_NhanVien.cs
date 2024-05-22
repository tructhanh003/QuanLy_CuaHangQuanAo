using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_NhanVien : Form
    {
        QLShopQADataContext db = new QLShopQADataContext();
        nhanvien nv;
        string[] lstTim = {"Mã nhân viên", "Họ tên"};
        public frm_NhanVien()
        {
            InitializeComponent();
        }
        public void loadDL()
        {
            var query1 = from chucvu in db.chucvus
                         select chucvu.tencv;
            cboCV.DataSource = query1;
            cboTim.DataSource = lstTim;
            var query = (from nv in db.nhanviens
                         join cv in db.chucvus on nv.macv equals cv.macv                       
                         select new
                         {
                             nv.manv,
                             nv.hoten,
                             nv.phai,
                             nv.ngaysinh,
                             nv.cccd,
                             nv.sodt,
                             cv.tencv,
                             nv.anh,
                             nv.tentk
                         }).OrderBy(x => x.manv);
            dgvNV.DataSource = query;
            dgvNV.Columns["manv"].HeaderText = "Mã nhân viên";
            dgvNV.Columns["hoten"].HeaderText = "Họ tên";
            dgvNV.Columns["hoten"].Width = 150;
            dgvNV.Columns["phai"].HeaderText = "Phái";
            dgvNV.Columns["phai"].Width = 50;
            dgvNV.Columns["ngaysinh"].HeaderText = "Ngày sinh";
            dgvNV.Columns["cccd"].HeaderText = "Căn cước";
            dgvNV.Columns["sodt"].HeaderText = "Điện thoại";
            dgvNV.Columns["tencv"].HeaderText = "Chức vụ";
            dgvNV.Columns["anh"].Visible = false;
            dgvNV.Columns["tentk"].Visible = false;
        }
        private void dgvNV_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgvNV.SelectedRows[0];
            txtMaNV.Text = dr.Cells["manv"].Value.ToString();
            string ma = dr.Cells["manv"].Value.ToString();
            txtHoTen.Text = dr.Cells["hoten"].Value.ToString();
            txtCCCD.Text = dr.Cells["cccd"].Value.ToString();
            txtDT.Text = dr.Cells["sodt"].Value.ToString();
            dtpNgaySinh.Text = dr.Cells["ngaysinh"].Value.ToString();
            txtTenTK.Text = dr.Cells["tentk"].Value.ToString();
            if (dr.Cells["phai"].Value.ToString().Equals("Nam"))
            {
                radNam.Checked = true;
            } 
            else
                radNu.Checked = true;
            HienThiAvt(ma);
            cboCV.Text = dr.Cells["tencv"].Value.ToString();
        }
        public void HienThiAvt(string s)
        {
            db = new QLShopQADataContext();
            nhanvien query = db.nhanviens.Where(nv => nv.manv == s).FirstOrDefault();
            if (query == null)
                return;
            MemoryStream ms = new MemoryStream(query.anh.ToArray());
            Image img = Image.FromStream(ms);
            if (img == null)
            {
                return;
            }
            picSP.Image = img;
        }
        public int chuyenMaCV(string tenCV)
        {
            var query = (from cl in db.chucvus
                         where cl.tencv == tenCV
                         select cl.macv
                         ).First();
            return query;
        }
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        public bool checkDL()
        {
            if (string.IsNullOrEmpty(txtTenTK.Text))
            {
                MessageBox.Show("Tên tài khoản không được trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenTK.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoTen.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDT.Text))
            {
                MessageBox.Show("Số điện thoại không được trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDT.Focus();
                return false;
            }
            else
            {
                if (txtDT.Text.Length > 11)
                {
                    MessageBox.Show("Số điện thoại chỉ chứa tối đa 11 số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDT.Focus();
                    return false;
                }
                else
                {
                    char[] ch = txtDT.Text.ToCharArray();
                    for (int i = 0; i < ch.Length; i++)
                    {
                        if (ch[i] < 48 || ch[i] > 57)
                        {
                            MessageBox.Show("Số điện thoại phải nhập số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtDT.Focus();
                            return false;
                        }
                    }
                }
            }
            if (string.IsNullOrEmpty(txtCCCD.Text))
            {
                MessageBox.Show("Căn cước công dân không được trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCCCD.Focus();
                return false;
            }
            else
            {
                if (txtCCCD.Text.Length > 12)
                {
                    MessageBox.Show("Căn cước công dân chỉ chứa tối đa 12 kí tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCCCD.Focus();
                    return false;
                }
                else
                {
                    char[] ch1 = txtCCCD.Text.ToCharArray();
                    for (int i = 0; i < ch1.Length; i++)
                    {
                        if (ch1[i] < 48 || ch1[i] > 57)
                        {
                            MessageBox.Show("Căn cước công dân phải nhập số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtCCCD.Focus();
                            return false;
                        }
                    }
                }

            }
            if (radNam.Checked == false && radNu.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn phái nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dtpNgaySinh.Value.Year > 2006)
            {
                MessageBox.Show("Năm sinh phải từ 2006 trở lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtMatKhau.Text) == false)
            {
                MD5 md5Hash = MD5.Create();
                string pass = GetMd5Hash(md5Hash, txtMatKhau.Text);
                string confirm = GetMd5Hash(md5Hash, txtConfirm.Text);
                if (pass != confirm)
                {
                    MessageBox.Show("Xác nhận mật khẩu chưa chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }
        private byte[] ImageToByteArray(PictureBox p)
        {
            MemoryStream memoryStream = new MemoryStream();
            p.Image.Save(memoryStream, ImageFormat.Jpeg);
            return memoryStream.ToArray();
        }
        private void LayDL()
        {
            nv = new nhanvien();
            nv.manv = txtMaNV.Text;
            nv.tentk = txtTenTK.Text;
            nv.hoten = txtHoTen.Text;
            nv.phai = radNam.Checked ? "Nam" : "Nữ";
            if (string.IsNullOrEmpty(txtMatKhau.Text) == false)
            {
                MD5 md5Hash = MD5.Create();
                nv.matkhau = GetMd5Hash(md5Hash, txtMatKhau.Text);
            }
            nv.ngaysinh = dtpNgaySinh.Value;
            nv.cccd = txtCCCD.Text;
            nv.sodt = txtDT.Text;
            nv.anh = ImageToByteArray(picSP);
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (checkDL())
            {
                try
                {
                    LayDL();
                    nhanvien staff = db.nhanviens.Single(x => x.manv == nv.manv);
                    staff.hoten = nv.hoten;
                    staff.tentk = nv.tentk;
                    if (nv.matkhau != null)
                    {
                        staff.matkhau = nv.matkhau;
                    }
                    staff.phai = nv.phai;
                    staff.cccd = nv.cccd;
                    staff.sodt = nv.sodt;
                    staff.ngaysinh = nv.ngaysinh;
                    staff.anh = nv.anh;
                    db.SubmitChanges();
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDL();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    nhanvien nv = db.nhanviens.Single(x => x.manv == txtMaNV.Text);
                    db.nhanviens.DeleteOnSubmit(nv);
                    db.SubmitChanges();
                    MessageBox.Show("Xóa 1 nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDL();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {

        }

        private void frm_NhanVien_Load(object sender, EventArgs e)
        {
            loadDL();
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh";
            openFileDialog.Filter = "Image Files(*.gif; *.jpg; *.jpeg; *.bmp; *.wmf; *.png)|*.gif; *.jpg; *.jpeg; *.bmp; *.wmf; *.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string f = openFileDialog.FileName;
                Image img = Image.FromFile(f);
                picSP.Image = img;
            }
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            ThemNV f = new ThemNV();
            f.ShowDialog();
        }

        private void btnReload_Click_1(object sender, EventArgs e)
        {
            loadDL();
            txtTim.Text = string.Empty;
            txtTim.Focus();
        }
        public void HienThiNV_theoMaNV()
        {
            var query = (from nv in db.nhanviens
                         join cv in db.chucvus on nv.macv equals cv.macv
                         where nv.manv == txtTim.Text
                         select new
                         {
                             nv.manv,
                             nv.hoten,
                             nv.phai,
                             nv.ngaysinh,
                             nv.cccd,
                             nv.sodt,
                             cv.tencv,
                             nv.anh,
                             nv.tentk
                         }).OrderBy(x => x.manv);
            dgvNV.DataSource = query;
            dgvNV.Columns["manv"].HeaderText = "Mã nhân viên";
            dgvNV.Columns["hoten"].HeaderText = "Họ tên";
            dgvNV.Columns["hoten"].Width = 150;
            dgvNV.Columns["phai"].HeaderText = "Phái";
            dgvNV.Columns["phai"].Width = 50;
            dgvNV.Columns["ngaysinh"].HeaderText = "Ngày sinh";
            dgvNV.Columns["cccd"].HeaderText = "Căn cước";
            dgvNV.Columns["sodt"].HeaderText = "Điện thoại";
            dgvNV.Columns["tencv"].HeaderText = "Chức vụ";
            dgvNV.Columns["anh"].Visible = false;
            dgvNV.Columns["tentk"].Visible = false;
        }
        public void HienThiNV_theoHoTen()
        {
            var query = (from nv in db.nhanviens
                         join cv in db.chucvus on nv.macv equals cv.macv
                         where nv.hoten == txtTim.Text
                         select new
                         {
                             nv.manv,
                             nv.hoten,
                             nv.phai,
                             nv.ngaysinh,
                             nv.cccd,
                             nv.sodt,
                             cv.tencv,
                             nv.anh,
                             nv.tentk
                         }).OrderBy(x => x.manv);
            dgvNV.DataSource = query;
            dgvNV.Columns["manv"].HeaderText = "Mã nhân viên";
            dgvNV.Columns["hoten"].HeaderText = "Họ tên";
            dgvNV.Columns["hoten"].Width = 150;
            dgvNV.Columns["phai"].HeaderText = "Phái";
            dgvNV.Columns["phai"].Width = 50;
            dgvNV.Columns["ngaysinh"].HeaderText = "Ngày sinh";
            dgvNV.Columns["cccd"].HeaderText = "Căn cước";
            dgvNV.Columns["sodt"].HeaderText = "Điện thoại";
            dgvNV.Columns["tencv"].HeaderText = "Chức vụ";
            dgvNV.Columns["anh"].Visible = false;
            dgvNV.Columns["tentk"].Visible = false;
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            if(cboTim.Text.Equals("Mã nhân viên"))
            {
                HienThiNV_theoMaNV();
                if (dgvNV.RowCount > 0)
                    MessageBox.Show("Đã tìm thấy nhân viên có mã là "+txtTim.Text+"!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                else
                    MessageBox.Show("Không tìm thấy nhân viên có mã là " + txtTim.Text + "!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }   
            if(cboTim.Text.Equals("Họ tên"))
            {
                HienThiNV_theoHoTen();
                if (dgvNV.RowCount > 0)
                    MessageBox.Show("Đã tìm thấy nhân viên có họ tên " + txtTim.Text + "!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Không tìm thấy nhân viên có họ tên " + txtTim.Text + "!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
        }
    }
}
