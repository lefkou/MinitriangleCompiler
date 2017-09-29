using System;

namespace Lab1
{
    public class MyOutputReader : MyReader 
    {

		protected override string ProcessLine(string line)
		{
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("../../../outputfile.txt", true))
            {
                file.WriteLine(lineCounter + " " + line);
            }
			return line;
		}


    }
}
