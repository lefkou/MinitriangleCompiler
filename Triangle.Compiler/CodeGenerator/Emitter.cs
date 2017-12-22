using System;
using System.IO;
using Triangle.AbstractMachine;

namespace Triangle.Compiler.CodeGenerator
{
    public class Emitter
    {

        // OBJECT CODE

        // Implementation notes:
        // Object code is generated directly into the TAM Code Store, starting at
        // CB.
        // The address of the next instruction is held in nextInstrAddr.

        ErrorReporter _errorReporter;

        int _nextInstrAddr;

        public Emitter(ErrorReporter errorReporter)
        {
            _errorReporter = errorReporter;
            _nextInstrAddr = Machine.CodeBase;
        }

        public int NextInstrAddr
        {
            get { return _nextInstrAddr; }
        }

        public int Emit(OpCode op)
        {
            return Emit(op, 0, 0, 0);
        }

        public int Emit(OpCode op, int operand)
        {
            return Emit(op, 0, 0, operand);
        }

        public int Emit(OpCode op, int length, int operand)
        {
            return Emit(op, length, 0, operand);
        }

        public int Emit(OpCode op, Register staticRegister, Register register, int operand)
        {
            return Emit(op, (int)staticRegister, register, operand);
        }

        public int Emit(OpCode op, Register register, int operand)
        {
            return Emit(op, 0, register, operand);
        }

        public int Emit(OpCode op, Register register)
        {
            return Emit(op, 0, register, 0);
        }

        public int Emit(OpCode op, int length, Register register)
        {
            return Emit(op, length, register, 0);
        }

        public int Emit(OpCode op, Register staticRegister, Register register, Primitive primitive)
        {
            return Emit(op, (int)staticRegister, register, (int)primitive);
        }

        /// <summary>
        /// Appends an instruction, with the given fields, to the object code.
        /// </summary>
        /// <param name="op">the opcode</param>
        /// <param name="length">the length field</param>
        /// <param name="register">the register field</param>
        /// <param name="operand">the operand field</param>
        /// <returns>the code address of the new instruction</returns>
        public int Emit(OpCode op, int length, Register register, int operand)
        {

            if (length > 255)
            {
                _errorReporter.ReportRestriction("length of operand can't exceed 255 words");
                length = 255; // to allow code generation to continue
            }

            Instruction nextInstr = new Instruction(op, register, length, operand);

            int currentInstrAddr = _nextInstrAddr;
            if (_nextInstrAddr == Machine.PrimitiveBase)
            {
                _errorReporter.ReportRestriction("too many instructions for code segment");
            }
            else
            {
                Machine.Code[_nextInstrAddr++] = nextInstr;
            }
            return currentInstrAddr;

        }

        // Patches the d-field of the instruction at address addr with the next
        // instruction address.
        public void Patch(int addr)
        {
            Machine.Code[addr].Operand = _nextInstrAddr;
        }

        /**
         * Saves the object program in the given object file.
         * 
         * @param objectFile
         *          the object file
         */
        public void SaveObjectProgram(string objectFileName)
        {
            try
            {
                using (var objectStream = new FileStream(objectFileName, FileMode.OpenOrCreate))
                {
                    for (int addr = Machine.CodeBase; addr < _nextInstrAddr; addr++)
                    {
                        Machine.Code[addr].Write(objectStream);
                    }
                }
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine("Error opening object file: " + fnfe);
            }
            catch (IOException ioe)
            {
                Console.WriteLine("Error writing object file: " + ioe);
            }
        }
    }
}