using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_2_3_PartialClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Phần 1:  Sử dụng PartialClass
             * Khi sử dụng đối tượng ClassA hoàn toàn bình thường như các class đã được học chỉ khác nó được tách thành 2 file.
             */
            ClassA cla = new ClassA();
            cla.Variable1 = 1;
            cla.Variable3 = 2;
            cla.Method1();
            cla.Method3();
            /*
             * Phần 2: Sử dụng Class lồng nhau Nested
             ** Lớp Nested được khai báo, định nghĩa trong lớp Container, nếu phạm vị lớp public, thì bên ngoài sử dụng lớp con này bằng cách chỉ rõ Container.Nested
             */
            ClassNested.classD classD = new ClassNested.classD();
            classD.Variable1 = 1;
            classD.Method1();
        }
    }
}
