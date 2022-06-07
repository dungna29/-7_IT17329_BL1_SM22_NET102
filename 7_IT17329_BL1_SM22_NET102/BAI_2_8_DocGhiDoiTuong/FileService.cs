using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BAI_2_8_DocGhiDoiTuong
{
    internal class FileService
    {
        private static FileStream _fs;
        private static BinaryFormatter _bf;

        //Ghi dữ liệu vào file thì phải biết file đó nằm ở đâu và dữ liệu ghi vào file là dữ liệu gì
        public static void WriteFile(string path,List<Meo> data)
        {
            //Serialization trong C# là kỹ thuật chuyển đổi object về dạng(text, mảng byte phục vụ lưu trữ)
            _fs = new FileStream(path, FileMode.Create);
            _bf = new BinaryFormatter();//Khởi tạo
            _bf.Serialize(_fs, data);//Serialize Tuần tự hóa hoặc tuần tự hóa là quá trình dịch cấu trúc dữ liệu hoặc trạng thái đối tượng sang định dạng có thể được lưu trữ hoặc truyền và tái tạo lại sau này.
            _fs.Close();
        }
        //Đọc file lên và trả ra 1 List đối tượng từ file
        public static List<Meo> ReadFile(string path)
        {
            //Deserialize là một phương thức đọc các byte từ luồng và chuyển đổi lại về object
            _fs = new FileStream(path, FileMode.Open);
            _bf = new BinaryFormatter();//Khởi tạo
            var dataReader = _bf.Deserialize(_fs);
            _fs.Close();
            return (List<Meo>)dataReader;
        }
    }
}
