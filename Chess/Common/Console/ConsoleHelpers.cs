namespace Chess.Common.Console
{
    using System;
    using System.Collections.Generic;

    using Chess.Figures;
    using Chess.Figures.Contracts;

    public static class ConsoleHelpers
    {
        private static readonly IDictionary<string, bool[,]> patterns = new Dictionary<string, bool[,]>
        {
            {"Pawn" , new bool[,] 
                {
                    {false, false, false, false, false, false, false, false, false},
                    {false, false, false, false, false, false, false, false, false},
                    {false, false, false, false, true, false, false, false, false},
                    {false, false, false, true, true, true, false, false, false},
                    {false, false, false, true, true, true, false, false, false},
                    {false, false, false, false, true, false, false, false, false},
                    {false, false, false, true, true, true, false, false, false},
                    {false, false, true, true, true, true, true, false, false},
                    {false, false, false, false, false, false, false, false, false},
                }
            },
            {"Rook" , new bool[,] 
                {
                    {false, false, false, false, false, false, false, false, false},
                    {false, false, true, false, true, false, true, false, false},
                    {false, false, false, true, true, true, false, false, false},
                    {false, false, false, true, true, true, false, false, false},
                    {false, false, false, true, true, true, false, false, false},
                    {false, false, false, true, true, true, false, false, false},
                    {false, false, true, true, true, true, true, false, false},
                    {false, false, true, true, true, true, true, false, false},
                    {false, false, false, false, false, false, false, false, false},
                }
            },
            {"Knight" , new bool[,] 
                {
                    {false, false, false, false, false, false, false, false, false},
                    {false, false, false, false, true, true, false, false, false},
                    {false, false, false, true, true, true, true, false, false},
                    {false, false, true, true, true, false, true, false, false},
                    {false, false, false, true, false, true, true, false, false},
                    {false, false, false, false, true, true, true, false, false},
                    {false, false, false, true, true, true, false, false, false},
                    {false, false, true, true, true, true, true, false, false},
                    {false, false, false, false, false, false, false, false, false},
                }
            },
            {"Bishop" , new bool[,] 
                {
                    {false, false, false, false, false, false, false, false, false},
                    {false, false, false, false, true, false, false, false, false},
                    {false, false, false, true, true, true, false, false, false},
                    {false, false, true, true, false, true, true, false, false},
                    {false, false, true, false, false, false, true, false, false},
                    {false, false, false, true, false, true, false, false, false},
                    {false, false, false, false, true, false, false, false, false},
                    {false, true, true, true, false, true, true, true, false},
                    {false, false, false, false, false, false, false, false, false},
                }
            },
            {"Queen" , new bool[,] 
                {
                    {false, false, false, false, false, false, false, false, false},
                    {false, false, false, false, true, false, false, false, false},
                    {false, false, true, false, true, false, true, false, false},
                    {false, false, false, true, false, true, false, false, false},
                    {false, true, false, true, true, true, false, true, false},
                    {false, false, true, false, true, false, true, false, false},
                    {false, false, true, true, false, true, true, false, false},
                    {false, false, true, true, true, true, true, false, false},
                    {false, false, false, false, false, false, false, false, false},
                }
            },
            {"King" , new bool[,] 
                {
                    {false, false, false, false, false, false, false, false, false},
                    {false, false, false, false, true, false, false, false, false},
                    {false, false, false, true, true, true, false, false, false},
                    {false, true, true, false, true, false, true, true, false},
                    {false, true, true, true, false, true, true, true, false},
                    {false, true, true, true, true, true, true, true, false},
                    {false, false, true, true, true, true, true, false, false},
                    {false, false, true, true, true, true, true, false, false},
                    {false, false, false, false, false, false, false, false, false},
                }
            },
            {"Nullable" , new bool[,] 
                {
                    {false, false, false, false, false, false, false, false, false},
                    {false, false, false, false, false, false, false, false, false},
                    {false, false, false, false, false, false, false, false, false},
                    {false, false, false, false, false, false, false, false, false},
                    {false, false, false, false, false, false, false, false, false},
                    {false, false, false, false, false, false, false, false, false},
                    {false, false, false, false, false, false, false, false, false},
                    {false, false, false, false, false, false, false, false, false},
                    {false, false, false, false, false, false, false, false, false},
                }
            }
        };

        public static ConsoleColor ToConsoleColor(this ChessColor chessColor)
        {
            switch (chessColor)
            {
                case ChessColor.Black:
                    return ConsoleColor.Black;
                case ChessColor.White:
                    return ConsoleColor.White;
                case ChessColor.Brown:
                    return ConsoleColor.DarkYellow;
                default:
                    throw new InvalidOperationException("Cannot convert Chess Color!");
            }
        }

        public static void SetCursorAtCenter(int lenghtOfMessage)
        {
            int centerRow = Console.WindowHeight / 2;

            int centerCol = Console.WindowWidth / 2 - lenghtOfMessage / 2;

            Console.SetCursorPosition(centerCol, centerRow);
        }

        public static void PrintFigure(IFigure figure, ConsoleColor backgroundColor,
             int top, int left)
        {
            if (figure == null)
            {
                PrintEmtySquare(backgroundColor, top, left);
                return;
            }

            if (!patterns.ContainsKey(figure.GetType().Name))
            {
                return;
            }

            var figurePattern = patterns[figure.GetType().Name];


            for (int i = 0; i < figurePattern.GetLength(0); i++)
            {
                for (int j = 0; j < figurePattern.GetLength(1); j++)
                {
                    Console.SetCursorPosition(left + j, top + i);
                    if (figurePattern[i, j] == true)
                    {
                        Console.BackgroundColor = figure.Color.ToConsoleColor();
                    }
                    else
                    {
                        Console.BackgroundColor = backgroundColor;
                    }

                    Console.WriteLine(" ");
                }
            }
        }

        public static void PrintEmtySquare(ConsoleColor backgroundColor, int top, int left)
        {
            for (int i = 0; i < ConsoleConstants.CharactersPerRowPerBoardSquare; i++)
            {
                for (int j = 0; j < ConsoleConstants.CharactersPerColPerBoardSquare; j++)
                {
                    Console.SetCursorPosition(left + j, top + i);
                    Console.Write(" ");
                }
            }
        }
    }
}
