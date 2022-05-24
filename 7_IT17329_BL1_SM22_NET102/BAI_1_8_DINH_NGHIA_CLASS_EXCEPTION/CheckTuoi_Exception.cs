using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_1_8_DINH_NGHIA_CLASS_EXCEPTION
{
    internal class CheckTuoi_Exception:Exception
    {
        public int Age { get; set; }

        public CheckTuoi_Exception(string message, int age) : base(message)
        {
            Age = age;
        }

        public void ThongBaoLoi()
        {
            Console.WriteLine($"Tuổi {Age} của bạn chưa thể đăng ký nhập học ngành PTPM FPOLY. Đợi đến 18 tuổi nhé");

        }
    }
}
