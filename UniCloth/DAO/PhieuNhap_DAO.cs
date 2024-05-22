using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public class PhieuNhap_DAO
    {
        static SqlConnection conn;
        public static List<PhieuNhap_DTO> LayPN_DataGridView()
        {
            string sTruyVan = "select pn.sophieu, s.tensp, s.size, n.hoten, ncc.tenncc, pn.ngaynhap, pn.soluong, pn.gianhap, pn.masp, pn.manv, pn.mancc " +
                "from phieunhap pn, sanpham s, nhanvien n, nhacungcap ncc " +
                "where pn.masp=s.masp and pn.manv = n.manv and pn.mancc = ncc.mancc";
            conn = DataProvider.TaoKetNoi();
            List<PhieuNhap_DTO> lstPN = new List<PhieuNhap_DTO>();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            if (dt.Rows.Count == 0)
                return null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PhieuNhap_DTO pn = new PhieuNhap_DTO();
                pn.SoPhieu = int.Parse(dt.Rows[i]["sophieu"].ToString());
                pn.MaSP = dt.Rows[i]["masp"].ToString();
                pn.TenNV = dt.Rows[i]["hoten"].ToString();
                pn.TenNCC = dt.Rows[i]["tenncc"].ToString();
                pn.SoLuong = int.Parse(dt.Rows[i]["soluong"].ToString());
                pn.NgayNhap = dt.Rows[i]["ngaynhap"].ToString();
                pn.TenSP = dt.Rows[i]["tensp"].ToString();
                pn.SizeSP = dt.Rows[i]["size"].ToString();
                pn.GiaNhap = int.Parse(dt.Rows[i]["gianhap"].ToString());
                pn.MaNV = dt.Rows[i]["manv"].ToString();
                pn.MaNCC = int.Parse(dt.Rows[i]["mancc"].ToString());
                lstPN.Add(pn);
            }
            return lstPN;
        }
        public static void Insert_Kho(PhieuNhap_DTO kho)
        {
            conn = DataProvider.TaoKetNoi();
            conn.Open();
            string query = string.Format(@"INSERT into phieunhap (masp, manv, mancc, soluong, ngaynhap, gianhap) VALUES  ('{0}', '{1}', {2}, {3}, '{4}', {5})",
                kho.MaSP, kho.MaNV, kho.MaNCC, kho.SoLuong, kho.NgayNhap, kho.GiaNhap);
            DataProvider.TruyVanKhongLayDuLieu(query, conn);
            conn.Close();
        }     
        public static void DeleteKho(int soPhieu)
        {
            conn = DataProvider.TaoKetNoi();
            conn.Open();
            string query = string.Format(@"delete from phieunhap where sophieu = {0}", soPhieu);
            DataProvider.TruyVanKhongLayDuLieu(query, conn);
            conn.Close();
        }        
        public static List<PhieuNhap_DTO> TimSP_TheoTen(string ten)
        {
            string sTruyVan = string.Format(@"select k.masp, s.tensp, s.size, k.sl, k.ngaynhap, k.gianhap, k.giaban from khohang k, sanpham s where k.masp=s.masp and s.tensp like N'{0}%'", ten);
            conn = DataProvider.TaoKetNoi();
            List<PhieuNhap_DTO> lstKho = new List<PhieuNhap_DTO>();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            if (dt.Rows.Count == 0)
                return null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PhieuNhap_DTO kho = new PhieuNhap_DTO();
                kho.MaSP = dt.Rows[i]["masp"].ToString();
                kho.SoLuong = int.Parse(dt.Rows[i]["sl"].ToString());
                kho.NgayNhap = dt.Rows[i]["ngaynhap"].ToString();
                kho.TenSP = dt.Rows[i]["tensp"].ToString();
                kho.SizeSP = dt.Rows[i]["size"].ToString();
                kho.GiaNhap = int.Parse(dt.Rows[i]["gianhap"].ToString());
               
                lstKho.Add(kho);
            }
            return lstKho;
        }
        public static PhieuNhap_DTO HienThi_SP(int sophieu)
        {
            string queryStr = string.Format(@"select pn.sophieu, s.tensp, s.size, n.hoten, ncc.tenncc, pn.ngaynhap, pn.soluong, pn.gianhap, pn.masp, pn.manv, pn.mancc " +
                "from phieunhap pn, sanpham s, nhanvien n, nhacungcap ncc " +
                "where pn.masp=s.masp and pn.manv = n.manv and pn.mancc = ncc.mancc and pn.sophieu = {0}", sophieu);
            conn = DataProvider.TaoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(queryStr, conn);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            PhieuNhap_DTO pn = new PhieuNhap_DTO();
            pn.SoPhieu = int.Parse(dt.Rows[0]["sophieu"].ToString());
            pn.MaSP = dt.Rows[0]["masp"].ToString();
            pn.TenNV = dt.Rows[0]["hoten"].ToString();
            pn.TenNCC = dt.Rows[0]["tenncc"].ToString();
            pn.SoLuong = int.Parse(dt.Rows[0]["soluong"].ToString());
            pn.NgayNhap = dt.Rows[0]["ngaynhap"].ToString();
            pn.TenSP = dt.Rows[0]["tensp"].ToString();
            pn.SizeSP = dt.Rows[0]["size"].ToString();
            pn.GiaNhap = int.Parse(dt.Rows[0]["gianhap"].ToString());
            pn.MaNV = dt.Rows[0]["manv"].ToString();
            pn.MaNCC = int.Parse(dt.Rows[0]["mancc"].ToString());
            return pn;
        }
        public static PhieuNhap_DTO TimSP_ID_Kho(string masp)
        {
            string queryStr = string.Format(@"select * from khohang where masp=N'{0}'", masp);
            conn = DataProvider.TaoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(queryStr, conn);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            PhieuNhap_DTO sp = new PhieuNhap_DTO();
            sp.MaSP = dt.Rows[0]["masp"].ToString();
            sp.NgayNhap = dt.Rows[0]["ngaynhap"].ToString();
            sp.SoLuong = int.Parse(dt.Rows[0]["sl"].ToString());
            sp.GiaNhap = int.Parse(dt.Rows[0]["gianhap"].ToString());
                   
            return sp;
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
    }
}
