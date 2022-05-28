using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_2_3_PartialClass
{
    partial class ClassA// Class A đang nằm thêm cả trên File Class B
    {
        public int Variable3 { get; set; }
        public string Variable4 { get; set; }

        public void Method3()
        {
            Console.WriteLine("Đây là method");
        }
        partial void Method2(string a)
        {
            Console.WriteLine("Đây là method2");
        }
    }
}
