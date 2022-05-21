using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_1_4_DELEGATE_EVENT2
{
    internal class Program
    {
        public delegate void SuKienNhap2So(int x,int y);

        class NguoiDung
        {
            public event SuKienNhap2So suKienNhapSo;

            public void NhapSo()
            {
                Console.WriteLine("Moi nhap so a: ");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Moi nhap so b: ");
                int b = Convert.ToInt32(Console.ReadLine());
                suKienNhapSo.Invoke(a,b);
            }
        }

        class TinhToan
        {
            public void ThiHanh(NguoiDung nd)
            {
                nd.suKienNhapSo += TinhTong;
            }
            
            private void TinhTong(int x, int y)
            {
                Console.WriteLine($"{x} + {y} = {x+y}");
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
