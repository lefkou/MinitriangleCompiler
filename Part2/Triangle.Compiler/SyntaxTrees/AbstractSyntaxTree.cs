

namespace Triangle.Compiler.SyntaxTrees
{

    public abstract class AbstractSyntaxTree
    {
        readonly SourcePosition _position;


        protected AbstractSyntaxTree(SourcePosition position)
        {
            _position = position;
        }

        public SourcePosition Position { get { return _position; } }

        public Location Start { get { return _position.Start; } }

        public Location Finish { get { return _position.Finish; } }

    }
}