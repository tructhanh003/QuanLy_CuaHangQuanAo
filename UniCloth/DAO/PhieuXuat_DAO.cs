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
    public class PhieuXuat_DAO
    {
        static SqlConnection conn;
        public static List<PhieuXuat_DTO> LayPX_DataGridView()
        {
            string sTruyVan = "select px.sophieu, s.tensp, s.size, n.hoten, kh.hoten as 'tenkh', px.ngayxuat, px.soluong, px.masp, px.manv, px.makh " +
                "from phieuxuat px, sanpham s, nhanvien n, khachhang kh " +
                "where px.masp=s.masp and px.manv = n.manv and px.makh = kh.makh";
            conn = DataProvider.TaoKetNoi();
            List<PhieuXuat_DTO> lstPX = new List<PhieuXuat_DTO>();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            if (dt.Rows.Count == 0)
                return null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PhieuXuat_DTO px = new PhieuXuat_DTO();
                px.SoPhieu = int.Parse(dt.Rows[i]["sophieu"].ToString());
                px.MaSP = dt.Rows[i]["masp"].ToString();
                px.TenNV = dt.Rows[i]["hoten"].ToString();
                px.TenKH = dt.Rows[i]["tenkh"].ToString();
                px.SoLuong = int.Parse(dt.Rows[i]["soluong"].ToString());
                px.NgayXuat = dt.Rows[i]["ngayxuat"].ToString();
                px.TenSP = dt.Rows[i]["tensp"].ToString();
                px.SizeSP = dt.Rows[i]["size"].ToString();           
                px.MaNV = dt.Rows[i]["manv"].ToString();
                px.MaKH = dt.Rows[i]["makh"].ToString();
                lstPX.Add(px);
            }
            return lstPX;
        }
        public static void Insert_PhieuXuat(PhieuXuat_DTO kho)
        {
            conn = DataProvider.TaoKetNoi();
            conn.Open();
            string query = string.Format(@"INSERT into phieuxuat (masp, manv, makh, soluong, ngayxuat) VALUES  ('{0}', '{1}', '{2}', {3}, '{4}')",
                kho.MaSP, kho.MaNV, kho.MaKH, kho.SoLuong, kho.NgayXuat);
            DataProvider.TruyVanKhongLayDuLieu(query, conn);
            conn.Close();
        }
        public static void Delete_PhieuXuat(int soPhieu)
        {
            conn = DataProvider.TaoKetNoi();
            conn.Open();
            string query = string.Format(@"delete from phieuxuat where sophieu = {0}", soPhieu);
            DataProvider.TruyVanKhongLayDuLieu(query, conn);
            conn.Close();
        }
        public static List<PhieuXuat_DTO> TimSP_Ten_PhieuXuat(string tensp)
        {
            string sTruyVan = string.Format(@"select px.sophieu, s.tensp, s.size, n.hoten, kh.hoten as 'tenkh', px.ngayxuat, px.soluong, px.masp, px.manv, px.makh " +
                " from phieuxuat px, sanpham s, nhanvien n, khachhang kh " +
                " where px.masp=s.masp and px.manv = n.manv and px.makh = kh.makh and s.tensp like N'{0}%'", tensp);
            conn = DataProvider.TaoKetNoi();
            List<PhieuXuat_DTO> lstPX = new List<PhieuXuat_DTO>();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            if (dt.Rows.Count == 0)
                return null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PhieuXuat_DTO px = new PhieuXuat_DTO();
                px.SoPhieu = int.Parse(dt.Rows[i]["sophieu"].ToString());
                px.MaSP = dt.Rows[i]["masp"].ToString();
                px.TenNV = dt.Rows[i]["hoten"].ToString();
                px.TenKH = dt.Rows[i]["tenkh"].ToString();
                px.SoLuong = int.Parse(dt.Rows[i]["soluong"].ToString());
                px.NgayXuat = dt.Rows[i]["ngayxuat"].ToString();
                px.TenSP = dt.Rows[i]["tensp"].ToString();
                px.SizeSP = dt.Rows[i]["size"].ToString();
                px.MaNV = dt.Rows[i]["manv"].ToString();
                px.MaKH = dt.Rows[i]["makh"].ToString();
                lstPX.Add(px);
            }
            return lstPX;
        }
        public static PhieuXuat_DTO HienThi_SP_PhieuXuat(int sophieu)
        {
            string queryStr = string.Format(@"select pn.sophieu, s.tensp, s.size, n.hoten, kh.hoten as 'tenkh', pn.ngayxuat, pn.soluong, k.giaban, pn.masp, pn.manv, pn.makh " +
                "from phieuxuat pn, sanpham s, nhanvien n, khachhang kh, khohang k " +
                "where pn.masp=s.masp and pn.manv = n.manv and pn.masp = k.masp and pn.makh = kh.makh and pn.sophieu = {0}", sophieu);
            conn = DataProvider.TaoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(queryStr, conn);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            PhieuXuat_DTO pn = new PhieuXuat_DTO();
            pn.SoPhieu = int.Parse(dt.Rows[0]["sophieu"].ToString());
            pn.MaSP = dt.Rows[0]["masp"].ToString();
            pn.TenNV = dt.Rows[0]["hoten"].ToString();
            pn.TenKH = dt.Rows[0]["tenkh"].ToString();
            pn.SoLuong = int.Parse(dt.Rows[0]["soluong"].ToString());
            pn.NgayXuat = dt.Rows[0]["ngayxuat"].ToString();
            pn.TenSP = dt.Rows[0]["tensp"].ToString();
            pn.SizeSP = dt.Rows[0]["size"].ToString();
            pn.GiaBan = int.Parse(dt.Rows[0]["giaban"].ToString());
            pn.MaNV = dt.Rows[0]["manv"].ToString();
            pn.MaKH = dt.Rows[0]["makh"].ToString();
            return pn;
        }
        public static List<PhieuXuat_DTO> TimSP_MaSP_PhieuXuat(string masp)
        {
            string sTruyVan = string.Format(@"select px.sophieu, s.tensp, s.size, n.hoten, kh.hoten as 'tenkh', px.ngayxuat, px.soluong, px.masp, px.manv, px.makh " +
                "from phieuxuat px, sanpham s, nhanvien n, khachhang kh " +
                "where px.masp=s.masp and px.manv = n.manv and px.makh = kh.makh and px.masp like '{0}%'", masp);
            conn = DataProvider.TaoKetNoi();
            List<PhieuXuat_DTO> lstPX = new List<PhieuXuat_DTO>();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            if (dt.Rows.Count == 0)
                return null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PhieuXuat_DTO px = new PhieuXuat_DTO();
                px.SoPhieu = int.Parse(dt.Rows[i]["sophieu"].ToString());
                px.MaSP = dt.Rows[i]["masp"].ToString();
                px.TenNV = dt.Rows[i]["hoten"].ToString();
                px.TenKH = dt.Rows[i]["tenkh"].ToString();
                px.SoLuong = int.Parse(dt.Rows[i]["soluong"].ToString());
                px.NgayXuat = dt.Rows[i]["ngayxuat"].ToString();
                px.TenSP = dt.Rows[i]["tensp"].ToString();
                px.SizeSP = dt.Rows[i]["size"].ToString();
                px.MaNV = dt.Rows[i]["manv"].ToString();
                px.MaKH = dt.Rows[i]["makh"].ToString();
                lstPX.Add(px);
            }
            return lstPX;
        }
    }
}
