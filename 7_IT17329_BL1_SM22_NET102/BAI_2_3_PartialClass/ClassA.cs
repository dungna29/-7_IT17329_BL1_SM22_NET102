using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_2_3_PartialClass
{
    internal partial class ClassA
    {
        public int Variable1 { get; set; }
        public string Variable2 { get; set; }

        public void Method1()
        {
            Console.WriteLine("Đây là method1");
        }
        /*
         * Phương thức partial khai báo, không có body code
         * Bạn có thể dùng từ khóa partial trong khai báo các phương thức, tuy nhiên mục đích chỉ để chia làm 2 nơi, Một nơi làm khai báo và một nơi triển khai.
         */
         partial void Method2(string a);

        public void method9()
        {

        }
    }
}
