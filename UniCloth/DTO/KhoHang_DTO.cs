using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhoHang_DTO
    {
        private string maSP;
        private int soLuong;
        private int giaBan;

        private string tenSP;
        private string sizeSP;
        private int giaNhap;
        private string ngayNhap;

        public KhoHang_DTO(string maSP, int soLuong, int giaBan)
        {
            this.MaSP = maSP;
            this.SoLuong = soLuong;
            this.GiaBan = giaBan;
        }
        public KhoHang_DTO() { }
        public string MaSP { get => maSP; set => maSP = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int GiaBan { get => giaBan; set => giaBan = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public string SizeSP { get => sizeSP; set => sizeSP = value; }
        public int GiaNhap { get => giaNhap; set => giaNhap = value; }
        public string NgayNhap { get => ngayNhap; set => ngayNhap = value; }
    }
}
