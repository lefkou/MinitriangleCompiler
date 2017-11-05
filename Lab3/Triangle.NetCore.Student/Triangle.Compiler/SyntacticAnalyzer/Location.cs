using System;

namespace Triangle.Compiler.SyntacticAnalyzer {

    public class Location
    {
		public static readonly Location Empty = new Location(0, 0);

		public readonly int Line;
		public readonly int Column;

		public Location(int line, int column)
		{
			Line = line;
			Column = column;
		}

		public override string ToString()
		{
			return string.Format("({0},{1})", Line, Column);
		}
    }
}