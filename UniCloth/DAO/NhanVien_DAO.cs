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
    public class NhanVien_DAO
    {
        static SqlConnection conn;
        public static NhanVien_DTO TimNhanVienTheoID(string manv)
        {
            string queryStr = string.Format(@"select * from nhanvien where manv=N'{0}'", manv);
            conn = DataProvider.TaoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(queryStr, conn);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            NhanVien_DTO nv = new NhanVien_DTO();
            nv.MaNV = dt.Rows[0]["manv"].ToString();
            nv.TenTK = dt.Rows[0]["tentk"].ToString();
            nv.MatKhau = dt.Rows[0]["matkhau"].ToString();
            nv.HoTen = dt.Rows[0]["hoten"].ToString();
            nv.Phai = dt.Rows[0]["phai"].ToString();
            nv.NgaySinh = dt.Rows[0]["ngaysinh"].ToString();
            nv.CCCD = dt.Rows[0]["cccd"].ToString();
            nv.SoDT = dt.Rows[0]["sodt"].ToString();
            nv.MaCV = int.Parse(dt.Rows[0]["macv"].ToString());
            return nv;
        }
        public static NhanVien_DTO TimNhanVienTheoTK(string user)
        {
            string queryStr = string.Format(@"select * from nhanvien where tentk=N'{0}'", user);
            conn = DataProvider.TaoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(queryStr, conn);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            NhanVien_DTO nv = new NhanVien_DTO();
            nv.MaNV = dt.Rows[0]["manv"].ToString();
            nv.TenTK = dt.Rows[0]["tentk"].ToString();
            nv.MatKhau = dt.Rows[0]["matkhau"].ToString();
            nv.HoTen = dt.Rows[0]["hoten"].ToString();
            nv.Phai = dt.Rows[0]["phai"].ToString();
            nv.NgaySinh = dt.Rows[0]["ngaysinh"].ToString();
            nv.CCCD = dt.Rows[0]["cccd"].ToString();
            nv.SoDT = dt.Rows[0]["sodt"].ToString();
            nv.MaCV = int.Parse(dt.Rows[0]["macv"].ToString());
            return nv;
        }
        public static NhanVien_DTO TimNhanVienTheoTK_MK(string user, string pass)
        {
            string queryStr = string.Format(@"select * from nhanvien where tentk=N'{0}' and matkhau='{1}'", user, pass);
            conn = DataProvider.TaoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(queryStr, conn);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            NhanVien_DTO nv = new NhanVien_DTO();
            nv.MaNV = dt.Rows[0]["manv"].ToString();
            nv.TenTK = dt.Rows[0]["tentk"].ToString();
            nv.MatKhau = dt.Rows[0]["matkhau"].ToString();
            nv.HoTen = dt.Rows[0]["hoten"].ToString();
            nv.Phai = dt.Rows[0]["phai"].ToString();
            nv.NgaySinh = dt.Rows[0]["ngaysinh"].ToString();
            nv.CCCD = dt.Rows[0]["cccd"].ToString();
            nv.SoDT = dt.Rows[0]["sodt"].ToString();
            nv.MaCV = int.Parse(dt.Rows[0]["macv"].ToString());
            return nv;
        }
        public static byte[] RetrieveImage(string manv)
        {
            byte[] imageData = null;
            string queryStr = string.Format(@"select anh from nhanvien where manv = '{0}'", manv);
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
    }
}
