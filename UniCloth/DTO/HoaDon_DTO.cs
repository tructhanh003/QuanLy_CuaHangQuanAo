using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDon_DTO
    {
        private string maHD;
        private string maNV;
        private string maKH;
        private string ngayLap;

        private string tenNV;
        private string tenKH;


        public HoaDon_DTO()
        {

        }

        public string MaHD { get => maHD; set => maHD = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public string MaKH { get => maKH; set => maKH = value; }
        public string NgayLap { get => ngayLap; set => ngayLap = value; }
        public string TenNV { get; set; }
        public string TenKH { get; set; }
    }
}
