using System;
using System.IO;


namespace Triangle.AbstractMachine.Interpreter
{
    public class Interpreter
    {

        // DATA STORE

        const int MaximumDataSize = 1024;

        int[] data = new int[MaximumDataSize];

        // DATA STORE REGISTERS AND OTHER REGISTERS

        const int StackBase = 0;
        const int HeapBase = MaximumDataSize;

        int _codeTop;
        int _codePointer;
        int _stackTop;
        int _heapTop;
        int _localBase;

        // status values
        enum Status
        {
            Running, Halted, FailedDatastoreFull, FailedInvalidCodeAddress, FailedInvalidInstruction,
            FailedOverflow, FailedZeroDivide, FailedIoError
        }

        Status _status;

        long _accumulator;

        int Content(Register register)
        {
            // Returns the current content of register r,
            // even if r is one of the pseudo-registers L1..L6.

            switch (register)
            {
                case Register.CB:
                    return Machine.CodeBase;
                case Register.CT:
                    return _codeTop;
                case Register.PB:
                    return Machine.PrimitiveBase;
                case Register.PT:
                    return Machine.PrimitiveTop;
                case Register.SB:
                    return StackBase;
                case Register.ST:
                    return _stackTop;
                case Register.HB:
                    return HeapBase;
                case Register.HT:
                    return _heapTop;
                case Register.LB:
                    return _localBase;
                case Register.L1:
                    return data[_localBase];
                case Register.L2:
                    return data[data[_localBase]];
                case Register.L3:
                    return data[data[data[_localBase]]];
                case Register.L4:
                    return data[data[data[data[_localBase]]]];
                case Register.L5:
                    return data[data[data[data[data[_localBase]]]]];
                case Register.L6:
                    return data[data[data[data[data[data[_localBase]]]]]];
                case Register.CP:
                    return _codePointer;
                default:
                    return 0;
            }
        }

        // PROGRAM STATUS

        void Dump()
        {
            // Writes a summary of the machine state.

            Console.WriteLine();
            Console.WriteLine("State of data store and registers:");
            Console.WriteLine();
            if (_heapTop == HeapBase)
            {
                Console.WriteLine("            |--------|          (heap is empty)");
            }
            else
            {
                Console.WriteLine("       HB-->");
                Console.WriteLine("            |--------|");
                for (int addr = HeapBase - 1; addr >= _heapTop; addr--)
                {
                    Console.Write(addr + ":");
                    if (addr == _heapTop)
                    {
                        Console.Write(" HT-->");
                    }
                    else
                    {
                        Console.Write("      ");
                    }
                    Console.WriteLine("|" + data[addr] + "|");
                }
                Console.WriteLine("            |--------|");
            }
            Console.WriteLine("            |////////|");
            Console.WriteLine("            |////////|");
            if (_stackTop == StackBase)
            {
                Console.WriteLine("            |--------|          (stack is empty)");
            }
            else
            {
                var dynamicLink = _localBase;
                var staticLink = _localBase;
                var localRegNum = Register.LB;
                Console.WriteLine("      ST--> |////////|");
                Console.WriteLine("            |--------|");
                for (var addr = _stackTop - 1; addr >= StackBase; addr--)
                {
                    Console.WriteLine("{0:D4}: ", addr);
                    if (addr == StackBase)
                    {
                        Console.Write("SB-->");
                    }
                    else if (addr == staticLink)
                    {
                        Console.Write(localRegNum.ToString());
                        Console.Write("-->");
                        staticLink = data[addr];
                        localRegNum = (Register)((int)localRegNum + 1);
                    }
                    else
                    {
                        Console.Write("     ");
                    }
                    if (addr == dynamicLink && dynamicLink != StackBase)
                    {
                        Console.Write("|SL=" + data[addr] + "|");
                    }
                    else if (addr == dynamicLink + 1 && dynamicLink != StackBase)
                    {
                        Console.Write("|DL=" + data[addr] + "|");
                    }
                    else if (addr == dynamicLink + 2 && dynamicLink != StackBase)
                    {
                        Console.Write("|RA=" + data[addr] + "|");
                    }
                    else
                    {
                        Console.Write("|" + data[addr] + "|");
                    }
                    Console.WriteLine();
                    if (addr == dynamicLink)
                    {
                        Console.WriteLine("            |--------|");
                        dynamicLink = data[addr + 1];
                    }
                }
            }
            Console.WriteLine();
        }

