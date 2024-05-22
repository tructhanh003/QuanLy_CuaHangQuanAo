using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPham_DTO
    {
        private string maSP;
        private string tenSP;
        private string mauSP;
        private string sizeSP;
        private string anhSP;
        private int maLoai;
        private int maCL;
        private int maNCC;
        private string noteSP;

        private string tenloai;
        private string tenNCC;
        private string tenCL;

        public SanPham_DTO(string maSP, string tenSP, string mauSP, string sizeSP, string anhSP, int maLoai, int maCL, int maNCC, string noteSP)
        {
            this.MaSP = maSP;
            this.TenSP = tenSP;
            this.MauSP = mauSP;
            this.SizeSP = sizeSP;
            this.AnhSP = anhSP;
            this.MaLoai = maLoai;
            this.MaCL = maCL;
            this.MaNCC = maNCC;
            this.NoteSP = noteSP;
        }
        public SanPham_DTO()
        {

        }
        public string MaSP { get => maSP; set => maSP = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public string MauSP { get => mauSP; set => mauSP = value; }
        public string SizeSP { get => sizeSP; set => sizeSP = value; }
        public string AnhSP { get => anhSP; set => anhSP = value; }
        public int MaLoai { get => maLoai; set => maLoai = value; }
        public int MaCL { get => maCL; set => maCL = value; }
        public int MaNCC { get => maNCC; set => maNCC = value; }
        public string NoteSP { get => noteSP; set => noteSP = value; }
        public string Tenloai { get => tenloai; set => tenloai = value; }
        public string TenNCC { get => tenNCC; set => tenNCC = value; }
        public string TenCL { get => tenCL; set => tenCL = value; }
    }
}
