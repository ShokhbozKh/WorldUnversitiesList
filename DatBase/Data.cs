using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unversite.Models;

namespace unversite.DatBase
{
    internal class Data
    {
        public async Task RecordData(List<Unversitet> data)
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string filePath = $@"{path}\\file.json";

            if (!File.Exists(path))
            {
               File.Create(filePath).Close();
            }
            using(StreamWriter sw = new StreamWriter(filePath))
            {
                foreach(var item in data)
                {
                    sw.WriteLine($"{item.name}, {item.country}, {item.web_pages[0]}");
                }
                await Console.Out.WriteLineAsync("Ma'lumot yozildi..");
            }
        }
    }
}
