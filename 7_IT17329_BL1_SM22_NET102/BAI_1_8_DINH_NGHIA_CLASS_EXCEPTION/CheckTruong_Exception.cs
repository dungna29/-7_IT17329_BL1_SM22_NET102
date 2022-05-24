using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_1_8_DINH_NGHIA_CLASS_EXCEPTION
{
    internal class CheckTruong_Exception:Exception
    {
        public CheckTruong_Exception(string message) : base(message)
        {
        }
    }
}
