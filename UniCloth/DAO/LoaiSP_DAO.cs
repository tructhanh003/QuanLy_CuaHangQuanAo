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
    public class LoaiSP_DAO
    {
        static SqlConnection conn;
        public static List<LoaiSP_DTO> LayLoaiSP_ComboBox()
        {
            string sTruyVan = "select * from loaisp";
            conn = DataProvider.TaoKetNoi();
            List<LoaiSP_DTO> lstLoaiSP = new List<LoaiSP_DTO>();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            if (dt.Rows.Count == 0)
                return null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LoaiSP_DTO loai = new LoaiSP_DTO();
                loai.MaLoai = int.Parse(dt.Rows[i]["maloai"].ToString());
                loai.TenLoai = dt.Rows[i]["tenloai"].ToString();
                lstLoaiSP.Add(loai);
            }
            return lstLoaiSP;
        }
        public static int chuyenMaLoai(string tenLoai)
        {
            int maLoai = 0;
            string sTruyVan = "select * from loaisp";
            conn = DataProvider.TaoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["tenloai"].ToString() == tenLoai)
                {
                    maLoai = int.Parse(dt.Rows[i]["maloai"].ToString());
                    break;
                }
            }
            return maLoai;
        }
        public static string chuyenMa_TenLoai(int maLoai)
        {
            string tenLoai = "";
            string sTruyVan = "select * from loaisp";
            conn = DataProvider.TaoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (int.Parse(dt.Rows[i]["maloai"].ToString()) == maLoai)
                {
                    tenLoai = dt.Rows[i]["tenloai"].ToString();
                    break;
                }
            }
            return tenLoai;
        }
    }
}
