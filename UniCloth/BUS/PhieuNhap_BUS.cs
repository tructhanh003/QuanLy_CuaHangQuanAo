using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
    public class PhieuNhap_BUS
    {
        public static List<PhieuNhap_DTO> LayPN_DataGridView()
        {
            return PhieuNhap_DAO.LayPN_DataGridView();
        }
        public static void Insert_Kho(PhieuNhap_DTO kho)
        {
            PhieuNhap_DAO.Insert_Kho(kho);
        }    
        public static void DeleteKho_BUS(int sophieu)
        {
            PhieuNhap_DAO.DeleteKho(sophieu);
        }       
        public static List<PhieuNhap_DTO> TimSP_TheoTen_BUS(string ten)
        {
            return PhieuNhap_DAO.TimSP_TheoTen(ten);
        }
        public static PhieuNhap_DTO TimSP_ID_Kho_BUS(string masp)
        {
            return PhieuNhap_DAO.TimSP_ID_Kho(masp);
        }
        public static int lay_SL_Kho_BUS(string masp)
        {
            return PhieuNhap_DAO.lay_SL_Kho(masp);
        }
        public static void Update_SoLuong_Kho_BUS(int sl, string masp)
        {
            PhieuNhap_DAO.Update_SoLuong_Kho(sl, masp);
        }
        public static PhieuNhap_DTO HienThi_SP_BUS(int sp)
        {
            return PhieuNhap_DAO.HienThi_SP(sp);
        }
    }
}
