using Triangle.Compiler.SyntaxTrees.Types;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Aggregates
{
    public abstract class RecordAggregate : AbstractSyntaxTree
    {
        FieldTypeDenoter _type;

        protected RecordAggregate(SourcePosition position)
            : base(position)
        {
            _type = null;
        }

        public FieldTypeDenoter Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public abstract TResult Visit<TArg, TResult>(IRecordAggregateVisitor<TArg, TResult> visitor, TArg arg);

        public TResult Visit<TResult>(IRecordAggregateVisitor<Void, TResult> visitor)
        {
            return Visit(visitor, null);
        }
    }
}