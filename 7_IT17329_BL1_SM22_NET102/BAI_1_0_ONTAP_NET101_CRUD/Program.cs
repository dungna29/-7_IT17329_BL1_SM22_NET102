using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_1_0_ONTAP_NET101_CRUD
{
    internal class Program
    {
        /*
         * CRUD Meo
         */
        static void Main(string[] args)
        {
           MeoService ms = new MeoService();
           string input;
           do
           {
               Console.WriteLine("1. Thêm");
               Console.WriteLine("2. Sửa");
               Console.WriteLine("3. Xóa");
               Console.WriteLine("4. Tìm kiếm");
               Console.WriteLine("5. Xuất ds");
               Console.WriteLine("6. Thoát");
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
                    default:
                        break;
               }
           } while (input != "6");
        }
    }
}
