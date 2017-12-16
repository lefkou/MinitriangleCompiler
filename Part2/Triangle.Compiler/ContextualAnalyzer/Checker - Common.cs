using Triangle.Compiler.SyntaxTrees;
using Triangle.Compiler.SyntaxTrees.Declarations;
using Triangle.Compiler.SyntaxTrees.Terminals;

namespace Triangle.Compiler.ContextualAnalyzer
{
    public partial class Checker
    {
        ErrorReporter _errorReporter;

        IdentificationTable _idTable;

        public Checker(ErrorReporter errorReporter)
        {
            _errorReporter = errorReporter;
            _idTable = new IdentificationTable();
            EstablishStdEnvironment();
        }

        public void Check(Program ast)
        {
            ast.Visit(this, null);
        }

        // Reports that the identifier or operator used at a leaf of the AST
        // has not been declared.

        void ReportUndeclaredOrError(Declaration binding, Terminal leaf, string message)
        {
            if (binding == null)
            {
                ReportError("\"%\" is not declared", leaf);
            }
            else
            {
                ReportError(message, leaf);
            }
        }

        void ReportError(string message, Terminal ast)
        {
            ReportError(message, ast, ast);
        }

        void ReportError(string message, Terminal spellingNode, AbstractSyntaxTree positionNode)
        {
            _errorReporter.ReportError(message, spellingNode.Spelling, positionNode.Position);
        }

        void ReportError(string message, AbstractSyntaxTree positionNode)
        {
            _errorReporter.ReportError(message, string.Empty, positionNode.Position);
        }

        void CheckAndReportError(bool condition, string message, string token,
                SourcePosition position)
        {
            if (!condition)
            {
                _errorReporter.ReportError(message, token, position);
            }
        }

        void CheckAndReportError(bool condition, string message, Terminal ast)
        {
            CheckAndReportError(condition, message, ast, ast);
        }

        void CheckAndReportError(bool condition, string message, Terminal spellingNode,
            AbstractSyntaxTree positionNode)
        {
            CheckAndReportError(condition, message, spellingNode.Spelling, positionNode.Position);
        }

        void CheckAndReportError(bool condition, string message,
                AbstractSyntaxTree positionNode)
        {
            CheckAndReportError(condition, message, string.Empty, positionNode.Position);
        }
        // Creates small ASTs to represent the standard types.
        // Creates small ASTs to represent "declarations" of standard types,
        // constants, procedures, functions, and operators.
        // Enters these "declarations" in the identification table.

        void EnterStdDeclaration(Terminal terminal, Declaration declaration)
        {
            _idTable.Enter(terminal, declaration);
        }

        void EnterStdDeclaration(TypeDeclaration declaration)
        {
            EnterStdDeclaration(declaration.Identifier, declaration);
        }

        void EnterStdDeclaration(ConstDeclaration declaration)
        {
            EnterStdDeclaration(declaration.Identifier, declaration);
        }

        void EnterStdDeclaration(FuncDeclaration declaration)
        {
            EnterStdDeclaration(declaration.Identifier, declaration);
        }

        void EnterStdDeclaration(ProcDeclaration declaration)
        {
            EnterStdDeclaration(declaration.Identifier, declaration);
        }

        void EnterStdDeclaration(BinaryOperatorDeclaration declaration)
        {
            EnterStdDeclaration(declaration.Operator, declaration);
        }

        void EnterStdDeclaration(UnaryOperatorDeclaration declaration)
        {
            EnterStdDeclaration(declaration.Operator, declaration);
        }

        void EstablishStdEnvironment()
        {

            // Boolean declarations
            EnterStdDeclaration(StandardEnvironment.BooleanDecl);
            EnterStdDeclaration(StandardEnvironment.FalseDecl);
            EnterStdDeclaration(StandardEnvironment.TrueDecl);
            EnterStdDeclaration(StandardEnvironment.NotDecl);
            EnterStdDeclaration(StandardEnvironment.AndDecl);
            EnterStdDeclaration(StandardEnvironment.OrDecl);

            // Integer declarations
            EnterStdDeclaration(StandardEnvironment.IntegerDecl);
            EnterStdDeclaration(StandardEnvironment.MaxintDecl);
            EnterStdDeclaration(StandardEnvironment.AddDecl);
            EnterStdDeclaration(StandardEnvironment.SubtractDecl);
            EnterStdDeclaration(StandardEnvironment.MultiplyDecl);
            EnterStdDeclaration(StandardEnvironment.DivideDecl);
            EnterStdDeclaration(StandardEnvironment.ModuloDecl);
            EnterStdDeclaration(StandardEnvironment.LessDecl);
            EnterStdDeclaration(StandardEnvironment.NotGreaterDecl);
            EnterStdDeclaration(StandardEnvironment.GreaterDecl);
            EnterStdDeclaration(StandardEnvironment.NotLessDecl);

            // Character declarations
            EnterStdDeclaration(StandardEnvironment.CharDecl);
            EnterStdDeclaration(StandardEnvironment.ChrDecl);
            EnterStdDeclaration(StandardEnvironment.OrdDecl);
            EnterStdDeclaration(StandardEnvironment.EofDecl);
            EnterStdDeclaration(StandardEnvironment.EolDecl);
            EnterStdDeclaration(StandardEnvironment.GetDecl);
            EnterStdDeclaration(StandardEnvironment.PutDecl);
            EnterStdDeclaration(StandardEnvironment.GetintDecl);
            EnterStdDeclaration(StandardEnvironment.PutintDecl);
            EnterStdDeclaration(StandardEnvironment.GeteolDecl);
            EnterStdDeclaration(StandardEnvironment.PuteolDecl);

            // Any declarations
            EnterStdDeclaration(StandardEnvironment.EqualDecl);
            EnterStdDeclaration(StandardEnvironment.UnequalDecl);

        }
    }
}