using Triangle.Compiler.SyntaxTrees.Commands;
using Triangle.Compiler.SyntaxTrees.Declarations;
using Triangle.Compiler.SyntaxTrees.Expressions;
using Triangle.Compiler.SyntaxTrees.Formals;
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
         * The procedure declaration for "{@code get(var Char)}".
         */
        public static readonly ProcDeclaration GetDecl = DeclareStdProc("get",
      new SingleFormalParameterSequence(new VarFormalParameter(CharType)));

        /**
         * The procedure declaration for "{@code put(Char)}".
         */
        public static readonly ProcDeclaration PutDecl = DeclareStdProc("put",
            new SingleFormalParameterSequence(new ConstFormalParameter(CharType)));

        /**
         * The procedure declaration for "{@code getint(var Integer)}".
         */
        public static readonly ProcDeclaration GetintDecl = DeclareStdProc("getint",
            new SingleFormalParameterSequence(new VarFormalParameter(IntegerType)));

        /**
         * The procedure declaration for "{@code putint(Integer)}".
         */
        public static readonly ProcDeclaration PutintDecl = DeclareStdProc("putint",
            new SingleFormalParameterSequence(new ConstFormalParameter(IntegerType)));

        /**
         * The procedure declaration for "{@code geteol()}".
         */
        public static readonly ProcDeclaration GeteolDecl = DeclareStdProc("geteol",
            new EmptyFormalParameterSequence());

        /**
         * The procedure declaration for "{@code puteol()}".
         */
        public static readonly ProcDeclaration PuteolDecl = DeclareStdProc("puteol",
            new EmptyFormalParameterSequence());

        /**
         * The function declaration for "{@code chr(Integer) : Char}".
         */
        public static readonly FuncDeclaration ChrDecl = DeclareStdFunc("chr",
            new SingleFormalParameterSequence(new ConstFormalParameter(IntegerType)), CharType);

        /**
         * The function declaration for "{@code ord(Char) : Integer}".
         */
        public static readonly FuncDeclaration OrdDecl = DeclareStdFunc("ord",
            new SingleFormalParameterSequence(new ConstFormalParameter(CharType)), IntegerType);

        /**
         * The function declaration for "{@code eol() : Boolean}".
         */
        public static readonly FuncDeclaration EolDecl = DeclareStdFunc("eol",
            new EmptyFormalParameterSequence(), BooleanType);

        /**
         * The function declaration for "{@code eof() : Boolean}".
         */
        public static readonly FuncDeclaration EofDecl = DeclareStdFunc("eof",
            new EmptyFormalParameterSequence(), BooleanType);

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
         * Creates a small AST to represent the declaration of a standard procedure.
         * 
         * @param id
         *          the name of the procedure
         * @param fps
         *          the formal parameter sequence for the procedure
         * @return a ProcDeclaration for the given identifier with the given formal
         *         parameters
         */
        static ProcDeclaration DeclareStdProc(string id, FormalParameterSequence fps)
        {
            var ident = new Identifier(id);
            var binding = new ProcDeclaration(ident, fps);
            return binding;
        }

        /**
         * Creates a small AST to represent the declaration of a standard function.
         * 
         * @param id
         *          the name of the function
         * @param fps
         *          the formal parameter sequence for the function
         * @param resultType
         *          the type of the function result
         * @return a FuncDeclaration for the given identifier with the given formal
         *         parameters and returning the given result type
         */
        static FuncDeclaration DeclareStdFunc(string id, FormalParameterSequence fps,
            TypeDenoter resultType)
        {

            var ident = new Identifier(id);
            var binding = new FuncDeclaration(ident, fps, resultType);
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