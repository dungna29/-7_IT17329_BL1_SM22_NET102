using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_1_3_DELEGATE_EVENT
{
    internal class Program
    {
        /*
      * ❑Sự kiện (Event) là các hành động, ví dụ như nhấn phím, click, di chuyển chuột...
        ❑Trong C#, Event là một đối tượng đặc biệt của  Delegate, nó là nơi chứa các phương thức, các phương thức này sẽ được thực thi khi sự kiện xảy ra
        ❑Đặc điểm của event:
            ❖Được khai báo trong các lớp hoặc interface
            ❖Được khai báo là abstract hoặc sealed, virtual
            ❖Được thực thi thông qua delegate
        ❑Tạo và sử dụng event
            ❖Đinh nghĩa delegate cho event
            ❖Tạo event thông qua delegate
            ❖Đăng ký để lắng nghe và xử lý event
            ❖Kích hoạt event
      */
        //Bước 1: Tạo 1 delegate
        delegate void UpdateName(string name);
        //Bước 2: Tạo class
        class SinhVien
        {
            public event UpdateName nameChange;
            private string name;

            public string Name
            {
                get => name;
                set
                {
                    name = value;
                    //Kiểm tra để gọi ra sự kiện mong muốn khi tên bị tác động giá trị
                    if (nameChange !=null)
                    {
                        nameChange(name);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding("UTF-8");
            SinhVien sv = new SinhVien();
            sv.nameChange += Sv_nameChange;//Gõ += và tab sẽ zen ra 1 phương thức sự kiện
            sv.Name = "dungna";
            Console.WriteLine("Tên mới: "+ sv.Name); 
            sv.Name = "C#2";
            Console.WriteLine("Tên mới: "+ sv.Name);
        }

        private static void Sv_nameChange(string name)
        {
            Console.WriteLine("Thông báo giá trị mới của name: " + name);
        }
    }
}
