# Compiler for Triangle Language written in C&#35;

This is a C# version of the Triangle Tools (compiler, disassembler and interpreter) used in the textbook:

"Programming Language Processors in Java" by D.A. Watt and D.F. Brown, Pearson (2000).

***

Different parts were used to make this compiler:

1. Lexical Analysis - Scanner
2. Syntax Analysis - Parser
3. Semantic Analysis - Checker
4. Code Generation - Encoder


Translates a language called Triangle to machine code.

Files of the triangle files *.tri* can be found under `Triangle.Compiler/tests/programs/`

It was ran .net framework version 1.1 with docker.

In order to run it with docker use:

`docker run -it --name dotnet1.1 -v $(pwd):/src/app dotnet1.1sdk
`

More info on C#-docker: http://www.lefkousis.com/How-dotnet-docker/
