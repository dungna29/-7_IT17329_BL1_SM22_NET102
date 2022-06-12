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
            LINQ_Distinct();
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
                .Join(_lstTheLoais, a => a.IdTheLoai, b => b.Id, (a, b) => new { a, b })
                .Join(_lstNhanViens, c => c.a.IdNhanVien, d => d.Id, (c, d) => new { c, d }).Select(e => new
                {
                    Ma = e.c.a.MaSP,
                    Ten = e.c.a.TenSP,
                    Mau = e.c.a.MauSac,
                    TenTheLoai = e.c.b.TenTheLoai,
                    TenNV = e.d.TenNV
                });
        }


        #endregion
        #region 6. Select

        static void LINQ_Select()
        {
            List<NhanVien> lst1 =
                (from a in _lstNhanViens
                 where a.TenNV.Length < 5
                 select a).ToList();//1 Tập đối tượng
            var lst2 = (from a in _lstNhanViens
                        where a.TenNV.Length < 5
                        select a.TenNV).ToList();//Trả ra 1 tập tên của thuộc thuộc tính đối tượng

            var temp1 = (from a in _lstNhanViens
                         where a.TenNV.Length < 5
                         select a).FirstOrDefault();//Trả ra 1 đối tượng nhân viên

            var temp2 = (from a in _lstNhanViens
                         where a.TenNV.Length < 5
                         select a.TenNV).FirstOrDefault();// Trả ra 1 tên nhân viên

            foreach (var x in _lstNhanViens.Select(c => c.TenNV))
            {
                //In ra 1 List String tên nhân viên
                Console.WriteLine(x);
            }
            //SelectMany đọc thêm.
            foreach (var x in _lstNhanViens.SelectMany(c => c.TenNV))
            {
                //In ra 1 List char 
                Console.WriteLine(x);
            }
        }


        #endregion
        #region 7. ALL/ANY

        static void LINQ_ALL_ANY()
        {
            //All: Kiểm tra xem tất cả các phần tử trong dãy có thỏa mãn thì trả ra true
            //Any: Kiểm tra xem tất cả các phần tử trong dãy chỉ cần có thỏa mãn thì trả ra true
            var temp1 = _lstNhanViens.All(c => c.MaNV == "Dungna2");
            var temp2 = _lstNhanViens.Any(c => c.MaNV == "Dungna2");
            Console.WriteLine("All = " + temp1);//false
            Console.WriteLine("Any = " + temp2);//true

            //Contains kiểm tra 1 đối tượng có tồn tại trong 1 tập đối tượng hay không
            NhanVien nv1 = new NhanVien()
            {
                Id = 1,
                MaNV = "Dungna1",
                TenNV = "Dũng",
                Email = "dungna29@gmail.com",
                Sdt = "0912345678",
                DiaChi = null,
                ThanhPho = "HN",
                QueQuan = "HN",
                TrangThai = true
            };
            //Cách không sử contains
            foreach (var x in _lstNhanViens)
            {
                if (x.Id == nv1.Id)//Có bao nhiêu thuộc tính liệt kê vào đây
                {
                    Console.WriteLine("Tìm thấy");
                }
            }

            var SoSanhObj = _lstNhanViens.Contains(nv1, new NhanVien());
            Console.WriteLine("Contains obj: " + SoSanhObj);
        }


        #endregion
        #region 8. Hàm Tổng Hợp Arrgreation - SUM - MIN - MAX - COUNT - AVERAGE

        static void LINQ_HamTongHop()
        {
            //Đếm số lượng nhân viên đang ở HN
            var countNV = _lstNhanViens.Count(c=>c.ThanhPho == "HN");

            //Tìm ra sản phẩm có giá bán lớn nhất
            var spGiaCao = _lsSanPhams.Max(c => c.GiaBan);
            Console.WriteLine("Sản phẩm giá cao nhất: " + spGiaCao);
        }


        #endregion
        #region 9. Firt và FirtOrDefault (Ngoài ra tìm hiểu thêm Last, LastOrDefault, ElementAt,ElementAtOrDefault, Single, SingleOrDefault)

        static void LINQ_Firt_FirtOrDefault()
        {
            //Chỉ trả ra 1 giá trị đầu tiên của 1 tập giá trị
            //First: Trả về phần tử đầu tiền của tập giá trị mà thỏa mãn điều kiện
            //FirstOrrDefault Trả về phần tử đầu tiền của tập giá trị mà thỏa mãn điều kiện còn không thì sẽ trả về mặc định là null.
            List<int> lst = new List<int>() {2, 4, 3, 9, 10};
            Console.WriteLine(lst.FirstOrDefault(c=>c %2 != 0));//=0
            Console.WriteLine(lst.First(c=>c %2 != 0));//Lỗi

            //Tìm từ dưới lên
            Console.WriteLine(lst.LastOrDefault(c => c % 2 != 0));//9

            //SingleOrDefault nếu số lẻ xuaatts hiên hơn 1 lần thì nó sẽ chết
            Console.WriteLine(lst.SingleOrDefault(c => c % 2 != 0));

            Console.WriteLine(lst.ElementAt(11));//Chết vì nằm ngoài index
            Console.WriteLine(lst.ElementAtOrDefault(11));//Sẽ không chết và lấy ra giá trị mặc định
        }


        #endregion
        #region 10. Concat

        static void LINQ_Concat()
        {
            /*
            * Concat dùng để nối 2 chuỗi và trả về 1 tập hợp chuỗi mới
            */
            List<string> lstName1 = new List<string>() { "DŨNG", "NHUNG" };
            List<string> lstName2 = new List<string>() { "HÙNG", "HOÀNG" };

            var lstTemp = lstName1.Concat(lstName2).ToList();
            //Đối với đối tượng cũng làm tương tự miễn là List có cùng kiểu dữ liệu

            List<NhanVien> lstNV1 = new List<NhanVien>
            {
                new NhanVien{Id = 7,MaNV = "Dungna1",TenNV = "Dũng",Email = "dungna29@gmail.com",Sdt = "0912345678",DiaChi = null,ThanhPho = "HN",QueQuan = "HN",TrangThai = true},
                new NhanVien{Id = 9,MaNV = "MinhDq",TenNV = "Minh",Email = "minhdq@gmail.com",Sdt = "0865791529",DiaChi = null,ThanhPho = "HN",QueQuan = "HN",TrangThai = true},
            };
            foreach (var x in lstNV1.Concat(_lstNhanViens))
            {
                x.InRaManHinh();
            }

            var lstTemp3 = _lstNhanViens.Select(c => c.TenNV).Concat(lstNV1.Select(c => c.TenNV));//Trả ra 1 tập tên được cộng bởi 2 list
        }


        #endregion 
        #region 11. Distinct - Trả về 1 tập giá trị không lặp

        static void LINQ_Distinct()
        {
            List<string> lstName1 = new List<string>() { "A", "A","B", "C", };
            List<string> lstName2 = new List<string>() { "D", "E", "A" };
            //Distinct: trả về tập giá trị mới Loại bỏ các phần tử trùng nhau
            foreach (var x in lstName1.Distinct())
            {
                Console.WriteLine(x);//A,B,C
            }

            Console.WriteLine("=========");
            //Except: Tra về 1 tập mới với cả phần từ từ tập đầu tiên không tồn tại trong tập hợp thứ 2.
            foreach (var x in lstName2.Except(lstName1))
            {
                Console.WriteLine(x);
            }
            //Ngoài ra về nhà nghiên cứu cách loại bỏ các đối tượng giống nhau 1 List đối tượng
        }

        //Kiến thức LINQ còn rộng các trong quá trình học thì chịu khó search thêm khi các gặp bài toán.
        #endregion
        #region temp

        static void LINQ_()
        {

        }


        #endregion
    }
}
