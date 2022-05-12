using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_1_0_ONTAP_NET101_CRUD
{
    /*
     * Trong C# và JAVA chỉ có đơn kế thừa.
     * Khi lớp con kế thừa lớp cha là abstract thì bắt buộc phải ghi đè tất cả các phương thức abstract
     */
    internal class Meo:DongVat
    {
        public string SoThich { get; set; }

        public Meo()
        {
            
        }

        public Meo(int id, string ten, double canNang, int gioiTinh, string SoThich1) : base(id, ten, canNang, gioiTinh)
        {
            SoThich = SoThich1;
            //this: Dùng để tham chiếu đến thuộc tính và phương thức của lớp hiện tại
            //base:Dùng để tham chiếu đến thuộc tính và phương thức của lớp cha
        }
        //Phần 3: Phương thức đối tượng
        //Muốn kế thừa phương thức của lớp cha
        //1. Chuột phải vào tên Class Con ở trên -> Quick Actions
        //2. Generate Overrides sau đó chọn phương thức các bạn muốn kế thừa
        //3. Khi kế thừa lại phương thức của lớp cha thì phương thức đặt tại lớp con có thể code lại nội dung bên trong thì hành động này gọi là ghi đè phương thức.
        public override void Method1(int a)
        {
            base.Method1(a);
        }

        public override void InRaManHinh()
        {
            Console.WriteLine($"{Id} {Ten} {(GioiTinh == 1?"Đực":"Cái")} {CanNang} {SoThich}");
        }
    }
}
