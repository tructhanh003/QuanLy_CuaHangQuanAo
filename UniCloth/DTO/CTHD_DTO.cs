using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CTHD_DTO
    {
        private string maHD;
        private string maSP;
        private int soLuong;
        private int tongTien = 0;
        private string tenSP;
        private int giaTien;
        private string thangDT;
        public CTHD_DTO(string maHD, string maSP, int soLuong)
        {
            this.MaHD = maHD;
            this.MaSP = maSP;
            this.SoLuong = soLuong;
        }
        public CTHD_DTO()
        {

        }
        public string MaHD { get => maHD; set => maHD = value; }
        public string MaSP { get => maSP; set => maSP = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int TongTien { get => tongTien; set => tongTien = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public int GiaTien { get => giaTien; set => giaTien = value; }
        public string ThangDT { get => thangDT; set => thangDT = value; }
    }
}
