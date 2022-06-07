using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_2_8_DocGhiDoiTuong
{
    [Serializable]
   internal class Meo:DongVat
    {
        public string SoThich { get; set; }

        public Meo()
        {
            
        }

        public Meo(int id, string ten, double canNang, int gioiTinh, string SoThich1) : base(id, ten, canNang, gioiTinh)
        {
            SoThich = SoThich1;
        }
        public override void InRaManHinh()
        {
            Console.WriteLine($"{Id} {Ten} {(GioiTinh == 1?"Đực":"Cái")} {CanNang} {SoThich}");
        }
    }
}
