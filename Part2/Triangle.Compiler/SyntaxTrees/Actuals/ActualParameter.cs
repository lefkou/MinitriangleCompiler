

namespace Triangle.Compiler.SyntaxTrees.Actuals
{
    public abstract class ActualParameter : AbstractSyntaxTree
    {
        protected ActualParameter(SourcePosition position)
            : base(position)
        {
            if(Compiler.debug){System.Console.WriteLine(this.GetType().Name);}
        }


    }
}