        void ShowStatus()
        {
            // Writes an indication of whether and why the program has terminated.
            Console.WriteLine();
            switch (_status)
            {
                case Status.Running:
                    Console.WriteLine("Program is running.");
                    break;
                case Status.Halted:
                    Console.WriteLine("Program has halted normally.");
                    break;
                case Status.FailedDatastoreFull:
                    Console.WriteLine("Program has failed due to exhaustion of Data Store.");
                    break;
                case Status.FailedInvalidCodeAddress:
                    Console.WriteLine("Program has failed due to an invalid code address.");
                    break;
                case Status.FailedInvalidInstruction:
                    Console.WriteLine("Program has failed due to an invalid instruction.");
                    break;
                case Status.FailedOverflow:
                    Console.WriteLine("Program has failed due to overflow.");
                    break;
                case Status.FailedZeroDivide:
                    Console.WriteLine("Program has failed due to division by zero.");
                    break;
                case Status.FailedIoError:
                    Console.WriteLine("Program has failed due to an IO error.");
                    break;
            }
            if (_status != Status.Halted)
            {
                Dump();
            }
        }

        // INTERPRETATION

        void CheckSpace(int spaceNeeded)
        {
            // Signals failure if there is not enough space to expand the stack or
            // heap by spaceNeeded.

            if (_heapTop - _stackTop < spaceNeeded)
            {
                _status = Status.FailedDatastoreFull;
            }
        }

        bool IsTrue(int datum)
        {
            // Tests whether the given datum represents true.
            return datum == Machine.TrueValue;
        }

        bool Equal(int size, int addr1, int addr2)
        {
            // Tests whether two multi-word objects are equal, given their common
            // size and their base addresses.

            for (var index = 0; index < size; index++)
            {
                if (data[addr1 + index] != data[addr2 + index])
                {
                    return false;
                }
            }
            return true;
        }

        int OverflowChecked(long datum)
        {
            // Signals failure if the datum is too large to fit into a single word,
            // otherwise returns the datum as a single word.

            if (-Machine.MaxintValue <= datum && datum <= Machine.MaxintValue)
            {
                return (int)datum;
            }
            _status = Status.FailedOverflow;
            return 0;
        }

        int ToInt(bool value)
        {
            return value ? Machine.TrueValue : Machine.FalseValue;
        }

        int currentChar;

        int ReadInt()
        {
            var temp = 0;
            var sign = 1;

            do
            {
                currentChar = Console.Read();
            } while (char.IsWhiteSpace((char)currentChar));

            while (currentChar == '-' || currentChar == '+')
            {
                sign = currentChar == '-' ? -1 : 1;
                currentChar = Console.Read();
            }

            while (char.IsDigit((char)currentChar))
            {
                temp = temp * 10 + currentChar - '0';
                currentChar = Console.Read();
            }

            return sign * temp;
        }

