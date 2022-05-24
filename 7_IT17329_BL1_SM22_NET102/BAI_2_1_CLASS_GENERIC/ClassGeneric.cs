using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_2_1_CLASS_GENERIC
{
    internal class ClassGeneric<Q>
    {
        private Q temp;

        public ClassGeneric()
        {
            
        }

        public ClassGeneric(Q temp)
        {
            this.temp = temp;
        }

        public Q Temp
        {
            get => temp;
            set => temp = value;
        }

        public Q getValue()
        {
            Console.WriteLine(temp);
            return temp;
        }
    }
}
