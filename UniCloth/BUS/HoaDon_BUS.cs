using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class HoaDon_BUS
    {
        public static void InsertHD(HoaDon_DTO hd)
        {
            HoaDon_DAO.InsertHD(hd);
        }
        public static List<HoaDon_DTO> LayHD_DataGridView_BUS()
        {
            return HoaDon_DAO.LayHD_DataGridView();
        }
        public static HoaDon_DTO TimHD_ID_BUS(string ID)
        {
            return HoaDon_DAO.TimHD_ID(ID);
        }
        public static void DeleteHD_BUS(string hd)
        {
            HoaDon_DAO.DeleteHD(hd);
        }
        public static List<HoaDon_DTO> LayHD_ChungTu_BUS(string n1, string n2)
        {
            return HoaDon_DAO.LayHD_ChungTu(n1, n2);
        }
        public static List<HoaDon_DTO> TimKiem_HD_TheoMa_DGV_BUS(string maHD)
        {
            return HoaDon_DAO.TimKiem_HD_TheoMa_DGV(maHD);
        }
    }
}
