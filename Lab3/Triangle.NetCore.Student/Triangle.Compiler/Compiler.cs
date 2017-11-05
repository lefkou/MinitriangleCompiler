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
        Parser _parser;
        // Creates a compiler for the given source file.
        Compiler(string sourceFileName)
        {
            _source = new SourceFile(sourceFileName);
            _scanner = new Scanner(_source);
            _parser = new Parser(_scanner);
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
                // compiler._parser.ParseProgram();

            }
        }
    }
}