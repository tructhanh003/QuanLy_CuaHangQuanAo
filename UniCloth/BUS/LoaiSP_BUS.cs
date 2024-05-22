using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class LoaiSP_BUS
    {
        public static List<LoaiSP_DTO> LayLoaiSP_ComboBox_BUS()
        {
            return LoaiSP_DAO.LayLoaiSP_ComboBox();
        }
        public static int chuyenMaLoai_BUS(string tenLoai)
        {
            return LoaiSP_DAO.chuyenMaLoai(tenLoai);
        }
        public static string chuyenMa_TenLoai(int maLoai)
        {
            return LoaiSP_DAO.chuyenMa_TenLoai(maLoai);
        }
    }
}
