/**
 * @Author: John Isaacs <john>
 * @Date:   19-Oct-172017
 * @Filename: Parser - Vnames.cs
 * @Last modified by:   john
 * @Last modified time: 19-Oct-172017
 */



namespace Triangle.Compiler.SyntacticAnalyzer
{
    public partial class Parser
    {

        // /////////////////////////////////////////////////////////////////////////////
        //
        // VALUE-OR-VARIABLE NAMES
        //
        // /////////////////////////////////////////////////////////////////////////////


        void ParseVname()
        {
          System.Console.WriteLine("parsing variable name");
            ParseIdentifier();

        }

    }
}
