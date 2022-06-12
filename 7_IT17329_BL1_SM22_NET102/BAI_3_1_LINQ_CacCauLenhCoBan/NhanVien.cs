using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_3_1_LINQ_CacCauLenhCoBan
{
    class NhanVien : IEqualityComparer<NhanVien>
    {
        public int Id { get; set; }
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string Email { get; set; }
        public string Sdt { get; set; }
        public string DiaChi { get; set; }
        public string QueQuan { get; set; }
        public string ThanhPho { get; set; }
        public bool TrangThai { get; set; }

       
        public void InRaManHinh()
        {
            Console.WriteLine($"{Id} | {MaNV} | {TenNV} | {Email} | {Sdt} | {DiaChi} | {ThanhPho} | {QueQuan} | {TrangThai}");
        }

        public bool Equals(NhanVien x, NhanVien y)
        {
            // if (ReferenceEquals(x, y)) return true;
            // if (ReferenceEquals(x, null)) return false;
            // if (ReferenceEquals(y, null)) return false;
            // if (x.GetType() != y.GetType()) return false;
            // return x.Id == y.Id && x.MaNV == y.MaNV && x.TenNV == y.TenNV && x.Email == y.Email && x.Sdt == y.Sdt && x.DiaChi == y.DiaChi && x.QueQuan == y.QueQuan && x.ThanhPho == y.ThanhPho && x.TrangThai == y.TrangThai;
            if (Object.ReferenceEquals(x, y)) return true;

            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;

            return x.Id == y.Id && x.MaNV == y.MaNV && x.TenNV == y.TenNV && x.Email == y.Email && x.Sdt == y.Sdt && x.DiaChi == y.DiaChi && x.QueQuan == y.QueQuan && x.ThanhPho == y.ThanhPho && x.TrangThai == y.TrangThai;
        }

        public int GetHashCode(NhanVien obj)
        {
            //If obj is null then return 0
            if (obj is null)
            {
                return 0;
            }
            int Id = obj.Id.GetHashCode();
            int MaNV = obj.MaNV == null ? 0 : obj.MaNV.GetHashCode();
            int TenNV = obj.TenNV.GetHashCode();
            int Email = obj.Email.GetHashCode() == null ? 0 : obj.Email.GetHashCode();
            int Sdt = obj.Sdt.GetHashCode() == null ? 0 : obj.Sdt.GetHashCode();
            int DiaChi = obj.DiaChi.GetHashCode() == null ? 0 : obj.DiaChi.GetHashCode();
            int QueQuan = obj.QueQuan.GetHashCode() == null ? 0 : obj.QueQuan.GetHashCode();
            int ThanhPho = obj.ThanhPho.GetHashCode() == null ? 0 : obj.ThanhPho.GetHashCode();
            int TrangThai = obj.TrangThai.GetHashCode();
            return Id ^ MaNV ^ TenNV ^ Email ^ DiaChi ^ QueQuan ^ ThanhPho ^ TrangThai;
        }
    }
}