        void CallPrimitive(int primitiveDisplacement)
        {
            // Invokes the given primitive routine.

            int addr;
            int size;
            char ch;

            var primitive = (Primitive)primitiveDisplacement;
            switch (primitive)
            {
                case Primitive.ID:
                    break; // nothing to be done

                case Primitive.NOT:
                    data[_stackTop - 1] = ToInt(!IsTrue(data[_stackTop - 1]));
                    break;

                case Primitive.AND:
                    _stackTop--;
                    data[_stackTop - 1] = ToInt(IsTrue(data[_stackTop - 1]) && IsTrue(data[_stackTop]));
                    break;

                case Primitive.OR:
                    _stackTop--;
                    data[_stackTop - 1] = ToInt(IsTrue(data[_stackTop - 1]) || IsTrue(data[_stackTop]));
                    break;

                case Primitive.SUCC:
                    data[_stackTop - 1] = OverflowChecked(data[_stackTop - 1] + 1);
                    break;

                case Primitive.PRED:
                    data[_stackTop - 1] = OverflowChecked(data[_stackTop - 1] - 1);
                    break;

                case Primitive.NEG:
                    data[_stackTop - 1] = -data[_stackTop - 1];
                    break;

                case Primitive.ADD:
                    _stackTop--;
                    _accumulator = data[_stackTop - 1];
                    data[_stackTop - 1] = OverflowChecked(_accumulator + data[_stackTop]);
                    break;

                case Primitive.SUB:
                    _stackTop--;
                    _accumulator = data[_stackTop - 1];
                    data[_stackTop - 1] = OverflowChecked(_accumulator - data[_stackTop]);
                    break;

                case Primitive.MULT:
                    _stackTop--;
                    _accumulator = data[_stackTop - 1];
                    data[_stackTop - 1] = OverflowChecked(_accumulator * data[_stackTop]);
                    break;

                case Primitive.DIV:
                    _stackTop--;
                    _accumulator = data[_stackTop - 1];
                    if (data[_stackTop] != 0)
                    {
                        data[_stackTop - 1] = (int)(_accumulator / data[_stackTop]);
                    }
                    else
                    {
                        _status = Status.FailedZeroDivide;
                    }
                    break;

                case Primitive.MOD:
                    _stackTop--;
                    _accumulator = data[_stackTop - 1];
                    if (data[_stackTop] != 0)
                    {
                        data[_stackTop - 1] = (int)(_accumulator % data[_stackTop]);
                    }
                    else
                    {
                        _status = Status.FailedZeroDivide;
                    }
                    break;

                case Primitive.LT:
                    _stackTop--;
                    data[_stackTop - 1] = ToInt(data[_stackTop - 1] < data[_stackTop]);
                    break;

                case Primitive.LE:
                    _stackTop--;
                    data[_stackTop - 1] = ToInt(data[_stackTop - 1] <= data[_stackTop]);
                    break;

                case Primitive.GE:
                    _stackTop--;
                    data[_stackTop - 1] = ToInt(data[_stackTop - 1] >= data[_stackTop]);
                    break;

                case Primitive.GT:
                    _stackTop--;
                    data[_stackTop - 1] = ToInt(data[_stackTop - 1] > data[_stackTop]);
                    break;

                case Primitive.EQ:
                    size = data[_stackTop - 1]; // size of each comparand
                    _stackTop -= 2 * size;
                    data[_stackTop - 1] = ToInt(Equal(size, _stackTop - 1, _stackTop - 1 + size));
                    break;

                case Primitive.NE:
                    size = data[_stackTop - 1]; // size of each comparand
                    _stackTop -= 2 * size;
                    data[_stackTop - 1] = ToInt(!Equal(size, _stackTop - 1, _stackTop - 1 + size));
                    break;

                case Primitive.EOL:
                    data[_stackTop] = ToInt(currentChar == '\n');
                    _stackTop++;
                    break;

                case Primitive.EOF:
                    data[_stackTop] = ToInt(currentChar == -1);
                    _stackTop++;
                    break;

                case Primitive.GET:
                    _stackTop--;
                    addr = data[_stackTop];
                    try
                    {
                        currentChar = Console.Read();
                    }
                    catch (IOException)
                    {
                        _status = Status.FailedIoError;
                    }
                    data[addr] = currentChar;
                    break;

                case Primitive.PUT:
                    _stackTop--;
                    ch = (char)data[_stackTop];
                    Console.Write(ch);
                    break;

                case Primitive.GETEOL:
                    try
                    {
                        while ((currentChar = Console.Read()) != '\n') { }
                    }
                    catch (IOException)
                    {
                        _status = Status.FailedIoError;
                    }
                    break;

                case Primitive.PUTEOL:
                    Console.WriteLine();
                    break;

                case Primitive.GETINT:
                    _stackTop--;
                    addr = data[_stackTop];
                    try
                    {
                        _accumulator = ReadInt();
                    }
                    catch (IOException)
                    {
                        _status = Status.FailedIoError;
                    }
                    data[addr] = (int)_accumulator;
                    break;

                case Primitive.PUTINT:
                    _stackTop--;
                    _accumulator = data[_stackTop];
                    Console.Write(_accumulator);
                    break;

                case Primitive.NEW:
                    size = data[_stackTop - 1];
                    CheckSpace(size);
                    _heapTop -= size;
                    data[_stackTop - 1] = _heapTop;
                    break;

                case Primitive.DISPOSE:
                    _stackTop--; // no action taken at present
                    break;
            }
        }

