using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_2_4_IMPLICITLY_VA_DYNAMIC_TYPE
{
    internal class Program
    {
        /*
       * Phần 1: Implicitly,Dynamic
       *          1.1 Implicitly (KIỀU NGẦM ĐỊNH):
       *             ❑Khai báo biến kiểu ngầm định (khai báo không tường minh) là biến được khai báo mà không cần phải chỉ ra kiểu dữ liệu
                     ❑Kiểu dữ liệu của biến sẽ được xác định bởi trình biên dịch dựa vào biểu thức được gán khi khai báo biến
                     ❑Sử dụng từ khóa “var” khi khai báo và cần khởi tạo giá trị
                  1.2 Công thức:
                      var varialble_name = value;
                  1.3 Hạn chế:
                     + Không thể sử dụng từ khóa var bên ngoài phạm vi của một method
                     + Không thể khởi tạo giá trị là null.
                     + Biến phải được khởi tạo giá trị khi nó được khai báo 
                     + Nếu biến được gán giá trị, thì kiểu dữ liệu phải giống        nhau
                     + Giá trị khởi tạo phải là một biểu thức. Giá trị khởi tạo     không được là một đối tượng hay tập hợp các giá trị. Nhưng nó có thể sử dụng toán tử new bởi một đối tượng hoặc tập hợp các giá trị.
                  2.1 Dynamic
                      Kiểu động - ngầm định - khai báo với từ khóa dynamic, thì kiểu thực sự của biến đó được xác định bằng đối tượng gán vào ở thời điểm chạy (khác với kiểu ngầm định var kiểu xác định ngay        thời điểm biên dịch)
       */
        /*
         * VAR không thể khai báo làm biến toàn cục
         */
        static void Main(string[] args)
        {
            #region Phần 1: Implicitly - Định kiểu ngay khi code

            //1. Khái báo:
            var temp1 = 1;//Implicitly
            var temp2 = new int[5];//Implicitly
            var temp3 = "112222";//Implicitly

            int temp4 = 2022;//Explicitly - Tường minh

            //2. Hạn chế:
            //var temp5 = null;// Không thể gán null khi khởi tạo
            //var temp5;//Khi khởi tạo var bắt buộc phải khởi tạo giá trị
            var temp5 = "a";
            //temp5 = 1; Khi khởi tạo giá trị có kiểu dữ liệu cho var thì biến đó sẽ chỉ nhận kiểu dữ liệu đó.
            //Không thể khai báo làm biến toàn cục và cũng không thể dùng nó làm tham số truyền vào của 1 phương thức

            //Giá trị khởi tạo phải là 1 biểu thức. Giá trị khởi tạo không được là 1 đối tượng hay tập giá trị. Nó có thể sử đụng toán tử new bởi 1 đối tượng hoặc tập giá trị khác

            //var arr = {5, 6, 7};
            var arr = new int[] {5, 6, 7};
            var lstString = new List<string>() {"Name", "Name"};

            #endregion

            #region Phần 2: Dynamic - Định kiểu khi biên dịch code
            //1. Khai báo: Các kiểu dữ liệu rồi giá trị tương tự như var
            dynamic d1;
            d1 = 1;
            d1 = "";
            //Khai báo nặc danh
            var SinhVien = new
            {
                Msv = "PH123456",
                Ten = "C#1",
                NganhHoc = "UDPM .NET"
            };

            Method2(SinhVien,SinhVien.NganhHoc);
            #endregion
        }

        private dynamic temp13;

        static void Method2(dynamic temp1, dynamic temp2)
        {
            Console.WriteLine(temp1.Ten + " " + temp2);
        }

        // static void Method1(var temp)
        // {
        //
        // }

    }
}
