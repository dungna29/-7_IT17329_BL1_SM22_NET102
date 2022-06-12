using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BAI_3_2_BieuThucChinhQuy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            Console.OutputEncoding = Encoding.GetEncoding("UTF-8");
            Console.Write("Mời bạn nhập gmail: ");
            input = Console.ReadLine();
            while (!CheckGmail(input))
            {
                Console.WriteLine("Bạn không biết đọc chữ à.");
                Console.Write("Mời bạn nhập gmail: ");
                input = Console.ReadLine();
            }

            Console.WriteLine("Kết thúc chương trình");
        }

        public static bool CheckSo(string text)
        {
            //return Regex.IsMatch(text, "^[0-9]*$");
            return Regex.IsMatch(text, "\\d+$");//nếu là số nguyên sẽ return true
        }
        public static bool CheckChu(string text)
        {
            return Regex.IsMatch(text, "^[a-zA-Z]+");
            //return Regex.IsMatch(text, "\\w+");//bao gồm cả chữ số lẫn chữ cái
        } public static bool CheckGmail(string text)
        {
            return Regex.IsMatch(text, "^[a-z0-9](\\.?[a-z0-9]){5,}@g(oogle)?mail\\.com$");
            //return Regex.IsMatch(text, "\\w+");//bao gồm cả chữ số lẫn chữ cái
        }
    }
}
