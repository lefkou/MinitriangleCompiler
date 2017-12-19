using Triangle.Compiler.SyntaxTrees.Declarations;
using Triangle.Compiler.SyntaxTrees.Expressions;
using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Types;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.ContextualAnalyzer
{
    public partial class Checker : IExpressionVisitor<Void, TypeDenoter>
    {
        // Expressions

        // Returns the TypeDenoter denoting the type of the expression. Does
        // not use the given object.


        public TypeDenoter VisitBinaryExpression(BinaryExpression ast, Void arg)
        {
            var e1Type = ast.LeftExpression.Visit(this);
            var e2Type = ast.RightExpression.Visit(this);
            var binding = ast.Operator.Visit(this);

            var bbinding = binding as BinaryOperatorDeclaration;
            if (bbinding != null)
            {
                if (bbinding.FirstArgument == StandardEnvironment.AnyType)
                {
                    // this operator must be "=" or "\="
                    CheckAndReportError(e1Type.Equals(e2Type), "incompatible argument types for \"%\"",
                        ast.Operator, ast);
                }
                else
                {
                    CheckAndReportError(e1Type.Equals(bbinding.FirstArgument),
                        "wrong argument type for \"%\"", ast.Operator, ast.LeftExpression);
                    CheckAndReportError(e2Type.Equals(bbinding.SecondArgument),
                        "wrong argument type for \"%\"", ast.Operator, ast.RightExpression);
                }
                return ast.Type = bbinding.Result;
            }

            ReportUndeclaredOrError(binding, ast.Operator, "\"%\" is not a binary operator");
            return ast.Type = StandardEnvironment.ErrorType;
        }

        public TypeDenoter VisitCallExpression(CallExpression ast, Void arg)
        {
            var binding = ast.Identifier.Visit(this);
            var function = binding as IFunctionDeclaration;
            if (function != null)
            {
                ast.Actuals.Visit(this, function.Formals);
                return ast.Type = function.Type;
            }

            ReportUndeclaredOrError(binding, ast.Identifier, "\"%\" is not a function identifier");
            return ast.Type = StandardEnvironment.ErrorType;
        }

        public TypeDenoter VisitCharacterExpression(CharacterExpression ast, Void arg)
        {
            return ast.Type = StandardEnvironment.CharType;
        }

        public TypeDenoter VisitEmptyExpression(EmptyExpression ast, Void arg)
        {
            return ast.Type = null;
        }

        public TypeDenoter VisitIfExpression(IfExpression ast, Void arg)
        {
            var e1Type = ast.TestExpression.Visit(this);
            CheckAndReportError(e1Type == StandardEnvironment.BooleanType,
                "Boolean expression expected here", ast.TestExpression);
            var e2Type = ast.TrueExpression.Visit(this);
            var e3Type = ast.FalseExpression.Visit(this);
            CheckAndReportError(e2Type.Equals(e3Type), "incompatible limbs in if-expression", ast);
            return ast.Type = e2Type;
        }

        public TypeDenoter VisitIntegerExpression(IntegerExpression ast, Void arg)
        {
            return ast.Type = StandardEnvironment.IntegerType;
        }

        public TypeDenoter VisitLetExpression(LetExpression ast, Void arg)
        {

            _idTable.OpenScope(); ast.Declaration.Visit(this);
            ast.Declaration.Visit(this);
            _idTable.CloseScope();
            return ast.Type;
        }


        public TypeDenoter VisitUnaryExpression(UnaryExpression ast, Void arg)
        {
            var expressionType = ast.Expression.Visit(this);
            var binding = ast.Operator.Visit(this);
            var ubinding = binding as UnaryOperatorDeclaration;
            if (ubinding != null)
            {
                CheckAndReportError(expressionType.Equals(ubinding.Argument),
                    "wrong argument type for \"%\"", ast.Operator);
                return ast.Type = ubinding.Result;
            }

            ReportUndeclaredOrError(binding, ast.Operator, "\"%\" is not a unary operator");
            return ast.Type = StandardEnvironment.ErrorType;
        }

        public TypeDenoter VisitVnameExpression(VnameExpression ast, Void arg)
        {
            var vnameType = ast.Vname.Visit(this);
            return ast.Type = vnameType;
        }
    }
}