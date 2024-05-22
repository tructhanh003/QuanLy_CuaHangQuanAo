using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class KhoHang_BUS
    {
        public static KhoHang_DTO TimSP_ID_KhoHang_BUS(string masp)
        {
            return KhoHang_DAO.TimSP_ID_Kho(masp);
        }
        public static void Insert_KhoHang_BUS(KhoHang_DTO kho)
        {
            KhoHang_DAO.Insert_KhoHang(kho);
        }
        public static void Delete_KhoHang_BUS(string masp)
        {
            KhoHang_DAO.Delete_KhoHang(masp);
        }
        public static int lay_SL_Kho_BUS(string masp)
        {
            return KhoHang_DAO.lay_SL_Kho(masp);
        }
        public static void Update_SoLuong_Kho_BUS(int sl, string masp)
        {
            KhoHang_DAO.Update_SoLuong_Kho(sl, masp);
        }
        public static List<KhoHang_DTO> LayKhoHang_DataGridView()
        {
            return KhoHang_DAO.LayKhoHang_DataGridView();
        }
        public static void Update_GiaBan_Kho(int giaBan, string masp)
        {
            KhoHang_DAO.Update_GiaBan_Kho(giaBan, masp);
        }
        public static List<KhoHang_DTO> LaySanPham_ComboBox_KhoHang_BUS()
        {
            return KhoHang_DAO.LaySanPham_ComboBox_KhoHang();
        }
        public static int LaySoLuong_SP_KhoHang_BUS()
        {
            return KhoHang_DAO.LaySoLuong_SP_KhoHang();
        }
        public static List<KhoHang_DTO> SapXep_TangDan_SoLuong_BUS()
        {
            return KhoHang_DAO.SapXep_TangDan_SoLuong();
        }
        public static List<KhoHang_DTO> SapXep_GiamDan_SoLuong_BUS()
        {
            return KhoHang_DAO.SapXep_GiamDan_SoLuong();
        }
    }
}
