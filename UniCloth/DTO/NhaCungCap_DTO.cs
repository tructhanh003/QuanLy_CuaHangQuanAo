using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhaCungCap_DTO
    {
        private int maNCC;
        private string tenNCC;

        public NhaCungCap_DTO(int maNCC, string tenNCC)
        {
            this.MaNCC = maNCC;
            this.TenNCC = tenNCC;
        }
        public NhaCungCap_DTO()
        {

        }
        public int MaNCC { get => maNCC; set => maNCC = value; }
        public string TenNCC { get => tenNCC; set => tenNCC = value; }
    }
}
