using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BAI_3_0_LINQ
{
    internal class Program
    {
        #region LINQ là gì
        /*
       *  LINQ: Language Integrated Query
       *  Định nghĩa:  ngôn ngữ truy vấn tích hợp - nó tích hợp cú pháp truy vấn (gần giống các câu lệnh SQL) vào bên trong ngôn ngữ lập trình C#, cho nó khả năng truy cập các nguồn dữ liệu khác nhau (SQL Db, XML, List ...) với cùng cú pháp.
       * Ưu điểm:
       * ➢Ưu điểm lớn nhất của Linq đó chính là sự mạch lạc trong code, xậy dựng nhanh, ít gây lỗi
         ➢Linq cung cấp nhiều phương thức trong truy vấn dữ liệu, nếu cùng một chức năng, khi sử dụng truy vẫn thuần có thể phải code nhiều gấp 2, 3 lần khi sử dụng linq (tùy ứng dụng)
         ➢Cách tiếp cận khai báo giúp truy vấn dễ hiểu và gọn hơn
       * Nhược điểm:
       *➢Tốc độ chậm nếu viết linq không khéo
          Linq query systax:
                              from object in datasource
                              where condition
                              select object
          from: Từ nguồn dữ liệu mà truy vấn sẽ thực hiện
          in: bên trong nguồi giá trị nào
          datasource: tập giá trị nguồn
          where: lọc dữ liệu theo điều kiện condition
          select object: Lấy ra kết quả có thể là giá trị hoặc tập giá trị
          Ngoài ra chúng ta cũng thấy việc áp dụng lambda cơ bản với những câu lọc dữ liệu ngắn sẽ đơn giản nhưng khi join vào nhiều datasource sẽ không dễ đọc với người chưa có kinh nghiệm
       */


        #endregion
        static void Main(string[] args)
        {
            string[] arrName = { "Hoa", "Trang", "Dũng", "Long", "Mạnh", "Hoàng", "Tùng", "Lan" };
            List<int> arrNumber = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
            //Ví dụ 1: Lấy ra nhuwxng người có tên bắt đầu bằng chữ L
            foreach (var x in arrName)
            {
                if (x.StartsWith("L"))
                {
                    Console.WriteLine(x);
                }
            }
            /*
             * IEnumerable: là 1 mảng và nó chỉ có thể đọc và không thể thêm hay bớt phần tử đi. Chỉ duyệt phần tử theo 1 chiều từ đầu đến cuối
             */
            var lst1 =
                from a in arrName
                where a.StartsWith("L")
                select a;
            foreach (var x in arrName.ToList().Where(c=>c.StartsWith("L")))
            {
                Console.WriteLine(x);
            }
            //Ví dụ 2: Truy vấn lấy ra các số chẵn ở listNumber ở trên
            var lst2 =
                from b in arrNumber
                where b % 2 == 0
                select b;

            foreach (var x in arrNumber.ToList().Where(c => c % 2 == 0))
            {
                Console.WriteLine(x);
            }

            var lst3 =
                from b in arrNumber
                where b % 2 == 0
                orderby b descending //ascending và descending và lưu ý mặc định không điền thì luôn là asc
                select b;
        }
    }
}
