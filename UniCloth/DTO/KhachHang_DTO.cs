using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang_DTO
    {
        private string maKH;
        private string hoTen;
        private string phaiKH;
        private string ngaySinh;
        private string soDT;
        private string diaChi;

        public KhachHang_DTO(string maKH, string hoTen, string phaiKH, string ngaySinh, string soDT, string diaChi)
        {
            this.MaKH = maKH;
            this.HoTen = hoTen;
            this.PhaiKH = phaiKH;
            this.NgaySinh = ngaySinh;
            this.SoDT = soDT;
            this.DiaChi = diaChi;
        }
        public KhachHang_DTO() { }
        public string MaKH { get => maKH; set => maKH = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string PhaiKH { get => phaiKH; set => phaiKH = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string SoDT { get => soDT; set => soDT = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
    }
}
