using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_2_3_PartialClass
{/*
     * Trong C# nó cho phép bạn khai báo một lớp (class), giao diện (interface), cấu trúc (struct) trong thân một lớp khác - chúng được gọi là kiểu lồng nhau (Nested Type)
     */
    internal class ClassNested
    {
        public class classD
        {
            public int Variable1 { get; set; }

            public classD()
            {
                
            }

            public classD(int variable1)
            {
                Variable1 = variable1;
            }

            public void Method1(){}

        }

    }
}
