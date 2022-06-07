using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_2_8_DocGhiDoiTuong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding("UTF-8");

            MeoService ms = new MeoService();
            string input;
            do
            {
                Console.WriteLine("1. Thêm");
                Console.WriteLine("2. Sửa");
                Console.WriteLine("3. Xóa");
                Console.WriteLine("4. Tìm kiếm");
                Console.WriteLine("5. Xuất ds");
                Console.WriteLine("6. Lưu File");
                Console.WriteLine("7. Đọc File");
                Console.WriteLine("8. Thoát");
                Console.WriteLine("Mời chọn: ");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ms.Them1();
                        break;
                    case "2":
                        ms.Sua();
                        break;
                    case "3":
                        ms.Xoa();
                        break;
                    case "4":
                        ms.TimKiem();
                        break;
                    case "5":
                        ms.InDs();
                        break;
                    case "6":
                        ms.LuuFile();
                        break;
                    case "7":
                        ms.DocFile();
                        break;
                    default:
                        break;
                }
            } while (input != "8");
        }
    }
}
