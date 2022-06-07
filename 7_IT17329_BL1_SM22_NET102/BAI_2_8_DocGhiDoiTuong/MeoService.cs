using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_2_8_DocGhiDoiTuong
{
    //Code các chức năng
    internal class MeoService
    {
        private List<Meo> _lstMeos;
        private Meo _meo;
        private string _input;
        private string _pathFileData = @"H:\Dungna29 Fpoly\8. Demo\Demo C#2\SM22_BL1\7_IT17329_BL1_SM22_NET102\7_IT17329_BL1_SM22_NET102\BAI_2_8_DocGhiDoiTuong\data.bin";
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

        public void Them1()
        {
            Console.WriteLine("Mời nhập sl: ");
            _input = Console.ReadLine();
            for (int i = 0; i < Convert.ToInt16(_input); i++)
            {
                _meo = new Meo();
                _meo.Id = GetAutoID();
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
       
        //Tìm kiếm, Sửa, Xóa
        public void TimKiem()
        {
            var temp = GetIndexByID();
            if (temp == -1) return;
            _lstMeos[temp].InRaManHinh();
        }
        public void Xoa()
        {
            var temp = GetIndexByID();
            if (temp == -1) return;
            _lstMeos.RemoveAt(temp);
            Console.WriteLine("Xóa thành công");
        }
        public void Sua()
        {
            
            var temp = GetIndexByID();
            if (temp == -1) return;
            _lstMeos[temp].Ten = GetInputValue("Tên");
        }

        public int GetIndexByID()
        {
           
            return _lstMeos.FindIndex(c => c.Id == Convert.ToInt16(GetInputValue("ID")));
        }
        public void InDs()
        {
            foreach (var x in _lstMeos)
            {
                x.InRaManHinh();
            }
        }
        public string GetInputValue(string msg)
        {
            Console.WriteLine($"Mời bạn nhập {msg}: ");
            return Console.ReadLine();
        }

        public int GetAutoID()
        {
            if (_lstMeos.Count < 0)
            {
                return 1;
            }

            return _lstMeos.Max(c => c.Id) + 1;
        }

        public void LuuFile()
        {
           FileService.WriteFile(_pathFileData,_lstMeos);
           Console.WriteLine("Lưu file thành công");
        } 
        public void DocFile()
        {
            _lstMeos = FileService.ReadFile(_pathFileData);
            Console.WriteLine("Đọc file thành công");
        }
    }
}
