using System;

namespace Lab1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            MyReader myreader = new MyReader();
            myreader.ReadFile("../../../testFile.txt");
            //Console.WriteLine("Hello World!");
        }
    }
}
