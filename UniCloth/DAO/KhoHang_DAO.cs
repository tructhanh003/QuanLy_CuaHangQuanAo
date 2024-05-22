using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class KhoHang_DAO
    {
        static SqlConnection conn;
        public static List<KhoHang_DTO> LayKhoHang_DataGridView()
        {
            string sTruyVan = "select k.masp, s.tensp, s.size, pn.gianhap, k.giaban, k.sl, MAX(pn.ngaynhap) as 'ngaynhap' " +
                " from phieunhap pn, sanpham s, khohang k  where k.masp=s.masp and k.masp = pn.masp " +
                " group by k.masp, s.tensp, s.size, pn.gianhap, k.giaban, k.sl";
            conn = DataProvider.TaoKetNoi();
            List<KhoHang_DTO> lstKH = new List<KhoHang_DTO>();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            if (dt.Rows.Count == 0)
                return null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                KhoHang_DTO pn = new KhoHang_DTO();               
                pn.MaSP = dt.Rows[i]["masp"].ToString();                
                pn.SoLuong = int.Parse(dt.Rows[i]["sl"].ToString());               
                pn.TenSP = dt.Rows[i]["tensp"].ToString();
                pn.SizeSP = dt.Rows[i]["size"].ToString();
                pn.GiaNhap = int.Parse(dt.Rows[i]["gianhap"].ToString());
                pn.GiaBan = int.Parse(dt.Rows[i]["giaban"].ToString());
                pn.NgayNhap = dt.Rows[i]["ngaynhap"].ToString();
                lstKH.Add(pn);
            }
            return lstKH;
        }
        public static int LaySoLuong_SP_KhoHang()
        {
            int sl = 0;
            string sTruyVan = "select * from khohang where giaban > 0";
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
        public static List<KhoHang_DTO> LaySanPham_ComboBox_KhoHang()
        {
            string sTruyVan = "select k.masp, sp.tensp, sp.size \r\n from sanpham sp, khohang k where k.masp = sp.masp and k.giaban > 0";
            conn = DataProvider.TaoKetNoi();
            List<KhoHang_DTO> lstSanPham = new List<KhoHang_DTO>();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            if (dt.Rows.Count == 0)
                return null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                KhoHang_DTO sp = new KhoHang_DTO();
                sp.MaSP = dt.Rows[i]["masp"].ToString();
                sp.TenSP = dt.Rows[i]["tensp"].ToString();
                sp.SizeSP = dt.Rows[i]["size"].ToString();
                lstSanPham.Add(sp);
            }
            return lstSanPham;
        }
        public static KhoHang_DTO TimSP_ID_Kho(string masp)
        {
            string queryStr = string.Format(@"select * from khohang where masp=N'{0}'", masp);
            conn = DataProvider.TaoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(queryStr, conn);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            KhoHang_DTO sp = new KhoHang_DTO();
            sp.MaSP = dt.Rows[0]["masp"].ToString();
            sp.SoLuong = int.Parse(dt.Rows[0]["sl"].ToString());
            sp.GiaBan = int.Parse(dt.Rows[0]["giaban"].ToString());

            return sp;
        }
        public static void Insert_KhoHang(KhoHang_DTO kho)
        {
            conn = DataProvider.TaoKetNoi();
            conn.Open();
            string query = string.Format(@"INSERT into khohang (masp, sl, giaban) VALUES  ('{0}', {1}, {2})",
                kho.MaSP, kho.SoLuong, kho.GiaBan);
            DataProvider.TruyVanKhongLayDuLieu(query, conn);
            conn.Close();
        }
        public static void Delete_KhoHang(string masp)
        {
            conn = DataProvider.TaoKetNoi();
            conn.Open();
            string query = string.Format(@"delete from khohang where masp = '{0}'", masp);
            DataProvider.TruyVanKhongLayDuLieu(query, conn);
            conn.Close();
        }
        public static int lay_SL_Kho(string masp)
        {
            string queryStr = string.Format(@"select sl from khohang where masp=N'{0}'", masp);
            conn = DataProvider.TaoKetNoi();
            int sl = 0;
            DataTable dt = DataProvider.TruyVanLayDuLieu(queryStr, conn);
            if (dt.Rows.Count == 0)
            {
                return sl;
            }
            sl = int.Parse(dt.Rows[0]["sl"].ToString());
            return sl;
        }
        public static void Update_SoLuong_Kho(int sl, string masp)
        {
            conn = DataProvider.TaoKetNoi();
            conn.Open();
            string query = string.Format(@"update khohang set sl = {0} where masp = '{1}'",
               sl, masp);
            DataProvider.TruyVanKhongLayDuLieu(query, conn);
            conn.Close();
        }
        public static void Update_GiaBan_Kho(int giaBan, string masp)
        {
            conn = DataProvider.TaoKetNoi();
            conn.Open();
            string query = string.Format(@"update khohang set giaban = {0} where masp = '{1}'",
               giaBan, masp);
            DataProvider.TruyVanKhongLayDuLieu(query, conn);
            conn.Close();
        }
        public static List<KhoHang_DTO> SapXep_TangDan_SoLuong()
        {
            string sTruyVan = "select k.masp, s.tensp, s.size, pn.gianhap, k.giaban, k.sl, MAX(pn.ngaynhap) as 'ngaynhap' " +
                " from phieunhap pn, sanpham s, khohang k  where k.masp=s.masp and k.masp = pn.masp " +
                " group by k.masp, s.tensp, s.size, pn.gianhap, k.giaban, k.sl"
                + " order by k.sl asc";
            conn = DataProvider.TaoKetNoi();
            List<KhoHang_DTO> lstKho = new List<KhoHang_DTO>();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            if (dt.Rows.Count == 0)
                return null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                KhoHang_DTO pn = new KhoHang_DTO();
                pn.MaSP = dt.Rows[i]["masp"].ToString();
                pn.SoLuong = int.Parse(dt.Rows[i]["sl"].ToString());
                pn.TenSP = dt.Rows[i]["tensp"].ToString();
                pn.SizeSP = dt.Rows[i]["size"].ToString();
                pn.GiaNhap = int.Parse(dt.Rows[i]["gianhap"].ToString());
                pn.GiaBan = int.Parse(dt.Rows[i]["giaban"].ToString());
                pn.NgayNhap = dt.Rows[i]["ngaynhap"].ToString();
                lstKho.Add(pn);
            }
            return lstKho;
        }
        public static List<KhoHang_DTO> SapXep_GiamDan_SoLuong()
        {
            string sTruyVan = "select k.masp, s.tensp, s.size, pn.gianhap, k.giaban, k.sl, MAX(pn.ngaynhap) as 'ngaynhap' " +
                " from phieunhap pn, sanpham s, khohang k  where k.masp=s.masp and k.masp = pn.masp " +
                " group by k.masp, s.tensp, s.size, pn.gianhap, k.giaban, k.sl"
                + " order by k.sl desc";
            conn = DataProvider.TaoKetNoi();
            List<KhoHang_DTO> lstKho = new List<KhoHang_DTO>();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            if (dt.Rows.Count == 0)
                return null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                KhoHang_DTO pn = new KhoHang_DTO();
                pn.MaSP = dt.Rows[i]["masp"].ToString();
                pn.SoLuong = int.Parse(dt.Rows[i]["sl"].ToString());
                pn.TenSP = dt.Rows[i]["tensp"].ToString();
                pn.SizeSP = dt.Rows[i]["size"].ToString();
                pn.GiaNhap = int.Parse(dt.Rows[i]["gianhap"].ToString());
                pn.GiaBan = int.Parse(dt.Rows[i]["giaban"].ToString());
                pn.NgayNhap = dt.Rows[i]["ngaynhap"].ToString();
                lstKho.Add(pn);
            }
            return lstKho;
        }
    }
}
