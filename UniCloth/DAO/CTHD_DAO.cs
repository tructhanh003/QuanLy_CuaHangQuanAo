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
    public class CTHD_DAO
    {
        static SqlConnection conn;
        public static void InsertCTHD(CTHD_DTO ct)
        {
            conn = DataProvider.TaoKetNoi();
            conn.Open();
            string query = string.Format(@"INSERT into cthd (mahd, masp, soluong) VALUES  ('{0}', '{1}', {2})",
                ct.MaHD, ct.MaSP, ct.SoLuong);
            DataProvider.TruyVanKhongLayDuLieu(query, conn);
            conn.Close();
        }
        public static List<CTHD_DTO> Lay_CTHD_DGV(string mahd)
        {
            string query = string.Format(@"select c.mahd, s.tensp +' ' + s.size as N'tensp', c.soluong, k.giaban
            from cthd c, sanpham s, khohang k
            where c.masp = k.masp and k.masp = s.masp and c.mahd = '{0}'", mahd);
            conn = DataProvider.TaoKetNoi();
            List<CTHD_DTO> lstCTHD = new List<CTHD_DTO>();
            DataTable dt = DataProvider.TruyVanLayDuLieu(query, conn);
            if (dt.Rows.Count == 0)
                return null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CTHD_DTO cthd = new CTHD_DTO();
                cthd.MaHD = dt.Rows[i]["mahd"].ToString();
                cthd.TenSP = dt.Rows[i]["tensp"].ToString();
                cthd.SoLuong = int.Parse(dt.Rows[i]["soluong"].ToString());
                cthd.GiaTien = int.Parse(dt.Rows[i]["giaban"].ToString());
                lstCTHD.Add(cthd);
            }
            return lstCTHD;
        }
        public static DataTable ThongKe_DT_Thang()
        {
            string query = string.Format(@"SELECT MONTH(h.ngaylap) AS N'Tháng', SUM(c.soluong*k.giaban) AS N'Tổng doanh thu'
                    FROM hoadon h, cthd c, khohang k
                    WHERE YEAR(h.ngaylap) = '2024' and c.masp = k.masp and h.mahd = c.mahd
                    GROUP BY MONTH(h.ngaylap)
                    ORDER BY MONTH(h.ngaylap)");
            conn = DataProvider.TaoKetNoi();            
            DataTable dt = DataProvider.TruyVanLayDuLieu(query, conn);
            return dt;
        }
        public static int TinhTongTien(string mahd)
        {
            int tt = 0;
            string query = string.Format(@"select SUM(k.giaban*c.soluong) as N'Thành tiền'
            from cthd c, khohang k
            where c.masp = k.masp and c.mahd='{0}'
            group by c.mahd", mahd);
            conn = DataProvider.TaoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(query, conn);
            if (dt.Rows.Count > 0)
            {
                tt = int.Parse(dt.Rows[0]["Thành tiền"].ToString());
            }    
            return tt;
        }
        public static CTHD_DTO kt_MaHD_CTHD(string mahd)
        {
            string queryStr = string.Format(@"select * from cthd where mahd ='{0}'", mahd);
            conn = DataProvider.TaoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(queryStr, conn);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            CTHD_DTO cthd = new CTHD_DTO();
            cthd.MaHD = dt.Rows[0]["mahd"].ToString();           
            cthd.SoLuong = int.Parse(dt.Rows[0]["soluong"].ToString());
            cthd.MaSP = dt.Rows[0]["masp"].ToString();
            return cthd;
        }
        public static int LaySoLuong_CTHD(string mahd)
        {
            int sl = 0;
            string sTruyVan = string.Format(@"select * from cthd where mahd = '{0}'", mahd);
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
    }
}
