using System;
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
using ComponentFactory.Krypton.Toolkit;
namespace GUI
{
    public partial class frm_DangKy : KryptonForm
    {
        nhanvien nv;
        QLShopQADataContext db = new QLShopQADataContext();
        public frm_DangKy()
        {
            InitializeComponent();
            var query1 = from chucvu in db.chucvus
                         select chucvu.tencv;
            cboCV.DataSource = query1;
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
            if (string.IsNullOrEmpty(txtUser.Text))
            {
                MessageBox.Show("Tên tài khoản không được trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUser.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("Mật khẩu không được trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPass.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Mã nhân viên không được trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNV.Focus();
                return false;
            }
            else
            {
                var query = (from nv in db.nhanviens
                             where nv.manv == txtMaNV.Text
                             select nv
                         ).FirstOrDefault();
                if (query != null)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {

                }
            }
            if (string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNV.Focus();
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
            return true;
        }
        private void LayDL()
        {
            MD5 md5Hash = MD5.Create();
            nv = new nhanvien();
            int maCV = 0;
            nv.manv = txtMaNV.Text;
            nv.tentk = txtUser.Text;
            nv.matkhau = GetMd5Hash(md5Hash, txtPass.Text);
            nv.hoten = txtHoTen.Text;
            nv.phai = radNam.Checked ? "Nam" : "Nữ";
            nv.ngaysinh = dtpNgaySinh.Value;
            nv.cccd = txtCCCD.Text;
            nv.sodt = txtDT.Text;
            if(cboCV.Text.Equals("Quản lý"))
            {
                maCV = 0;
            } 
            else if(cboCV.Text.Equals("Thủ kho"))
            {
                maCV = 2;
            }
            else if (cboCV.Text.Equals("Nhân viên"))
            {
                maCV = 1;
            }
            nv.macv = maCV;
            nv.anh = ImageToByteArray(picAnh);
        }
        private byte[] ImageToByteArray(PictureBox p)
        {
            MemoryStream memoryStream = new MemoryStream();
            p.Image.Save(memoryStream, ImageFormat.Jpeg);
            return memoryStream.ToArray();
        }
        private void frm_DangKy_Load(object sender, EventArgs e)
        {

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

        private void btnDK_Click(object sender, EventArgs e)
        {
            if (checkDL())
            {
                try
                {
                    LayDL();
                    db.nhanviens.InsertOnSubmit(nv);
                    db.SubmitChanges();
                    MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void txtReset_Click(object sender, EventArgs e)
        {
            txtUser.Text = "";
            txtUser.Focus();
            txtPass.Text = "";
            txtMaNV.Text = "";
            txtHoTen.Text = "";
            txtCCCD.Text = "";
            txtDT.Text = "";
            radNam.Checked = false;
            radNu.Checked = false;
            dtpNgaySinh.Value = DateTime.Now;
        }

        private void frm_DangKy_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            frm_DangNhap f = new frm_DangNhap();
            f.ShowDialog();
            this.Close();
        }
    }
}
