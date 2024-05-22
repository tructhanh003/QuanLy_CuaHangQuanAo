using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public class KhachHang_DAO
    {
        static SqlConnection conn;
        public static List<KhachHang_DTO> LayKhachHang_DataGridView()
        {
            string sTruyVan = "select * from khachhang";
            conn = DataProvider.TaoKetNoi();
            List<KhachHang_DTO> lstKH = new List<KhachHang_DTO>();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            if (dt.Rows.Count == 0)
                return null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                KhachHang_DTO kh = new KhachHang_DTO();
                kh.MaKH = dt.Rows[i]["makh"].ToString();
                kh.HoTen = dt.Rows[i]["hoten"].ToString();
                kh.PhaiKH = dt.Rows[i]["phai"].ToString();
                kh.NgaySinh = dt.Rows[i]["ngaysinh"].ToString();
                kh.SoDT = dt.Rows[i]["sodt"].ToString();
                kh.DiaChi = dt.Rows[i]["diachi"].ToString();
                lstKH.Add(kh);
            }
            return lstKH;
        }
        public static KhachHang_DTO TimKH_ID(string makh)
        {
            string queryStr = string.Format(@"select * from khachhang where makh=N'{0}'", makh);
            conn = DataProvider.TaoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(queryStr, conn);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            KhachHang_DTO kh = new KhachHang_DTO();
            kh.MaKH = dt.Rows[0]["makh"].ToString();
            kh.HoTen = dt.Rows[0]["hoten"].ToString();
            kh.PhaiKH = dt.Rows[0]["phai"].ToString();
            kh.NgaySinh = dt.Rows[0]["ngaysinh"].ToString();
            kh.SoDT = dt.Rows[0]["sodt"].ToString();
            kh.DiaChi = dt.Rows[0]["diachi"].ToString();
            return kh;
        }
        public static int LaySoLuong_KH()
        {
            int sl = 0;
            string sTruyVan = "select * from khachhang";
            conn = DataProvider.TaoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            if (dt.Rows.Count == 0)
                return 0;
            else
            {
                sl = dt.Rows.Count;
                return sl;
            }
        }
        public static void InsertKH(KhachHang_DTO kh)
        {
            conn = DataProvider.TaoKetNoi();
            conn.Open();
            string query = string.Format(@"insert into khachhang (makh, hoten, phai, ngaysinh, sodt, diachi) values ('{0}', N'{1}', N'{2}', '{3}', '{4}', N'{5}')",
               kh.MaKH, kh.HoTen, kh.PhaiKH, kh.NgaySinh, kh.SoDT, kh.DiaChi);
            DataProvider.TruyVanKhongLayDuLieu(query, conn);
            conn.Close();
        }
        public static void UpdateKH(KhachHang_DTO kh)
        {
            conn = DataProvider.TaoKetNoi();
            conn.Open();
            string query = string.Format(@"update khachhang set hoten = N'{0}', phai = N'{1}', ngaysinh = '{2}', sodt = '{3}', diachi = N'{4}' where makh = '{5}'",
                kh.HoTen, kh.PhaiKH, kh.NgaySinh, kh.SoDT, kh.DiaChi, kh.MaKH);
            DataProvider.TruyVanKhongLayDuLieu(query, conn);
            conn.Close();
        }
        public static void DeleteKH(string makh)
        {
            conn = DataProvider.TaoKetNoi();
            conn.Open();
            string query = string.Format(@"delete from khachhang where makh = '{0}'", makh);
            DataProvider.TruyVanKhongLayDuLieu(query, conn);
            conn.Close();
        }
        public static List<KhachHang_DTO> TimKH_TheoMa(string makh)
        {
            string sTruyVan = string.Format(@"select * from khachhang where makh like '{0}%'", makh);
            conn = DataProvider.TaoKetNoi();
            List<KhachHang_DTO> lstKho = new List<KhachHang_DTO>();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            if (dt.Rows.Count == 0)
                return null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                KhachHang_DTO kh = new KhachHang_DTO();
                kh.MaKH = dt.Rows[i]["makh"].ToString();
                kh.HoTen = dt.Rows[i]["hoten"].ToString();
                kh.PhaiKH = dt.Rows[i]["phai"].ToString();
                kh.NgaySinh = dt.Rows[i]["ngaysinh"].ToString();
                kh.SoDT = dt.Rows[i]["sodt"].ToString();
                kh.DiaChi = dt.Rows[i]["diachi"].ToString();                
                lstKho.Add(kh);
            }
            return lstKho;
        }
        public static List<KhachHang_DTO> TimKH_TheoTen(string tenkh)
        {
            string sTruyVan = string.Format(@"select * from khachhang where hoten like N'{0}%'", tenkh);
            conn = DataProvider.TaoKetNoi();
            List<KhachHang_DTO> lstKho = new List<KhachHang_DTO>();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            if (dt.Rows.Count == 0)
                return null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                KhachHang_DTO kh = new KhachHang_DTO();
                kh.MaKH = dt.Rows[i]["makh"].ToString();
                kh.HoTen = dt.Rows[i]["hoten"].ToString();
                kh.PhaiKH = dt.Rows[i]["phai"].ToString();
                kh.NgaySinh = dt.Rows[i]["ngaysinh"].ToString();
                kh.SoDT = dt.Rows[i]["sodt"].ToString();
                kh.DiaChi = dt.Rows[i]["diachi"].ToString();
                lstKho.Add(kh);
            }
            return lstKho;
        }
        public static List<KhachHang_DTO> TimKH_TheoDT(string sdt)
        {
            string sTruyVan = string.Format(@"select * from khachhang where sodt like '{0}%'", sdt);
            conn = DataProvider.TaoKetNoi();
            List<KhachHang_DTO> lstKho = new List<KhachHang_DTO>();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            if (dt.Rows.Count == 0)
                return null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                KhachHang_DTO kh = new KhachHang_DTO();
                kh.MaKH = dt.Rows[i]["makh"].ToString();
                kh.HoTen = dt.Rows[i]["hoten"].ToString();
                kh.PhaiKH = dt.Rows[i]["phai"].ToString();
                kh.NgaySinh = dt.Rows[i]["ngaysinh"].ToString();
                kh.SoDT = dt.Rows[i]["sodt"].ToString();
                kh.DiaChi = dt.Rows[i]["diachi"].ToString();
                lstKho.Add(kh);
            }
            return lstKho;
        }
    }
}
