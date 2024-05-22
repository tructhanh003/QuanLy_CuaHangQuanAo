using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChatLieu_DTO
    {
        private int maCL;
        private string tenCL;

        public ChatLieu_DTO(int maCL, string tenCL)
        {
            this.MaCL = maCL;
            this.TenCL = tenCL;
        }
        public ChatLieu_DTO()
        {

        }
        public int MaCL { get => maCL; set => maCL = value; }
        public string TenCL { get => tenCL; set => tenCL = value; }
    }
}
