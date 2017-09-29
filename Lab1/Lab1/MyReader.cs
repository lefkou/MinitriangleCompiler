using System;
using System.IO;


namespace Lab1
{
    public class MyReader : StatsGenerator
    {

        protected int lineCounter;
        protected string[] lines = new string[100];
        protected int wordCounter;
        protected int charCounter;
        protected string firstLetter;
        protected string firstWord;
        protected string endLine;


        public MyReader()
        {
            lineCounter = 0;
        }

        public int getCharacterCount()
        {
            throw new NotImplementedException();
        }

        public string getEndLine()
        {
            for
        }

        public string getFirstLetter()
        {
            throw new NotImplementedException();
        }

        public string getFirstWord()
        {
            throw new NotImplementedException();
        }

        public int getLineCount()
        {
            return lineCounter;
        }

        public int getWordCount()
        {
            throw new NotImplementedException();
        }


        // the read file method will take a file instance and 
        // read the file given line by line
        public void ReadFile(string fileName)
        {
			StreamReader reader = File.OpenText(fileName);
			string line = reader.ReadLine();
			while (line != null)
			{
                lineCounter += 1;
                lines[lineCounter] = reader.ReadLine();
                line = ProcessLine(reader.ReadLine());
				
			}
			reader.Close();
        }
            

        // the process method will process the file line by line.
        // It should prepend a line number to each line, 
        // then write the line to the console.
        protected virtual string ProcessLine(string line) 
        {
            if(line != null) {
				Console.WriteLine(lineCounter + " " + line);
			}
			return line;   
        }
    }
}
