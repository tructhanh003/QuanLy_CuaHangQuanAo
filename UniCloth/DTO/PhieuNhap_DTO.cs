using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuNhap_DTO
    {
        private int soPhieu;
        private string maSP;
        private string maNV;
        private string ngayNhap;
        private int soLuong;
        private int giaNhap;
        private int maNCC;

        private string tenSP;
        private string sizeSP;
        private string tenNCC;
        private string tenNV;

        public PhieuNhap_DTO() { }

        public PhieuNhap_DTO(int soPhieu, string maSP, string maNV, string ngayNhap, int soLuong, int giaNhap, int maNCC)
        {
            this.soPhieu = soPhieu;
            this.maSP = maSP;
            this.maNV = maNV;            
            this.ngayNhap = ngayNhap;
            this.soLuong = soLuong;
            this.giaNhap = giaNhap;            
            this.maNCC = maNCC;
        }

        public string MaSP { get => maSP; set => maSP = value; }
        public string NgayNhap { get => ngayNhap; set => ngayNhap = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public int GiaNhap { get => giaNhap; set => giaNhap = value; }
        public string SizeSP { get => sizeSP; set => sizeSP = value; }
        public int SoPhieu { get => soPhieu; set => soPhieu = value; }
        public int MaNCC { get => maNCC; set => maNCC = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public string TenNCC { get => tenNCC; set => tenNCC = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
    }
}
