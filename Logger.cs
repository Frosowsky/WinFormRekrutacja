using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;

namespace WinFormRekrutacja
{
    public class Logger
    {
        private string Directory { get; set; }
        private string FileName { get; set; }
        private string FilePath { get; set; }
        
        
        
        public Logger()
        {
            Directory = System.IO.Directory.GetCurrentDirectory();
            FileName = "log.txt";
            FilePath = Directory + "/" + FileName;

        }

        public void log(string message)
        {
            using(StreamWriter w = System.IO.File.AppendText(FilePath))
            
            {
                w.Write("\r\n LOG ENTRY :");
                w.WriteLine($"{DateTime.Now.ToLongDateString()} , {DateTime.Now.ToLongTimeString()}");
                w.WriteLine(message);
                w.WriteLine("--------------------------------------------");         
            }
        }
            
    }
}

