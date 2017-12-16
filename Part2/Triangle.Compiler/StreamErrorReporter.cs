using System;
using System.IO;

namespace Triangle.Compiler
{
    class StreamErrorReporter : ErrorReporter
    {
        TextWriter _output;
        
        int _errorCount;

        internal StreamErrorReporter()
        {
            _output = Console.Out;
            _errorCount = 0;
        }

        public void ReportError(string message, string tokenName, SourcePosition pos)
        {
            _output.WriteLine("ERROR: {0} {1}", message.Replace("%", tokenName), pos);
            _errorCount++;
        }

        public void ReportRestriction(string message)
        {
            _output.WriteLine("RESTRICTION: {0}", message);
        }

        public void ReportMessage(string message)
        {
           _output.WriteLine(message);
        }

        public int ErrorCount { get { return _errorCount; } }

        public bool HasErrors { get { return _errorCount > 0; } }
    }
}