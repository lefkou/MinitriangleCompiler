using Triangle.Compiler.SyntaxTrees.Commands;
using Triangle.Compiler.SyntaxTrees.Declarations;
using Triangle.Compiler.SyntaxTrees.Expressions;
using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Types;

namespace Triangle.Compiler
{
    public static class StandardEnvironment
    {

        // These are small ASTs representing standard types.

        /**
         * The type denoter for the "{@code Boolean}" type.
         */
        public static readonly TypeDenoter BooleanType = new BoolTypeDenoter();

        /**
         * The type denoter for the "{@code Char}" type.
         */
        public static readonly TypeDenoter CharType = new CharTypeDenoter();

        /**
         * The type denoter for the "{@code Integer}" type.
         */
        public static readonly TypeDenoter IntegerType = new IntTypeDenoter();

        /**
         * The type denoter for any type, used for the arguments of the equality and
         * inequality operators.
         */
        public static readonly TypeDenoter AnyType = new AnyTypeDenoter();

        /**
         * A type denoter for the error type, used for errors in contextual analysis.
         */
        public static readonly TypeDenoter ErrorType = new ErrorTypeDenoter();

        /**
         * The type declaration for the "{@code Boolean}" type.
         */
        public static readonly TypeDeclaration BooleanDecl = DeclareStdType("Boolean", BooleanType);

        /**
         * The type declaration for the "{@code Char}" type.
         */
        public static readonly TypeDeclaration CharDecl = DeclareStdType("Char", CharType);

        /**
         * The type declaration for the "{@code Integer}" type.
         */
        public static readonly TypeDeclaration IntegerDecl = DeclareStdType("Integer", IntegerType);

        // These are small ASTs representing "declarations" of standard entities.

        /**
         * The constant declaration for "{@code false}".
         */
        public static readonly ConstDeclaration FalseDecl = DeclareStdConst("false", BooleanType);

        /**
         * The constant declaration for "{@code true}".
         */
        public static readonly ConstDeclaration TrueDecl = DeclareStdConst("true", BooleanType);

        /**
         * The constant declaration for "{@code maxint}".
         */
        public static readonly ConstDeclaration MaxintDecl = DeclareStdConst("maxint", IntegerType);

        /**
         * The unary operator declaration for "{@code \}" (logical not).
         */
        public static readonly UnaryOperatorDeclaration NotDecl = DeclareStdUnaryOp("\\", BooleanType,
            BooleanType);

        /**
         * The binary operator declaration for "{@code /\}" (logical and).
         */
        public static readonly BinaryOperatorDeclaration AndDecl = DeclareStdBinaryOp("/\\", BooleanType,
            BooleanType, BooleanType);

        /**
         * The binary operator declaration for "{@code \/}" (logical or).
         */
        public static readonly BinaryOperatorDeclaration OrDecl = DeclareStdBinaryOp("\\/", BooleanType,
            BooleanType, BooleanType);

        /**
         * The binary operator declaration for "{@code +}" (addition).
         */
        public static readonly BinaryOperatorDeclaration AddDecl = DeclareStdBinaryOp("+", IntegerType,
            IntegerType, IntegerType);

        /**
         * The binary operator declaration for "{@code -}" (subtraction).
         */
        public static readonly BinaryOperatorDeclaration SubtractDecl = DeclareStdBinaryOp("-",
            IntegerType, IntegerType, IntegerType);

        /**
         * The binary operator declaration for "{@code *}" (multiplication).
         */
        public static readonly BinaryOperatorDeclaration MultiplyDecl = DeclareStdBinaryOp("*",
            IntegerType, IntegerType, IntegerType);

        /**
         * The binary operator declaration for "{@code /}" (division).
         */
        public static readonly BinaryOperatorDeclaration DivideDecl = DeclareStdBinaryOp("/", IntegerType,
            IntegerType, IntegerType);

        /**
         * The binary operator declaration for "{@code //}" (modulo).
         */
        public static readonly BinaryOperatorDeclaration ModuloDecl = DeclareStdBinaryOp("//", IntegerType,
            IntegerType, IntegerType);

