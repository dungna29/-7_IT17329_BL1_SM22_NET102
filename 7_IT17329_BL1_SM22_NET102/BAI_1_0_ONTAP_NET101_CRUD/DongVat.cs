using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_1_0_ONTAP_NET101_CRUD
{
    /*
     * Lớp cha
     * Lớp abstract thì bắt buộc phải có phương thức abstract
     */
    internal abstract class DongVat
    {
        //Phần 1: Khai báo các property mà đối tượng cần phải có
        //prop + tab
        public int Id { get; set; }
        public string Ten { get; set; }
        public double CanNang { get; set; }
        public int GioiTinh { get; set; }
        //Phần 2: 2 Contructor khi mới học
        public DongVat()
        {

        }
        //Alt + Enter => Gen....Contructor
        public DongVat(int id, string ten, double canNang, int gioiTinh)
        {
            Id = id;
            Ten = ten;
            CanNang = canNang;
            GioiTinh = gioiTinh;
        }
        //Phần 3: Các phương thức
        public virtual void Method1(int a)
        {

        }
        public virtual void Method2(int a, int b)
        {

        }
        private void Method3(int a, int b)
        {

        }
        //Phương thức abstract không có body code
        public abstract void InRaManHinh();

        /*Tính đa hình
         * 1. Overloading (Nạp chồng phương thức): Phương thức trùng tên nhưng phải khác tham số. Khi sử dụng để gọi đúng phương thức phải truyền đủ số lượng tham số và kiểu dữ liệu.
           2. Overriding (Ghi đè phương thức): Nhớ đến kế thừa,Lớp con ghi đè lại phương thức của lớp cha và lưu ý khi ghi đè bắt buộc phương thức tại lớp con phải giống tuyệt đối.
         */
    }
}
