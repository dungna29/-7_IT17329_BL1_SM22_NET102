using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_2_1_CLASS_GENERIC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding("UTF-8");
            /*
             * Ví dụ 1: Sử dụng Class Generic
             */
            ClassGeneric<double> ClassGenericdouble = new ClassGeneric<double>();
            ClassGenericdouble.Temp = 6.9;
            Console.WriteLine(ClassGenericdouble.Temp);
            /*
            * Ví dụ 2: Triển khai 1 đối tượng có 1 thuộc tính là mảng chưa xác kiểu dữ liệu
            * 1. Khai báo 1 mảng
            * 2. Nhập giá trị
            * 3. In tất cả phần tử trong mảng
            */
            Console.WriteLine("Mời bạn nhập số lượng phần tử: ");
            int size = Convert.ToInt32(Console.ReadLine());
            ArrayGeneric<string> ag = new ArrayGeneric<string>(size);
            for (int i = 0; i < ag.Array.Length; i++)
            {
                Console.Write($"Mời bạn nhập phần tử thứ {i}:");
                ag.AddArr(i,Console.ReadLine());
            }

            Console.WriteLine();
            for (int i = 0; i < ag.Array.Length; i++)
            {
                Console.Write(ag.GetValue(i) + " ");
            }
        }
    }
}
