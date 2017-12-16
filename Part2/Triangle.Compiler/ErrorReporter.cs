namespace Triangle.Compiler
{
    public struct Location
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

    public struct SourcePosition
    {
        public static readonly SourcePosition Empty = new SourcePosition(Location.Empty, Location.Empty);

        public readonly Location Start;

        public readonly Location Finish;

        public SourcePosition(Location start, Location finish)
        {
            Start = start;
            Finish = finish;
        }

        public override string ToString()
        {
            return string.Format("{0}..{1}", Start, Finish);
        }
    }

    public interface ErrorReporter
    {
        void ReportError(string message, string tokenName, SourcePosition pos);

        void ReportRestriction(string message);

        void ReportMessage(string message);

        int ErrorCount { get; }

        bool HasErrors { get; }
    }
}