using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Types;


namespace Triangle.Compiler.SyntaxTrees.Declarations
{
    public class TypeDeclaration : Declaration
    {
        Identifier _identifier;

        TypeDenoter _type;

        public TypeDeclaration(Identifier identifier, TypeDenoter type, SourcePosition position)
            : base(position)
        {if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
            _identifier = identifier;
            _type = type;
        }

        public TypeDeclaration(Identifier identifier, TypeDenoter type)
            : this(identifier, type, SourcePosition.Empty)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
        }

        public Identifier Identifier { get { return _identifier; } }

        public TypeDenoter Type
        {
            get { return _type; }
            set { _type = value; }
        }


    }
}