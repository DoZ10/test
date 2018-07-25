using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "test1";
            IntPtr p = Marshal.StringToCoTaskMemAnsi(a);


            Console.WriteLine(string.Format("a = {0} = {1:X}", a, p.ToInt64()));
            
            a += "test2";
            p = Marshal.StringToCoTaskMemAnsi(a);

            Console.WriteLine(string.Format("a = {0} = {1:X}", a, p.ToInt64()));

            a = new string('.', 40);

            p = Marshal.StringToCoTaskMemAnsi(a);

            Console.WriteLine(string.Format("a = {0} = {1:X}", a, p.ToInt64()));
            Console.ReadLine();
        }
    }
}