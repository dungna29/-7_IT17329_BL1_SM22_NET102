using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BAI_3_1_LINQ_CacCauLenhCoBan
{
    internal class Program
    {
        private static ServiceAll _sv = new ServiceAll();
        private static List<NhanVien> _lstNhanViens;
        private static List<TheLoai> _lstTheLoais;
        private static List<SanPham> _lsSanPhams;
        public Program()
        {
            _lstNhanViens = _sv.GetListNhanViens();
            _lstTheLoais = _sv.GetListTheLoais();
            _lsSanPhams = _sv.GetListSanPhams();
        }
        static void Main(string[] args)
        {
            //Gọi các ví dụ về lý thuyết lên để chạy
            Console.OutputEncoding = Encoding.GetEncoding("UTF-8");
            Program program = new Program();//Khi khởi tạo thì các List trên sẽ có giá trị
            LINQ_GroupBy();
        }
        #region 1. Where điều kiện lọc
        static void LINQ_Where()
        {
            //1. Lấy danh sách những nhân viên có tên bắt đầu bằng chữ D
            var lst1 =
                (from a in _lstNhanViens
                 where a.TenNV.StartsWith("D") || a.TenNV.StartsWith("T")
                 select a).ToList();//== List Nhân viên.
            var lst2 = _lstNhanViens.Where(c => c.TenNV.StartsWith("D") || c.TenNV.StartsWith("T")).ToList();

            foreach (var x in _lstNhanViens.Where(c => c.TenNV.StartsWith("D") || c.TenNV.StartsWith("T")).ToList())
            {
                x.InRaManHinh();
            }

        }
        #endregion
        #region  2. Toán tử OfType để lọc các kiểu dữ liệu

        static void LINQ_OfType()
        {
            List<dynamic> lstString = new List<dynamic>() { 9, "Chín", 10, 7, "Bẩy" };

            var lst1 =
                from a in lstString.OfType<string>()
                select a;
            var lst2 =
                from a in lstString.OfType<int>()
                select a;
            Console.WriteLine("lstString.OfType<string>()");
            foreach (var x in lst1) Console.WriteLine(x);
            Console.WriteLine("lstString.OfType<int>()");
            foreach (var x in lst2) Console.WriteLine(x);
        }

        #endregion
        #region 3. Orderby dùng sắp xếp ngược xuôi và mặc định là ASC theo 1 điều kiện cụ thể


        static void LINQ_Orderby()
        {
            var lst1 =
                from a in _lsSanPhams
                orderby a.TenSP descending
                select a;
            var lst2 = _lsSanPhams.OrderBy(c => c.GiaBan);
        }
        //ThenBy đi với Orderby giúp mở rộng để sắp xếp thêm nhiều cột hơn cùng lúc
        static void LINQ_Orderby_Thenby()
        {
            var lst2 = _lsSanPhams.OrderBy(c => c.GiaBan).ThenBy(c => c.TenSP).ThenBy(c => c.KickThuoc);
            var lst3 = _lsSanPhams.OrderBy(c => c.GiaBan).ThenByDescending(c => c.TenSP);
        }

        #endregion


        #region 4. Group By nhóm các phần giống nhau

        static void LINQ_GroupBy()
        {
            List<string> lstName = new List<string> { "A", "A", "A", "NHAM", "NHAM", "NAM", "NAM" };
            var list =
                from a in lstName
                group a by a
                into g
                select g.Key;
            //Ví dụ 1: Lấy ra số lượng sản phẩm của các thể loại 
            var lst2 =
                (from a in _lsSanPhams
                 group a by new
                 {
                     //Nhóm nhiều cột lại
                     a.IdTheLoai
                 }
                into g
                 select new SanPham()
                 {
                     Id = g.Key.IdTheLoai,
                     IdTheLoai = g.Count(c => c.IdTheLoai == g.Key.IdTheLoai)
                 }).ToList();
            foreach (var x in lst2)
            {
                Console.WriteLine($"{x.Id} {x.IdTheLoai}");
            }

            //Ví dụ 2: Đếm số lượng sản phẩm theo mầu sắc và tổng tiền đã nhập trên sản phẩm mầu tượng
            var lst3 =
                (from a in _lsSanPhams
                 group a by new
                 {
                     //Nhóm nhiều cột lại
                     a.MauSac
                 }
                    into g
                 select new
                 {
                     Mau = g.Key.MauSac,
                     TongTien = g.Sum(c => c.GiaNhap),
                     SoLuong = g.Count(c => c.MauSac == g.Key.MauSac)
                 }).ToList();
            var lst4 = _lsSanPhams.GroupBy(c => new { c.MauSac }).Select(g => new
            {
                Mau = g.Key.MauSac,
                TongTien = g.Sum(c => c.GiaNhap),
                SoLuong = g.Count(c => c.MauSac == g.Key.MauSac)
            });
            foreach (var x in lst3)
            {
                Console.WriteLine($"{x.Mau} {x.TongTien} {x.SoLuong}");
            }
        }


        #endregion


        #region 5. Join

        static void LINQ_JOIN()
        {
            //Hiển thị thông tin sản phẩm bao gồm (MÃ, TÊN, MẦU, THỂ LOẠI, TÊN NGƯỜI TẠO)
            var lstSP =
                from a in _lsSanPhams
                join b in _lstTheLoais on a.IdTheLoai equals b.Id //inner join
                join c in _lstNhanViens on a.IdNhanVien equals c.Id
                where a.TrangThai
                select new//Select ra các cột do lập trình viên tự định nghĩa
                {
                    Ma = a.MaSP,
                    Ten = a.TenSP,
                    Mau = a.MauSac,
                    TenTheLoai = b.TenTheLoai,
                    TenNV = c.TenNV
                };
            var lstSP2 = _lsSanPhams.Where(c => c.TrangThai)
                .Join(_lstTheLoais, a => a.IdTheLoai, b => b.Id, (a, b) => new {a, b})
                .Join(_lstNhanViens, c => c.a.IdNhanVien, d => d.Id, (c, d) => new {c, d}).Select(e => new
                {
                    Ma = e.c.a.MaSP,
                    Ten = e.c.a.TenSP,
                    Mau = e.c.a.MauSac,
                    TenTheLoai = e.c.b.TenTheLoai,
                    TenNV = e.d.TenNV
                });
        }


        #endregion


        #region temp

        static void LINQ_()
        {

        }


        #endregion
    }
}
