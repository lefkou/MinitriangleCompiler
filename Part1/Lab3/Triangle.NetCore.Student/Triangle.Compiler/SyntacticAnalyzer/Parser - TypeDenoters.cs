/**
 * @Author: Eleftherios Kousis <lef>
 * @Date:   5-Nov-2017
 * @Filename: Parser - TypeDenoters.cs
 * @Last modified by:   lef
 * @Last modified time: 5-Nov-2017
 */




namespace Triangle.Compiler.SyntacticAnalyzer
{        
    // Only contains the method for parsing a type denoter
    public partial class Parser
    {   


        // Parse a type denoter with a message
        void ParseTypeDenoter()
        {
            System.Console.WriteLine("parsing type denoter");
            ParseIdentifier();
        }
    }
}