using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_TaiKhoan : Form
    {
        string id_nv;
        nhanvien nv;
        QLShopQADataContext db = new QLShopQADataContext();
        public frm_TaiKhoan(string manv)
        {
            InitializeComponent();
            id_nv = manv;
        }
        public void Display_Setting()
        {
            nhanvien staff = db.nhanviens.Single(x => x.manv == id_nv);
            txtMaNV.Text = id_nv;
            txtHoTen.Text = staff.hoten.ToString();
            txtUser.Text = staff.tentk.ToString();
            txtDT.Text = staff.sodt.ToString();
            txtCCCD.Text = staff.cccd.ToString();
            dtpNgaySinh.Value = staff.ngaysinh;
            if (staff.phai.ToString() == "Nam")
            {
                radNam.Checked = true;
            }
            else
                radNu.Checked = true;
            txtCV.Text = chuyenTenCV(staff.macv);
        }
        public string chuyenTenCV(int macv)
        {
            var query = (from cl in db.chucvus
                         where cl.macv == macv
                         select cl.tencv
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
            picAnh.Image = img;
        }
        public bool checkDL()
        {
            if (string.IsNullOrEmpty(txtUser.Text))
            {
                MessageBox.Show("Tên tài khoản không được trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUser.Focus();
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
            if (string.IsNullOrEmpty(txtPass.Text) == false)
            {
                MD5 md5Hash = MD5.Create();
                string pass = GetMd5Hash(md5Hash, txtPass.Text);
                string confirm = GetMd5Hash(md5Hash, txtConfirm.Text);
                if (pass != confirm)
                {
                    MessageBox.Show("Xác nhận mật khẩu chưa chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }
        private void frm_TaiKhoan_Load(object sender, EventArgs e)
        {
            Display_Setting();
            HienThiAvt(id_nv);
        }
        private byte[] ImageToByteArray(PictureBox p)
        {
            MemoryStream memoryStream = new MemoryStream();
            p.Image.Save(memoryStream, ImageFormat.Jpeg);
            return memoryStream.ToArray();
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
                picAnh.Image = img;
            }
        }
        private void LayDL()
        {
            nv = new nhanvien();
            nv.tentk = txtUser.Text;
            nv.hoten = txtHoTen.Text;
            nv.phai = radNam.Checked ? "Nam" : "Nữ";
            if (string.IsNullOrEmpty(txtPass.Text) == false)
            {
                MD5 md5Hash = MD5.Create();
                nv.matkhau = GetMd5Hash(md5Hash, txtPass.Text);
            }
            nv.ngaysinh = dtpNgaySinh.Value;
            nv.cccd = txtCCCD.Text;
            nv.sodt = txtDT.Text;
            nv.anh = ImageToByteArray(picAnh);
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (checkDL())
            {
                try
                {
                    LayDL();
                    nhanvien staff = db.nhanviens.Single(x => x.manv == id_nv);
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // do nothing...
            }
        }
    }
}
