/*
    for the commands each time an object is 
    returned based on the AbstractSyntaxTree structure
    provided
*/




using Triangle.Compiler.SyntaxTrees.Commands;
using Triangle.Compiler.SyntaxTrees.Declarations;
using Triangle.Compiler.SyntaxTrees.Expressions;

namespace Triangle.Compiler.SyntacticAnalyzer
{
    public partial class Parser
    {
        ///////////////////////////////////////////////////////////////////////////////
        //
        // COMMANDS
        //
        ///////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Parses the command, and constructs an AST to represent its phrase
        /// structure.
        /// </summary>
        /// <returns>
        /// a <link>Triangle.SyntaxTrees.Commands.Command</link>
        /// </returns>
        /// <throws type="SyntaxError">
        /// a syntactic error
        /// </throws>
        Command ParseCommand()
        {
            var startLocation = _currentToken.Start;
            var command = ParseSingleCommand();
            while (_currentToken.Kind == TokenKind.Semicolon)
            {
                AcceptIt();
                var command2 = ParseSingleCommand();
                var commandPosition = new SourcePosition(startLocation, _currentToken.Finish);
                command = new SequentialCommand(command, command2, commandPosition);
            }
            return command;
        }

        /// <summary>
        /// Parses the single command, and constructs an AST to represent its phrase
        /// structure.
        /// </summary>
        /// <returns>
        /// a {@link triangle.compiler.syntax.trees.commands.Command}
        /// </returns>
        /// <throws type="SyntaxError">
        /// a syntactic error
        /// </throws>
        Command ParseSingleCommand()
        {

            var startLocation = _currentToken.Start;

            switch (_currentToken.Kind)
            {

                case TokenKind.Identifier:
                    {
                        var identifier = ParseIdentifier();
                        if (_currentToken.Kind == TokenKind.LeftParen)
                        {
                            AcceptIt();
                            var actuals = ParseActualParameterSequence();
                            Accept(TokenKind.RightParen);
                            var commandPosition = new SourcePosition(startLocation, _currentToken.Finish);
                            return new CallCommand(identifier, actuals, commandPosition);
                        }
                        else
                        {
                            var vname = ParseRestOfVname(identifier);
                            Accept(TokenKind.Becomes);
                            var expression = ParseExpression();
                            var commandPosition = new SourcePosition(startLocation, _currentToken.Finish);
                            return new AssignCommand(vname, expression, commandPosition);
                        }
                    }

                case TokenKind.Begin:
                    {
                        AcceptIt();
                        var command = ParseCommand();
                        Accept(TokenKind.End);
                        return command;
                    }

                case TokenKind.Let:
                    {
                        AcceptIt();
                        var declaration = ParseDeclaration();
                        Accept(TokenKind.In);
                        var command = ParseSingleCommand();
                        var commandPosition = new SourcePosition(startLocation, _currentToken.Finish);
                        return new LetCommand(declaration, command, commandPosition);
                    }

                case TokenKind.If:
                    {
                        AcceptIt();
                        var expression = ParseExpression();
                        Accept(TokenKind.Then);
                        var command1 = ParseSingleCommand();
                        Accept(TokenKind.Else);
                        var command2 = ParseSingleCommand();
                        var commandPosition = new SourcePosition(startLocation, _currentToken.Finish);
                        return new IfCommand(expression, command1, command2, commandPosition);
                    }

                case TokenKind.While:
                    {
                        AcceptIt();
                        var expression = ParseExpression();
                        Accept(TokenKind.Do);
                        var command = ParseSingleCommand();
                        var commandPosition = new SourcePosition(startLocation, _currentToken.Finish);
                        return new WhileCommand(expression, command, commandPosition);
                    }

                case TokenKind.Semicolon:
                case TokenKind.End:
                case TokenKind.Else:
                case TokenKind.In:
                case TokenKind.EndOfText:
                    {
                        var commandPosition = new SourcePosition(startLocation, _currentToken.Finish);
                        return new EmptyCommand(commandPosition);
                    }

                default:
                    RaiseSyntacticError("\"%\" cannot start a command", _currentToken);
                    return null;

            }
        }
    }
}