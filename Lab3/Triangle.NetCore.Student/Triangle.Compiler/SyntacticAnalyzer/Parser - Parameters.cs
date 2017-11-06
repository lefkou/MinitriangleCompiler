/**
 * @Author: Eleftherios Kousis <lef>
 * @Date:   5-Nov-2017
 * @Filename: Parser - Parameters.cs
 * @Last modified by:   lef
 * @Last modified time: 5-Nov-2017
 */




namespace Triangle.Compiler.SyntacticAnalyzer
{

    // ACTUAL PARAMETERS. Here the actual parameters are specified using for guideline
    // the language definition provided.
    public partial class Parser
    {

        void ParseActualParameter()
        {
            System.Console.WriteLine("parsing actual parameter");
            
            if(_currentToken.Kind == TokenKind.Var) {
                ParseVname();
            }
            else {
                ParseExpression();
            }
        }

        void ParseActualParameterSequence()
        {
            System.Console.WriteLine("parsing actual parameter sequence");
            ParseActualParameter();
            while(_currentToken.Kind == TokenKind.Comma) {
              ParseActualParameter();
            }
        }
    }
}