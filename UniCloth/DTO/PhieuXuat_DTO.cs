using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuXuat_DTO
    {
        private int soPhieu;
        private string maSP;
        private string maNV;
        private string maKH;
        private int soLuong;
        private string ngayXuat;

        private string tenSP;
        private string sizeSP;
        private string tenKH;
        private string tenNV;
        private int thanhTien;
        private int giaBan;

        public PhieuXuat_DTO(int soPhieu, string maSP, string maNV, string maKH, int soLuong, string ngayXuat)
        {
            this.SoPhieu = soPhieu;
            this.MaSP = maSP;
            this.MaNV = maNV;
            this.MaKH = maKH;
            this.SoLuong = soLuong;
            this.NgayXuat = ngayXuat;
        }
        public PhieuXuat_DTO()
        { }
        public int SoPhieu { get => soPhieu; set => soPhieu = value; }
        public string MaSP { get => maSP; set => maSP = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public string MaKH { get => maKH; set => maKH = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public string NgayXuat { get => ngayXuat; set => ngayXuat = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public string SizeSP { get => sizeSP; set => sizeSP = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public int ThanhTien { get => thanhTien; set => thanhTien = value; }
        public int GiaBan { get => giaBan; set => giaBan = value; }
    }
}
