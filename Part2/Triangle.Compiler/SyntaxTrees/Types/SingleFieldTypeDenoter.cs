using Triangle.Compiler.SyntaxTrees.Terminals;


namespace Triangle.Compiler.SyntaxTrees.Types
{
    public class SingleFieldTypeDenoter : FieldTypeDenoter
    {
        Identifier _identifier;

        TypeDenoter _type;

        public SingleFieldTypeDenoter(Identifier identifier, TypeDenoter type,
                SourcePosition position)
            : base(position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
            _identifier = identifier;
            _type = type;
        }

        public Identifier Identifier { get { return _identifier; } }

        public TypeDenoter Type
        {
            get { return _type; }
            set { _type = value; }
        }

       
    }
}