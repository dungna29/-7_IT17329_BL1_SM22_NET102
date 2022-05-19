using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_1_1_DELEGATE
{
    internal class Program
    {
        #region Định nghĩa Delegate 
        /*
      * Định nghĩa:
          * ❑Delegate là một biến chứa tham chiếu đến phương thức cần thực thi.
            ❑Một delegate có thể trỏ tới một hoặc nhiều phương thức
            ❑Delegate có thể gọi bất kỳ phương thức nào nó trỏ tới tại thời điểm thực thi
            ❑
      * + Có thể khai báo trong namespace hoặc khai báo trong class
      * + Khi khai báo giống như khai báo một phương thức
      * + Công thức:
      *      <phạm vi truy cập> delegate <kiểu phương thức> <tên>(<Tham số>); 
      */


        #endregion
        //Khai báo delegate
        public delegate void ThongBao(string msg);

        public static void ThongTin1(string noidung)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ThongTin1: " + noidung);
            Console.ResetColor();
        }
        public static void ThongTin2(string noidung)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ThongTin1: " + noidung);
            Console.ResetColor();
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding("UTF-8");

            #region Phần 1: Khởi tạo delegate null

            Console.WriteLine("===Phần 1: Khởi tạo delegate null===");
            ThongBao thongBao = null;//Khai báo delegate và tên biến gán giá trị null
            thongBao = ThongTin1;//Gán phương thức cho delegate và delegate sẽ trỏ đến phương thức đó.
            thongBao?.Invoke("Chào các bạn đến với delagate");//? Dùng để kiểm tra xem delegate có null hay không nếu không thì sẽ thực thi.

            #endregion

            #region Phần 2: Khởi tạo delegate
            Console.WriteLine("===Phần 2: Khởi tạo delegate===");
            ThongBao thongBao1 = new ThongBao(ThongTin2);
            thongBao1("Môn C#2");
            #endregion

            #region Phần 3:  Multicast Delegate
            Console.WriteLine("===Phần 3:  Multicast Delegatee===");
            ThongBao thongBao2 = new ThongBao(ThongTin1);
            ThongBao thongBao3 = new ThongBao(ThongTin2);
            ThongBao Multicast = thongBao2 + thongBao3;
            Multicast -= thongBao3;
            Multicast += thongBao3;
            Multicast += thongBao3;
            Multicast += thongBao3;
            Multicast("multicast");
            #endregion

            #region Phần 4: Delegate CallBack
            Console.WriteLine("===Phần 4: Delegate CallBack===");
            DelegateCallBack dcb = new DelegateCallBack(ThongTin3);
            CallBack(dcb);

            #endregion
        }
        #region Phần 4: Delegate CallBack

        public delegate void DelegateCallBack(int a);

        public static void ThongTin3(int temp)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("ThongTin3: " + temp);
            Console.ResetColor();
        }

        public static void CallBack(DelegateCallBack delegateCallBack)
        {
            Console.WriteLine("Mời bạn nhập số nguyên: ");
            int so = Convert.ToInt32(Console.ReadLine());
            delegateCallBack(so);
        }

        #endregion
    }
}
