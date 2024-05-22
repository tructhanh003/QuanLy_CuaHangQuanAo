using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using ComponentFactory.Krypton.Toolkit;
namespace GUI
{
    public partial class frm_DangNhap : KryptonForm
    {
        string user, pass;
        public frm_DangNhap()
        {
            InitializeComponent();
        }
        public bool chk_DL()
        {
            if (String.IsNullOrEmpty(txtUser.Text))
            {
                MessageBox.Show("Tên tài khoản không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUser.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("Mật khẩu không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPass.Focus();
                return false;
            }
            return true;
        }
        public void layDL()
        {
            if (chk_DL())
            {
                MD5 md5Hash = MD5.Create();
                user = txtUser.Text;
                pass = NhanVien_BUS.GetMd5Hash(md5Hash, txtPass.Text);
            }
        }
        private void btnDN_Click(object sender, EventArgs e)
        {
            layDL();
            if (NhanVien_BUS.TimNhanVienTheoTK_BUS(user) != null)
            {
                if (NhanVien_BUS.TimNhanVienTheoTK_MK_BUS(user, pass) != null)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    string manv = NhanVien_BUS.TimNhanVienTheoTK_MK_BUS(user, pass).MaNV;
                    int macv = NhanVien_BUS.TimNhanVienTheoTK_MK_BUS(user, pass).MaCV;
                    if(macv==0)
                    {
                        frm_TrangChu home = new frm_TrangChu(manv);
                        home.ShowDialog();
                        this.Close();
                    }    
                    else if(macv==1)
                    {
                        frm_TrangChu_NhanVien home = new frm_TrangChu_NhanVien(manv);
                        home.ShowDialog();
                        this.Close();
                    }
                    else if (macv==2)
                    {
                        frm_TrangChu_ThuKho home = new frm_TrangChu_ThuKho(manv);
                        home.ShowDialog();
                        this.Close();
                    }    
                }
                else
                {
                    MessageBox.Show("Sai mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDK_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_DangKy dk = new frm_DangKy();
            dk.ShowDialog();
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
