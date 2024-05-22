using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class PhieuXuat_BUS
    {
        public static List<PhieuXuat_DTO> LayPX_DataGridView_BUS()
        {
            return PhieuXuat_DAO.LayPX_DataGridView();
        }
        public static void Insert_PhieuXuat_BUS(PhieuXuat_DTO kho)
        {
            PhieuXuat_DAO.Insert_PhieuXuat(kho);
        }
        public static void Delete_PhieuXuat_BUS(int soPhieu)
        {
            PhieuXuat_DAO.Delete_PhieuXuat(soPhieu);
        }
        public static List<PhieuXuat_DTO> TimSP_Ten_PhieuXuat_BUS(string tensp)
        {
            return PhieuXuat_DAO.TimSP_Ten_PhieuXuat(tensp);
        }
        public static List<PhieuXuat_DTO> TimSP_MaSP_PhieuXuat_BUS(string masp)
        {
            return PhieuXuat_DAO.TimSP_MaSP_PhieuXuat(masp);
        }
        public static PhieuXuat_DTO HienThi_SP_PhieuXuat_BUS(int sophieu)
        {
            return PhieuXuat_DAO.HienThi_SP_PhieuXuat(sophieu);
        }
    }
}
