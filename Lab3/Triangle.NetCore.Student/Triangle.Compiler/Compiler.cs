using System;
using Triangle.Compiler.SyntacticAnalyzer;

namespace Triangle.Compiler
{

    public class Compiler
    {
        
        const string ObjectFileName = "obj.tam";

        SourceFile _source;

		// The scanner.	
		Scanner _scanner;

        // Creates a compiler for the given source file.
        Compiler(string sourceFileName)
        {
            _source = new SourceFile(sourceFileName);
            _scanner = new Scanner(_source);
        }


        // Triangle compiler main program.
        public static void Main(string[] args)
        {
            var sourceFileName = args[0];

            if (sourceFileName != null)
            {
                var compiler = new Compiler(sourceFileName);
				foreach (var token in compiler._scanner)
				{
                    Console.WriteLine(token);
				}

            }
        }
    }
}