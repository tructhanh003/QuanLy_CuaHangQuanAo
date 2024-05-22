using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class HoaDon_DAO
    {
        static SqlConnection conn;       
        public static HoaDon_DTO TimHD_ID(string ID)
        {
            string queryStr = string.Format(@"select * from hoadon where mahd='{0}'", ID);
            conn = DataProvider.TaoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(queryStr, conn);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            HoaDon_DTO hd = new HoaDon_DTO();
            hd.MaHD = dt.Rows[0]["mahd"].ToString();
            hd.MaNV = dt.Rows[0]["manv"].ToString();
            hd.MaKH = dt.Rows[0]["makh"].ToString();
            hd.NgayLap = dt.Rows[0]["ngaylap"].ToString();
            return hd;
        }
        public static List<HoaDon_DTO> LayHD_DataGridView()
        {
            string sTruyVan = "select h.mahd, h.manv, n.hoten, h.makh, k.hoten as N'Khách hàng', h.ngaylap from hoadon h, nhanvien n, khachhang k where h.manv = n.manv and h.makh = k.makh";
            //string sTruyVan = "select * from hoadon";
            conn = DataProvider.TaoKetNoi();
            List<HoaDon_DTO> lstHD = new List<HoaDon_DTO>();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            if (dt.Rows.Count == 0)
                return null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HoaDon_DTO hd = new HoaDon_DTO();
                hd.MaHD = dt.Rows[i]["mahd"].ToString();
                hd.MaNV = dt.Rows[i]["manv"].ToString();
                hd.MaKH = dt.Rows[i]["makh"].ToString();
                hd.TenNV = dt.Rows[i]["hoten"].ToString();
                hd.TenKH = dt.Rows[i]["Khách hàng"].ToString();
                hd.NgayLap = dt.Rows[i]["ngaylap"].ToString();
                lstHD.Add(hd);
            }
            return lstHD;
        }
        public static List<HoaDon_DTO> TimKiem_HD_TheoMa_DGV(string maHD)
        {
            string sTruyVan = string.Format(@"select h.mahd, h.manv, n.hoten, h.makh, k.hoten as N'Khách hàng', h.ngaylap from hoadon h, nhanvien n, khachhang k where h.manv = n.manv and h.makh = k.makh and h.mahd = '{0}'", maHD);
            //string sTruyVan = "select * from hoadon";
            conn = DataProvider.TaoKetNoi();
            List<HoaDon_DTO> lstHD = new List<HoaDon_DTO>();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            if (dt.Rows.Count == 0)
                return null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HoaDon_DTO hd = new HoaDon_DTO();
                hd.MaHD = dt.Rows[i]["mahd"].ToString();
                hd.MaNV = dt.Rows[i]["manv"].ToString();
                hd.MaKH = dt.Rows[i]["makh"].ToString();
                hd.TenNV = dt.Rows[i]["hoten"].ToString();
                hd.TenKH = dt.Rows[i]["Khách hàng"].ToString();
                hd.NgayLap = dt.Rows[i]["ngaylap"].ToString();
                lstHD.Add(hd);
            }
            return lstHD;
        }
        public static void InsertHD(HoaDon_DTO hd)
        {
            conn = DataProvider.TaoKetNoi();
            conn.Open();
            string query = string.Format(@"INSERT into hoadon (mahd, manv, makh, ngaylap) VALUES  ('{0}', '{1}', '{2}', '{3}')",
                hd.MaHD, hd.MaNV, hd.MaKH, hd.NgayLap);
            DataProvider.TruyVanKhongLayDuLieu(query, conn);
            conn.Close();
        }
        public static void DeleteHD(string hd)
        {
            conn = DataProvider.TaoKetNoi();
            conn.Open();
            string query = string.Format(@"delete from hoadon where mahd = '{0}'", hd);
            DataProvider.TruyVanKhongLayDuLieu(query, conn);
            conn.Close();
        }
        public static List<HoaDon_DTO> LayHD_ChungTu(string n1, string n2)
        {
            string sTruyVan = string.Format("select h.mahd, h.manv, n.hoten, h.makh, k.hoten as N'Khách hàng', h.ngaylap from hoadon h, nhanvien n, khachhang k where h.manv = n.manv and h.makh = k.makh and ('{0}' < h.ngaylap and '{1}' > h.ngaylap)", n1, n2);
            //string sTruyVan = "select * from hoadon";
            conn = DataProvider.TaoKetNoi();
            List<HoaDon_DTO> lstHD = new List<HoaDon_DTO>();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            if (dt.Rows.Count == 0)
                return null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HoaDon_DTO hd = new HoaDon_DTO();
                hd.MaHD = dt.Rows[i]["mahd"].ToString();
                hd.MaNV = dt.Rows[i]["manv"].ToString();
                hd.MaKH = dt.Rows[i]["makh"].ToString();
                hd.TenNV = dt.Rows[i]["hoten"].ToString();
                hd.TenKH = dt.Rows[i]["Khách hàng"].ToString();
                hd.NgayLap = dt.Rows[i]["ngaylap"].ToString();
                lstHD.Add(hd);
            }
            return lstHD;
        }
    }
}
