using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace util_rename
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(var f in System.IO.Directory.GetFiles("."))
            {
                if (f.EndsWith(".png"))
                {
                    System.IO.File.Move(f, f.Replace("（", "(").Replace("）", ")").Replace(" ", ""));
                    Console.WriteLine(f + " -> " + f.Replace("（", "(").Replace("）", ")").Replace(" ", ""));
                }
            }
        }
    }
}
