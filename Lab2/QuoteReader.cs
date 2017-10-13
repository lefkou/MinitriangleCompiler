using System;
using System.Collections.Generic;
using System.IO;

namespace TeleprompterConsole
{
    public class QuoteReader    
    {
        public QuoteReader()
        {
            IEnumerable <string> lines = ReadFrom("sampleQuotes.txt"); 
            foreach (string line in lines)
            {
				Console.WriteLine(line);
			}
        }

		IEnumerable<string> ReadFrom(string file)
		{
            string line;
            using (StreamReader reader = File.OpenText(file))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
		}
    }
}
