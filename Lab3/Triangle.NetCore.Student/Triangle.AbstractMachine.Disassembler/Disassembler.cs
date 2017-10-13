using System;
using System.IO;

namespace Triangle.AbstractMachine
{
    /**
 * Disassembles the TAM code in the given file, and displays the instructions on
 * standard output. For example:
 * 
 * <pre>
 *   java TAM.Disassembler obj.tam
 * </pre>
 *
 * <p>Copyright 1991 David A. Watt, University of Glasgow<br>
 * Copyright 1998 Deryck F. Brown, The Robert Gordon University</p>
 *
 */

    public class Disassembler
    {

        /**
         * Writes the r-field of an instruction in the form "l<I>reg</I>r", where l
         * and r are the bracket characters to use.
         * 
         * @param leftbracket
         *          the character to print before the register.
         * @param register
         *          the number of the register.
         * @param rightbracket
         *          the character to print after the register.
         */
        void WriteR(char leftbracket, Register register, char rightbracket)
        {
            Console.Write(leftbracket);
            Console.Write(register.ToString());
            Console.Write(rightbracket);
        }

        /**
         * Writes a void n-field of an instruction.
         */
        void BlankN()
        {
            Console.Write("      ");
        }

        // Writes the n-field of an instruction.
        /**
         * Writes the n-field of an instruction in the form "(n)".
         * 
         * @param length
         *          the integer to write.
         */
        void WriteLength(int length)
        {
            Console.Write("(" + length + ") ");
            if (length < 10)
            {
                Console.Write("  ");
            }
            else if (length < 100)
            {
                Console.Write(" ");
            }
        }

        /**
         * Writes the d-field of an instruction.
         * 
         * @param operand
         *          the integer to write.
         */
        void WriteOperand(int operand)
        {
            Console.Write(operand);
        }

        /**
         * Writes the given instruction in assembly-code format.
         * 
         * @param instr
         *          the instruction to display.
         */
        void WriteInstruction(Instruction instr)
        {

            var opcode = instr.OpCode.ToString();
            Console.Write("{0,-6}", opcode);

            switch (instr.OpCode)
            {

                case OpCode.LOAD:
                case OpCode.STORE:
                case OpCode.JUMPIF:
                    WriteLength(instr.Length);
                    WriteOperand(instr.Operand);
                    WriteR('[', instr.Register, ']');
                    break;

                case OpCode.LOADA:
                case OpCode.JUMP:
                    BlankN();
                    WriteOperand(instr.Operand);
                    WriteR('[', instr.Register, ']');
                    break;

                case OpCode.LOADI:
                    WriteLength(instr.Length);
                    break;

                case OpCode.LOADL:
                case OpCode.PUSH:
                    BlankN();
                    WriteOperand(instr.Operand);
                    break;

                case OpCode.STOREI:
                    WriteLength(instr.Length);
                    break;

                case OpCode.CALL:
                    if (instr.Register == Register.PB)
                    {
                        BlankN();
                        Console.Write((Primitive)instr.Operand);
                    }
                    else
                    {
                        WriteR('(', (Register)instr.Length, ')');
                        Console.Write("  ");
                        WriteOperand(instr.Operand);
                        WriteR('[', instr.Register, ']');
                    }
                    break;

                case OpCode.POP:
                case OpCode.RETURN:
                    WriteLength(instr.Length);
                    WriteOperand(instr.Operand);
                    break;

                case OpCode.CALLI:
                case OpCode.JUMPI:
                case OpCode.HALT:
                    break;
            }
        }

        /**
         * Writes all instructions of the program in code store.
         * 
         * @param codeTop
         *          the address following the last instruction of the program
         */
        void DisassembleProgram(int codeTop)
        {
            for (var addr = Machine.CodeBase; addr < codeTop; addr++)
            {
                Console.Write("{0:D4}: ", addr);
                WriteInstruction(Machine.Code[addr]);
                Console.WriteLine();
            }
        }

        // LOADING

        /**
         * Loads the TAM object program into code store from the named file.
         * 
         * @param objectName
         *          the name of the file containing the program.
         * @return the address following the last instruction of the loaded program
         */
        int LoadObjectProgram(string objectName)
        {

            using (var objectStream = new FileStream(objectName, FileMode.Open))
            {
                try
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
        }

        // DISASSEMBLE

        /**
         * Runs the disassembler with the given command-line arguments. There is a
         * single, optional argument that is the filename of the object code to be
         * disassembled. If omitted, this defaults to the file "obj.tam" in the
         * current directory.
         * 
         * @param args
         *          the command-line arguments
         */
        public static void Main(string[] args)
        {
            Console.WriteLine("********** TAM Disassembler (C# Version 3.0) **********");

            Disassembler disassembler = new Disassembler();

            var objectName = args.Length == 1 ? args[0] : "obj.tam";
            var codeTop = disassembler.LoadObjectProgram(objectName);
            disassembler.DisassembleProgram(codeTop);
        }
    }
}