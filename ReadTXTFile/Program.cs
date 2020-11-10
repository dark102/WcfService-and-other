using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadTXTFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Podgotovka();
            Console.ReadLine();
        }
        private static void Podgotovka()
        {
            Console.WriteLine("Введите имя файла с расширением (при пустом вводе, имя файла будет Fail.txt)");
            var name = Console.ReadLine();
            if (name == "")
                name = "Fail.txt";
            Console.WriteLine("Введить коренную папку для поиска(при пустом вводе, ПО будет искать фаил в корневой дирректории ПО)");
            var Path = Console.ReadLine();
            if (Path == "")
                Path = Directory.GetCurrentDirectory();
            ReadFile(name, Path);
            Console.WriteLine("Чтение файла закончино. для закрытия нажмите любую клавишу");
        }
        private static void ReadFile(string name, string Path)
        {
            DirectoryInfo pachInfo = new DirectoryInfo(Path);
            if (!pachInfo.Exists)
            {
                Console.WriteLine("Текущего каталога несуществует");
                Podgotovka();
            }
            FileInfo filehInfo = new FileInfo($"{Path}\\{name}");
            if (!filehInfo.Exists)
            {
                Console.WriteLine($"Файла {name} не существует в директоррии {Path}");
                Podgotovka();
            }
            Console.WriteLine($"Построчное чтение из файла {Path}\\{name}. Для перехода к следующей строке нажмите любую клавишу.");
            StreamReader sr = new StreamReader($"{Path}\\{name}");
            string line;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                Console.WriteLine(line);
                Console.ReadKey();
            }
            sr.Close();
        }
    }
}
