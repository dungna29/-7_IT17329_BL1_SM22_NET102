using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_2_0_GENERIC
{
    internal class Program
    {
        #region Tham trị và Tham chiếu
        /*
         * Có hai hình thức truyền tham số cho phương thức khi nó được gọi là tham trị và tham chiếu:    
            + Tham trị là cách thức mặc định khi tham số đó là kiểu giá trị. Có nghĩa là gán tham số bằng một biến, thì giá trị của biến được copy và sử dụng trong phương thức như biến cục bộ, còn bản thân biến bên ngoài không hề ảnh hưởng.
            + Tham chiếu là cách thức mặc định khi tham số đó là kiểu tham chiếu, thì bản thân biến ở tham số sẽ được hàm sử dụng trực tiếp (tham chiếu) chứ không tạo ra một biến cục bộ trong hàm, nên nó có tác động trực tiếp đến biến này bên ngoài.
                - Trong phần này mở rộng thêm, nếu muốn biến kiểu giá trị nhưng được truyền vào phương thức dạng tham chiếu (giống cách thức biến tham chiếu) thì khai báo tham số ở phương thức, cũng như khi gọi cần cho thêm từ khóa ref
         */
        #endregion
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding("UTF-8");
            int x = 9, y = 11;
            Console.WriteLine($"x = {x} | y = {y}");
            HoanViThamTri(x, y);
            Console.WriteLine($"HoanViThamTri: x = {x} | y = {y}");
            HoanViThamChieu(ref x, ref y);
            Console.WriteLine($"HoanViThamChieu: x = {x} | y = {y}");

            double x1 = 99.9, x2 = 33.2;
            HoanViThamTri_GENERIC(x1, x2);
            string x3 ="A", x4 = "B";
            HoanViThamTri_GENERIC(x3, x4);

        }
        /* ❑ Generic trong C# cho phép định nghĩa một phương thức,một lớp mà không cần chỉ ra đối số kiểu dữ liệu là gì.
        ❑ Generic cũng là một kiểu dữ liệu trong C# như int, string, bool,… nhưng nó là một kiểu dữ liệu “tự do”, tùy vào mục đích sử dụng mà nó có thể đại diện cho tất cả các kiểu dữ liệu còn lại.
        ❑ Có thể định nghĩa lớp, interface, phương thức, delegate như là kiểu generic
        */
        static void HoanViThamTri_GENERIC<T>(T a, T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        static void HoanViThamTri(int a, int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        static void HoanViThamChieu(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
