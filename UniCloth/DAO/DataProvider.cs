using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DataProvider
    {
        public static SqlConnection TaoKetNoi()
        {
            string strConn = @"Data Source=LAPTOP-DGG3IKPJ\SQLEXPRESS;Initial Catalog=QuanLyShopQuanAo;Integrated Security=True;TrustServerCertificate=True";
            SqlConnection conn = new SqlConnection(strConn);
            return conn;
        }
        public static DataTable TruyVanLayDuLieu(string sTruyVan, SqlConnection conn)
        {
            SqlDataAdapter da = new SqlDataAdapter(sTruyVan, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static void TruyVanKhongLayDuLieu(string sTruyVan, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand(sTruyVan, conn);
            cmd.ExecuteNonQuery();
        }
    }
}
