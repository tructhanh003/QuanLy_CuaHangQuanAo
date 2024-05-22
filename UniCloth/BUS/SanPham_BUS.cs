using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
    public class SanPham_BUS
    {
        public static List<SanPham_DTO> LaySanPham_DataGridView_BUS()
        {
            return SanPham_DAO.LaySanPham_DataGridView();
        }
        public static void InsertSP_BUS(SanPham_DTO sp)
        {
            SanPham_DAO.InsertSP(sp);
        }
        public static byte[] RetrieveImage_SP_BUS(string masp)
        {
            return SanPham_DAO.RetrieveImage(masp);
        }
        public static SanPham_DTO TimSP_ID_BUS(string masp)
        {
            return SanPham_DAO.TimSP_ID(masp);
        }
        public static void UpdateSP_BUS(SanPham_DTO sp)
        {
            SanPham_DAO.UpdateSP(sp);
        }
        public static void DeleteSP_BUS(string masp)
        {
            SanPham_DAO.DeleteSP(masp);
        }
        public static List<SanPham_DTO> TimSP_Ten(string tensp)
        {
            return SanPham_DAO.TimSP_Ten(tensp);
        }
        public static List<SanPham_DTO> TimSP_MaSP(string masp)
        {
            return SanPham_DAO.TimSP_MaSP(masp);
        }
        public static List<SanPham_DTO> TimSP_MauSP(string mau)
        {
            return SanPham_DAO.TimSP_MauSP(mau);
        }
        public static List<SanPham_DTO> LaySanPham_ComboBox_BUS()
        {
            return SanPham_DAO.LaySanPham_ComboBox();
        }
        public static int LaySoLuong_SP_BUS()
        {
            return SanPham_DAO.LaySoLuong_SP();
        }       
    }
}
