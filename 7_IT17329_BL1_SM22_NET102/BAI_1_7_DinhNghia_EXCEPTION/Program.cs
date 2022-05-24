using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_1_7_DinhNghia_EXCEPTION
{
    internal class Program
    {
        #region Tự định nghĩa ra 1 Exception trong 1 phương thức

        static void CheckTuoiHocFPOLY(string TruongDK,int tuoi)
        {
            if (TruongDK != "FPOLY")
            {
                Exception exception = new Exception("Bạn không thể đăng ký trường FPOLY");
                throw exception;
            }

            if (tuoi < 18)
            {
                throw new Exception("Bạn chưa đủ tuổi để nhập học");
            }

            Console.WriteLine("Đăng ký nhập học thành công");
        }

        #endregion
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding("UTF-8");
            try
            {
                CheckTuoiHocFPOLY("FPOLY",19);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
               
            }

        }


    }
}
