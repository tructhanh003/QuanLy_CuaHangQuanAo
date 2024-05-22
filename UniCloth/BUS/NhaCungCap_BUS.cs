using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NhaCungCap_BUS
    {
        public static List<NhaCungCap_DTO> LayNCC_ComboBox_BUS()
        {
            return NhaCungCap_DAO.LayNCC_ComboBox();
        }
        public static int chuyenMaNCC_BUS(string tenNCC)
        {
            return NhaCungCap_DAO.chuyenMaNCC(tenNCC);
        }
        public static string chuyenMa_TenNCC(int maNCC)
        {
            return NhaCungCap_DAO.chuyenMa_TenNCC(maNCC);
        }
    }
}
