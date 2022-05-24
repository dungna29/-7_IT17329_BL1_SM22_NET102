using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_1_8_DINH_NGHIA_CLASS_EXCEPTION
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding("UTF-8");
            try
            {
                CheckTuoiHocFPOLY("FPOLY", 17);
            }
            catch (CheckTruong_Exception e)
            {
                Console.WriteLine(e.Message);
            }
            catch (CheckTuoi_Exception e)
            {
                Console.WriteLine(e.Message);
                e.ThongBaoLoi();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void CheckTuoiHocFPOLY(string TruongDK, int tuoi)
        {
            if (TruongDK != "FPOLY")
            {
                CheckTruong_Exception exception = new CheckTruong_Exception("Bạn không thể đăng ký trường FPOLY");
                throw exception;
            }

            if (tuoi < 18)
            {
                throw new CheckTuoi_Exception("CheckTuoi_Exception: ", tuoi);
            }

            Console.WriteLine("Đăng ký nhập học thành công");
        }
    }
}
