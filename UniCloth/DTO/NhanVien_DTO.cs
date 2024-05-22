using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien_DTO
    {
        private string maNV;
        private string tenTK;
        private string matKhau;
        private string hoTen;
        private string phai;
        private string ngaySinh;
        private string cCCD;
        private string soDT;
        private int maCV;
        private byte[] anhNV;
        private string tencv;

        public NhanVien_DTO()
        {

        }

        public NhanVien_DTO(string maNV, string tenTK, string matKhau, string hoTen, string phai, string ngaySinh, string cCCD, string soDT, int maCV, byte[] anhNV, string tencv)
        {
            this.maNV = maNV;
            this.tenTK = tenTK;
            this.matKhau = matKhau;
            this.hoTen = hoTen;
            this.phai = phai;
            this.ngaySinh = ngaySinh;
            this.cCCD = cCCD;
            this.soDT = soDT;
            this.maCV = maCV;
            this.anhNV = anhNV;
            this.Tencv = tencv;
        }

        public string MaNV { get => maNV; set => maNV = value; }
        public string TenTK { get => tenTK; set => tenTK = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string Phai { get => phai; set => phai = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string CCCD { get => cCCD; set => cCCD = value; }
        public string SoDT { get => soDT; set => soDT = value; }
        public byte[] AnhNV { get => anhNV; set => anhNV = value; }
        public int MaCV { get => maCV; set => maCV = value; }
        public string Tencv { get => tencv; set => tencv = value; }
    }
}
