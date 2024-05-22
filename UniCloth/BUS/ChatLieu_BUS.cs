using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ChatLieu_BUS
    {
        public static List<ChatLieu_DTO> LayChatLieu_ComboBox_BUS()
        {
            return ChatLieu_DAO.LayChatLieu_ComboBox();
        }
        public static int chuyenMaCL_BUS(string tenCL)
        {
            return ChatLieu_DAO.chuyenMaCL(tenCL);
        }
        public static string chuyenMa_TenCL(int maCL)
        {
            return ChatLieu_DAO.chuyenMa_TenCL(maCL);
        }
    }
}
