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
                    string new_filename =  f.Replace("（", "(").Replace("）", ")").Replace(" ", "");
                    while (System.IO.File.Exists(new_filename))
                    {
                        new_filename = new_filename.Replace(".png", "_.png");
                    }

                    System.IO.File.Move(f, new_filename);
                    Console.WriteLine(f + " -> " + f.Replace("（", "(").Replace("）", ")").Replace(" ", ""));
                }
            }
        }
    }
}
