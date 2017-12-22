using Triangle.AbstractMachine;
using Triangle.Compiler.CodeGenerator.Entities;
using Triangle.Compiler.SyntaxTrees;
using Triangle.Compiler.SyntaxTrees.Declarations;
using Triangle.Compiler.SyntaxTrees.Vnames;

namespace Triangle.Compiler.CodeGenerator
{
    public partial class Encoder
    {
        ErrorReporter _errorReporter;

        Emitter _emitter;

        public Encoder(ErrorReporter errorReporter)
        {
            _errorReporter = errorReporter;
            _emitter = new Emitter(_errorReporter);
            ElaborateStdEnvironment();
        }

        public void EncodeRun(Program ast)
        {
            ast.Visit(this, Frame.Initial);
            _emitter.Emit(OpCode.HALT);
        }

        public void SaveObjectProgram(string objectFileName)
        {
            _emitter.SaveObjectProgram(objectFileName);
        }

        // REGISTERS

        // Generates code to fetch the value of a named constant or variable
        // and push it on to the stack.
        // currentLevel is the routine level where the vname occurs.
        // frameSize is the anticipated size of the local stack frame when
        // the constant or variable is fetched at run-time.
        // valSize is the size of the constant or variable's value.

        void EncodeAssign(Vname vname, Frame frame, int valSize)
        {

            var baseObject = vname.Visit(this, frame) as AddressableEntity;
            // If indexed = true, code will have been generated to load an index
            // value.
            if (valSize > 255)
            {
                _errorReporter.ReportRestriction("can't store values larger than 255 words");
                valSize = 255; // to allow code generation to continue
            }
            baseObject.EncodeAssign(_emitter, frame, valSize, vname);
        }

        // Generates code to fetch the value of a named constant or variable
        // and push it on to the stack.
        // currentLevel is the routine level where the vname occurs.
        // frameSize is the anticipated size of the local stack frame when
        // the constant or variable is fetched at run-time.
        // valSize is the size of the constant or variable's value.

        void EncodeFetch(Vname vname, Frame frame, int valSize)
        {

            IFetchableEntity baseObject = vname.Visit(this, frame);
            // If indexed = true, code will have been generated to load an index
            // value.
            if (valSize > 255)
            {
                _errorReporter.ReportRestriction("can't load values larger than 255 words");
                valSize = 255; // to allow code generation to continue
            }
            baseObject.EncodeFetch(_emitter, frame, valSize, vname);
        }

        // Generates code to compute and push the address of a named variable.
        // vname is the program phrase that names this variable.
        // currentLevel is the routine level where the vname occurs.
        // frameSize is the anticipated size of the local stack frame when
        // the variable is addressed at run-time.

        void EncodeFetchAddress(Vname vname, Frame frame)
        {

            var baseObject = vname.Visit(this, frame) as AddressableEntity;
            // If indexed = true, code will have been generated to load an index
            // value.
            baseObject.EncodeFetchAddress(_emitter, frame, vname);

        }

        // Decides run-time representation of a standard constant.
        void ElaborateStdConst(ConstDeclaration decl, int value)
        {
            int typeSize = decl.Expression.Type.Visit(this, null);
            decl.Entity = new KnownValue(typeSize, value);
            Encoder.WriteTableDetails(decl);
        }

        // Decides run-time representation of a standard routine.
        void ElaborateStdPrimRoutine(Declaration routineDeclaration, Primitive primitive)
        {
            routineDeclaration.Entity = new PrimitiveRoutine(Machine.ClosureSize, primitive);
            Encoder.WriteTableDetails(routineDeclaration);
        }

        void ElaborateStdEqRoutine(Declaration routineDeclaration, Primitive primitive)
        {
            routineDeclaration.Entity = new EqualityProcedure(Machine.ClosureSize, primitive);
            Encoder.WriteTableDetails(routineDeclaration);
        }

        void ElaborateStdEnvironment()
        {
            ElaborateStdConst(StandardEnvironment.FalseDecl, Machine.FalseValue);
            ElaborateStdConst(StandardEnvironment.TrueDecl, Machine.TrueValue);
            ElaborateStdPrimRoutine(StandardEnvironment.NotDecl, Primitive.NOT);
            ElaborateStdPrimRoutine(StandardEnvironment.AndDecl, Primitive.AND);
            ElaborateStdPrimRoutine(StandardEnvironment.OrDecl, Primitive.OR);

            ElaborateStdConst(StandardEnvironment.MaxintDecl, Machine.MaxintValue);
            ElaborateStdPrimRoutine(StandardEnvironment.AddDecl, Primitive.ADD);
            ElaborateStdPrimRoutine(StandardEnvironment.SubtractDecl, Primitive.SUB);
            ElaborateStdPrimRoutine(StandardEnvironment.MultiplyDecl, Primitive.MULT);
            ElaborateStdPrimRoutine(StandardEnvironment.DivideDecl, Primitive.DIV);
            ElaborateStdPrimRoutine(StandardEnvironment.ModuloDecl, Primitive.MOD);

            ElaborateStdPrimRoutine(StandardEnvironment.LessDecl, Primitive.LT);
            ElaborateStdPrimRoutine(StandardEnvironment.NotGreaterDecl, Primitive.LE);
            ElaborateStdPrimRoutine(StandardEnvironment.GreaterDecl, Primitive.GT);
            ElaborateStdPrimRoutine(StandardEnvironment.NotLessDecl, Primitive.GE);

            ElaborateStdPrimRoutine(StandardEnvironment.ChrDecl, Primitive.ID);
            ElaborateStdPrimRoutine(StandardEnvironment.OrdDecl, Primitive.ID);

            ElaborateStdPrimRoutine(StandardEnvironment.EolDecl, Primitive.EOL);
            ElaborateStdPrimRoutine(StandardEnvironment.EofDecl, Primitive.EOF);
            ElaborateStdPrimRoutine(StandardEnvironment.GetDecl, Primitive.GET);
            ElaborateStdPrimRoutine(StandardEnvironment.PutDecl, Primitive.PUT);
            ElaborateStdPrimRoutine(StandardEnvironment.GetintDecl, Primitive.GETINT);
            ElaborateStdPrimRoutine(StandardEnvironment.PutintDecl, Primitive.PUTINT);
            ElaborateStdPrimRoutine(StandardEnvironment.GeteolDecl, Primitive.GETEOL);
            ElaborateStdPrimRoutine(StandardEnvironment.PuteolDecl, Primitive.PUTEOL);

            ElaborateStdEqRoutine(StandardEnvironment.EqualDecl, Primitive.EQ);
            ElaborateStdEqRoutine(StandardEnvironment.UnequalDecl, Primitive.NE);
        }

        static void WriteTableDetails(AbstractSyntaxTree ast)
        {
        }
    }
}