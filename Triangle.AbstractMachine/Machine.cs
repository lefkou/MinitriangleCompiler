namespace Triangle.AbstractMachine
{
    public enum OpCode
    {
        LOAD, LOADA, LOADI, LOADL, STORE, STOREI, CALL, CALLI, RETURN, PUSH, POP, JUMP, JUMPI, JUMPIF,
        HALT
    }

    public enum Register
    {
        CB, CT, PB, PT, SB, ST, HB, HT, LB, L1, L2, L3, L4, L5, L6, CP
    }

    public enum Primitive
    {
        ID, NOT, AND, OR, SUCC, PRED, NEG, ADD, SUB, MULT, DIV, MOD, LT, LE, GE, GT, EQ, NE, EOL, EOF,
        GET, PUT, GETEOL, PUTEOL, GETINT, PUTINT, NEW, DISPOSE
    }

    public static class Machine
    {
        public const int MaximumRoutineLevel = 7;

        // CODE STORE

        public static Instruction[] Code = new Instruction[1024];

        // CODE STORE REGISTERS

        public const short CodeBase = 0;

        // = upper bound of code array + 1
        public const int PrimitiveBase = 1024;
        public const int PrimitiveTop = PrimitiveBase + 28;

        public const int BooleanSize = 1;
        public const int CharacterSize = 1;
        public const int IntegerSize = 1;
        public const int AddressSize = 1;
        public const int ClosureSize = 2 * AddressSize;
        public const int LinkDataSize = 3 * AddressSize;

        public const byte FalseValue = 0;
        public const byte TrueValue = 1;
        public const short MaxintValue = 32767;
    }
}