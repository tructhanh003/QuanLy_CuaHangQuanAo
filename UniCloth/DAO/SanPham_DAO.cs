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
    public class SanPham_DAO
    {
        static SqlConnection conn;
        public static List<SanPham_DTO> LaySanPham_DataGridView()
        {
            string query = string.Format(@"select s.masp, s.tensp, s.mau, s.size, s.maloai, s.mancc, s.machatlieu, l.tenloai, n.tenncc, cl.tenchatlieu, s.note, s.anh from sanpham s, loaisp l, nhacungcap n, chatlieu cl where s.maloai = l.maloai and s.mancc = n.mancc and s.machatlieu = cl.machatlieu");
            conn = DataProvider.TaoKetNoi();
            List<SanPham_DTO> lstSanPham = new List<SanPham_DTO>();
            DataTable dt = DataProvider.TruyVanLayDuLieu(query, conn);
            if (dt.Rows.Count == 0)
                return null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SanPham_DTO sp = new SanPham_DTO();
                sp.MaSP = dt.Rows[i]["masp"].ToString();
                sp.TenSP = dt.Rows[i]["tensp"].ToString();
                sp.MauSP = dt.Rows[i]["mau"].ToString();
                sp.MaLoai = int.Parse(dt.Rows[i]["maloai"].ToString());
                sp.MaNCC = int.Parse(dt.Rows[i]["mancc"].ToString());
                sp.MaCL = int.Parse(dt.Rows[i]["machatlieu"].ToString());
                sp.SizeSP = dt.Rows[i]["size"].ToString();
                sp.Tenloai = dt.Rows[i]["tenloai"].ToString();
                sp.TenNCC = dt.Rows[i]["tenncc"].ToString();
                sp.TenCL = dt.Rows[i]["tenchatlieu"].ToString();
                sp.NoteSP = dt.Rows[i]["note"].ToString();
                sp.AnhSP = dt.Rows[i]["anh"].ToString();
                lstSanPham.Add(sp);
            }
            return lstSanPham;
        }
        public static SanPham_DTO TimSP_ID(string masp)
        {
            string queryStr = string.Format(@"select * from sanpham where masp=N'{0}'", masp);
            conn = DataProvider.TaoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(queryStr, conn);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            SanPham_DTO sp = new SanPham_DTO();
            sp.MaSP = dt.Rows[0]["masp"].ToString();
            sp.TenSP = dt.Rows[0]["tensp"].ToString();           
            sp.MauSP = dt.Rows[0]["mau"].ToString();
            sp.SizeSP = dt.Rows[0]["size"].ToString();
            sp.NoteSP = dt.Rows[0]["note"].ToString();
            sp.MaLoai = int.Parse(dt.Rows[0]["maloai"].ToString());
            sp.MaNCC = int.Parse(dt.Rows[0]["mancc"].ToString());
            sp.MaCL = int.Parse(dt.Rows[0]["machatlieu"].ToString());
            sp.AnhSP = dt.Rows[0]["anh"].ToString();
            return sp;
        }
        public static void InsertSP(SanPham_DTO sp)
        {
            conn = DataProvider.TaoKetNoi();
            conn.Open();
            string query = string.Format(@"INSERT into sanpham (masp, tensp, mau, size, anh, maloai, mancc, machatlieu, note) VALUES  ('{0}', N'{1}', N'{2}', N'{3}', '{4}', {5}, {6}, {7}, N'{8}')",
                sp.MaSP, sp.TenSP, sp.MauSP, sp.SizeSP, sp.AnhSP, sp.MaLoai, sp.MaNCC, sp.MaCL, sp.NoteSP);
            DataProvider.TruyVanKhongLayDuLieu(query, conn);
            conn.Close();
        }
        public static void UpdateSP(SanPham_DTO sp)
        {
            conn = DataProvider.TaoKetNoi();
            conn.Open();
            string query = string.Format(@"update sanpham set tensp = N'{0}', mau = N'{1}', size = N'{2}', anh = '{3}', maloai = {4}, mancc = {5}, machatlieu = {6}, note = N'{7}' where masp = '{8}'",
                sp.TenSP, sp.MauSP, sp.SizeSP, sp.AnhSP, sp.MaLoai, sp.MaNCC, sp.MaCL, sp.NoteSP, sp.MaSP);
            DataProvider.TruyVanKhongLayDuLieu(query, conn);
            conn.Close();
        }
        public static void DeleteSP(string masp)
        {
            conn = DataProvider.TaoKetNoi();
            conn.Open();
            string query = string.Format(@"delete from sanpham where masp = '{0}'", masp);
            DataProvider.TruyVanKhongLayDuLieu(query, conn);
            conn.Close();
        }
        public static byte[] RetrieveImage(string masp)
        {
            byte[] imageData = null;
            string queryStr = string.Format(@"select anh from sanpham where masp = '{0}'", masp);
            conn = DataProvider.TaoKetNoi();
            conn.Open();
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            // Assume previously established command and connection
            // The command SELECTs the IMAGE column from the table

            using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                reader.Read();
                // Get size of image data – pass null as the byte array parameter
                long bytesize = reader.GetBytes(0, 0, null, 0, 0);
                // Allocate byte array to hold image data
                imageData = new byte[bytesize];
                long bytesread = 0;
                int curpos = 0;
                int chunkSize = 1;
                while (bytesread < bytesize)
                {
                    // chunkSize is an arbitrary application defined value
                    bytesread += reader.GetBytes(0, curpos, imageData, curpos, chunkSize);
                    curpos += chunkSize;
                }
            }
            conn.Close();
            // byte array ‘imageData’ now contains BLOB from database
            return imageData;
        }
        public static List<SanPham_DTO> TimSP_Ten(string tensp)
        {
            string query = string.Format(@"select s.masp, s.tensp, s.mau, s.size, s.maloai, s.mancc, s.machatlieu, l.tenloai, n.tenncc, cl.tenchatlieu, s.note, s.anh from sanpham s, loaisp l, nhacungcap n, chatlieu cl where s.maloai = l.maloai and s.mancc = n.mancc and s.machatlieu = cl.machatlieu and s.tensp like N'{0}%'", tensp);
            conn = DataProvider.TaoKetNoi();
            List<SanPham_DTO> lstSanPham = new List<SanPham_DTO>();
            DataTable dt = DataProvider.TruyVanLayDuLieu(query, conn);
            if (dt.Rows.Count == 0)
                return null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SanPham_DTO sp = new SanPham_DTO();
                sp.MaSP = dt.Rows[i]["masp"].ToString();
                sp.TenSP = dt.Rows[i]["tensp"].ToString();               
                sp.MauSP = dt.Rows[i]["mau"].ToString();
                sp.MaLoai = int.Parse(dt.Rows[i]["maloai"].ToString());
                sp.MaNCC = int.Parse(dt.Rows[i]["mancc"].ToString());
                sp.MaCL = int.Parse(dt.Rows[i]["machatlieu"].ToString());
                sp.SizeSP = dt.Rows[i]["size"].ToString();
                sp.Tenloai = dt.Rows[i]["tenloai"].ToString();
                sp.TenNCC = dt.Rows[i]["tenncc"].ToString();
                sp.TenCL = dt.Rows[i]["tenchatlieu"].ToString();
                sp.NoteSP = dt.Rows[i]["note"].ToString();
                sp.AnhSP = dt.Rows[i]["anh"].ToString();
                lstSanPham.Add(sp);
            }
            return lstSanPham;
        }
        public static List<SanPham_DTO> TimSP_MaSP(string masp)
        {
            string query = string.Format(@"select s.masp, s.tensp, s.mau, s.size, s.maloai, s.mancc, s.machatlieu, l.tenloai, n.tenncc, cl.tenchatlieu, s.note, s.anh  from sanpham s, loaisp l, nhacungcap n, chatlieu cl  where s.maloai = l.maloai and s.mancc = n.mancc and s.machatlieu = cl.machatlieu and s.masp like '{0}%'", masp);
            conn = DataProvider.TaoKetNoi();
            List<SanPham_DTO> lstSanPham = new List<SanPham_DTO>();
            DataTable dt = DataProvider.TruyVanLayDuLieu(query, conn);
            if (dt.Rows.Count == 0)
                return null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SanPham_DTO sp = new SanPham_DTO();
                sp.MaSP = dt.Rows[i]["masp"].ToString();
                sp.TenSP = dt.Rows[i]["tensp"].ToString();                
                sp.MaLoai = int.Parse(dt.Rows[i]["maloai"].ToString());
                sp.MaNCC = int.Parse(dt.Rows[i]["mancc"].ToString());
                sp.MaCL = int.Parse(dt.Rows[i]["machatlieu"].ToString());
                sp.SizeSP = dt.Rows[i]["size"].ToString();
                sp.Tenloai = dt.Rows[i]["tenloai"].ToString();
                sp.TenNCC = dt.Rows[i]["tenncc"].ToString();
                sp.TenCL = dt.Rows[i]["tenchatlieu"].ToString();
                sp.NoteSP = dt.Rows[i]["note"].ToString();
                sp.AnhSP = dt.Rows[i]["anh"].ToString();
                lstSanPham.Add(sp);
            }
            return lstSanPham;
        }
        public static List<SanPham_DTO> TimSP_MauSP(string mau)
        {
            string query = string.Format(@"select s.masp, s.tensp, s.mau, s.size, s.maloai, s.mancc, s.machatlieu, l.tenloai, n.tenncc, cl.tenchatlieu, s.note, s.anh from sanpham s, loaisp l, nhacungcap n, chatlieu cl where s.maloai = l.maloai and s.mancc = n.mancc and s.machatlieu = cl.machatlieu and s.mau like N'{0}%'", mau);
            conn = DataProvider.TaoKetNoi();
            List<SanPham_DTO> lstSanPham = new List<SanPham_DTO>();
            DataTable dt = DataProvider.TruyVanLayDuLieu(query, conn);
            if (dt.Rows.Count == 0)
                return null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SanPham_DTO sp = new SanPham_DTO();
                sp.MaSP = dt.Rows[i]["masp"].ToString();
                sp.TenSP = dt.Rows[i]["tensp"].ToString();              
                sp.MauSP = dt.Rows[i]["mau"].ToString();
                sp.MaLoai = int.Parse(dt.Rows[i]["maloai"].ToString());
                sp.MaNCC = int.Parse(dt.Rows[i]["mancc"].ToString());
                sp.MaCL = int.Parse(dt.Rows[i]["machatlieu"].ToString());
                sp.SizeSP = dt.Rows[i]["size"].ToString();
                sp.Tenloai = dt.Rows[i]["tenloai"].ToString();
                sp.TenNCC = dt.Rows[i]["tenncc"].ToString();
                sp.TenCL = dt.Rows[i]["tenchatlieu"].ToString();
                sp.NoteSP = dt.Rows[i]["note"].ToString();
                sp.AnhSP = dt.Rows[i]["anh"].ToString();
                lstSanPham.Add(sp);
            }
            return lstSanPham;
        }
        public static int LaySoLuong_SP()
        {
            int sl = 0;
            string sTruyVan = "select * from sanpham";
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
        public static List<SanPham_DTO> LaySanPham_ComboBox()
        {
            string sTruyVan = "select masp, tensp, size \r\n from sanpham";
            conn = DataProvider.TaoKetNoi();
            List<SanPham_DTO> lstSanPham = new List<SanPham_DTO>();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            if (dt.Rows.Count == 0)
                return null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SanPham_DTO sp = new SanPham_DTO();
                sp.MaSP = dt.Rows[i]["masp"].ToString();
                sp.TenSP = dt.Rows[i]["tensp"].ToString();               
                sp.SizeSP = dt.Rows[i]["size"].ToString();              
                lstSanPham.Add(sp);
            }
            return lstSanPham;
        }
    }
}
