using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_1_2_DELEGATE_ACTION_FUNC_PREDICATE
{
    internal class Program
    {
        #region  Bài Action, Predicate, Func: Delegate - Generic(Sử dụng sẵn tham số Generic để khai báo)
        /*
         Thay vì chúng ta phải khai báo định nghĩa trước delegate thì chúng ta sẽ sử dụng 3 kiểu dưới đây khai báo cho nhanh.
          Action, Predicate, Func (Viết tắt là APF là cho nhanh) trong C#
            + Action: Action<T in1, T in2, …>. Action tương đương 1 delegate với kiểu trả về là void, với in1, in2 là các params nhận vào.
            + Predicate: Predicate<T in>. Predicate tương đương 1 delegate với kiểu trả về là bool, với in là các param nhận vào. Predicate chỉ có thể nhận vào 1 param duy nhất.
            + Func: Func<T in1, T in2, … , T result>. Function tương đương 1 delegate với kiểu trả về do ta khai báo (result), in1, in2 là các params nhận vào. Func bắt buộc phải trả ra giá trị, không thể trả void.
            Bảng so sánh cách khai báo bằng delegate cùng với cách khai báo tương ứng bằng Action, Predicate, Func:
            delegate void VoidDelegate(int input1, bool input2)	- Action<int, bool>	
            
            delegate bool BoolDelegate(int input1)	-  Predicate<int>	|| Func<int, bool>
            delegate int intDelegate(bool input2)	- Func<bool, int>
            
            delegate void HelloWorldDelegate()	- Action
            delegate bool HelloWorldBoolDelegate()	- Predicate -  Func<bool>
        */
        #endregion      
        public static void ThongTin1(string noidung)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ThongTin1: " + noidung);
            Console.ResetColor();
        }
        public static void ThongTin2(string noidung)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ThongTin2: " + noidung);
            Console.ResetColor();
        }
        public static void ThongTin3(string noidung,int a)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ThongTin3: " + noidung);
            Console.ResetColor();
        }

        public static double PhepChia(int a,int b)
        {
            return a / b;
        }

        public static bool CheckVietHoa(string name)//dung
        {
            return name.Equals(name.ToUpper());//dung == DUNG
        }
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.GetEncoding("UTF-8");

            #region Phần 1: Action - Chỉ đi với void

            Action action;//Tương đương delegate void tenDelegate();
            Action<string> action2;//Tương đương delegate void tendelegate(string a);
            Action<string, int> action3;//Tương đương delegate void tenDelegate(string a, int b)
            Action<string,string,string,int> action4;//Tương đương delegate void tenDelegate(string a, string b, string c, int d);
            //action = ThongTin1;
            action2 = ThongTin1;
            action2("Action");
            action2?.Invoke("action 2");
            #endregion

            #region Phần 2: Predicate - Chỉ đi với phương thức trả về kiểu bool

            Predicate<string> predicate;//Tương đương delegate bool tendelegate(string a);
            predicate = CheckVietHoa;
            Console.WriteLine("Chữ dung truyền vào có viết hoa: "+predicate.Invoke("dung"));

            #endregion

            #region Phần 3: Func - Chỉ đi với tất cả các phương thức trả về
            //Tham số cuối cùng chính là kiểu trả về của phương thức
            Func<int, int, double> func1;//Tương đương delegate double tenDelegate(int a,int b);
            func1 = PhepChia;
            Func<int, int, double, string> func2;


            #endregion
            /*
            * Bài tập ví dụ:
            * Viết 4 phương thức để gán được cho các delegate dưới đây
            * Func<double,double,string,int> funcbt1;
            * Predicate<string,string,bool> predbt2;
            * Action<string,int,double> actionbt3;
            * Func<int,string,string> funcbt4;
             * Action action2;
            */
            Action action8;
            action8 = method1;
        }

        static void method1()
        {

        }
    }
}