        void InterpretProgram()
        {
            // Runs the program in code store.

            // Initialize registers ...
            _stackTop = StackBase;
            _heapTop = HeapBase;
            _localBase = StackBase;
            _codePointer = Machine.CodeBase;
            _status = Status.Running;
            do
            {
                // Fetch instruction ...
                var currentInstr = Machine.Code[_codePointer];
                // Decode instruction ...
                var op = currentInstr.OpCode;
                var register = currentInstr.Register;
                var length = currentInstr.Length;
                var operand = currentInstr.Operand;
                // Execute instruction ...
                switch (op)
                {
                    case OpCode.LOAD:
                        var addr = operand + Content(register);
                        CheckSpace(length);
                        for (var index = 0; index < length; index++)
                        {
                            data[_stackTop + index] = data[addr + index];
                        }
                        _stackTop += length;
                        _codePointer++;
                        break;

                    case OpCode.LOADA:
                        addr = operand + Content(register);
                        CheckSpace(1);
                        data[_stackTop++] = addr;
                        _codePointer++;
                        break;

                    case OpCode.LOADI:
                        _stackTop--;
                        addr = data[_stackTop];
                        CheckSpace(length);
                        for (var index = 0; index < length; index++)
                        {
                            data[_stackTop + index] = data[addr + index];
                        }
                        _stackTop += length;
                        _codePointer++;
                        break;

                    case OpCode.LOADL:
                        CheckSpace(1);
                        data[_stackTop++] = operand;
                        _codePointer++;
                        break;

                    case OpCode.STORE:
                        addr = operand + Content(register);
                        _stackTop -= length;
                        for (var index = 0; index < length; index++)
                        {
                            data[addr + index] = data[_stackTop + index];
                        }
                        _codePointer++;
                        break;

                    case OpCode.STOREI:
                        _stackTop--;
                        addr = data[_stackTop];
                        _stackTop -= length;
                        for (var index = 0; index < length; index++)
                        {
                            data[addr + index] = data[_stackTop + index];
                        }
                        _codePointer++;
                        break;

                    case OpCode.CALL:
                        addr = operand + Content(register);
                        if (addr >= Machine.PrimitiveBase)
                        {
                            CallPrimitive(addr - Machine.PrimitiveBase);
                            _codePointer++;
                        }
                        else
                        {
                            CheckSpace(3);
                            if (0 <= length && length <= 15)
                            {
                                data[_stackTop] = Content((Register)length); // static link
                            }
                            else
                            {
                                _status = Status.FailedInvalidInstruction;
                            }
                            data[_stackTop + 1] = _localBase; // dynamic link
                            data[_stackTop + 2] = _codePointer + 1; // return address
                            _localBase = _stackTop;
                            _stackTop += 3;
                            _codePointer = addr;
                        }
                        break;

                    case OpCode.CALLI:
                        _stackTop -= 2;
                        addr = data[_stackTop + 1];
                        if (addr >= Machine.PrimitiveBase)
                        {
                            CallPrimitive(addr - Machine.PrimitiveBase);
                            _codePointer++;
                        }
                        else
                        {
                            // data[ST] = static link already
                            data[_stackTop + 1] = _localBase; // dynamic link
                            data[_stackTop + 2] = _codePointer + 1; // return address
                            _localBase = _stackTop;
                            _stackTop += 3;
                            _codePointer = addr;
                        }
                        break;

                    case OpCode.RETURN:
                        addr = _localBase - operand;
                        _codePointer = data[_localBase + 2];
                        _localBase = data[_localBase + 1];
                        _stackTop -= length;
                        for (var index = 0; index < length; index++)
                        {
                            data[addr + index] = data[_stackTop + index];
                        }
                        _stackTop = addr + length;
                        break;

                    case OpCode.PUSH:
                        CheckSpace(operand);
                        _stackTop += operand;
                        _codePointer++;
                        break;

                    case OpCode.POP:
                        addr = _stackTop - length - operand;
                        _stackTop -= length;
                        for (var index = 0; index < length; index++)
                        {
                            data[addr + index] = data[_stackTop + index];
                        }
                        _stackTop = addr + length;
                        _codePointer++;
                        break;

                    case OpCode.JUMP:
                        _codePointer = operand + Content(register);
                        break;

                    case OpCode.JUMPI:
                        _stackTop--;
                        _codePointer = data[_stackTop];
                        break;

                    case OpCode.JUMPIF:
                        _stackTop--;
                        if (data[_stackTop] == length)
                        {
                            _codePointer = operand + Content(register);
                        }
                        else
                        {
                            _codePointer++;
                        }
                        break;

                    case OpCode.HALT:
                        _status = Status.Halted;
                        break;
                }
                if (_codePointer < Machine.CodeBase || _codePointer >= _codeTop)
                {
                    _status = Status.FailedInvalidCodeAddress;
                }
            } while (_status == Status.Running);
        }

        // LOADING

        int LoadObjectProgram(string objectName)
        {
            // Loads the TAM object program into code store from the named file.

            try
            {
                using (var objectStream = new FileStream(objectName, FileMode.Open))
                {

                    var addr = Machine.CodeBase;
                    while (true)
                    {
                        var instr = Instruction.Read(objectStream);
                        if (instr == null)
                        {
                            break;
                        }
                        Machine.Code[addr++] = instr;
                    }
                    return addr;
                }
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine("Error opening object file: " + fnfe);
            }
            catch (IOException ioe)
            {
                Console.WriteLine("Error reading object file: " + ioe);
            }
            return Machine.CodeBase;
        }

        // RUNNING

        /**
         * Runs the interpreter with the given command-line arguments. There is a
         * single, optional argument that is the filename of the object code to be
         * interpreted. If omitted, this defaults to the file "obj.tam" in the current
         * directory.
         * 
         * @param args
         *          the command-line arguments
         */
        public static void Main(string[] args)
        {
            Console.WriteLine("********** TAM Interpreter (.NET CORE) **********");

            var objectName = args.Length == 1 ? args[0] : "obj.tam";
            var interpreter = new Interpreter();
            interpreter._codeTop = interpreter.LoadObjectProgram(objectName);
            if (interpreter._codeTop != Machine.CodeBase)
            {
                interpreter.InterpretProgram();
                interpreter.ShowStatus();
            }
        }
    }
}
