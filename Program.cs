using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileDelete
{
    class Program
    {
        static void Main(string[] args)
        {
            string p = @"E:/sc";
            //string p = @"C:/A";
            DateTime d = new DateTime(2012, 5, 1, 0, 0, 0);

            Del de = new Del(p, d);
            de.DeleteFile();

            Console.ReadLine();
        }
    }
}