        /**
         * The binary operator declaration for "{@code =}" (equals).
         */
        public static readonly BinaryOperatorDeclaration EqualDecl = DeclareStdBinaryOp("=", AnyType,
            AnyType, BooleanType);

        /**
         * The binary operator declaration for "{@code \=}" (not equals).
         */
        public static readonly BinaryOperatorDeclaration UnequalDecl = DeclareStdBinaryOp("\\=", AnyType,
            AnyType, BooleanType);

        /**
         * The binary operator declaration for "{@code <}" (less than).
         */
        public static readonly BinaryOperatorDeclaration LessDecl = DeclareStdBinaryOp("<", IntegerType,
            IntegerType, BooleanType);

        /**
         * The binary operator declaration for "{@code >=}" (greater than or equal).
         */
        public static readonly BinaryOperatorDeclaration NotLessDecl = DeclareStdBinaryOp(">=",
            IntegerType, IntegerType, BooleanType);

        /**
         * The binary operator declaration for "{@code >}" (greater than).
         */
        public static readonly BinaryOperatorDeclaration GreaterDecl = DeclareStdBinaryOp(">", IntegerType,
            IntegerType, BooleanType);

        /**
         * The binary operator declaration for "{@code <=}" (less than or equal).
         */
        public static readonly BinaryOperatorDeclaration NotGreaterDecl = DeclareStdBinaryOp("<=",
            IntegerType, IntegerType, BooleanType);


        /**
         * Creates a small AST to represent the declaration of a standard type.
         * 
         * @param id
         *          the name of the type
         * @param typedenoter
         *          the type of the declaration
         * @return a TypeDeclaration for the given identifier to the given type
         */
        static TypeDeclaration DeclareStdType(string id, TypeDenoter typedenoter)
        {
            var ident = new Identifier(id);
            var binding = new TypeDeclaration(ident, typedenoter);
            return binding;
        }

        /**
         * Creates a small AST to represent the declaration of a standard constant.
         * 
         * @param id
         *          the name of the constant
         * @param constType
         *          the type of the constant declaration
         * @return a ConstDeclaration for the given identifier to the given type
         */
        static ConstDeclaration DeclareStdConst(string id, TypeDenoter constType)
        {
            var ident = new Identifier(id);
            // constExpr used only as a placeholder for constType
            var constExpr = new EmptyExpression();
            constExpr.Type = constType;
            var binding = new ConstDeclaration(ident, constExpr);
            return binding;
        }



       

        /**
         * Creates a small AST to represent the declaration of a unary operator. This
         * declaration summarizes the operator's type information.
         * 
         * @param op
         *          the spelling of the operator
         * @param argType
         *          the type of the argument of the unary operator
         * @param resultType
         *          the type of the result
         * @return a UnaryOperatorDeclaration of the given operator with the given
         *         argument type and returning the given result type
         */
        static UnaryOperatorDeclaration DeclareStdUnaryOp(string op, TypeDenoter argType,
            TypeDenoter resultType)
        {
            var opAst = new Operator(op);
            var binding = new UnaryOperatorDeclaration(opAst, argType, resultType);
            return binding;
        }

        /**
         * Creates a small AST to represent the declaration of a binary operator. This
         * declaration summarizes the operator's type information.
         * 
         * @param op
         *          the spelling of the operator
         * @param arg1Type
         *          the type of the first argument of the binary operator
         * @param arg2Type
         *          the type of the second argument of the binary operator
         * @param resultType
         *          the type of the result
         * @return a BinaryOperatorDeclaration of the given operator with the given
         *         argument types and returning the given result type
         */
        static BinaryOperatorDeclaration DeclareStdBinaryOp(string op, TypeDenoter arg1Type,
            TypeDenoter arg2Type, TypeDenoter resultType)
        {
            var opAst = new Operator(op, SourcePosition.Empty);
            var binding = new BinaryOperatorDeclaration(opAst, arg1Type, arg2Type, resultType);
            return binding;
        }

    }
}