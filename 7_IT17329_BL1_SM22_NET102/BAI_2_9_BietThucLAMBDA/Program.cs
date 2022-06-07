using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_2_9_BietThucLAMBDA
{
    internal class Program
    {
        /*
      * Biểu thức lambda còn gọi là biểu thức (Anonymous), một biểu thức khai báo giống phương thức nhưng thiếu tên. Cú pháp để khai báo biểu thức lambda là sử dụng toán dử => như sau:
         Công thức 1:
             (tham_số) => biểu_thức;
         Công thức 2:
         (tham_số) =>
             {
                các câu lệnh
                Sử dụng return nếu có giá trị trả về
             }            
        */

        //Ví dụ 1: Sử dụng Delegate với lambda
        delegate int PhepTinh(int a, int b);

        public static int PhepTinhNhan(int a, int b)
        {
            return a*b;
        }
        public static void Vidu1()
        {
            int x = 8, y = 5;
            PhepTinh pn = PhepTinhNhan;

            //Áp dụng lambda vào thì không cần phải khai báo bên ngoài có thể triển khai nhanh bên trong phương thức
            //Cách 1:
            PhepTinh pn2 = (int a, int b) =>
            {
                return a * b;
            };
            //Cách 2:
            PhepTinh pn3 = (int a, int b) => a * b;
            ;
            Console.WriteLine(pn2(x,y));
        }
        //Ví dụ 2:
        public int PhepCong3So(int a, int b, int c) => a + b + c;
        
        //Ví dụ 3:
        public void ViDu3()
        {
            int[] arrNumbers = {1, 2, 3, 4, 5, 6};
            //Cách làm foreach
            foreach (var x in arrNumbers)
            {
                Console.WriteLine(x);
            }

            //Cách 1:
            Array.ForEach(arrNumbers, delegate(int x){ Console.WriteLine(x); });

            //Cách 2:
            Array.ForEach(arrNumbers, x=> Console.WriteLine(x));

            //Cách 3:
            foreach (var x in arrNumbers) Console.WriteLine(x);
           
        }
        #region Một số quy tắc khi sử dụng lambda
        delegate void ChaoBan1(string name);
        delegate void ChaoBan2();
        delegate void ChaoBan3(string name1, string name2, string name3);
        delegate int TinhToan(int a, int b);
        delegate bool Check1(int a, int b);

        static void ViDu4()
        {
            //1. Không quan tâm đến kiểu dữ liệu đầu vào
            ChaoBan1 chao1 = (string temp) => { Console.WriteLine("Chào bạn " + temp); };
            ChaoBan1 chao2 = (temp) => { Console.WriteLine("Chào bạn " + temp); };

            //2. Để trống nếu không có tham số ()
            ChaoBan2 chao3 = () => { Console.WriteLine("Chào bạn"); };

            //3. Nếu chỉ có một tham số bỏ luôn dấu ()
            ChaoBan1 chao4 = temp => { Console.WriteLine("Chào bạn " + temp); };

            //4. Nếu có nhiều tham số ngăn cách bằng dấu ,
            ChaoBan3 chao5 = (x, y, z) => { Console.WriteLine("Chào" + x + y + z); };

            //5. Nếu phương thức chỉ có 1 câu lệnh thực thi bỏ dấu {}
            ChaoBan3 chao6 = (x, y, z) => Console.WriteLine("Chào" + x + y + z);

            //6. Đối với phương thức return
            TinhToan tinhToan = (x, y) => { return x + y; };
            Check1 check1 = (x, y) => { return x > 10 && y < 20; };
        }
        //Ngoài ra các bạn mở rộng kiến thức bằng cách search nhiều
        #endregion
        static void Main(string[] args)
        {
        }
    }
}
