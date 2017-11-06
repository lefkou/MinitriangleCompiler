using System;
using Triangle.Compiler.SyntacticAnalyzer;

namespace Triangle.Compiler
{

    public class Compiler
    {
        
        const string ObjectFileName = "obj.tam";

        SourceFile _source;

		Scanner _scanner;
        Parser _parser;
        ErrorReporter _errorReporter;
        // Creates a compiler for the given source file.
        Compiler(string sourceFileName)
        {
            _source = new SourceFile(sourceFileName);
            _scanner = new Scanner(_source);
            _errorReporter = new ErrorReporter();
            _parser = new Parser(_scanner, _errorReporter);
        }


        // Triangle compiler main program.
        public static void Main(string[] args)
        {
            var sourceFileName = args[0];

            if (sourceFileName != null)
            {
                var compiler = new Compiler(sourceFileName);
				// foreach (var token in compiler._scanner)
				// {
                //     Console.WriteLine(token);
                    
				// }
                compiler._source.Reset();
                compiler._parser.ParseProgram();
                
                if(compiler._parser._errorReporter.HasErrors) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else 
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.WriteLine("Finished with {0} errors.", compiler._parser._errorReporter.ErrorCount);
                Console.ResetColor();
            }
            
            
            
        }
    }
}