using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class CTHD_BUS
    {
        public static void InsertCTHD(CTHD_DTO ct)
        {
            CTHD_DAO.InsertCTHD(ct);
        }
        public static List<CTHD_DTO> Lay_CTHD_DGV(string mahd)
        {
            return CTHD_DAO.Lay_CTHD_DGV(mahd);
        }
        public static int TinhTongTien_BUS(string mahd)
        {
            return CTHD_DAO.TinhTongTien(mahd);
        }
        public static CTHD_DTO kt_MaHD_CTHD(string mahd)
        {
            return CTHD_DAO.kt_MaHD_CTHD(mahd);
        }
        public static int LaySoLuong_CTHD_BUS(string mahd)
        {
            return CTHD_DAO.LaySoLuong_CTHD(mahd);
        }
        public static DataTable ThongKe_DT_Thang_BUS()
        {
            return CTHD_DAO.ThongKe_DT_Thang();
        }
    }
}
