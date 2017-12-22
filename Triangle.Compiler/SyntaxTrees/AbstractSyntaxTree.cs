using Triangle.Compiler.CodeGenerator.Entities;

namespace Triangle.Compiler.SyntaxTrees
{

    public abstract class AbstractSyntaxTree
    {
        readonly SourcePosition _position;
        RuntimeEntity _entity;

        protected AbstractSyntaxTree(SourcePosition position)
        {
            _position = position;
        }

        public SourcePosition Position { get { return _position; } }

        public RuntimeEntity Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }

        public Location Start { get { return _position.Start; } }

        public Location Finish { get { return _position.Finish; } }

    }
}