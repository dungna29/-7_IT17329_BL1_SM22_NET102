using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_2_1_CLASS_GENERIC
{
    internal class ArrayGeneric<T>
    {
        private T[] array;//Mảng không xác định kiểu

        public ArrayGeneric()
        {
            
        }

        public ArrayGeneric(T[] array)
        {
            this.array = array;
        }

        public ArrayGeneric(int size)//Khi khởi tạo mảng với contructor này sẽ khởi tạo kích thước cho mảng.
        {
            array = new T[size];
        }

        public T[] Array
        {
            get => array;
            set => array = value;
        }

        //Phương thức thêm phần tử vào trong mảng
        public void AddArr(int index,T value)
        {
            if (index < 0 || index >= array.Length)
            {
                throw new IndexOutOfRangeException();
            }
            array[index] = value;
        }
        //Phương thức lấy giá trị trong mảng
        public T GetValue(int index)
        {
            if (index < 0 || index >= array.Length)
            {
                throw new IndexOutOfRangeException();
            }

            return array[index];
        }
    }
}
