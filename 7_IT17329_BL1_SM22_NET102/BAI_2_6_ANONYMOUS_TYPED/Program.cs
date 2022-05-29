using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BAI_2_6_ANONYMOUS_TYPED
{
    internal class Program
    {

        #region ANONYMOUS TYPED
        /*
         * Phần 1:  Định nghĩa:
             * ❑Kiểu ẩn danh (Anonymous Type) cung cấp một cách thuận tiện để đóng gói (encapsulate) một tập các thuộc tính chỉ đọc (read-only properties) vào một đối tượng mà không cần phải xác định rõ ràng loại (type) của nó ngay lúc viết code
             * ❑Cho phép tạo type mới (user-defined) mà không cần xác định tên của nó
               ❑Tạo các type ẩn danh này bằng cách sử dụng toán tử new
           Phần 2: ANONYMOUS METHOD
            ❑Phương thức vô danh (anonymous method) là một phương thức:
               ❖Không cần khai báo tên phương thức khi định nghĩa phương thức
               ❖Có thể khai báo trực tiếp ở chỗ cần dùng, không cần định nghĩa trước
               ❖Đươc dùng như tham số của delegate
            ❑Một số giới hạn Anonymous methods
                ❖Không khái báo được các lệnh goto, break or continue bên trong phương thức
                ❖Không truy cập được các tham số ref hoặc out bên ngoài
                ❖Phải được dùng kết hợp với delegate
         */
        #endregion
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding("UTF-8");
            /*
             * Phần 1: Khai báo Anonymous và Anonymous lồng nhau
             */
            var SinhVienUDPM = new
            {
                ID = 1,
                MSV = "PH00533",
                Lop = "IT17329",
            };
            Console.WriteLine($"{SinhVienUDPM.ID} {SinhVienUDPM.MSV} {SinhVienUDPM.Lop}");
            var SinhVienUDPM1 = new
            {
                ID = 1,
                MSV = "PH00533",
                Lop = "IT17329",
                DiaChi = new
                {
                    SoNha = 22,
                    Duong = "Trịnh Văn Bô"
                }
            };
            Console.WriteLine($"{SinhVienUDPM1.ID} {SinhVienUDPM1.MSV} {SinhVienUDPM1.Lop} {SinhVienUDPM1.DiaChi.SoNha}");
            /*
             * Phần 2: Phương thức nặc danh
             */
            //Method1 = Nhẽ ra phải gán delegate này cho 1 phương thức tương ứng.
            Method1 method1 = delegate(int i)
            {
                //Có thể gọi các biến cục bụ bên ngoài thức nặc danh này
                Console.WriteLine("Đây là phức nặc danh, Giá trị: " + i);
            };
            Method1 method2 = new Method1(method1);
            method2 += method1;

            method2(2022);//Thực thi phương thức
        }

        public delegate void Method1(int a);
    }
}
