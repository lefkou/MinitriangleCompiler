/**
 * @Author: Eleftherios Kousis <lef>
 * @Date:   5-Nov-2017
 * @Filename: ErrorReporter.cs
 * @Last modified by:   lef
 * @Last modified time: 5-Nov-2017
 */


using System; 

namespace Triangle.Compiler.SyntacticAnalyzer {


    public class ErrorReporter {

        int numErrors;

        public ErrorReporter() {
            numErrors = 0;
        }

        // This function outputs a error-appropriate message in the console and is used
        // when a token is accepted.
        public void ReportError(string message, Token currentToken, SourcePosition position) 
        {
            // increment error count to output the number at the end
            numErrors += 1;
            // changes output colors
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine("Error: Expected :{0} got :{1} value: {2} \nPosition ->  {3}", 
                                message, currentToken, currentToken.Spelling, currentToken._position);
            Console.ResetColor();                   
        }


        // check if any error occured. For output only.
        public bool HasErrors { get {
            if(numErrors >= 1) {
                return true;
            }
            return false;
        }}


        // Counts the error. For output only.
        public int ErrorCount { get { return numErrors; }}
    }
}