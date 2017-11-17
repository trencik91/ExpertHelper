using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EdiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            String path = Console.ReadLine().Trim('"');

            String[] fileName = path.Split('_');

            String code = fileName.Last().Substring(0, 3);
            String name = fileName.Last().Substring(3).Split('.')[0];
            
            Console.WriteLine("code " + code + "   name " + name);

            string[] lines = File.ReadAllLines(path);

            StringBuilder sb = new StringBuilder();
            lines.ToList().ForEach(s => { sb.Append(s); sb.Append("\r\n"); });

            String[] orders = Regex.Split(sb.ToString(), "^BEG\\.\r\n$");

            int i = 0;
            
            Console.ReadKey();
        }
    }
}
