using System;
using System.IO;


namespace Lab1
{
    public class MyReader
    {
        public MyReader()
        {
        }


        // the read file method will take a file instance and 
        // read the file given line by line
        public void ReadFile(string fileName)
        {
			StreamReader reader = File.OpenText(fileName);
			string line = reader.ReadLine();
			while (line != null)
			{
                line = ProcessLine(reader.ReadLine());
				Console.WriteLine(line);
				
			}
			reader.Close();
        }


        // the process method will process the file line by line.
        // It should prepend a line number to each line, 
        // then write the line to the console.
        string ProcessLine(string line) 
        {
            return line;   
        }
    }
}
