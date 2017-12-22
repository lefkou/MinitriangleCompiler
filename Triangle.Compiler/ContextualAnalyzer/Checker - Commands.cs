using Triangle.Compiler.SyntaxTrees.Commands;
using Triangle.Compiler.SyntaxTrees.Declarations;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.ContextualAnalyzer
{
    public partial class Checker : ICommandVisitor
    {

        // Commands

        public Void VisitAssignCommand(AssignCommand ast, Void arg)
        {
            var vnameType = ast.Vname.Visit(this);
            var expressionType = ast.Expression.Visit(this);
            CheckAndReportError(ast.Vname.IsVariable, "LHS of assignment is not a variable",
                ast.Vname);
            CheckAndReportError(expressionType.Equals(vnameType), "assignment incompatibilty", ast);
            return null;
        }

        public Void VisitCallCommand(CallCommand ast, Void arg)
        {
            var binding = ast.Identifier.Visit(this);
            var procedure = binding as IProcedureDeclaration;
            if (procedure != null)
            {
                ast.Actuals.Visit(this, procedure.Formals);
            }
            else
            {
                ReportUndeclaredOrError(binding, ast.Identifier, "\"%\" is not a procedure identifier");
            }
            return null;
        }

        public Void VisitEmptyCommand(EmptyCommand ast, Void arg)
        {
            return null;
        }

        public Void VisitIfCommand(IfCommand ast, Void arg)
        {
            var expressionType = ast.Expression.Visit(this);
            CheckAndReportError(expressionType == StandardEnvironment.BooleanType,
                "Boolean expression expected here", ast.Expression);
            ast.TrueCommand.Visit(this);
            ast.FalseCommand.Visit(this);
            return null;
        }

        public Void VisitLetCommand(LetCommand ast, Void arg)
        {
            _idTable.OpenScope();
            ast.Declaration.Visit(this);
            ast.Command.Visit(this);
            _idTable.CloseScope();
            return null;
        }

        public Void VisitSequentialCommand(SequentialCommand ast, Void arg)
        {
            ast.FirstCommand.Visit(this);
            ast.SecondCommand.Visit(this);
            return null;
        }

        public Void VisitWhileCommand(WhileCommand ast, Void arg)
        {
            var expressionType = ast.Expression.Visit(this);
            CheckAndReportError(expressionType == StandardEnvironment.BooleanType,
                "Boolean expression expected here", ast.Expression);
            ast.Command.Visit(this);
            return null;
        }

    }
}