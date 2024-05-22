using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
    public class KhachHang_BUS
    {
        public static List<KhachHang_DTO> LayKhachHang_DataGridView_BUS()
        {
            return KhachHang_DAO.LayKhachHang_DataGridView();
        }
        public static int LaySoLuong_KH_BUS()
        {
            return KhachHang_DAO.LaySoLuong_KH();
        }
        public static void InsertKH_BUS(KhachHang_DTO kh)
        {
            KhachHang_DAO.InsertKH(kh);
        }
        public static KhachHang_DTO TimKH_ID_BUS(string makh)
        {
            return KhachHang_DAO.TimKH_ID(makh);
        }
        public static void UpdateKH_BUS(KhachHang_DTO kh)
        {
            KhachHang_DAO.UpdateKH(kh);
        }
        public static void DeleteKH_BUS(string makh)
        {
            KhachHang_DAO.DeleteKH(makh);
        }
        public static List<KhachHang_DTO> TimKH_TheoMa_BUS(string makh)
        {
            return KhachHang_DAO.TimKH_TheoMa(makh);
        }
        public static List<KhachHang_DTO> TimKH_TheoTen_BUS(string tenkh)
        {
            return KhachHang_DAO.TimKH_TheoTen(tenkh);
        }
        public static List<KhachHang_DTO> TimKH_TheoDT_BUS(string sdt)
        {
            return KhachHang_DAO.TimKH_TheoDT(sdt);
        }
    }
}
