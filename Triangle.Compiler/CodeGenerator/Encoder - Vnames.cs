using Triangle.AbstractMachine;
using Triangle.Compiler.CodeGenerator.Entities;
using Triangle.Compiler.SyntaxTrees.Visitors;
using Triangle.Compiler.SyntaxTrees.Vnames;

namespace Triangle.Compiler.CodeGenerator
{
    public partial class Encoder : IVnameVisitor<Frame, IFetchableEntity>
    {


        public IFetchableEntity VisitSimpleVname(SimpleVname ast, Frame frame)
        {
            return ast.Identifier.Declaration.Entity as IFetchableEntity;
        }

       
    }
}