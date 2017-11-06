/**
 * @Author: Eleftherios Kousis <lef>
 * @Date:   5-Nov-2017
 * @Filename: Parser - Programs.cs
 * @Last modified by:   lef
 * @Last modified time: 5-Nov-2017
 */




namespace Triangle.Compiler.SyntacticAnalyzer
{
    public partial class Parser
    {
        // PROGRAM: Starts the program and moves to the next token

        public void ParseProgram()
        {
                System.Console.WriteLine("parsing Program");
                _tokens.MoveNext();
                _currentToken = _tokens.Current;
                //var startLocation = _currentToken.Start;
                ParseCommand();
        }
    }
}
