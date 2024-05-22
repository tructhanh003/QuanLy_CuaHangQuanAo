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
    public class NhaCungCap_DAO
    {
        static SqlConnection conn;
        public static List<NhaCungCap_DTO> LayNCC_ComboBox()
        {
            string sTruyVan = "select * from nhacungcap";
            conn = DataProvider.TaoKetNoi();
            List<NhaCungCap_DTO> lstNCC = new List<NhaCungCap_DTO>();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            if (dt.Rows.Count == 0)
                return null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NhaCungCap_DTO ncc = new NhaCungCap_DTO();
                ncc.MaNCC = int.Parse(dt.Rows[i]["mancc"].ToString());
                ncc.TenNCC = dt.Rows[i]["tenncc"].ToString();
                lstNCC.Add(ncc);
            }
            return lstNCC;
        }
        public static int chuyenMaNCC(string tenNCC)
        {
            int maNCC = 0;
            string sTruyVan = "select * from nhacungcap";
            conn = DataProvider.TaoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["tenncc"].ToString() == tenNCC)
                {
                    maNCC = int.Parse(dt.Rows[i]["mancc"].ToString());
                    break;
                }
            }
            return maNCC;
        }
        public static string chuyenMa_TenNCC(int maNCC)
        {
            string tenNCC = "";
            string sTruyVan = "select * from nhacungcap";
            conn = DataProvider.TaoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (int.Parse(dt.Rows[i]["mancc"].ToString()) == maNCC)
                {
                    tenNCC = dt.Rows[i]["tenncc"].ToString();
                    break;
                }
            }
            return tenNCC;
        }
    }
}
