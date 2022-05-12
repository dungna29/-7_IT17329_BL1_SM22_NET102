using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_1_0_ONTAP_NET101_CRUD
{
    //Code các chức năng
    internal class MeoService
    {
        private List<Meo> _lstMeos;
        private Meo _meo;
        private string _input;
        public MeoService()
        {
            FakeData();
        }

        private void FakeData()
        {
            _lstMeos = new List<Meo>()
            {
                new Meo(1,"A",40,1,"Cá"),
                new Meo(2,"B",40,0,"Thịt"),
                new Meo(3,"C",40,1,"Thịt bò"),
            };
        }

        private void Them1()
        {
            Console.WriteLine("Mời nhập sl: ");
            _input = Console.ReadLine();
            for (int i = 0; i < Convert.ToInt16(_input); i++)
            {
                _meo = new Meo();
                Console.WriteLine("Mời bạn nhập ID: ");
                _meo.Id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Mời bạn nhập tên: ");
                _meo.Ten = Console.ReadLine();
                Console.WriteLine("Mời bạn nhập cân nặng: ");
                _meo.CanNang = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Mời bạn nhập giới tính: (1 Đực | 0 Cái)");
                _meo.GioiTinh = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Mời bận nhập sở thích: ");
                _meo.SoThich = Console.ReadLine();
                _lstMeos.Add(_meo);
            }
        }
        private void Them2()
        {
            
            _input = GetInputValue("sl");
            for (int i = 0; i < Convert.ToInt16(_input); i++)
            {
                _meo = new Meo();
                _meo.Id = Convert.ToInt32(GetInputValue("ID"));
                _meo.Ten = GetInputValue("Tên");
                _meo.CanNang = Convert.ToDouble(GetInputValue("Cân nặng"));
                _meo.GioiTinh = Convert.ToInt32(GetInputValue("giới tính: (1 Đực | 0 Cái)"));
                _meo.SoThich = GetInputValue("sở thích");
                _lstMeos.Add(_meo);
            }
        }
        private void Them3()
        {
            
            _input = GetInputValue("sl");
            for (int i = 0; i < Convert.ToInt16(_input); i++)
            {
              
                _lstMeos.Add(new Meo(Convert.ToInt32(GetInputValue("ID")), GetInputValue("Tên"), Convert.ToDouble(GetInputValue("Cân nặng")), Convert.ToInt32(GetInputValue("giới tính: (1 Đực | 0 Cái)")), GetInputValue("sở thích")));
            }
        }

        public string GetInputValue(string msg)
        {
            Console.WriteLine($"Mời bạn nhập {msg}: ");
            return Console.ReadLine();
        }
    }
}
