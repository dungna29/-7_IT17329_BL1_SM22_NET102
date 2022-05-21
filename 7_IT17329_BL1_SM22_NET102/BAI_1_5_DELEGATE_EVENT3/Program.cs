using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_1_5_DELEGATE_EVENT3
{
    internal class Program
    {
        /*
    * Ngoài ra trong C# có sẵn chuẩn tạo ra sẵn sự kiện Delegate
    */
        class NguoiDung
        {
            public event EventHandler suKienNhapSo;//Tương đương delegate void ten(object sender, EventArgs e)

            public void NhapSo()
            {
                Console.WriteLine("Moi nhap so a: ");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Moi nhap so b: ");
                int b = Convert.ToInt32(Console.ReadLine());
                suKienNhapSo.Invoke(this, new NguoiDung1(a,b));
            }
        }

        class NguoiDung1:EventArgs
        {
            public int a { get; set; }
            public int b { get; set; }

            public NguoiDung1(int a, int b)
            {
                this.a = a;
                this.b = b;
            }
        }
        class TinhToan
        {
            public void ThiHanh(NguoiDung nd)
            {
                nd.suKienNhapSo += TinhTong;
            }

            private void TinhTong(object sender, EventArgs e)
            {
                NguoiDung1 nd = (NguoiDung1) e;
                Console.WriteLine($"{nd.a} + {nd.b} = {nd.a + nd.b}");
            }
        }
        static void Main(string[] args)
        {
            //Phát đi sự kiện
            NguoiDung nd = new NguoiDung();

            //Nhận sự kiện
            TinhToan tt = new TinhToan();
            tt.ThiHanh(nd);

            //Thực thi
            nd.NhapSo();
        }
    }
}
