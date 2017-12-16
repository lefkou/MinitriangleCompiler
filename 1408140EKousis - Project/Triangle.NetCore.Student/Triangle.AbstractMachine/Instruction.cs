using System;
using System.IO;

namespace Triangle.AbstractMachine
{
    public class Instruction
    {
        // C# has no type synonyms, so the following representations are
        // assumed:
        //
        // type
        // OpCode = 0..15; {4 bits unsigned}
        // Length = 0..255; {8 bits unsigned}
        // Operand = -32767..+32767; {16 bits signed}

        // Represents TAM instructions.
        readonly OpCode _opCode;
        readonly Register _register;
        readonly int _length;
        int _operand; // Not final to allow for patching jump address

        /// <summary>
        /// Creates a Triangle abstract machine instruction with the given op-code,
        /// register, length and operand.
        /// </summary>
        /// <param name="opcode">the op-code field</param>
        /// <param name="register">the register field</param>
        /// <param name="length">the length field</param>
        /// <param name="operand">the operand field</param>
        public Instruction(OpCode opcode, Register register, int length, int operand)
        {
            _opCode = opcode;
            _register = register;
            _length = length;
            _operand = operand;
        }

        public OpCode OpCode
        {
            get { return _opCode; }
        }

        public Register Register
        {
            get { return _register; }
        }

        public int Length
        {
            get { return _length; }
        }

        public int Operand
        {
            get { return _operand; }
            set { _operand = value; }
        }

        /// <summary>
        /// Writes this Triangle abstract machine instruction to the given output
        /// stream.
        /// </summary>
        /// <param name="output">the output stream</param>
        /// <throws type="IOException">if the write fails</throws>
        public void Write(Stream output)
        {
            output.WriteByte((byte)_opCode);
            output.WriteByte((byte)_register);
            output.WriteByte((byte)_length);
            output.Write(BitConverter.GetBytes(_operand), 0, 2);
        }

        /// <summary>
        /// Reads the field values of a Triangle abstract machine instruction from the
        /// given input stream, and returns a new {@link Instruction} object with these
        /// fields.
        /// </summary>
        /// <param name="input">the input stream</param>
        /// <returns>the instruction read from the input</returns>
        /// <throws type="IOException">if the read fails</throws>
        public static Instruction Read(Stream input)
        {
            try
            {
                var bytes = new byte[5];
                if (input.Read(bytes, 0, 5) != 5)
                {
                    return null;
                }
                OpCode op = (OpCode)bytes[0];
                Register register = (Register)bytes[1];
                byte length = bytes[2];
                short operand = BitConverter.ToInt16(bytes, 3);
                return new Instruction(op, register, length, operand);
            }
            catch (EndOfStreamException)
            {
                return null;
            }
        }
    }
}