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
    public class ChatLieu_DAO
    {
        static SqlConnection conn;
        public static List<ChatLieu_DTO> LayChatLieu_ComboBox()
        {
            string sTruyVan = "select * from chatlieu";
            conn = DataProvider.TaoKetNoi();
            List<ChatLieu_DTO> lstCL = new List<ChatLieu_DTO>();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            if (dt.Rows.Count == 0)
                return null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChatLieu_DTO cl = new ChatLieu_DTO();
                cl.MaCL = int.Parse(dt.Rows[i]["machatlieu"].ToString());
                cl.TenCL = dt.Rows[i]["tenchatlieu"].ToString();
                lstCL.Add(cl);
            }
            return lstCL;
        }
        public static int chuyenMaCL(string tenCL)
        {
            int maCL = 0;
            string sTruyVan = "select * from chatlieu";
            conn = DataProvider.TaoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["tenchatlieu"].ToString() == tenCL)
                {
                    maCL = int.Parse(dt.Rows[i]["machatlieu"].ToString());
                    break;
                }
            }
            return maCL;
        }
        public static string chuyenMa_TenCL(int maCL)
        {
            string tenCL = "";
            string sTruyVan = "select * from chatlieu";
            conn = DataProvider.TaoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (int.Parse(dt.Rows[i]["machatlieu"].ToString()) == maCL)
                {
                    tenCL = dt.Rows[i]["tenchatlieu"].ToString();
                    break;
                }
            }
            return tenCL;
        }
    }
}
