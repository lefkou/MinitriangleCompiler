/**
 * @Author: Eleftherios Kousis <lef>
 * @Date:   5-Nov-2017
 * @Filename: Location.cs
 * @Last modified by:   lef
 * @Last modified time: 5-Nov-2017
 */


using System;

namespace Triangle.Compiler.SyntacticAnalyzer {


		// class used to identify token location
    public class Location
    {
			
			// used to reset location
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