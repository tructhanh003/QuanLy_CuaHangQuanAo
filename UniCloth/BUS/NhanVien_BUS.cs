using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NhanVien_BUS
    {
        public static NhanVien_DTO TimNhanVienTheoID_BUS(string manv)
        {
            return NhanVien_DAO.TimNhanVienTheoID(manv);
        }
        public static NhanVien_DTO TimNhanVienTheoTK_BUS(string user)
        {
            return NhanVien_DAO.TimNhanVienTheoTK(user);
        }
        public static NhanVien_DTO TimNhanVienTheoTK_MK_BUS(string user, string pass)
        {
            return NhanVien_DAO.TimNhanVienTheoTK_MK(user, pass);
        }
        public static byte[] RetrieveImage_BUS(string manv)
        {
            return NhanVien_DAO.RetrieveImage(manv);
        }
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
